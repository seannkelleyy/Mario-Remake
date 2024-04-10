import { Item } from "./item";

export type Block = {
  type: string;
  x: number;
  y: number;
  collidable: boolean;
  breakable: boolean;
  item: Item;
};
