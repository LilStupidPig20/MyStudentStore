import React, {memo, useEffect, useState} from 'react';
import { ProductItem } from '../../components/ProductItem/productItem';
import './shopPage.scss';
import {useDispatch} from "react-redux";
import {setPageName} from "../../features/pageNameSlice";
import {ShopLayout} from "../../components/Layouts/ShopLayout/shopLayout";

export const ShopPage = memo(() => {
    const dispatch = useDispatch();
    const [shopItems, setShopItems] = useState([]);
    useEffect(()=> {
        dispatch(setPageName('shop'));
    },[dispatch])

    useEffect(() => {
        fetch('/api/store/getAllProducts')
            .then(res => res.json())
            .then(items => setShopItems(items))
    }, [])

    return (
        <div className='shopPage'>
            <ShopLayout />
            <div className='shopPage__search-cont'>
                <input className='shopPage__search-input' type="text" placeholder="Поиск" />
                <svg className='shopPage__search-logo' width="21" height="25" viewBox="0 0 21 25" fill="none" xmlns="http://www.w3.org/2000/svg">
                    <path d="M15.9129 8.27994C15.9129 12.3489 12.744 15.5849 8.91052 15.5849C5.07708 15.5849 1.9081 12.3489 1.9081 8.27994C1.9081 4.21101 5.07708 0.974993 8.91052 0.974993C12.744 0.974993 15.9129 4.21101 15.9129 8.27994Z" stroke="#15B6E9" strokeWidth="1.94999"/>
                    <path d="M13.4199 14.3999L20.01 23.3998" stroke="#15B6E9" strokeWidth="1.94999" strokeLinecap="round"/>
                </svg>
            </div>
                <div className='shopPage__products'>
                    {shopItems?.map((item, index) => {
                        return (
                            <ProductItem
                                key={index}
                                id={item.id}
                                title={item.name}
                                imgSrc={item.image}
                                price={item.price}
                                availability={item.notAvailable}
                            />
                        )
                    })}
                </div>
        </div>
    )
})