export type BlockType = {
  type: string;
  x: number;
  y: number;
  collidable: boolean;
  breakable: boolean;
  item: string;
};

export const blockTypes = [
  "air",
  "floor",
  "floorUnderground",
  "brick",
  "brickUnderground",
  "mystery",
  "flag",
  "deathBlock",
  "stone",
  "pipeTubeVertical",
  "pipeTubeUpsideDown",
  "pipeTubeHorizontal",
  "goomba",
  "koopa",
  "piranha",
  "bulletBillLauncher",
  "fireBro",
];

export const blockImages: { [key: string]: string } = {
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
