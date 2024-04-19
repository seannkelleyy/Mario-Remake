export type Enemy = {
  type: string;
  startingX: number;
  startingY: number;
  direction: boolean;
};

export type enemyTypes = [
  "goomba",
  "koopa",
  "piranha",
  "bulletBill",
  "fireBro"
];
