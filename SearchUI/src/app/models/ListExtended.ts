import { List } from "./List";
import { WeatherExtended } from "./WeatherExtended";

export interface ListExtended extends List {
    weather: WeatherExtended[];
}
