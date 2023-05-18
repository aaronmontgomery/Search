import { Source } from "./Source";

export interface Article {
    author: string;
    content: string;
    description: string;
    publishedAt: Date;
    source: Source;
    title: string;
    url: string;
    urlToImage: string;
}
