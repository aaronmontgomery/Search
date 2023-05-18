import { Article } from "./Article";

export interface News {
    articles: Article[];
    status: string | null;
    totalResults: number | null;
}
