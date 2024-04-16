import { useState } from "react";

type BlockProps = {
  dragging: boolean;
  onDragStart: (blockType: string) => void;
  onDragEnd: () => void;
  nextBlockType: string;
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
  nextBlockType,
}: BlockProps) => {
  const [blockType, setBlockType] = useState(blockTypes[0]);

  const handleMouseDown = () => {
    changeBlockType();
    onDragStart(blockType);
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
    let currentIndex = blockTypes.indexOf(blockType);
    if (currentIndex === blockTypes.length - 1) {
      currentIndex = 0;
    } else {
      currentIndex++;
    }
    setBlockType(blockTypes[currentIndex]);
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
