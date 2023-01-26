import React, {useEffect, useState} from "react";
import {useDispatch, useSelector} from "react-redux";
import {setPageName} from "../../features/pageNameSlice";
import OrderItem from "../../components/OrderItem/orderItem";
import {showUser} from "../../features/authSlice";
import './orderPage.scss';
import right_back from "../../images/shop/back-img.png";
import {ShopLayout} from "../../components/Layouts/ShopLayout/shopLayout";

export const OrderPage = () => {
    const dispatch = useDispatch();
    const [orders, setOrders] = useState([]);
    const auth = useSelector(showUser);

    useEffect(()=> {
        dispatch(setPageName('orders'));
    },[dispatch])

    console.log(orders);

    useEffect(() => {
        fetch('/api/store/getOrders',
            {
                headers: {
                    "Authorization": `Bearer ${auth.token}`
                }
            })
            .then(res => res.json())
            .then(orders => {
                setOrders(orders.reverse());
            })
            .catch(error => console.log(error))
    }, [])
    return (
            <div className='wrapper'>
                <ShopLayout/>
                <h1 className='orders_title'>Мои заказы</h1>
                <div className='container'>
                    {
                        orders.map((order) => {
                            let count = 0;
                            for(let elem of order.orderProducts) {
                                count += elem.price;
                            }
                            console.log(order);
                            return <OrderItem
                                key={order.orderId}
                                id={order.orderId}
                                products={order.orderProducts}
                                status={order.status}
                                totalPrice={count}
                            />
                        })
                    }
                </div>
        </div>)
}