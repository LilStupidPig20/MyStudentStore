import { configureStore } from '@reduxjs/toolkit';
import calendarSlice from "../features/calendarSlice";
import userBalanceSlice from "../features/userBalanceSlice";
import authSlice from "../features/authSlice";
import pageNameSlice from "../features/pageNameSlice";
import eventsSlice from "../features/eventsSlice";
import cartSlice from "../features/cartSlice";

export const store = configureStore({
    reducer: {
        authData: authSlice,
        calendarInfo : calendarSlice,
        userBalance : userBalanceSlice,
        pageName : pageNameSlice,
        eventsInfo : eventsSlice,
        cart: cartSlice,
    },
});