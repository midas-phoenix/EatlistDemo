import React, { Component } from 'react';
import userManager from '../utils/userManager';
import { Button } from 'semantic-ui-react'



export class Login extends Component {
  displayName = Login.name

    constructor(props) {
        super(props);
        this.state = { username: "", loading: true };

    }
    oidcLogin(event) {
        console.log("loading....");
        event.preventDefault();
        userManager.signinRedirect()
            .then(() => console.log("Success :"))
            .catch((ex) => console.log("Error :", ex))
        //var oidcUser = userManager.signinRedirect();
       // console.log("appUser :", JSON.stringify(oidcUser));
        //console.log("appUser :");
    }

 
  render() {
    
    return (
      <div>
        <h1>User Login</h1>
        <p>This component demonstrates fetching data from the server.</p>
        <div>
            <Button basic color='olive' onClick={this.oidcLogin}>Log In</Button>
        </div>
      </div>
    );
  }
}
