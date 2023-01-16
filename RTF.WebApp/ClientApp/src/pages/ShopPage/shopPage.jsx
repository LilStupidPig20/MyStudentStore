import React, {memo, useEffect, useState} from 'react';
import { Link } from 'react-router-dom';
import { ProductItem } from '../../components/ProductItem/productItem';
import './shopPage.scss';
import right_back from '../../images/shop/back-img.png'
import {useDispatch} from "react-redux";
import {setPageName} from "../../features/pageNameSlice";

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
            <img className='shopPage__back-img' src={right_back} alt='' />
            <div className='shopPage__wrapper'>
            <div className='shopPage__navbar'>
                <div className='shopPage__navbar__logo'>Магазин</div>
                <div className='shopPage__navbar__right-cont'>
                    <Link to="/cart" style={{ textDecoration: 'none' }}>
                        <div className='shopPage__navbar__cart'>
                            <svg className='shopPage__navbar__cart-img' width="26" height="25" viewBox="0 0 26 25" fill="none" xmlns="http://www.w3.org/2000/svg">
                                <path d="M4.75 6.25H21.9875C22.3368 6.25001 22.6822 6.32321 23.0014 6.46488C23.3207 6.60655 23.6067 6.81354 23.8411 7.07252C24.0754 7.33149 24.2529 7.6367 24.3621 7.96847C24.4713 8.30024 24.5098 8.65121 24.475 8.99875L23.725 16.4988C23.6633 17.1156 23.3746 17.6876 22.915 18.1036C22.4553 18.5196 21.8575 18.75 21.2375 18.75H9.3C8.72184 18.7502 8.16147 18.5501 7.71431 18.1836C7.26714 17.8171 6.96082 17.3069 6.8475 16.74L4.75 6.25Z" stroke="black" strokeWidth="2" strokeLinejoin="round"/>
                                <path d="M18.5 23.75H21M4.75 6.25L3.7375 2.19625C3.66979 1.92594 3.51369 1.68601 3.29401 1.51457C3.07433 1.34313 2.80366 1.25001 2.525 1.25H1L4.75 6.25ZM8.5 23.75H11H8.5Z" stroke="black" strokeWidth="2" strokeLinecap="round" strokeLinejoin="round"/>
                            </svg>
                            <span>Корзина</span>
                            {
                                <div className='shopPage__navbar__cart-amount'>3</div>
                            }
                        </div>
                    </Link>

                    <Link to="/myOrders" style={{ textDecoration: 'none' }}>
                        <div className='shopPage__navbar__orders'>
                            <svg className='shopPage__navbar__orders-img' width="25" height="27" viewBox="0 0 25 27" fill="none" xmlns="http://www.w3.org/2000/svg">
                                <path d="M2.01176 10.8C2.06204 10.1735 2.34646 9.58894 2.80836 9.16271C3.27026 8.73648 3.87575 8.49987 4.50426 8.5H19.5768C20.2053 8.49987 20.8108 8.73648 21.2727 9.16271C21.7346 9.58894 22.019 10.1735 22.0693 10.8L23.073 23.3C23.1006 23.644 23.0567 23.99 22.9441 24.3162C22.8314 24.6423 22.6524 24.9417 22.4184 25.1953C22.1844 25.4489 21.9004 25.6514 21.5843 25.7899C21.2682 25.9283 20.9269 25.9999 20.5818 26H3.49926C3.15417 25.9999 2.81283 25.9283 2.49674 25.7899C2.18065 25.6514 1.89665 25.4489 1.66263 25.1953C1.42861 24.9417 1.24964 24.6423 1.13698 24.3162C1.02431 23.99 0.980405 23.644 1.00801 23.3L2.01176 10.8V10.8Z" stroke="black" strokeWidth="2" strokeLinecap="round" strokeLinejoin="round"/>
                                <path d="M17.0405 12.25V6C17.0405 4.67392 16.5137 3.40215 15.5761 2.46447C14.6384 1.52678 13.3666 1 12.0405 1C10.7144 1 9.44268 1.52678 8.50499 2.46447C7.56731 3.40215 7.04053 4.67392 7.04053 6V12.25" stroke="black" strokeWidth="2" strokeLinecap="round" strokeLinejoin="round"/>
                            </svg>
                            <span>Мои заказы</span>
                        </div>
                    </Link>
                </div>
            </div>
            
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
        </div>
    )
})