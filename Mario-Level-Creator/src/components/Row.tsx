import { Block } from "./Block";

type ColumnProps = {
  columnIndex: number;
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
  isEditMode: boolean;
};

export const Column = ({
  columnIndex,
  dragging,
  onDragStart,
  onDragEnd,
  updateBlock,
  setSelectedCoordinates,
  nextBlockType,
  isEditMode,
}: ColumnProps) => {
  return (
    <section id={columnIndex.toString()} className="column">
      {Array(16)
        .fill(0)
        .map((_, rowIndex) => (
          <Block
            nextBlockType={nextBlockType}
            key={rowIndex}
            dragging={dragging}
            onDragStart={onDragStart}
            onDragEnd={onDragEnd}
            updateBlock={updateBlock}
            setSelectedCoordinates={setSelectedCoordinates}
            x={columnIndex}
            y={rowIndex}
            isEditMode={isEditMode}
          />
        ))}
    </section>
  );
};
