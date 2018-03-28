import 'bootstrap/dist/css/bootstrap.css';
import 'bootstrap/dist/css/bootstrap-theme.css';
import './index.css';
import 'semantic-ui-css/semantic.min.css';

import React from 'react';
import ReactDOM from 'react-dom';
//import {browserHistory} from 'react-router';
import { Router,BrowserRouter, /*Router,Route, IndexRoute, */} from 'react-router-dom';
import { OidcProvider } from 'redux-oidc';
import { Provider } from 'react-redux';
//import { createStore} from 'redux';
import userManager from './utils/userManager';
import store from './store';
import App from './App';
import createHistory from "history/createBrowserHistory"
import registerServiceWorker from './registerServiceWorker';
import { syncHistoryWithStore, routerReducer } from 'react-router-redux'


const baseUrl = document.getElementsByTagName('base')[0].getAttribute('href');
const rootElement = document.getElementById('root');
//const history = syncHistoryWithStore( createHistory({basename : baseUrl}), store);
const history = syncHistoryWithStore( createHistory({basename : baseUrl,forceRefresh:true}), store);


// you'll need this for older browsers
require("es6-promise").polyfill();
 
ReactDOM.render(
  //<BrowserRouter basename={baseUrl}>
  //  <App />
    //</BrowserRouter>
    (
        <Router history={history} >
            <Provider store={store}>
                <OidcProvider store={store} userManager={userManager}>
                    <App />
                </OidcProvider>
            </Provider>
        </Router  >
    )    ,
  rootElement);

registerServiceWorker();
