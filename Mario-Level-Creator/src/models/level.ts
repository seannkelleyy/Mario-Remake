import { BlockType } from "./block";
import { BlockSection } from "./blockSection";
import { Enemy } from "./enemy";
import { Hero } from "./hero";

export type Level = {
  level: string;
  song: string;
  width: number;
  height: number;
  hero: Hero;
  enemies: Enemy[];
  blockSections: BlockSection[];
  blocks: BlockType[];
};
