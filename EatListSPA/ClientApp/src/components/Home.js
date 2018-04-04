import React, { Component } from 'react';
import userManager from '../utils/userManager';
import {bindActionCreators} from 'redux';
import { connect } from 'react-redux'
import { Route ,Redirect,} from 'react-router-dom'
import {fetchPosts} from '../actions/index'

 class HomePage extends React.Component {
    //displayName = HomePage.name
    constructor(props){
      //super(props);
      super(props);
      this.state = {
            eatlistUser:{},
      }
      //console.log("Props Home", JSON.stringify(props));
     
    }
    async componentDidMount() {
      //console.log("Props", JSON.stringify(this.props));
      try{
        //const states=this.props.states;//=>this.props.states.oidc;
        console.log("eUser", JSON.stringify(this.props.eUser));
        var user=await userManager.getUser()
        if (user&&!user.expired){
          //console.log("User logged in", user.profile);
          this.setState({eatlistUser:user})
          if (this.state.eatlistUser){
            //console.log("this.state.eatlistUser: ",this.state.eatlistUser)
            //console.log("this.props: ",this.props)
            console.log("Access Token: ",user.access_token)
            Promise.resolve(this.props.fetchViewablePosts(user.access_token))
                    .then(()=>res=>console.log("rep1",res))
                    .catch(err=>console.log(err));
          }
        }
        else {
            console.log("User not logged in");
            // <Redirect to="/" push />
            <Route path="/" children={({history})=>{() => history.push('/')}}/>
            console.log("Done");
            this.props.history.push("/");
            //console.log("Done Props:",props)}}
            //console.log("Done Props:",{(props)=>{props});
        }
     // });
        
      }
      catch(error){
        console.log("catch :",error);
      }
    }


    render() {
      
      return (
        <div>
          <h1>Hello, world!</h1>
          <p>Welcome to your new single-page application, built with:</p>
          <ul>
            <li><a href='https://get.asp.net/'>ASP.NET Core</a> and <a href='https://msdn.microsoft.com/en-us/library/67ef8sbd.aspx'>C#</a> for cross-platform server-side code</li>
            <li><a href='https://facebook.github.io/react/'>React</a> for client-side code</li>
            <li><a href='http://getbootstrap.com/'>Bootstrap</a> for layout and styling</li>
          </ul>
          <p>To help you get started, we've also set up:</p>
          <ul>
            <li><strong>Client-side navigation</strong>. For example, click <em>Counter</em> then <em>Back</em> to return here.</li>
            <li><strong>Development server integration</strong>. In development mode, the development server from <code>create-react-app</code> runs in the background automatically, so your client-side resources are dynamically built on demand and the page refreshes when you modify any file.</li>
            <li><strong>Efficient production builds</strong>. In production mode, development-time features are disabled, and your <code>dotnet publish</code> configuration produces minified, efficiently bundled JavaScript files.</li>
          </ul>
          <p>The <code>ClientApp</code> subdirectory is a standard React application based on the <code>create-react-app</code> template. If you open a command prompt in that directory, you can run <code>npm</code> commands such as <code>npm test</code> or <code>npm install</code>.</p>
        </div>
      );
    }
}

const mapStateToProps = state => {
  return {
    eUser: state.oidc,
    posts:state.posts,
  }
}

// function mapDispatchToProps(dispatch) {
//     return({
//       fetchViewablePosts: () => {dispatch(fetchPosts)}
//     });
//   // return {
//   //     dispatch(fetchPosts),
      
//   // };
// }
const mapDispatchToProps = dispatch => {
  return {
    fetchViewablePosts: token => {
      //console.log("b4 props:",JSON.stringify(this.props))
      bindActionCreators(fetchPosts(token), dispatch)
      //dispatch(fetchPosts(token))
      //console.log("afta props:",JSON.stringify(this.props))
    }
  }
}
 
// function mapDispatchToProps = dispatch => {
//   return {
//     dispatch
//     // onTodoClick: id => {
//     //   //console.log("b4 props:",JSON.stringify(this.props))
//     //   dispatch(toggleTodo(id))
//     //   //console.log("afta props:",JSON.stringify(this.props))
//     // }
//   }
// }
 
//export 
export const Home=connect(mapStateToProps,mapDispatchToProps)(HomePage)
//export default Home

//export default Home;
 