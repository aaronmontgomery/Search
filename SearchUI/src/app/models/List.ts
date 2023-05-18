import { Main } from "./Main";
import { Weather } from "./Weather";

export interface List {
    dt: number | null;
    dt_txt: string;
    main: Main;
    pop: number;
    weather: Weather[];
}
