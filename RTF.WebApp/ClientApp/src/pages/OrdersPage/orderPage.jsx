import React, {useEffect} from "react";
import {useDispatch} from "react-redux";
import {setPageName} from "../../features/pageNameSlice";

export const OrderPage = () => {
    const dispatch = useDispatch();
    useEffect(()=> {
        dispatch(setPageName('orders'));
    },[dispatch])
    return (<div>

    </div>)
}