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
            selectedEnemy.ai
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
            selectedEnemy.ai
          )
        }
      >
        <option value="true">Right</option>
        <option value="false">Left</option>
      </select>
      <label>AI:</label>
      <select
        multiple
        value={selectedEnemy?.ai ? selectedEnemy.ai : []}
        onChange={(e) => {
          const options = e.target.options;
          const value = [];
          for (let i = 0, l = options.length; i < l; i++) {
            if (options[i].selected) {
              value.push(options[i].value);
            }
          }
          updateEnemy(
            selectedEnemy.type,
            selectedEnemy.startingX,
            selectedEnemy.startingY,
            selectedEnemy.direction,
            value
          );
        }}
      >
        <option value="none">None</option>
        <option value="seek">Seek</option>
        <option value="scare">Scare</option>
        <option value="jump">Jump</option>
      </select>
    </section>
  );
};
