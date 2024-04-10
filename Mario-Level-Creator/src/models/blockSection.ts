import { Item } from "./item";

export type BlockSection = {
  type: string;
  startingX: number;
  startingY: number;
  endingX: number;
  endingY: number;
  collidable: boolean;
  breakable: boolean;
  item: Item;
};
