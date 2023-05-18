import { Coord } from "./Coord";

export interface City {
    coord: Coord;
    country: string | null;
    name: string | null;
}
