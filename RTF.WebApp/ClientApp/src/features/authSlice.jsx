import {createSlice} from "@reduxjs/toolkit";

const API_URL = 'api/account/login';
const json = localStorage.getItem('auth');
const localData = JSON.parse(json) || [];

export const authSlice = createSlice({
    name: 'authData',
    initialState: {
        data: {
            firstName: localData.firstName || null,
            lastName: localData.lastName || null,
            group: localData.group || null,
            userName: localData.userName || null,
            token: localData.token || null,
            role: localData.role || null,
            isFail: false,
        }
    },
    reducers: {
        setUser: (state, action) => {
            console.log(action);
            state.data.firstName = action.payload.firstName;
            state.data.lastName = action.payload.lastName;
            state.data.group = action.payload.group;
            state.data.userName = action.payload.userName;
            state.data.token = action.payload.token;
            state.data.role = action.payload.role;
            localStorage.setItem('auth', JSON.stringify({
                firstName: action.payload.firstName,
                lastName: action.payload.lastName,
                group: action.payload.group,
                userName: action.payload.userName,
                token: action.payload.token,
                role: action.payload.role,
            }))
        },
        logout : (state) => {
            state.data.firstName = null;
            state.data.lastName = null;
            state.data.group = null;
            state.data.userName = null;
            state.data.token = null;
            state.data.role = null;
            window.localStorage.removeItem('auth');
        },
        setError: (state, action) => {
            console.log(action);
            state.data.isFail = action.payload;
        }
    }
})

export const setUserAsync = (form) => async (dispatch) => {
    const response = await fetch(API_URL, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(form)
    }).then(items => {
        if (items.status !== 200) return dispatch(setError(true))
        dispatch(setError(false));
        return items.json()
    })
    dispatch(setUser(response));
};

export const { setUser, logout, setError } = authSlice.actions;
export const showUser = (state) => state.authData.data;
export default authSlice.reducer;