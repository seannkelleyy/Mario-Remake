import React, { useState } from "react";
import { EditLevel } from "./components/MenuItems/EditLevel";
import { Level } from "./models/level";
import { BlockType } from "./models/block";
import { BlockSection } from "./models/blockSection";
import { Enemy } from "./models/enemy";
import { Block } from "./components/Block";
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
    level: "Level-1",
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
    enemies: [] as Enemy[],
    blockSections: [] as BlockSection[],
    blocks: [] as BlockType[],
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
      let newBlocks = prevState.blocks.filter(
        (block) => block.x !== x || block.y !== y
      );

      if (blockType !== "air") {
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

  const handleColumnChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    if (parseInt(e.target.value) < 1) {
      return setColumns(1);
    }
    setColumns(parseInt(e.target.value));
  };

  const handleDrag = (isDragging: boolean, blockType: string = "") => {
    setDragging(isDragging);
    setNextBlockType(blockType);
  };

  const getBlockTypeAt = (x: number, y: number) => {
    const block = level.blocks.find((block) => block.x === x && block.y === y);
    console.log("getBlockTypeAt", x, y, selectedBlock);
    return block ? block.type : "air"; // return 'air' or any default type for no block
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
          handleColumnChange={handleColumnChange}
        />
        <EditBlock
          selectedBlock={selectedBlock ? selectedBlock : null}
          updateBlock={updateBlock}
        />
      </section>
      <section className="level">
        {Array(columns)
          .fill(0)
          .map((_, columnIndex) => (
            <section id={columnIndex.toString()} className="column">
              {Array(15)
                .fill(0)
                .map((_, rowIndex) => (
                  <Block
                    key={`${columnIndex}-${rowIndex}`}
                    nextBlockType={nextBlockType}
                    dragging={dragging}
                    handleDrag={handleDrag}
                    isEditMode={isEditMode}
                    existingBlockType={getBlockTypeAt(columnIndex, rowIndex)}
                    x={columnIndex}
                    y={rowIndex}
                    updateBlock={updateBlock}
                    setSelectedCoordinates={setSelectedCoordinates}
                  />
                ))}
            </section>
          ))}
      </section>
    </div>
  );
};
