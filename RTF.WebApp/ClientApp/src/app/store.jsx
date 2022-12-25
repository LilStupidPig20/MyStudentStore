import { configureStore } from '@reduxjs/toolkit';
import calendarSlide from "../features/calendarSlice";
import userBalanceSlide from "../features/userBalanceSlice";
import authSlide from "../features/authSlice";
import pageNameSlide from "../features/pageNameSlice";

export const store = configureStore({
    reducer: {
        authData: authSlide,
        calendarInfo : calendarSlide,
        userBalance : userBalanceSlide,
        pageName : pageNameSlide
    },
});