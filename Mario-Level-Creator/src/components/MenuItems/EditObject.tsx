import { blockTypes } from "../../models/block";
import { enemyTypes } from "../../models/enemy";
import { ObjectType } from "../../models/object";
import { pipeTypes } from "../../models/pipe";
import { EditBlock } from "./EditBlock";
import { EditEnemy } from "./EditEnemy";
import { EditPipe } from "./EditPipe";

type EditObjectProps = {
  selectedObject: ObjectType;
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
    blockType: string,
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

export const EditObject = ({
  selectedObject,
  updateBlock,
  updateEnemy,
  updatePipe,
}: EditObjectProps) => {
  return (
    <section>
      {enemyTypes.includes(selectedObject?.type) && (
        <EditEnemy
          selectedEnemy={{
            type: selectedObject?.type,
            startingX: selectedObject?.x,
            startingY: selectedObject?.y,
            direction: selectedObject?.direction
              ? selectedObject.direction
              : false,
            AI: selectedObject?.AI ? selectedObject.AI : [],
          }}
          updateEnemy={updateEnemy}
        />
      )}
      {blockTypes.includes(selectedObject?.type) && (
        <EditBlock
          selectedBlock={{
            type: selectedObject?.type,
            x: selectedObject?.x,
            y: selectedObject?.y,
            collidable: selectedObject?.collidable
              ? selectedObject.collidable
              : false,
            breakable: selectedObject?.breakable
              ? selectedObject.breakable
              : false,
            item: selectedObject?.item ? selectedObject.item : "",
          }}
          updateBlock={updateBlock}
        />
      )}
      {pipeTypes.includes(selectedObject?.type) && (
        <EditPipe
          selectedPipe={{
            type: selectedObject?.type,
            x: selectedObject?.x,
            startingY: selectedObject?.y,
            endingY: selectedObject?.endingY ? selectedObject.endingY : 0,
            transportable: selectedObject?.transportable
              ? selectedObject.transportable
              : false,
            transportDestinationX: selectedObject?.transportDestinationX
              ? selectedObject.transportDestinationX
              : 0,
            transportDestinationY: selectedObject?.transportDestinationY
              ? selectedObject.transportDestinationY
              : 0,
            collidable: selectedObject?.collidable
              ? selectedObject.collidable
              : false,
            breakable: selectedObject?.breakable
              ? selectedObject.breakable
              : false,
          }}
          updatePipe={updatePipe}
        />
      )}
    </section>
  );
};
