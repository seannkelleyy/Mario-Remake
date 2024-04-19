import { useCallback, useEffect, useState } from "react";
import { ObjectTypes, objectImages } from "../models/object";
import { enemyTypes } from "../models/enemy";
import { pipeTypes } from "../models/pipe";
import { blockTypes } from "../models/block";

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
    startingX: number,
    startingY: number,
    enemyType: string,
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
}: ObjectProps) => {
  const [objectType, setObjectType] = useState(
    ObjectTypes[ObjectTypes.indexOf(existingObjectType)]
  );

  useEffect(() => {
    setObjectType(ObjectTypes[ObjectTypes.indexOf(existingObjectType)]);
  }, [existingObjectType]);

  const handleMouseDown = useCallback(
    (e: React.MouseEvent) => {
      if (isEditMode) {
        e.preventDefault();
        console.log("handleMouseDown", x, y, objectType);
        setSelectedCoordinates({ x: x, y: y });
      } else {
        let newBlockType = changeObjectType();
        handleDrag(true, newBlockType);
        if (pipeTypes.includes(newBlockType)) {
          updatePipe(x, y, y + 2, newBlockType, true, x, y + 2, true, false);
        }
        if (enemyTypes.includes(newBlockType)) {
          updateEnemy(x, y, newBlockType, true, []);
        }
        if (blockTypes.includes(newBlockType)) {
          updateBlock(x, y, newBlockType, "none", true, true);
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
          updateEnemy(x, y, nextObjectType, true, []);
        }
        if (blockTypes.includes(nextObjectType)) {
          updateBlock(x, y, nextObjectType, "none", true, true);
        }
      }
    },
    [dragging, setObjectType]
  );

  const changeObjectType = () => {
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
      onMouseDown={handleMouseDown}
      onMouseMove={handleMouseMove}
      onMouseUp={() => handleDrag(false, "")}
    >
      {getObjectImage(objectType)}
    </button>
  );
};
