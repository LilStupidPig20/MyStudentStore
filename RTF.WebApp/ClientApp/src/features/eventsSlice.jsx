import {createSlice} from "@reduxjs/toolkit";

const API_URL = '/api/events/getEventsByDateInterval';

export const eventsSlice = createSlice({
    name: 'eventsInfo',
    initialState: {
        data: []
    },
    reducers: {
        getEvents: (state, action) => {
            state.data = action.payload;
        }
    }
})

export const getEventsAsync = (firstDay, lastDay) => async (dispatch) => {
    try {
        const response = await fetch(API_URL, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                "startDateTime" : String(firstDay.toISOString()).slice(0,-13).concat('00:00:00'),
                "endDateTime" : String(lastDay.toISOString()).slice(0,-13).concat('23:59:59')
            })
        }).then(items => items.json())
        dispatch(getEvents(response));
    } catch (err) {
        throw new Error(err);
    }
};

export const { getEvents } = eventsSlice.actions;
export const showEventsInfo = (state) => state.eventsInfo.data;
export default eventsSlice.reducer;