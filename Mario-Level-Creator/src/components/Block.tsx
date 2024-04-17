import { useState } from "react";

type BlockProps = {
  dragging: boolean;
  onDragStart: (blockType: string) => void;
  onDragEnd: () => void;
  setSelectedCoordinates: (coordinates: { x: number; y: number }) => void;
  updateBlock: (
    x: number,
    y: number,
    blockType: string,
    item: string,
    collidable: boolean,
    breakable: boolean
  ) => void;
  nextBlockType: string;
  x: number;
  y: number;
  isEditMode: boolean;
};

export const blockTypes = [
  "air",
  "floor",
  "brick",
  "square-brick",
  "smooth-brick",
  "mystery",
  "pipe",
  "pipe-top",
];

export const Block = ({
  dragging,
  onDragStart,
  onDragEnd,
  updateBlock,
  setSelectedCoordinates,
  nextBlockType,
  x,
  y,
  isEditMode,
}: BlockProps) => {
  const [blockType, setBlockType] = useState(blockTypes[0]);
  const [item, setItem] = useState("none");
  const [collidable, setCollidable] = useState(true);
  const [breakable, setBreakable] = useState(true);

  const handleMouseDown = (e: React.MouseEvent) => {
    if (isEditMode) {
      e.preventDefault();
      setSelectedCoordinates({ x: x, y: y });
      console.log(`x: ${x}, y: ${y}, blockType: ${blockType}`);
    } else {
      let newBlockType = changeBlockType();
      onDragStart(newBlockType);
      updateBlock(x, y, newBlockType, item, collidable, breakable);
      console.log(`x: ${x}, y: ${y}, blockType: ${newBlockType}`);
    }
  };

  const handleMouseMove = (e: React.MouseEvent) => {
    if (dragging && e.buttons === 1) {
      setBlockType(nextBlockType);
    }
  };

  const handleMouseUp = () => {
    onDragEnd();
  };

  const changeBlockType = () => {
    console.log("changeBlockType" + blockType);
    let currentIndex = blockTypes.indexOf(blockType);
    if (currentIndex === blockTypes.length - 1) {
      currentIndex = 0;
    } else {
      currentIndex++;
    }
    let newBlockType = blockTypes[currentIndex];
    setBlockType(newBlockType);
    console.log("changedBlockType" + newBlockType);
    return newBlockType;
  };

  const getBlockImage = (blockType: String) => {
    switch (blockType) {
      case "air":
        return <></>;
      case "floor":
        return <img src="floorBlock.jpeg" alt="floor" width={16} height={16} />;
      case "brick":
        return <img src="brick.jpeg" alt="brick" width={16} height={16} />;
      case "square-brick":
        return (
          <img
            src="squareBrick.jpeg"
            alt="square-brick"
            width={16}
            height={16}
          />
        );
      case "smooth-brick":
        return (
          <img
            src="smoothBrick.jpeg"
            alt="smooth-brick"
            width={16}
            height={16}
          />
        );
      case "mystery":
        return <img src="mystery.jpeg" alt="mystery" width={16} height={16} />;
      case "pipe":
        return <img src="pipe.jpeg" alt="pipe" width={12} height={16} />;
      case "pipe-top":
        return <img src="pipe-top.png" alt="pipe-top" width={16} height={16} />;
      default:
        return <></>;
    }
  };

  return (
    <button
      className="block"
      onMouseDown={handleMouseDown}
      onMouseMove={handleMouseMove}
      onMouseUp={handleMouseUp}
    >
      {getBlockImage(blockType)}
    </button>
  );
};
