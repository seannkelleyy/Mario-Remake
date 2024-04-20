import { BlockType } from "./block";
import { BlockSection } from "./blockSection";
import { EnemyType } from "./enemy";
import { Hero } from "./hero";
import { ItemType } from "./item";
import { ItemSectionType } from "./itemSection";
import { PipeType } from "./pipe";

export type Level = {
  level: string;
  pathToSpriteJson: string;
  width: number;
  height: number;
  timeLimit: number;
  song: string;
  hero: Hero;
  enemies: EnemyType[];
  items: ItemType[];
  itemSections: ItemSectionType[];
  blockSections: BlockSection[];
  blocks: BlockType[];
  pipes: PipeType[];
};
