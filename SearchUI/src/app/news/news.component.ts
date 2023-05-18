import { Component, OnInit } from '@angular/core';
import { HttpService } from '../services/http.service';
import { News } from '../models/News';

@Component({
  selector: 'app-news',
  templateUrl: './news.component.html',
  styleUrls: ['./news.component.scss']
})
export class NewsComponent implements OnInit {
  
  public news: News = {
    articles: [],
    status: null,
    totalResults: null
  };

  private _httpService: HttpService;

  private apiUrl: string = "https://localhost:7023/api/News";

  constructor(httpService: HttpService) {
    this._httpService = httpService;
  }

  ngOnInit(): void {

    let countryCode: string = "us";
    
    this._httpService.get<News>(`${this.apiUrl}/GetTopHeadlines?country=${countryCode}`).subscribe({
      next: (result: News) => {
        console.log(result);
        this.news = result;
      },
      error: (error: Error) => {

      },
      complete: () => {

      }
    });
  }
}
