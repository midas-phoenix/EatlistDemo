//import React from "react";
//import { connect } from "react-redux";
//import { CallbackComponent } from "redux-oidc";
//import { push } from "react-router-redux";
//import userManager from "../utils/userManager";

//class CallbackPage extends React.Component {
//    render() {
//        console.log("MYPROPS: ", this.props);

//        // just redirect to '/' in both cases
//        return (
//            <CallbackComponent
//                userManager={userManager}
//                successCallback={() => this.props.dispatch(push("/"))}
//                errorCallback={() => this.props.dispatch(push("/"))}
//            >
//                <div>Redirecting...</div>
//            </CallbackComponent>
//        );
//    }
//}

//export default connect()(CallbackPage);

import React from 'react';
import { CallbackComponent } from 'redux-oidc';
import { push } from 'react-router-redux';
import { connect } from 'react-redux';
import userManager from '../utils/userManager';
import { Redirect } from 'react-router';

class CallbackPage extends React.Component {

    // define a success callback which receives the signed in user & handles redirection
    // NOTE: this example uses react-router-redux, 
    // but any other routing library should work the same
    successCallback = (user) => {
        // the user object gets the browser's URL before 
        // redirection was triggered passed into its state
        // when triggerAuthFlow is set to `true`
        console.log("calling..."+JSON.stringify(user));
        //this.props.history.push("/fetchData");
        this.props.history.push("/home");
        console.log("props :"+JSON.stringify(this.props));
        console.log("dispatched...");
    };
    errorCallback = (error) => {
        // the user object gets the browser's URL before 
        // redirection was triggered passed into its state
        // when triggerAuthFlow is set to `true`
        console.log(error);
        this.props.dispatch(push("/"))
    };
    
    render() {
        return (
            <div>
                <CallbackComponent
                    userManager={userManager}
                    successCallback={this.successCallback}
                    errorCallback={this.errorCallback}
                    route="/"
                >
                    <div>Redirecting...</div>
                </CallbackComponent>
            </div>
        );
            
        
    }
}

function mapDispatchToProps(dispatch) {
    return {
        dispatch
    };
}

export default connect(null, mapDispatchToProps)(CallbackPage);