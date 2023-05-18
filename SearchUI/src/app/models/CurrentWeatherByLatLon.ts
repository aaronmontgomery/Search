import { Main } from "./Main";
import { Weather } from "./Weather";

export interface CurrentWeatherByLatLon {
    dt: number | null;
    main: Main;
    name: string | null;
    weather: Weather[];
}
