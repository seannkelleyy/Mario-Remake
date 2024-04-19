type EditBlockProps = {
  selectedBlock: any;
  updateBlock: any;
};

export const EditBlock = ({ selectedBlock, updateBlock }: EditBlockProps) => {
  return (
    <section className="edit-block-popup">
      <h2>Edit Block</h2>
      <label>Block Type:</label>
      <select
        value={selectedBlock?.type ? selectedBlock.type : "air"}
        onChange={(e) => {
          updateBlock(
            selectedBlock.x,
            selectedBlock.y,
            e.target.value,
            selectedBlock.item,
            selectedBlock.collidable,
            selectedBlock.breakable
          );
        }}
      >
        <option value="air">Air</option>
        <option value="floor">Floor</option>
        <option value="brick">Brick</option>
        <option value="square-brick">Square Brick</option>
        <option value="smooth-brick">Smooth Brick</option>
        <option value="mystery">Mystery</option>
        <option value="pipeTubeVeritcal">Pipe Vertical</option>
        <option value="pipeTubeUpsideDown">Pipe Upside Down</option>
        <option value="pipeTubeHorizontal">Pipe Horizontal</option>
      </select>
      <label>Collideable:</label>
      <input
        type="checkbox"
        checked={selectedBlock?.collidable ? selectedBlock.collidable : false}
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
        checked={selectedBlock?.breakable ? selectedBlock.breakable : false}
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
        value={selectedBlock?.item ? selectedBlock.item : "none"}
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
