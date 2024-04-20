import React, { useState } from "react";
import { EditLevel } from "./MenuItems/EditLevel";
import { Level } from "../models/level";
import { BlockType } from "../models/block";
import { BlockSection } from "../models/blockSection";
import { EnemyType, enemyTypes } from "../models/enemy";
import { Object } from "./Object";
import { EditObject } from "./MenuItems/EditObject";
import { PipeType, pipeTypes } from "../models/pipe";
import { ObjectType } from "../models/object";
import { ItemType } from "../models/item";
import { ItemSectionType } from "../models/itemSection";

export const LevelCreator = () => {
  const [openLevel, setOpenLevel] = useState(true);
  const [openObject, setOpenObject] = useState(true);
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
      startingX: 3,
      startingY: 12,
      direction: true,
      startingPower: "small",
      lives: 3,
      statingLives: 3,
    },
    enemies: [] as EnemyType[],
    items: [] as ItemType[],
    itemSections: [] as ItemSectionType[],
    blockSections: [] as BlockSection[],
    blocks: [] as BlockType[],
    pipes: [] as PipeType[],
  });

  const isAtSelectedCoordinates = (object: { x: number; y: number }) =>
    object.x === selectedCoordinates?.x && object.y === selectedCoordinates?.y;

  let selectedObject =
    (level.blocks.find(isAtSelectedCoordinates) as ObjectType) ||
    (level.enemies.find((enemy) =>
      isAtSelectedCoordinates({ x: enemy.startingX, y: enemy.startingY })
    ) as ObjectType) ||
    (level.pipes.find((pipe) =>
      isAtSelectedCoordinates({ x: pipe.x, y: pipe.startingY })
    ) as ObjectType);

  const updateLevel = (property: any, value: any) => {
    setLevel((prevState) => ({
      ...prevState,
      [property]: value,
    }));
  };

  const updateEnemy = (
    enemyType: string,
    startingX: number,
    startingY: number,
    direction: boolean,
    AI: string[]
  ) => {
    setLevel((prevState) => {
      let newBlocks = prevState.blocks.filter(
        (block) => block.x !== startingX || block.y !== startingY
      );
      let newPipes = prevState.pipes.filter(
        (pipe) => pipe.x !== startingX || pipe.startingY !== startingY
      );
      let newEnemies = prevState.enemies.filter(
        (enemy) =>
          enemy.startingX !== startingX || enemy.startingY !== startingY
      );
      let newItems = prevState.items.filter(
        (item) => item.x !== startingX || item.y !== startingY
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
        blocks: newBlocks,
        pipes: newPipes,
        enemies: newEnemies,
        items: newItems,
      };
    });
  };

  const updateItem = (x: number, y: number, itemType: string) => {
    setLevel((prevState) => {
      let newBlocks = prevState.blocks.filter(
        (block) => block.x !== x || block.y !== y
      );
      let newPipes = prevState.pipes.filter(
        (pipe) => pipe.x !== x || pipe.startingY !== y
      );
      let newEnemies = prevState.enemies.filter(
        (enemy) => enemy.startingX !== x || enemy.startingY !== y
      );
      let newItems = prevState.items.filter(
        (item) => item.x !== x || item.y !== y
      );

      if (itemType !== "none") {
        newItems.push({
          type: itemType,
          x: x,
          y: y,
        });
      }

      return {
        ...prevState,
        items: newItems,
        blocks: newBlocks,
        pipes: newPipes,
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
      let newBlocks = prevState.blocks.filter(
        (block) => block.x !== x || block.y !== startingY
      );
      let newPipes = prevState.pipes.filter(
        (pipe) => pipe.x !== x || pipe.startingY !== startingY
      );
      let newEnemies = prevState.enemies.filter(
        (enemy) => enemy.startingX !== x || enemy.startingY !== startingY
      );
      let newItems = prevState.items.filter(
        (item) => item.x !== x || item.y !== startingY
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
        blocks: newBlocks,
        pipes: newPipes,
        enemies: newEnemies,
        items: newItems,
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
      let newPipes = prevState.pipes.filter(
        (pipe) => pipe.x !== x || pipe.startingY !== y
      );
      let newEnemies = prevState.enemies.filter(
        (enemy) => enemy.startingX !== x || enemy.startingY !== y
      );
      let newItems = prevState.items.filter(
        (item) => item.x !== x || item.y !== y
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
        pipes: newPipes,
        enemies: newEnemies,
        items: newItems,
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

  const getObjectTypeAt = (x: number, y: number) => {
    const block = level.blocks.find((block) => block.x === x && block.y === y);
    const enemy = level.enemies.find(
      (enemy) => enemy.startingX === x && enemy.startingY === y
    );
    const pipe = level.pipes.find(
      (pipe) => pipe.x === x && pipe.startingY === y
    );
    const item = level.items.find((item) => item.x === x && item.y === y);

    if (block) {
      return block.type;
    } else if (enemy) {
      return enemy.type;
    } else if (pipe) {
      return pipe.type;
    } else if (item) {
      return item.type;
    } else {
      return "air";
    }
  };

  return (
    <div className="level-loader">
      <section className="control">
        <h1>Mario Level Creator</h1>
        <p>
          How to use: To begin, set the value for your width and height. By
          default, all blocks are set to an air block, which don't get added to
          the json. Simply click a block to change its type, keep clicking to
          cycle through all blocks. To edit a block, use the 'edit mode' button
          to turn on edit mode. Once finished, download the level, and add it to
          `/Levels` in the game. Also make sure to change the path to be your
          new level in `game.cs`.
        </p>
        <button className="std-button" onClick={() => setOpenLevel(!openLevel)}>
          {openLevel ? "Close Edit Level" : "Open Edit Level"}
        </button>
        {openLevel && (
          <EditLevel
            level={level}
            updateLevel={updateLevel}
            rows={rows}
            columns={columns}
            handleColumnChange={handleColumnChange}
            handleRowChange={handleRowChange}
          />
        )}
        <button
          className="std-button"
          onClick={() => setOpenObject(!openObject)}
        >
          {openObject ? "Close Edit Object" : "Open Edit Object"}
        </button>
        {openObject && (
          <EditObject
            selectedObject={selectedObject}
            updateBlock={updateBlock}
            updateEnemy={updateEnemy}
            updatePipe={updatePipe}
          />
        )}
        <section className="buttons">
          <button className="std-button" onClick={downloadLevel}>
            Download Level
          </button>
          <button
            className={isEditMode ? "on-button" : "on-button-disabled"}
            onClick={() => setIsEditMode(!isEditMode)}
          >
            {isEditMode ? "Edit Mode On" : "Edit Mode Off"}
          </button>
        </section>
      </section>
      <section className="level">
        {Array(columns > 0 ? columns : 1)
          .fill(0)
          .map((_, columnIndex) => (
            <section
              key={columnIndex}
              id={columnIndex.toString()}
              className="column"
            >
              {Array(rows > 0 ? rows : 1)
                .fill(0)
                .map((_, rowIndex) => (
                  <Object
                    key={`${columnIndex}-${rowIndex}`}
                    nextObjectType={nextBlockType}
                    dragging={dragging}
                    handleDrag={handleDrag}
                    isEditMode={isEditMode}
                    existingObjectType={getObjectTypeAt(columnIndex, rowIndex)}
                    x={columnIndex}
                    y={rowIndex}
                    updateBlock={updateBlock}
                    updateEnemy={updateEnemy}
                    updatePipe={updatePipe}
                    updateItem={updateItem}
                    setSelectedCoordinates={setSelectedCoordinates}
                  />
                ))}
            </section>
          ))}
      </section>
    </div>
  );
};
