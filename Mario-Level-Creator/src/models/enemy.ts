export type EnemyType = {
  type: string;
  startingX: number;
  startingY: number;
  direction: boolean;
  AI: string[];
};

export const enemyTypes = [
  "goomba",
  "koopa",
  "piranha",
  "bulletBillLauncher",
  "fireBro",
];
