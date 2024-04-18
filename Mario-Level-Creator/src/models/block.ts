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
  "brick",
  "square-brick",
  "smooth-brick",
  "mystery",
  "pipe",
  "pipe-top",
];

export const blockImages: { [key: string]: string } = {
  floor: "floorBlock.jpeg",
  brick: "brick.jpeg",
  "square-brick": "squareBrick.jpeg",
  "smooth-brick": "smoothBrick.jpeg",
  mystery: "mystery.jpeg",
  pipe: "pipe.jpeg",
  "pipe-top": "pipe-top.png",
};
