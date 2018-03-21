import 'bootstrap/dist/css/bootstrap.css';
import 'bootstrap/dist/css/bootstrap-theme.css';
import './index.css';
import 'semantic-ui-css/semantic.min.css';

import React from 'react';
import ReactDOM from 'react-dom';
import { BrowserRouter, Router,Route, IndexRoute, browserHistory} from 'react-router-dom';
import createOidcMiddleware, { createUserManager, OidcProvider, reducer } from 'redux-oidc';
import { Provider } from 'react-redux';
import { createStore} from 'redux';
import userManager from './utils/userManager';
import store from './store';
import App from './App';
import registerServiceWorker from './registerServiceWorker';

const baseUrl = document.getElementsByTagName('base')[0].getAttribute('href');
const rootElement = document.getElementById('root');

// you'll need this for older browsers
require("es6-promise").polyfill();
 
ReactDOM.render(
  //<BrowserRouter basename={baseUrl}>
  //  <App />
    //</BrowserRouter>
    (
        <BrowserRouter  >
            <Provider store={store}>
                <OidcProvider store={store} userManager={userManager}>
                    <App />
                </OidcProvider>
            </Provider>
        </BrowserRouter  >
    )    ,
  rootElement);

registerServiceWorker();
