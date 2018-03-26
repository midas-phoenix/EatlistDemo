
import { createUserManager } from 'redux-oidc';

const userManagerConfig = {
   

    authority: 'http://localhost:5000/',
    client_id: 'oidcreactwev',
    automaticSilentRenew: true,

    //This doesn't work
    redirect_uri: "http://localhost:51540/callback",
    post_logout_redirect_uri: "http://localhost:51540/home",
    silent_redirect_uri: "http://localhost/callback",
    scope: "openid profile apiApp",
    response_type: "id_token token",
    filterProtocolClaims: true,
    loadUserInfo: true
   
};

const userManager = createUserManager(userManagerConfig);

export default userManager;
