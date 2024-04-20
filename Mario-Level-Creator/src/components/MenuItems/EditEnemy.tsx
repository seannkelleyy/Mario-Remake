import { EnemyType } from "../../models/enemy";

type EditEnemyProps = {
  selectedEnemy: EnemyType;
  updateEnemy: (
    enemeyType: string,
    startingX: number,
    startingY: number,
    direction: boolean,
    AI: string[]
  ) => void;
};

export const EditEnemy = ({ selectedEnemy, updateEnemy }: EditEnemyProps) => {
  return (
    <section className="edit-popup">
      <label>Enemy Type:</label>
      <select
        value={selectedEnemy?.type ? selectedEnemy.type : "goomba"}
        onChange={(e) => {
          updateEnemy(
            e.target.value,
            selectedEnemy.startingX,
            selectedEnemy.startingY,
            selectedEnemy.direction ? selectedEnemy.direction : false,
            selectedEnemy.AI
          );
        }}
      >
        <option value="goomba">Goomba</option>
        <option value="koopa">Koopa</option>
        <option value="piranha">Piranha</option>
        <option value="bulletBillLauncher">Bullet Bill</option>
        <option value="fireBro">Fire Bro</option>
      </select>
      <label>Direction:</label>
      <select
        value={selectedEnemy?.direction ? "true" : "false"}
        onChange={(e) =>
          updateEnemy(
            selectedEnemy.type,
            selectedEnemy.startingX,
            selectedEnemy.startingY,
            e.target.value === "true" ? true : false,
            selectedEnemy.AI
          )
        }
      >
        <option value="true">Right</option>
        <option value="false">Left</option>
      </select>
      <label>AI:</label>
      <select
        multiple
        value={selectedEnemy?.AI ? selectedEnemy.AI : []}
        onChange={(e) =>
          updateEnemy(
            selectedEnemy.type,
            selectedEnemy.startingX,
            selectedEnemy.startingY,
            selectedEnemy.direction,
            e.target.value.split(",").filter((ai) => ai !== "")
          )
        }
      >
        <option value="none">None</option>
        <option value="seek">Seek</option>
        <option value="scare">Scare</option>
        <option value="jump">Jump</option>
      </select>
    </section>
  );
};