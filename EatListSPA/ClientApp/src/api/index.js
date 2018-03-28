import axios from 'axios'


let BaseAddress = "http://localhost:60597/api";

export default {
    user: {
        makeRestaurant: payload => {
            axios.post(BaseAddress + "/User/makeRestaurant", payload.data, {
                headers: {
                    'Content-Type': 'application/json;charset=UTF-8',
                    "Access-Control-Allow-Origin": "*",
                    "Authorization": "Bearer " + payload.token,
                }
            })
            .then(response => response)
        },
        getRestaurant: payload => {
            axios.get(BaseAddress + "/User/getRestaurant", payload.data, {
                headers: {
                    'Content-Type': 'application/json;charset=UTF-8',
                    "Access-Control-Allow-Origin": "*",
                    "Authorization": "Bearer " + payload.token,
                }
            })
            .then(response => response)
        },
        getUserInfo: token => {
            axios.get(BaseAddress + "/User/getRestaurant", {
                headers: {
                    'Content-Type': 'application/json;charset=UTF-8',
                    "Access-Control-Allow-Origin": "*",
                    "Authorization": "Bearer " + token,
                }
            })
            .then(response => response)
        },
        profileUpdate: payload => {
            axios.post(BaseAddress + "/User/profileUp", payload.data, {
                headers: {
                    'Content-Type': 'application/json;charset=UTF-8',
                    "Access-Control-Allow-Origin": "*",
                    "Authorization": "Bearer " + payload.token,
                }
            })
            .then(response => response)
        },
        updateAccount: payload => {
            axios.post(BaseAddress + "/User/UpdateAccount", payload.data, {
                headers: {
                    'Content-Type': 'application/json;charset=UTF-8',
                    "Access-Control-Allow-Origin": "*",
                    "Authorization": "Bearer " + payload.token,
                }
            })
            .then(response => response)
        },
        
    },
    post: {
        fetchviewablePosts: token => {
            axios.get(BaseAddress + "/Post/getviewablepost", {
                headers: {
                    'Content-Type': 'application/json;charset=UTF-8',
                    "Access-Control-Allow-Origin": "*",
                    "Authorization": "Bearer " + token,
                }
            })
            .then(response => response)
        },

    },
}