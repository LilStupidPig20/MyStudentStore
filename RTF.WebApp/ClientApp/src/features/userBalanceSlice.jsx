import {createSlice} from "@reduxjs/toolkit";

const API_URL = '/api/userBalance/getCurrentUserBalance';

export const userBalanceSlide = createSlice({
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
        throw new Error(err);
    }
};

export const { getUserBalance } = userBalanceSlide.actions;
export const showUserBalance = (state) => state.userBalance.data;
export default userBalanceSlide.reducer;