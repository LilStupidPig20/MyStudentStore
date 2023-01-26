import React, { useState, useEffect } from 'react';
import { Link } from 'react-router-dom';
import styles from './orderItem.module.css';
import {useSelector} from "react-redux";
import {showUser} from "../../features/authSlice";

export default function OrderItem({
                                      id,
                                      products,
                                      status,
                                      totalPrice,
                                      date
                                  }) {
    const [isCancelable, setIsCancelable] = useState(() => {
        if (status === 0 || status === 1) {
            return true;
        } else {
            return false;
        }
    });
    const [cancellationComment, setCancellationComment] = useState('');
    const [cancelFlag, setCancelFlag] = useState(false);
    const [alertFlag, setAlertFlag] = useState(false);
    const [statusText, setStatusText] = useState('');
    const token = useSelector(showUser).token;

    let counter = 0;
    let count = 0;

    const setStates = (status) => {
        if (status === 0) {
            return 'В обработке';
        }
        if (status === 3) {
            return 'Отменен';
        }
        if (status === 2) {
            return 'Принят';
        }
        if (status === 1) {
            return 'Готов к получению';
        }
    };

    useEffect(() => {

        setStatusText(setStates(status));
    }, []);

    const cancelOrder = (orderId, cancellationComment) => {
        const auth = JSON.parse(localStorage.getItem('userData'));
        const body = {
            cancellationComment: cancellationComment
        };
        fetch('/api/store/CancelOrder',
            {
                method: 'POST',
                headers: {
                    "Authorization": `Bearer ${token}`,
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify({
                    orderId: orderId,
                    cancellationComment: cancellationComment
                })
            })
            .then(res => {
                console.log(res.status)
                setCancelFlag(false);
                setAlertFlag(true);
                setCancellationComment('');
                setStatusText('Отменен');
                setIsCancelable(false);
            })
            .catch(error => console.log(error))
    };

    const onChangeMessageInput = (e) => {
        setCancellationComment(e.target.value);
    }

    return (
        <>

            {/*<h2 className={styles.date}>Дата заказа: {date}</h2>*/}
            <div className={styles.wrapper}>
                <div className={styles.headerBlock}>
                    <h2>Номер заказа #{id}</h2>
                    <h2>Сумма заказа: {totalPrice} баллов</h2>
                </div>
                <div style={{display: 'flex', flexDirection: 'row'}}>
                    {
                        products.map((product) => {
                            if (counter < 4) {
                                counter += 1;
                                return (
                                    <div className={styles.productItem} key={product.productId}>
                                        <img src={product.imageUrl} width={137} height={187} alt="" />
                                        <p className={styles.title}>{product.name}</p>
                                        {
                                            product.size !== null && product.size !== 0
                                                ?
                                                <p className={styles.count}>Размер: {product.size}</p>
                                                :
                                                null
                                        }
                                        <p className={styles.count}>Кол-во {product.count} шт.</p>
                                        <p className={styles.price}>Цена: {product.price} б.</p>
                                    </div>
                                )
                            }

                        })
                    }
                    <div className={styles.statusBlock}>
                        <p className={styles.status}>{statusText}</p>
                        {
                            isCancelable
                                ?
                                <p className={styles.cancelButton} onClick={() => {
                                    setCancelFlag(true);
                                }}>Отменить заказ</p>
                                :
                                null
                        }
                    </div>
                </div>
            </div>

            {
                cancelFlag
                    ?
                    <div className={styles.popup} onClick={() => {
                        setCancelFlag(false);
                        setCancellationComment('');
                    }}>
                        <div className={styles.container} onClick={(e) => e.stopPropagation()}>
                            <Link to='/user/orders' className={styles.close} onClick={()=> setCancelFlag(false)}>
                                <svg width="23" height="23" viewBox="0 0 23 22" fill="none" xmlns="http://www.w3.org/2000/svg">
                                    <path d="M16.7781 5.30322L6.17147 15.9098" stroke="black" strokeWidth="2.5" strokeLinecap="round" strokeLinejoin="round"/>
                                    <path d="M16.7781 15.9102L6.17148 5.30355" stroke="black" strokeWidth="2.5" strokeLinecap="round" strokeLinejoin="round"/>
                                </svg>
                            </Link>
                            <h1>Отмена заказа</h1>
                            <h2>Номер заказа #{id}</h2>
                            <div style={{ display: 'flex' }}>
                                {
                                    products.map(product => {
                                        return (
                                            <div className={styles.productItem} key={product.productId}>
                                                <img src={product.imageUrl} width={137} height={187} alt="" />
                                                <p className={styles.title}>{product.name}</p>
                                                {
                                                    product.size !== null && product.size !== 0
                                                        ?
                                                        <p className={styles.count}>Размер: {product.size}</p>
                                                        :
                                                        null
                                                }
                                                <p className={styles.count}>Кол-во {product.count} шт.</p>
                                                <p className={styles.price}>Цена: {product.price * product.count} б.</p>
                                            </div>
                                        )
                                    })
                                }
                            </div>

                            <h2>Сумма заказа: {totalPrice} б.</h2>
                            <p>Вы действительно хотите отменить заказ?</p>
                            <div>
                                <textarea
                                    className={styles.cancelInput}
                                    placeholder='Укажите причину отмены... (необязательно)'
                                    value={cancellationComment}
                                    onChange={onChangeMessageInput} />
                            </div>
                            <div className={styles.buttonContainer}>
                                <button className={styles.popupButton} onClick={() => cancelOrder(id, cancellationComment)}>Готово</button>
                            </div>
                        </div>
                    </div>
                    :
                    null
            }
            {
                alertFlag
                    ?
                    <div className={styles.popup} onClick={() => {
                        setAlertFlag(false);
                    }}>
                        <div className={styles.container} onClick={(e) => e.stopPropagation()}>
                            <h1>Заказ отменен</h1>
                            <h3>Будем ждать новых заказов!</h3>
                            <div className={styles.buttonContainer}>
                                <button className={styles.popupButton} onClick={() => setAlertFlag(false)}>Готово</button>
                            </div>
                        </div>
                    </div>
                    :
                    null
            }
        </>
    );
}