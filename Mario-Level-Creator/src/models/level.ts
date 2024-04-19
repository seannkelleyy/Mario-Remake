import { BlockType } from "./block";
import { BlockSection } from "./blockSection";
import { Enemy } from "./enemy";
import { Hero } from "./hero";
import { Pipe } from "./pipe";

export type Level = {
  level: string;
  pathToSpriteJson: string;
  width: number;
  height: number;
  timeLimit: number;
  song: string;
  hero: Hero;
  enemies: Enemy[];
  blockSections: BlockSection[];
  blocks: BlockType[];
  pipes: Pipe[];
};
