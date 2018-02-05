import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';
import { AuthService } from '../../services/auth.service';

@Component({
    selector: 'fetchdata',
    templateUrl: './fetchdata.component.html'
})
export class FetchDataComponent {
    public forecasts: WeatherForecast[];

    //constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {

    constructor(authService: AuthService, @Inject('API_URL') apiUrl: string) {
        console.log(apiUrl);
        authService.get(apiUrl + 'api/SampleData/WeatherForecasts').subscribe(result => {
            this.forecasts = result as WeatherForecast[];
        }, error => console.error(error));
    }
}

interface WeatherForecast {
    dateFormatted: string;
    temperatureC: number;
    temperatureF: number;
    summary: string;
}
