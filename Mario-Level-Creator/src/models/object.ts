import { BlockType, blockTypes } from "./block";
import { EnemyType, enemyTypes } from "./enemy";
import { PipeType, pipeTypes } from "./pipe";

// export type ObjectType = {
//   type: string;
//   x?: number;
//   startingX: number;
//   startingY: number;
//   y?: number;
//   endingY?: number;
//   collidable?: boolean;
//   breakable?: boolean;
//   item?: string;
//   direction?: boolean;
//   transportable?: boolean;
//   transportDestinationX?: number;
//   transportDestinationY?: number;
//   AI?: string[];
// };
export type ObjectType = PipeType & EnemyType & BlockType;

export const ObjectTypes = blockTypes.concat(pipeTypes, enemyTypes);

export const objectImages: { [key: string]: string } = {
  floor: "floorBlock.jpeg",
  floorUnderground: "floorUnderground.png",
  brick: "brick.jpeg",
  brickUnderground: "brickUnderground.png",
  smoothBrick: "smoothBrick.jpeg",
  mystery: "mystery.jpeg",
  flag: "flag.png",
  stone: "stone.jpeg",
  pipeTubeVertical: "pipeVertical.png",
  pipeTubeUpsideDown: "pipeUpsideDown.png",
  pipeTubeHorizontal: "pipeRight.png",
  deathBlock: "deathBlock.png",
  goomba: "goomba.png",
  koopa: "koopa.png",
  piranha: "piranha.png",
  bulletBillLauncher: "bullet.png",
  fireBro: "fireBro.png",
};
