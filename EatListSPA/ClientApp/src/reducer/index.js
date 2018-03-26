//import { routerReducer } from 'react-router-redux';
//import { combineReducers } from 'redux';
//import { reducer as oidcReducer } from 'redux-oidc';
//import subscriptionsReducer from './subscriptions';

//const reducer = combineReducers(
//  {
//    routing: routerReducer,
//    oidc: oidcReducer,
//    subscriptions: subscriptionsReducer
//  }
//);

//export default reducer;


import { combineReducers } from 'redux';
//import {  Provider } from 'react-redux';
import  { reducer } from 'redux-oidc';
import {routerReducer } from 'react-router-redux'


// configure your reducers
const reducers = combineReducers({
    oidc: reducer,
    routing:routerReducer,
    // your other reducers
});

export default reducers;