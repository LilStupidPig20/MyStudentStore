import {createSlice} from "@reduxjs/toolkit";
import {logout} from "./authSlice";

const API_URL = '/api/userBalance/getCurrentUserBalance';

export const userBalanceSlice = createSlice({
    name: 'userBalance',
    initialState: {
        data: 0
    },
    reducers: {
        getUserBalance: (state, action) => {
            state.data = [action.payload];
        }
    }
})

export const getUserBalanceAsync = (token) => async (dispatch) => {
    try {
        const response = await fetch(API_URL, {
            method: 'GET',
            headers: {
                'Content-Type': 'application/json',
                'Authorization': `Bearer ${token}`
            }
        }).then(items => items.json())
        dispatch(getUserBalance(response));
    } catch (err) {
        dispatch(logout());
        throw new Error(err);
    }
};

export const { getUserBalance } = userBalanceSlice.actions;
export const showUserBalance = (state) => state.userBalance.data;
export default userBalanceSlice.reducer;