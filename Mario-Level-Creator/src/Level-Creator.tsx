import React, { useState } from "react";
import { EditLevel } from "./components/MenuItems/EditLevel";
import { Level } from "./models/level";
import { BlockType } from "./models/block";
import { BlockSection } from "./models/blockSection";
import { Enemy } from "./models/enemy";
import { Block } from "./components/Block";
import { EditBlock } from "./components/MenuItems/EditBlock";
import { Pipe } from "./models/pipe";

export const LevelCreator = () => {
  const [columns, setColumns] = useState(40);
  const [rows, setRows] = useState(15);
  const [dragging, setDragging] = useState(false);
  const [nextBlockType, setNextBlockType] = useState<string>("");
  const [isEditMode, setIsEditMode] = useState(false);
  const [selectedCoordinates, setSelectedCoordinates] = useState<{
    x: number;
    y: number;
  } | null>(null);

  const [level, setLevel] = useState<Level>({
    level: "1",
    pathToSpriteJson: "../../../Levels/Data/SpriteData.json",
    width: columns,
    height: 15,
    timeLimit: 400,
    song: "ground",
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
    pipes: [] as Pipe[],
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
      let newBlocks = prevState.blocks.filter(
        (block) => block.x !== x || block.y !== y
      );

      let newEnemies = prevState.enemies.filter(
        (enemy) => enemy.startingX !== x || enemy.startingY !== y
      );

      let newPipes = prevState.pipes.filter(
        (pipe) => pipe.x !== x || pipe.startingY !== y
      );

      // add to enemies if goomba, koopa, piranha, or bulletBill or fire bro
      if (
        blockType === "goomba" ||
        blockType === "koopa" ||
        blockType === "piranha" ||
        blockType === "bulletBill" ||
        blockType === "fireBro"
      ) {
        newEnemies.push({
          type: blockType,
          startingX: x,
          startingY: y,
          direction: true,
        });
      }

      if (
        blockType === "pipeTubeVertical" ||
        blockType === "pipeTubeUpsideDown" ||
        blockType === "pipeTubeHorizontal"
      ) {
        newPipes.push({
          type: blockType,
          x: x,
          startingY: y,
          endingY: y + 2,
          transportable: true,
          transportDestinationX: x,
          transportDestinationY: y + 2,
          collidable: collidable,
          breakable: breakable,
        });
      }

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

      return {
        ...prevState,
        blocks: newBlocks,
        enemies: newEnemies,
        pipes: newPipes,
      };
    });
  };

  const downloadLevel = () => {
    const a = document.createElement("a");
    const file = new Blob([JSON.stringify(level)], {
      type: "application/json",
    });
    a.href = URL.createObjectURL(file);
    a.download = level.level + ".json";
    a.click();
  };

  const handleColumnChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    if (parseInt(e.target.value) < 1) {
      return setColumns(1);
    }
    setColumns(parseInt(e.target.value));
  };

  const handleRowChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    if (parseInt(e.target.value) < 1) {
      return setRows(1);
    }
    setRows(parseInt(e.target.value));
  };

  const handleDrag = (isDragging: boolean, blockType: string = "") => {
    setDragging(isDragging);
    setNextBlockType(blockType);
  };

  const getBlockTypeAt = (x: number, y: number) => {
    const block = level.blocks.find((block) => block.x === x && block.y === y);
    console.log("getBlockTypeAt", x, y, selectedBlock);
    return block ? block.type : "air";
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
          handleRowChange={handleRowChange}
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
              {Array(rows)
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
