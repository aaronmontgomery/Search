import { Component, OnInit } from '@angular/core';
import { formatDate } from '@angular/common';
import { HttpService } from '../services/http.service';
import { ForecastZipCodeCountryCode } from '../models/ForecastZipCodeCountryCode';
import { CurrentWeatherByLatLon } from '../models/CurrentWeatherByLatLon';
import { ListExtended } from '../models/ListExtended';
import { WeatherExtended } from '../models/WeatherExtended';
import { List } from '../models/List';
import { Main } from '../models/Main';

@Component({
  selector: 'app-weather',
  templateUrl: './weather.component.html',
  styleUrls: ['./weather.component.scss']
})
export class WeatherComponent implements OnInit {
  
  public forecastZipCodeCountryCode: ForecastZipCodeCountryCode = {
    city: {
      coord: {
        lat: null,
        lon: null
      },
      country: null,
      name: null
    },
    list: []
  };

  public currentWeatherByLatLon: CurrentWeatherByLatLon = {
    dt: null,
    main: {
      temp: null,
      temp_max: null,
      temp_min: null
    },
    name: null,
    weather: []
  };
  
  public forecasts: ListExtended[] = [];
  
  public title: string | null = null;
  
  private _httpService: HttpService;
  
  private apiUrl: string = "https://localhost:7023/api/Weather";

  constructor(httpService: HttpService) {
    this._httpService = httpService;
  }
  
  ngOnInit(): void {
    
    const zipCode: string = "94089"; //"98101";
    const countryCode: string = "us";
    
    this._httpService.get<ForecastZipCodeCountryCode>(`${this.apiUrl}/GetForecastByZipCodeCountryCode?zipCode=${zipCode}&country=${countryCode}`).subscribe({
      next: (result: ForecastZipCodeCountryCode) => {
        console.log(result);
        this.forecastZipCodeCountryCode = result;
      },
      error: (error: Error) => {

      },
      complete: () => {
        
        for (let i = 0; i < this.forecastZipCodeCountryCode.list.length; i++) {
          let date: Date = new Date(this.forecastZipCodeCountryCode.list[i].dt_txt);
          if (date.getHours() === 12) {
            let weatherExtendeds: WeatherExtended[] = [];
            for (let j = 0; j < this.forecastZipCodeCountryCode.list[i].weather.length; j++) {
              weatherExtendeds.push({
                description: this.forecastZipCodeCountryCode.list[i].weather[j].description,
                icon: this.forecastZipCodeCountryCode.list[i].weather[j].icon,
                main: this.forecastZipCodeCountryCode.list[i].weather[j].main,
                iconUrl: `https://openweathermap.org/img/wn/${this.forecastZipCodeCountryCode.list[i].weather[j].icon}@2x.png`
              });
            }
            
            this.forecasts.push({
              dt: this.forecastZipCodeCountryCode.list[i].dt,
              dt_txt: this.forecastZipCodeCountryCode.list[i].dt_txt,
              main: this.getMain(this.forecastZipCodeCountryCode.list[i], this.forecastZipCodeCountryCode.list, date.getDate()),
              pop: this.getPopValueDay(this.forecastZipCodeCountryCode.list, date.getDate()),
              weather: weatherExtendeds
            });
          }
          
          i = this.forecasts.length === 3 ? this.forecastZipCodeCountryCode.list.length - 1 : i;
        }
        
        this._httpService.get<CurrentWeatherByLatLon>(`${this.apiUrl}/GetCurrentWeatherByLatLon?lat=${this.forecastZipCodeCountryCode.city.coord.lat}&lon=${this.forecastZipCodeCountryCode.city.coord.lon}`).subscribe({
          next: (result: CurrentWeatherByLatLon) => {
            console.log(result);
            this.currentWeatherByLatLon = result;
            let weathersExendeds: WeatherExtended[] = [];
            for (let i = 0; i < this.currentWeatherByLatLon.weather.length; i++) {
              weathersExendeds.push({
                description: this.currentWeatherByLatLon.weather[i].description,
                icon: this.currentWeatherByLatLon.weather[i].icon,
                main: this.currentWeatherByLatLon.weather[i].main,
                iconUrl: `https://openweathermap.org/img/wn/${this.currentWeatherByLatLon.weather[i].icon}@2x.png`
              });
            }
            
            let pop: number = -1;
            for (let i = 0; i < this.forecastZipCodeCountryCode.list.length; i++) {
              let currentDay: number = new Date().getDate();
              let day: number = new Date(this.forecastZipCodeCountryCode.list[i].dt_txt).getDate();
              if (day > currentDay) {
                i = this.forecastZipCodeCountryCode.list.length - 1;
              }

              else {
                pop = this.forecastZipCodeCountryCode.list[i].pop > pop ? this.forecastZipCodeCountryCode.list[i].pop : pop;
              }
            }

            let dateString: string = formatDate(Date.now(), 'yyyy-MM-dd HH:mm:ss', 'en-us');
            this.forecasts.splice(0, 0, {
              dt: this.currentWeatherByLatLon.dt,
              dt_txt: dateString,
              main: this.currentWeatherByLatLon.main,
              pop: this.getPopValueDay(this.forecastZipCodeCountryCode.list, new Date(dateString).getDate()),
              weather: weathersExendeds,
            });
          },
          error: (error: Error) => {

          },
          complete: () => {
            console.log(this.forecasts);
            this.title = `${this.forecastZipCodeCountryCode.city.name}, ${this.currentWeatherByLatLon.name}, ${this.forecastZipCodeCountryCode.city.country}`;
          }
        });

      }
    });
  }

  private getPopValueDay(lists: List[], dayOfMonth: number): number {
    let pop: number = -1;
    for (let i = 0; i < lists.length; i++) {
      let date: Date = new Date(lists[i].dt_txt);
      if (date.getDate() === dayOfMonth) {
        pop = lists[i].pop > pop ? lists[i].pop : pop;
      }

      else {
        pop = date.getDate() > dayOfMonth ? lists[0].pop : 0;
      }
    }
    
    return pop;
  }

  private getMain(list: List, lists: List[], dayOfMonth: number): Main {
    let main: Main = list.main;
    let temp_min: number = (lists[0].main.temp_min ?? 0);
    let temp_max: number = (lists[0].main.temp_max ?? 0);
    for (let i = 0; i < lists.length; i++) {
      let date: Date = new Date(lists[i].dt_txt);
      if (date.getDate() === dayOfMonth) {
        temp_min = (lists[i].main.temp_min ?? 0) < temp_min ? (lists[i].main.temp_min ?? 0) : temp_min;
        temp_max = (lists[i].main.temp_max ?? 0) > temp_max ? (lists[i].main.temp_max ?? 0) : temp_max;
      }
    }
    
    main.temp_min = temp_min;
    main.temp_max = temp_max;
    return main;
  }

}
