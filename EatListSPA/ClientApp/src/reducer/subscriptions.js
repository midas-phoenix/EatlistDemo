import { LOAD_SUBSCRIPTIONS_SUCCESS, FETCH_POSTS } from "../actions";
import { SESSION_TERMINATED, USER_EXPIRED } from "redux-oidc";

const initialState = {
  //channels: []
    posts: []
};

export default function reducer(state = initialState, action) {
  switch (action.type) {
    case SESSION_TERMINATED:
    case USER_EXPIRED:
      return Object.assign({}, state, { channels: [] });
    case LOAD_SUBSCRIPTIONS_SUCCESS:
          return Object.assign({}, state, { channels: action.payload });
    case FETCH_POSTS:
        return Object.assign({}, state, { posts: action.payload });
    default:
      return state;
  }
}
