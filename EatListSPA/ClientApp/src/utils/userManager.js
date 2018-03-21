//import { createUserManager } from 'redux-oidc';
import React from 'react';
import ReactDOM from 'react-dom';
//import { applyMiddleware, compose, combineReducers } from 'redux';
import { createStore, applyMiddleware, compose, combineReducers } from 'redux';
import { Provider } from 'react-redux';
import createOidcMiddleware, { createUserManager, OidcProvider, reducer } from 'redux-oidc';

const userManagerConfig = {
   

    authority: 'http:http://localhost:5100/',
    client_id: 'oidcreactwev',
    automaticSilentRenew: true,

    //This doesn't work
    redirect_uri: "http://localhost:51540/callback",
    post_logout_redirect_uri: "http://localhost:51540/callback",
    silent_redirect_uri: "http://localhost/callback",
    scope: "openid profile apiApp",
    response_type: "id_token token",
    filterProtocolClaims: true,
    loadUserInfo: true
   
};

const userManager = createUserManager(userManagerConfig);

export default userManager;
