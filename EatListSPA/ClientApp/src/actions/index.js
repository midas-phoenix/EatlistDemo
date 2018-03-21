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

export function fetchPosts(posts) {
    return {
        type: FETCH_POSTS,
        payload: posts
    };
}
