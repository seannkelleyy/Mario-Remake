import { useCallback, useEffect, useState } from "react";
import { blockImages, blockTypes } from "../models/block";

type BlockProps = {
  dragging: boolean;
  nextBlockType: string;
  isEditMode: boolean;
  existingBlockType: string;
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
};

export const Block = ({
  dragging,
  nextBlockType,
  isEditMode,
  existingBlockType,
  x,
  y,
  handleDrag,
  setSelectedCoordinates,
  updateBlock,
}: BlockProps) => {
  const [blockType, setBlockType] = useState(
    blockTypes[blockTypes.indexOf(existingBlockType)]
  );

  useEffect(() => {
    setBlockType(blockTypes[blockTypes.indexOf(existingBlockType)]);
  }, [existingBlockType]);

  const handleMouseDown = useCallback(
    (e: React.MouseEvent) => {
      if (isEditMode) {
        e.preventDefault();
        console.log("handleMouseDown", x, y, blockType);
        setSelectedCoordinates({ x: x, y: y });
      } else {
        let newBlockType = changeBlockType();
        handleDrag(true, newBlockType);
        updateBlock(x, y, newBlockType, "none", true, true);
      }
    },
    [isEditMode, handleDrag]
  );

  const handleMouseMove = useCallback(
    (e: React.MouseEvent) => {
      e.preventDefault();
      if (dragging && e.buttons === 1) {
        setBlockType(nextBlockType);
        updateBlock(x, y, nextBlockType, "none", true, true);
      }
    },
    [dragging, setBlockType]
  );

  const changeBlockType = () => {
    let currentIndex = blockTypes.indexOf(blockType);
    if (currentIndex === blockTypes.length - 1) {
      currentIndex = 0;
    } else {
      currentIndex++;
    }
    let newBlockType = blockTypes[currentIndex];
    setBlockType(newBlockType);
    return newBlockType;
  };

  const getBlockImage = (blockType: string) => {
    const imageSrc = blockImages[blockType];
    return imageSrc ? (
      <img
        src={blockImages[blockType]}
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
      {getBlockImage(blockType)}
    </button>
  );
};
