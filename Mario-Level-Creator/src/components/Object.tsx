import { useCallback, useEffect, useState } from "react";
import { ObjectTypes, objectImages } from "../models/object";
import { enemyTypes } from "../models/enemy";
import { pipeTypes } from "../models/pipe";
import { blockTypes } from "../models/block";
import { itemTypes } from "../models/item";

type ObjectProps = {
  dragging: boolean;
  nextObjectType: string;
  isEditMode: boolean;
  existingObjectType: string;
  x: number;
  y: number;
  handleDrag: (isDragging: boolean, blockType: string) => void;
  setSelectedCoordinates: (coordinates: { x: number; y: number }) => void;
  updateBlock: (
    x: number,
    y: number,
    blockType: string,
    item: string,
    collidable: boolean,
    breakable: boolean
  ) => void;
  updateEnemy: (
    enemyType: string,
    startingX: number,
    startingY: number,
    direction: boolean,
    AI: string[]
  ) => void;
  updatePipe: (
    x: number,
    startingY: number,
    endingY: number,
    pipeType: string,
    transportable: boolean,
    transportDestinationX: number,
    transportDestinationY: number,
    collidable: boolean,
    breakable: boolean
  ) => void;
  updateItem: (x: number, y: number, itemType: string) => void;
};

export const Object = ({
  dragging,
  nextObjectType,
  isEditMode,
  existingObjectType,
  x,
  y,
  handleDrag,
  setSelectedCoordinates,
  updateBlock,
  updateEnemy,
  updatePipe,
  updateItem,
}: ObjectProps) => {
  const [objectType, setObjectType] = useState(
    ObjectTypes[ObjectTypes.indexOf(existingObjectType)]
  );

  useEffect(() => {
    setObjectType(ObjectTypes[ObjectTypes.indexOf(existingObjectType)]);
  }, [existingObjectType]);

  const handleMouseDownLeft = useCallback(
    (e: React.MouseEvent) => {
      if (isEditMode) {
        e.preventDefault();
        setSelectedCoordinates({ x: x, y: y });
      } else {
        let newObjectType = changeObjectTypeUp();
        handleDrag(true, newObjectType);
        if (pipeTypes.includes(newObjectType)) {
          updatePipe(x, y, y + 2, newObjectType, true, x, y + 2, true, false);
          return;
        }
        if (enemyTypes.includes(newObjectType)) {
          updateEnemy(newObjectType, x, y, true, []);
          return;
        }
        if (blockTypes.includes(newObjectType)) {
          updateBlock(x, y, newObjectType, "none", true, true);
          return;
        }
        if (itemTypes.includes(newObjectType)) {
          updateItem(x, y, newObjectType);
          return;
        }
      }
    },
    [isEditMode, handleDrag]
  );

  const handleMouseDownRight = useCallback(
    (e: React.MouseEvent) => {
      e.preventDefault();
      if (isEditMode) {
        setSelectedCoordinates({ x: x, y: y });
      } else {
        let newObjectType = changeObjectTypeBack();
        handleDrag(true, newObjectType);
        if (pipeTypes.includes(newObjectType)) {
          updatePipe(x, y, y + 2, newObjectType, true, x, y + 2, true, false);
          return;
        }
        if (enemyTypes.includes(newObjectType)) {
          updateEnemy(newObjectType, x, y, true, []);
          return;
        }
        if (blockTypes.includes(newObjectType)) {
          updateBlock(x, y, newObjectType, "none", true, true);
          return;
        }
        if (itemTypes.includes(newObjectType)) {
          updateItem(x, y, newObjectType);
          return;
        }
      }
    },
    [isEditMode, handleDrag]
  );

  const handleMouseMove = useCallback(
    (e: React.MouseEvent) => {
      e.preventDefault();
      if (dragging && e.buttons === 1) {
        setObjectType(nextObjectType);
        if (pipeTypes.includes(nextObjectType)) {
          updatePipe(x, y, y + 2, nextObjectType, true, x, y + 2, true, false);
        }
        if (enemyTypes.includes(nextObjectType)) {
          updateEnemy(nextObjectType, x, y, true, []);
        }
        if (blockTypes.includes(nextObjectType)) {
          updateBlock(x, y, nextObjectType, "none", true, true);
        }
        if (itemTypes.includes(nextObjectType)) {
          updateItem(x, y, nextObjectType);
        }
      }
    },
    [dragging, setObjectType]
  );

  const changeObjectTypeUp = () => {
    let currentIndex = ObjectTypes.indexOf(objectType);
    if (currentIndex === ObjectTypes.length - 1) {
      currentIndex = 0;
    } else {
      currentIndex++;
    }
    let newBlockType = ObjectTypes[currentIndex];
    setObjectType(newBlockType);
    return newBlockType;
  };

  const changeObjectTypeBack = () => {
    let currentIndex = ObjectTypes.indexOf(objectType);
    if (currentIndex === 0) {
      currentIndex = ObjectTypes.length - 1;
    } else {
      currentIndex--;
    }
    let newBlockType = ObjectTypes[currentIndex - 1];
    setObjectType(newBlockType);
    return newBlockType;
  };

  const getObjectImage = (blockType: string) => {
    const imageSrc = objectImages[blockType];
    return imageSrc ? (
      <img
        src={objectImages[blockType]}
        alt={blockType}
        width={16}
        height={16}
      />
    ) : (
      <></>
    );
  };

  return (
    <button
      className="block"
      onMouseDown={handleMouseDownLeft}
      onMouseMove={handleMouseMove}
      onContextMenu={handleMouseDownRight}
      onMouseUp={() => handleDrag(false, "")}
    >
      {getObjectImage(objectType)}
    </button>
  );
};
