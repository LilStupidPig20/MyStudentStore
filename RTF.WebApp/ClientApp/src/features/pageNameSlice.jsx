import {createSlice} from "@reduxjs/toolkit";

const localData = localStorage.getItem('page');

export const pageNameSlice = createSlice({
    name: 'pageName',
    initialState: {
        name: localData || null,
    },
    reducers: {
        setName: (state, action) => {
            state.name = action.payload;
        },
        deletePageName: (state) => {
            state.name = null;
            localStorage.removeItem('page');
        }
    }
})

export const setPageName = (name) => async (dispatch) => {
    localStorage.setItem('page', name);
    dispatch(setName(name));
}

export const { setName, deletePageName } = pageNameSlice.actions;
export const showPageName = (state) => state.pageName.name;
export default pageNameSlice.reducer;