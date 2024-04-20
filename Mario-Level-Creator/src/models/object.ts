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
  pipeTile: "pipe.jpeg",
  deathBlock: "deathBlock.png",
  goomba: "goomba.png",
  koopa: "koopa.png",
  piranha: "piranha.png",
  bulletBillLauncher: "bullet.png",
  fireBro: "fireBro.png",
  coin: "coin.png",
  coinUnderground: "coinUnderground.png",
  redMushroom: "mushroom.png",
  star: "star.png",
  fireflower: "fireFlower.png",
  oneUp: "oneUp.png",
  pistol: "pistol.png",
  shotgun: "shotgun.png",
  rocketLauncher: "rocketLauncher.png",
};
