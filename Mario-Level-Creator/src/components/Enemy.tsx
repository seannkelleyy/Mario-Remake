import { blockImages, blockTypes } from "../models/block";

type EnemyProps = {
  isEditMode: boolean;
  x: number;
  y: number;
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
  isEditMode,
  x,
  y,
  setSelectedCoordinates,
  updateBlock,
}: EnemyProps) => {
  const changeEnemyType = () => {
    let currentIndex = enemyTypes.indexOf(blockType);
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
      <img src={imageSrc} alt={blockType} width={16} height={16} />
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
