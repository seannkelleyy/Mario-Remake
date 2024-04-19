export const pipeTypes = [
  "pipeTubeVertical",
  "pipeTubeUpsideDown",
  "pipeTubeHorizontal",
];

export type Pipe = {
  type: string;
  x: number;
  startingY: number;
  endingY: number;
  transportable: boolean;
  transportDestinationX: number;
  transportDestinationY: number;
  collidable: boolean;
  breakable: boolean;
};
