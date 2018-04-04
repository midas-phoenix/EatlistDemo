import React, { Component } from 'react';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { FetchData } from './components/FetchData';
import { Counter } from './components/Counter';
import { Login } from './components/Login';
import {Router, Route, withRouter  } from 'react-router-dom';
//import { syncHistoryWithStore } from 'react-router-redux';
//import store from './store';
import callback from './components/CallBack'

//const history = syncHistoryWithStore(this.props.history, store);

class App extends Component {
  displayName = App.name

  render() {
    return (
        <Layout>
            <Route exact path='/' component={Login} />
            <Route exact path='/Home' component={Home} />
            <Route path='/counter' component={Counter} />
            <Route path='/fetchdata' component={FetchData} />
            <Route path='/callback' component={callback} />
      </Layout>
    );
  }
}

export default App;
//export default withRouter(App);
//export default function App(props) {
//    return (
//        <Provider store={store}>
//            <OidcProvider store={store} userManager={userManager}>
//                /* //<Root>
//                //    <Routes />
//                //</Root>
//                    */
//                <Layout>
//                    <Route exact path='/' component={Home} />
//                    <Route path='/counter' component={Counter} />
//                    <Route path='/fetchdata' component={FetchData} />
//                </Layout>
//            </OidcProvider>
//        </Provider>
//    );
//}
