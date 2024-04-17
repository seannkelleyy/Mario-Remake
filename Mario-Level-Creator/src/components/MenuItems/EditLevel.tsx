import { Level } from "../../models/level";

type EditLevelProps = {
  level: Level;
  updateLevel: (property: any, value: any) => void;
  rows: number;
  handleRowChange: (e: React.ChangeEvent<HTMLInputElement>) => void;
};

export const EditLevel = ({
  level,
  updateLevel,
  rows,
  handleRowChange,
}: EditLevelProps) => {
  return (
    <>
      <label>Level Name</label>
      <input
        type="text"
        value={level.level}
        onChange={(e) => updateLevel("level", e.target.value)}
      />
      <label>Width in Blocks</label>
      <input type="number" value={rows} onChange={handleRowChange} />
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
          <option value="enemyStar">Star Theme</option>
          <option value="levelComplete">Level Complete</option>
          <option value="castleComplete">Castle Complete</option>
          <option value="lostLife">Lost Life</option>
          <option value="gameOver">Game Over</option>
          <option value="ending">Ending</option>
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
    </>
  );
};
