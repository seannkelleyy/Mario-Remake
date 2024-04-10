import { Block } from "./Block";

type RowProps = {
  rowIndex: number;
  dragging: boolean;
  onDragStart: (blockType: string) => void;
  onDragEnd: () => void;
  nextBlockType: string;
};

export const Row = ({
  rowIndex,
  dragging,
  onDragStart,
  onDragEnd,
  nextBlockType,
}: RowProps) => {
  return (
    <section id={rowIndex.toString()} className="row">
      {Array(16)
        .fill(0)
        .map((_, columnIndex) => (
          <Block
            nextBlockType={nextBlockType}
            key={columnIndex}
            dragging={dragging}
            onDragStart={onDragStart}
            onDragEnd={onDragEnd}
          />
        ))}
    </section>
  );
};
