import {createSlice} from "@reduxjs/toolkit";

const API_URL = '/api/basket/get';

export const cartSlice = createSlice({
    name: 'cart',
    initialState: {
        data: []
    },
    reducers: {
        getCartsInfo: (state, action) => {
            state.data = action.payload;
        }
    }
})

export const getCart = (token) => async (dispatch) => {
    try {
        const response = await fetch(API_URL, {
            method: 'GET',
            headers: {
                'Content-Type': 'application/json',
                'Authorization': `Bearer ${token}`
            }
        }).then(items => items.json())
        dispatch(getCartsInfo(response));
    } catch (err) {
        throw new Error(err);
    }
};

export const { getCartsInfo } = cartSlice.actions;
export const showCartInfo = (state) => state.cart.data;
export default cartSlice.reducer;