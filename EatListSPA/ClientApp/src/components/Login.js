import React, { Component } from 'react';
import userManager from '../utils/userManager';
import { Button } from 'semantic-ui-react';
import { push } from 'react-router-redux';
import { Redirect } from 'react-router';


export class Login extends Component {
  displayName = Login.name

    constructor(props) {
        super(props);
        this.state = { username: "", loading: true };

        // userManager.getUser()
        //            .then(user=>function(user){if(user){this.props.dispatch(push("/fetchdata"));}}) 
    }
    oidcLogin(event) {
        console.log("loading....");
        event.preventDefault();
        userManager.signinRedirect({
            data: {
              path: window.location.pathname
            }
          })
          .then(() => console.log("Success :"))
            .catch((ex) => console.log("Error :", ex));
        // userManager.signinRedirect()
        //     .then(() => console.log("Success :"))
        //     .catch((ex) => console.log("Error :", ex))
        //var oidcUser = userManager.signinRedirect();
       // console.log("appUser :", JSON.stringify(oidcUser));
        //console.log("appUser :");
    }

    signOut(event) {
      console.log("loading....");
      event.preventDefault();
      userManager.signoutRedirect()
          .then(() => console.log("Success :"))
          .catch((ex) => console.log("Error :", ex))
      //var oidcUser = userManager.signinRedirect();
     // console.log("appUser :", JSON.stringify(oidcUser));
      //console.log("appUser :");
  }

    componentWillMount() {
       userManager.getUser().then(()=>function (user) {
           if (user) {
               console.log("User logged in", user.profile);
               this.props.navigateTo('/fetchdata');
              //  push("/fetchdata");
           }
           else {
               console.log("User not logged in");
           }
       });
    }
 
  render() {
    
    return (
      <div>
        <h1>User Login</h1>
        <p>This component demonstrates fetching data from the server.</p>
        <div>
            <Button basic color='olive' onClick={this.oidcLogin}>Log In</Button>
        </div>
        <div>
            <Button basic color='olive' onClick={this.signOut}>Log Out</Button>
        </div>
      </div>
    );
  }
}
