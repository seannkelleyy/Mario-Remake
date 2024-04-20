export type EnemyType = {
  type: string;
  startingX: number;
  startingY: number;
  direction: boolean;
  ai: string[];
};

export const enemyTypes = ["goomba", "koopa", "piranha", "fireBro"];
