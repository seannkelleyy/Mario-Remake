import { PipeType } from "../../models/pipe";

type EditPipeProps = {
  selectedPipe: PipeType;
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

export const EditPipe = ({ selectedPipe, updatePipe }: EditPipeProps) => {
  return (
    <section className="edit-popup">
      <h2>Edit Pipe</h2>
      <label>Pipe Type:</label>
      <select
        value={selectedPipe?.type ? selectedPipe.type : "pipeTubeVertical"}
        onChange={(e) => {
          updatePipe(
            selectedPipe.x,
            selectedPipe.startingY,
            selectedPipe.endingY,
            e.target.value,
            selectedPipe.transportable ? true : false,
            selectedPipe.x,
            selectedPipe.endingY,
            selectedPipe.collidable ? true : false,
            selectedPipe.breakable ? true : false
          );
        }}
      >
        <option value="pipeTubeVertical">Pipe Vertical</option>
        <option value="pipeTubeUpsideDown">Pipe Upside Down</option>
        <option value="pipeTubeHorizontal">Pipe Horizontal</option>
      </select>
      <label>Ending Y</label>
      <input
        type="number"
        value={selectedPipe?.endingY ? selectedPipe.endingY : 0}
        onChange={(e) =>
          updatePipe(
            selectedPipe.x,
            selectedPipe.startingY,
            Number(e.target.value),
            selectedPipe.type,
            selectedPipe.transportable ? true : false,
            selectedPipe.transportDestinationX
              ? selectedPipe.transportDestinationX
              : selectedPipe.x,
            selectedPipe.transportDestinationY
              ? selectedPipe.transportDestinationY
              : Number(e.target.value),
            selectedPipe.collidable ? true : false,
            selectedPipe.breakable ? true : false
          )
        }
      />
      <label>Transportable: </label>
      <input
        type="checkbox"
        checked={
          selectedPipe?.transportable ? selectedPipe.transportable : false
        }
        onChange={(e) =>
          updatePipe(
            selectedPipe.x,
            selectedPipe.startingY,
            selectedPipe.endingY,
            selectedPipe.type,
            e.target.checked,
            selectedPipe.transportDestinationX
              ? selectedPipe.transportDestinationX
              : selectedPipe.x,
            selectedPipe.transportDestinationY
              ? selectedPipe.transportDestinationY
              : selectedPipe.endingY,
            selectedPipe.collidable ? true : false,
            selectedPipe.breakable ? true : false
          )
        }
      />

      <label>Transport X</label>
      <input
        type="number"
        value={
          selectedPipe?.transportDestinationX
            ? selectedPipe.transportDestinationX
            : selectedPipe.x
        }
        onChange={(e) =>
          updatePipe(
            selectedPipe.x,
            selectedPipe.startingY,
            selectedPipe.endingY,
            selectedPipe.type,
            selectedPipe.transportable ? true : false,
            Number(e.target.value),
            selectedPipe.transportDestinationY
              ? selectedPipe.transportDestinationY
              : selectedPipe.endingY,
            selectedPipe.collidable ? true : false,
            selectedPipe.breakable ? true : false
          )
        }
      />
      <label>Transport Y</label>
      <input
        type="number"
        value={
          selectedPipe?.transportDestinationY
            ? selectedPipe.transportDestinationY
            : selectedPipe.endingY
        }
        onChange={(e) =>
          updatePipe(
            selectedPipe.x,
            selectedPipe.startingY,
            selectedPipe.endingY,
            selectedPipe.type,
            selectedPipe.transportable ? true : false,
            selectedPipe.transportDestinationX
              ? selectedPipe.transportDestinationX
              : selectedPipe.x,
            Number(e.target.value),
            selectedPipe.collidable ? true : false,
            selectedPipe.breakable ? true : false
          )
        }
      />
      <label>Collideable:</label>
      <input
        type="checkbox"
        checked={selectedPipe?.collidable ? selectedPipe.collidable : false}
        onChange={(e) =>
          updatePipe(
            selectedPipe.x,
            selectedPipe.startingY,
            selectedPipe.endingY,
            selectedPipe.type,
            selectedPipe.transportable ? true : false,
            selectedPipe.transportDestinationX
              ? selectedPipe.transportDestinationX
              : selectedPipe.x,
            selectedPipe.transportDestinationY
              ? selectedPipe.transportDestinationY
              : selectedPipe.endingY,
            e.target.checked,
            selectedPipe.breakable ? true : false
          )
        }
      />
      <label>Breakable:</label>
      <input
        type="checkbox"
        checked={selectedPipe?.breakable ? selectedPipe.breakable : false}
        onChange={(e) =>
          updatePipe(
            selectedPipe.x,
            selectedPipe.startingY,
            selectedPipe.endingY,
            selectedPipe.type,
            selectedPipe.transportable ? true : false,
            selectedPipe.transportDestinationX
              ? selectedPipe.transportDestinationX
              : selectedPipe.x,
            selectedPipe.transportDestinationY
              ? selectedPipe.transportDestinationY
              : selectedPipe.endingY,
            selectedPipe.collidable ? true : false,
            e.target.checked
          )
        }
      />
    </section>
  );
};
