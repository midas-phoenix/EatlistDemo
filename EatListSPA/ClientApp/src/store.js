//import { createStore, combineReducers, applyMiddleware, compose } from "redux";
//import { browserHistory } from "react-router";
//import {syncHistoryWithStore, routerReducer, routerMiddleware} from "react-router-redux";
//import { createUserManager, loadUser } from "redux-oidc";
//import reducer from "./reducer";
//import userManager from "./utils/userManager";

//// create the middleware with the userManager
//// const oidcMiddleware = createOidcMiddleware(userManager);

//const loggerMiddleware = store => next => action => {
//  console.log("Action type:", action.type);
//  console.log("Action payload:", action.payload);
//  console.log("State before:", store.getState());
//  next(action);
//  console.log("State after:", store.getState());
//};

//const initialState = {};

//const createStoreWithMiddleware = compose(
//  applyMiddleware(loggerMiddleware, routerMiddleware(browserHistory))
//)(createStore);

//const store = createStoreWithMiddleware(reducer, initialState);
//loadUser(store, userManager);

//export default store;


//import React from 'react';
//import ReactDOM from 'react-dom';
import { createStore,applyMiddleware, } from 'redux';
//import { Provider } from 'react-redux';
import createOidcMiddleware from 'redux-oidc';
import reducers from './reducer/index';
import userManager from './utils/userManager';

// create the middleware
//const oidcMiddleware = createOidcMiddleware(userManager, () => true, false, '/callback');
const oidcMiddleware = createOidcMiddleware(userManager, () => true, true, '/callback');

// configure your redux store
const store = createStore(
    reducers,
    applyMiddleware(oidcMiddleware)
);

export default store;
