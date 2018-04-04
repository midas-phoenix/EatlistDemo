import api from '../api/index';

export const LOAD_SUBSCRIPTIONS_START =
  "redux-oidc-sample/LOAD_SUBSCRIPTIONS_START";
export const LOAD_SUBSCRIPTIONS_SUCCESS =
  "redux-oidc-sample/LOAD_SUBSCRIPTIONS_SUCCESS";
export const FETCH_POSTS = "api/post/fetch";


export function loadSubscriptionsStart() {
  return {
    type: LOAD_SUBSCRIPTIONS_START
  };
}

export function loadSubscriptionsSuccess(channels) {
  return {
    type: LOAD_SUBSCRIPTIONS_SUCCESS,
    payload: channels
  };
}

///Users
//data=token+{"restaurantName": "string","isRestaurant": true}
export function makeRestaurant(data) {
    return {
        type: MAKE_RESTAURANT,
        payload: api.user.makeRestaurant(data),//.then(viewPosts=>viewPosts),
    };
}
//data=token+id(string) i.e restaurant's id
export function getRestaurant(data) {
  return {
      type: MAKE_RESTAURANT,
      payload: api.user.getRestaurant(data),//.then(viewPosts=>viewPosts),
  };
}

export function getUserInfo(token) {
  return {
      type: MAKE_RESTAURANT,
      payload: api.user.getUserInfo(token),//.then(viewPosts=>viewPosts),
  };
}

///Posts
export function fetchPosts(token) {
  return {
      type: FETCH_POSTS,
      payload: api.post.fetchviewablePosts(token),//.then(viewPosts=>viewPosts),
  };
}
