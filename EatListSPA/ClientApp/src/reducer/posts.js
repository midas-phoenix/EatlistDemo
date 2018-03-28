import { LOAD_SUBSCRIPTIONS_SUCCESS, FETCH_POSTS } from "../actions";
import { SESSION_TERMINATED, USER_EXPIRED } from "redux-oidc";
//import {posts} from '../api/index'
// const initialState = {
//   //channels: []
//     posts: []
// };

export default function posts(state = [], action) {
  switch (action.type) {
    // case SESSION_TERMINATED:
    // case USER_EXPIRED:
    //   //return Object.assign({}, state, []);
    //   return [
    //     ...state,
    //   ]
    // case USER_LOGGED_IN:
    //     return [
    //       ...state,
    //     ] 
    //   //return Object.assign({}, state, { channels: action.payload });
     case FETCH_POSTS:
          return action.payload
        
        // return Object.assign({}, state, { posts: action.payload });
    default:
      return state;
  }
}
