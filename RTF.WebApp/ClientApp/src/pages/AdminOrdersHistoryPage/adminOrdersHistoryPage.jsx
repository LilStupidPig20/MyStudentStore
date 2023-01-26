import styles from './adminOrdersHistoryPage.module.css';
import React, {useEffect, useState} from "react";
import {useDispatch, useSelector} from "react-redux";
import {showUser} from "../../features/authSlice";
import AdminOrder from "../../components/AdminOrder/adminOrder";
import profile_top from "../../images/profile/profile-top.svg";
import {setPageName} from "../../features/pageNameSlice";

export const AdminOrdersHistoryPage = () => {
    const [ordersHistory, setOrdersHistory] = useState([]);
    const token = useSelector(showUser).token;
    const dispatch = useDispatch();
    useEffect(()=> {
        dispatch(setPageName('ordersHistory'));
    },[dispatch])
    useEffect(() => {
        fetch('/api/admin/orders/getAllClosedOrders',
            {
                headers: {
                    'Authorization': `Bearer ${token}`
                }
            })
            .then(res => res.json())
            .then(items => setOrdersHistory(items))
    }, []);

    return (
        <div className={styles.wrapper}>
            <img className='profile__pic-top' src={profile_top} alt='' style={{marginTop: '-50px'}}/>
            <div className={styles.align}>
                <div className={styles.ordersWindow}>
                    <h1 className={styles.title}>История заказов</h1>
                    <div className={styles.ordersTitle}>
                        <div>Дата заказа</div>
                        <div>ФИО</div>
                        <div>Заказ</div>
                        <div>Статус</div>
                    </div>
                    <div className={styles.orders}>
                        {ordersHistory.map((ord) => {
                            return <AdminOrder
                                key={ord.orderId}
                                id={ord.orderId}
                                fio={ord.studentFullName}
                                products={ord.orderProducts}
                                status={ord.status}
                                time={ord.timeOfOrder}
                                isHistory={true}
                                cancellationComment={ord.cancellationComment}
                            />
                        })}
                    </div>
                </div>
            </div>
        </div>
    )
}