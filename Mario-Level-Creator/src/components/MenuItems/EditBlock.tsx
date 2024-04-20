import { BlockType } from "../../models/block";

type EditBlockProps = {
  selectedBlock: BlockType;
  updateBlock: (
    x: number,
    y: number,
    blockType: string,
    item: string,
    collidable: boolean,
    breakable: boolean
  ) => void;
};

export const EditBlock = ({ selectedBlock, updateBlock }: EditBlockProps) => {
  return (
    <section className="edit-popup">
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
        <option value="mystery">Mystery</option>
        <option value="flag">Flag</option>
        <option value="deathBlock">Death Block</option>
        <option value="stone">Stone</option>
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
        <option value="coin">Coin</option>
        <option value="coinUnderground">Coin Underground</option>
        <option value="pistol">Pistol</option>
        <option value="shotgun">Shotgun</option>
        <option value="rocketLauncher">Rocket Launcher</option>
      </select>
    </section>
  );
};
