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
  "bulletBillLauncher",
];
