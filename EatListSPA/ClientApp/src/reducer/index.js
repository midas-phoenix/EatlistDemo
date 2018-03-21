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


import { createStore, applyMiddleware, compose, combineReducers } from 'redux';
import {  Provider } from 'react-redux';
import createOidcMiddleware, { createUserManager, OidcProvider, reducer } from 'redux-oidc';

// configure your reducers
const reducers = combineReducers({
    oidc: reducer,
    // your other reducers
});

export default reducers;