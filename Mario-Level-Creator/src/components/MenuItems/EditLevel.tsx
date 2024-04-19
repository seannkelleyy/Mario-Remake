import { Level } from "../../models/level";

type EditLevelProps = {
  level: Level;
  rows: number;
  handleColumnChange: (e: React.ChangeEvent<HTMLInputElement>) => void;
  handleRowChange: (e: React.ChangeEvent<HTMLInputElement>) => void;
  updateLevel: (property: any, value: any) => void;
};

export const EditLevel = ({
  level,
  rows,
  handleColumnChange,
  handleRowChange,
  updateLevel,
}: EditLevelProps) => {
  return (
    <section>
      <label>Level Name</label>
      <input
        type="text"
        value={level.level}
        onChange={(e) => updateLevel("level", e.target.value)}
      />
      <label>Width in Blocks</label>
      <input type="number" value={rows} onChange={handleColumnChange} />
      <label>Height in Blocks</label>
      <input type="number" value={level.height} onChange={handleRowChange} />
      <label>Time Limit</label>
      <input
        type="number"
        value={level.timeLimit}
        onChange={(e) => updateLevel("timeLimit", parseInt(e.target.value))}
      />
      <section>
        <label>Song</label>
        <select
          value={level.song}
          onChange={(e) => updateLevel("song", e.target.value)}
        >
          <option value="ground">Ground Theme</option>
          <option value="underground">Underground Theme</option>
          <option value="underwater">Underwater Theme</option>
          <option value="castle">Castle Theme</option>
        </select>
        <label>Hero Type</label>
        <select
          value={level.hero.type}
          onChange={(e) =>
            updateLevel("hero", { ...level.hero, type: e.target.value })
          }
        >
          <option value="mario">Mario</option>
        </select>
        <label>Starting Power</label>
        <select
          value={level.hero.startingPower}
          onChange={(e) =>
            updateLevel("hero", {
              ...level.hero,
              startingPower: e.target.value,
            })
          }
        >
          <option value="small">Small</option>
          <option value="big">Big</option>
          <option value="fire">Fire</option>
        </select>
        <label>Starting Lives</label>
        <input
          type="number"
          value={level.hero.statingLives}
          onChange={(e) =>
            updateLevel("hero", {
              ...level.hero,
              statingLives: parseInt(e.target.value),
              lives: parseInt(e.target.value),
            })
          }
        />
        <label>Starting X</label>
        <input
          type="number"
          value={level.hero.startingX}
          onChange={(e) =>
            updateLevel("hero", {
              ...level.hero,
              startingX: parseInt(e.target.value),
            })
          }
        />
        <label>Starting Y</label>
        <input
          type="number"
          value={level.hero.startingY}
          onChange={(e) =>
            updateLevel("hero", {
              ...level.hero,
              startingY: parseInt(e.target.value),
            })
          }
        />
      </section>
    </section>
  );
};
