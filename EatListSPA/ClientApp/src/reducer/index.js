import { combineReducers } from 'redux';
//import {  Provider } from 'react-redux';
import  { reducer } from 'redux-oidc';
import {routerReducer } from 'react-router-redux'
import posts from './posts'

// configure your reducers
const reducers = combineReducers({
    oidc: reducer,
    routing:routerReducer,
    post:posts,
    //posts=()=>{()=>{return ["Hello","Thanks"]}},
    // your other reducers
});

export default reducers;