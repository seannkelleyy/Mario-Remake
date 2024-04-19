import React, { useState } from "react";
import { EditLevel } from "./components/MenuItems/EditLevel";
import { Level } from "./models/level";
import { BlockType } from "./models/block";
import { BlockSection } from "./models/blockSection";
import { EnemyType, enemyTypes } from "./models/enemy";
import { Object } from "./components/Object";
import { EditObject } from "./components/MenuItems/EditObject";
import { PipeType, pipeTypes } from "./models/pipe";

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
    enemies: [] as EnemyType[],
    blockSections: [] as BlockSection[],
    blocks: [] as BlockType[],
    pipes: [] as PipeType[],
  });

  let selectedObject =
    level.blocks.find(
      (block) =>
        block.x === selectedCoordinates?.x && block.y === selectedCoordinates?.y
    ) ||
    level.enemies.find(
      (enemy) =>
        enemy.startingX === selectedCoordinates?.x &&
        enemy.startingY === selectedCoordinates?.y
    ) ||
    level.pipes.find(
      (pipe) =>
        pipe.x === selectedCoordinates?.x &&
        pipe.startingY === selectedCoordinates?.y
    );

  const updateLevel = (property: any, value: any) => {
    setLevel((prevState) => ({
      ...prevState,
      [property]: value,
    }));
  };

  const updateEnemy = (
    startingX: number,
    startingY: number,
    enemyType: string,
    direction: boolean,
    AI: string[]
  ) => {
    setLevel((prevState) => {
      let newEnemies = prevState.enemies.filter(
        (enemy) =>
          enemy.startingX !== startingX || enemy.startingY !== startingY
      );

      if (enemyTypes.includes(enemyType)) {
        if (AI.includes("none")) AI = [];
        newEnemies.push({
          type: enemyType,
          startingX: startingX,
          startingY: startingY,
          direction: direction ? direction : true,
          AI: AI ? AI : [],
        });
      }

      return {
        ...prevState,
        enemies: newEnemies,
      };
    });
  };

  const updatePipe = (
    x: number,
    startingY: number,
    endingY: number,
    pipeType: string,
    transportable: boolean,
    transportDestinationX: number,
    transportDestinationY: number,
    collidable: boolean,
    breakable: boolean
  ) => {
    setLevel((prevState) => {
      let newPipes = prevState.pipes.filter(
        (pipe) => pipe.x !== x || pipe.startingY !== startingY
      );

      if (pipeTypes.includes(pipeType)) {
        newPipes.push({
          type: pipeType,
          x: x,
          startingY: startingY,
          endingY: endingY,
          transportable: transportable ? true : false,
          transportDestinationX: transportDestinationX
            ? transportDestinationX
            : x,
          transportDestinationY: transportDestinationY
            ? transportDestinationY
            : endingY,
          collidable: collidable ? collidable : true,
          breakable: breakable ? breakable : false,
        });
      }

      return {
        ...prevState,
        pipes: newPipes,
      };
    });
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
    console.log("getBlockTypeAt", x, y, selectedObject);
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
        <EditObject
          selectedObject={selectedObject ? selectedObject : null}
          updateBlock={updateBlock}
          updateEnemy={updateEnemy}
          updatePipe={updatePipe}
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
                  <Object
                    key={`${columnIndex}-${rowIndex}`}
                    nextObjectType={nextBlockType}
                    dragging={dragging}
                    handleDrag={handleDrag}
                    isEditMode={isEditMode}
                    existingObjectType={getBlockTypeAt(columnIndex, rowIndex)}
                    x={columnIndex}
                    y={rowIndex}
                    updateBlock={updateBlock}
                    updateEnemy={updateEnemy}
                    updatePipe={updatePipe}
                    setSelectedCoordinates={setSelectedCoordinates}
                  />
                ))}
            </section>
          ))}
      </section>
    </div>
  );
};
