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
};

export const EditObject = ({
  selectedObject,
  updateBlock,
  updateEnemy,
  updatePipe,
}: EditObjectProps) => {
  return (
    <section className="edit">
      <h3>Edit Object</h3>
      {!selectedObject && <p>Select an object to edit</p>}
      {enemyTypes.includes(selectedObject?.type) && (
        <EditEnemy
          selectedEnemy={{
            type: selectedObject?.type,
            startingX: selectedObject?.startingX || selectedObject?.x,
            startingY: selectedObject?.startingY || selectedObject?.y,
            direction: selectedObject?.direction
              ? selectedObject.direction
              : false,
            ai: selectedObject?.ai ? selectedObject.ai : [],
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
            startingY: selectedObject?.startingY || selectedObject?.y,
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
