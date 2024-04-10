import { useState } from "react";
import { Row } from "./components/Row";

export const LevelCreator = () => {
  const [rows, setRows] = useState(10);
  const [dragging, setDragging] = useState(false);
  const [nextBlockType, setNextBlockType] = useState<string>("");
  const [level, setLevel] = useState({
    level: "1",
    song: "ground",
    width: 16,
    height: rows,
    hero: {
      type: "mario",
      startingX: 0,
      startingY: 0,
      direction: true,
      startingPower: "small",
    },
    enemies: [],
    blockSections: [],
    blocks: Array(rows).fill(
      Array(16).fill({
        type: "air",
        item: "none",
        collidable: false,
        breakable: false,
      })
    ),
  });

  const downloadLevel = () => {
    const a = document.createElement("a");
    const file = new Blob([JSON.stringify(level)], {
      type: "application/json",
    });
    a.href = URL.createObjectURL(file);
    a.download = "level.json";
    a.click();
  };

  const handleRowChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    if (parseInt(e.target.value) < 1) {
      return setRows(1);
    }
    setRows(parseInt(e.target.value));
  };

  const onDragStart = (blockType: string) => {
    setDragging(true);
    setNextBlockType(blockType);
  };

  const onDragEnd = () => {
    setDragging(false);
    setNextBlockType("");
  };

  return (
    <div className="level-loader">
      <section className="control">
        <h1>Mario Level Creator</h1>
        <p>
          How to use: To begin, set the value for your width. By default, all
          blocks are set to an air block. Simply click a block to change its
          type, keep clicking to cycle through all blocks
        </p>
        <button onClick={downloadLevel}>Download Level</button>
        <label>Width in Blocks</label>
        <input type="number" value={rows} onChange={handleRowChange} />
      </section>
      <div className="level">
        {rows &&
          Array(rows)
            .fill(0)
            .map((_, rowIndex) => (
              <Row
                rowIndex={rowIndex}
                dragging={dragging}
                onDragStart={onDragStart}
                onDragEnd={onDragEnd}
                nextBlockType={nextBlockType}
              />
            ))}
      </div>
    </div>
  );
};
