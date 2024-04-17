import React, { useState } from "react";
import { Column } from "./components/Row";
import { EditLevel } from "./components/MenuItems/EditLevel";
import { Level } from "./models/level";
import { EditBlock } from "./components/MenuItems/EditBlock";

export const LevelCreator = () => {
  const [columns, setColumns] = useState(40);
  const [dragging, setDragging] = useState(false);
  const [nextBlockType, setNextBlockType] = useState<string>("");
  const [isEditMode, setIsEditMode] = useState(false);
  const [selectedCoordinates, setSelectedCoordinates] = useState<{
    x: number;
    y: number;
  } | null>(null);

  const [level, setLevel] = useState<Level>({
    level: "1",
    song: "ground",
    width: columns,
    height: 15,
    hero: {
      type: "mario",
      startingX: 0,
      startingY: 0,
      direction: true,
      startingPower: "small",
      lives: 3,
      statingLives: 3,
    },
    enemies: [],
    blockSections: [],
    blocks: [],
  });
  let selectedBlock = level.blocks.find(
    (block) =>
      block.x === selectedCoordinates?.x && block.y === selectedCoordinates?.y
  );

  const updateLevel = (property: any, value: any) => {
    setLevel((prevState) => ({
      ...prevState,
      [property]: value,
    }));
  };

  const updateBlock = (
    x: number,
    y: number,
    blockType: string,
    item: string,
    collidable: boolean,
    breakable: boolean
  ) => {
    setLevel((prevState) => {
      console.log("updateBlock", x, y, blockType, item, collidable, breakable);
      if (blockType === "air") {
        return {
          ...prevState,
          blocks: prevState.blocks.filter(
            (block) => block.x !== x || block.y !== y
          ),
        };
      }
      // Copy the existing blocks array
      let newBlocks = [...prevState.blocks];

      // Find the block at the given coordinates
      let blockIndex = newBlocks.findIndex(
        (block) => block.x === x && block.y === y
      );

      // If a block exists at the coordinates, update it
      if (blockIndex !== -1) {
        newBlocks[blockIndex].type = blockType;
        newBlocks[blockIndex].item = item;
        newBlocks[blockIndex].collidable = collidable;
        newBlocks[blockIndex].breakable = breakable;
      }
      // If no block exists at the coordinates, add a new block
      else {
        newBlocks.push({
          type: blockType,
          x: x,
          y: y,
          collidable: collidable,
          breakable: breakable,
          item: item,
        });
      }

      return { ...prevState, blocks: newBlocks };
    });
  };

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
      return setColumns(1);
    }
    setColumns(parseInt(e.target.value));
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
        <button onClick={() => setIsEditMode(!isEditMode)}>
          {isEditMode ? "Edit Mode On" : "Edit Mode Off"}
        </button>
        <EditLevel
          level={level}
          updateLevel={updateLevel}
          rows={columns}
          handleRowChange={handleRowChange}
        />
        {isEditMode && (
          <EditBlock selectedBlock={selectedBlock} updateBlock={updateBlock} />
        )}
      </section>
      <section className="level">
        {columns &&
          Array(columns)
            .fill(0)
            .map((_, columnIndex) => (
              <Column
                key={columnIndex}
                columnIndex={columnIndex}
                setSelectedCoordinates={setSelectedCoordinates}
                dragging={dragging}
                onDragStart={onDragStart}
                onDragEnd={onDragEnd}
                nextBlockType={nextBlockType}
                updateBlock={updateBlock}
                isEditMode={isEditMode}
              />
            ))}
      </section>
    </div>
  );
};
