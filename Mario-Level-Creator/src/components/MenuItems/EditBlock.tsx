type EditBlockProps = {
  selectedBlock: any;
  updateBlock: any;
};

export const EditBlock = ({ selectedBlock, updateBlock }: EditBlockProps) => {
  return (
    <section>
      <h2>Edit Block</h2>

      <label>Block Type:</label>
      <select
        value={selectedBlock?.type}
        onChange={(e) => {
          if (selectedBlock) {
            updateBlock(
              selectedBlock.x,
              selectedBlock.y,
              e.target.value,
              selectedBlock.item,
              selectedBlock.collidable,
              selectedBlock.breakable
            );
          }
        }}
      >
        <option value="air">Air</option>
        <option value="floor">Floor</option>
        <option value="brick">Brick</option>
        <option value="square-brick">Square Brick</option>
        <option value="smooth-brick">Smooth Brick</option>
        <option value="mystery">Mystery</option>
        <option value="pipe">Pipe</option>
        <option value="pipe-top">Pipe Top</option>
      </select>
      <label>Collideable:</label>
      <input
        type="checkbox"
        checked={selectedBlock?.collidable}
        onChange={(e) =>
          updateBlock(
            selectedBlock.x,
            selectedBlock.y,
            selectedBlock.type,
            selectedBlock.item,
            e.target.checked,
            selectedBlock.breakable
          )
        }
      />
      <label>Breakable:</label>
      <input
        type="checkbox"
        checked={selectedBlock?.breakable}
        onChange={(e) =>
          updateBlock(
            selectedBlock.x,
            selectedBlock.y,
            selectedBlock.type,
            selectedBlock.item,
            selectedBlock.collidable,
            e.target.checked
          )
        }
      />
      <label>Item:</label>
      <select
        value={selectedBlock?.item}
        onChange={(e) => {
          if (selectedBlock) {
            updateBlock(
              selectedBlock.x,
              selectedBlock.y,
              selectedBlock.type,
              e.target.value,
              selectedBlock.collidable,
              selectedBlock.breakable
            );
          }
        }}
      >
        <option value="none">None</option>
        <option value="mushroom">Mushroom</option>
        <option value="flower">Flower</option>
        <option value="star">Star</option>
        <option value="oneUp">1-Up</option>
      </select>
    </section>
  );
};
