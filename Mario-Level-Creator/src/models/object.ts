import { BlockType, blockTypes } from "./block";
import { EnemyType, enemyTypes } from "./enemy";
import { ItemType, itemTypes } from "./item";
import { PipeType, pipeTypes } from "./pipe";

export type ObjectType = PipeType & EnemyType & BlockType & ItemType;

export const ObjectTypes = blockTypes.concat(pipeTypes, enemyTypes, itemTypes);

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
  coin: "coin.png",
  coinUnderground: "coinUnderground.png",
  mushroom: "mushroom.png",
  star: "star.png",
  fireFlower: "fireFlower.png",
  oneUp: "oneUp.png",
};
