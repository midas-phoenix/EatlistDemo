import React, { Component } from 'react';

export class FetchData extends Component {
  displayName = FetchData.name

  constructor(props) {
    super(props);
    this.state = { forecasts: [], loading: true };

      //vhbhnb
       //fetch('https://facebook.github.io/react-native/movies.json')
       // .then((response) => response.json())
       // .then((responseJson) => {
       //        console.log("resp :" + JSON.stringify(responseJson.movies));
       // })
       // .catch((error) => {
       //     console.error(error);
       // });

      fetch('api/SampleData/WeatherForecasts')
        .then(response => response.json())
        //.then(response => console.log("resp2 :" + JSON.stringify(response)))
        .then(data => {
            this.setState({ forecasts: data, loading: false });
            //console.log("forecasts :" + JSON.stringify(this.state.forecasts));
        });
  }

  static renderForecastsTable(forecasts) {
    return (
      <table className='table'>
        <thead>
          <tr>
            <th>Date</th>
            <th>Temp. (C)</th>
            <th>Temp. (F)</th>
            <th>Summary</th>
          </tr>
        </thead>
        <tbody>
          {forecasts.map(forecast =>
            <tr key={forecast.dateFormatted}>
              <td>{forecast.dateFormatted}</td>
              <td>{forecast.temperatureC}</td>
              <td>{forecast.temperatureF}</td>
              <td>{forecast.summary}</td>
            </tr>
          )}
        </tbody>
      </table>
    );
  }

  render() {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
      : FetchData.renderForecastsTable(this.state.forecasts);

    return (
      <div>
        <h1>Weather forecast</h1>
        <p>This component demonstrates fetching data from the server.</p>
        {contents}
      </div>
    );
  }
}