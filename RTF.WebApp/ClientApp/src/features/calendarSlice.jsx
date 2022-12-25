import {createSlice} from "@reduxjs/toolkit";

const API_URL = '/api/events/getCalendarInfo/';

export const calendarSlice = createSlice({
    name: 'calendarInfo',
    initialState: {
        data: {}
    },
    reducers: {
        getCalendarInfo: (state, action) => {
            state.data = action.payload;
        }
    }
})

export const getCalendarInfoAsync = (today, token) => async (dispatch) => {
    try {
        const response = await fetch(`${API_URL}/${today}`, {
            method: 'GET',
            headers: {
                'Content-Type': 'application/json',
                'Authorization': `Bearer ${token}`
            }
        }).then(items => items.json())
        dispatch(getCalendarInfo(response));
    } catch (err) {
        throw new Error(err);
    }
};

export const { getCalendarInfo } = calendarSlice.actions;
export const showCalendarInfo = (state) => state.calendarInfo.data;
export default calendarSlice.reducer;