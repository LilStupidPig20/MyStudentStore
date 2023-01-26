import React, {useContext, useEffect, useState} from "react";
import { Link } from "react-router-dom";
import styles from './adminOrder.module.css';
import {useSelector} from "react-redux";
import {showUser} from "../../features/authSlice";

export default function AdminOrder({
                                  id,
                                  fio,
                                  products,
                                  func,
                                  status,
                                  time,
                                  selId,
                                  isHistory,
                                  cancellationComment
                              }) {
    const [isClicked, setClicked] = useState(false);
    const [isRejected, setRejected] = useState(false);
    const [isRetry, setRetry] = useState(false);
    const [isSent, setSent] = useState(false);
    const [isError1, setError1] = useState(false);
    const [comment, setComment] = useState('');
    const [details, setDetails] = useState({});
    const auth = useSelector(showUser);
    let allStatuses = ['В обработке', 'Готов к получению', 'Получен', 'Отменен'];
    let statusRus = '';

    const getOrderDetails = (orderId) => {
        fetch(`/api/admin/orders/getOrderFullInfo/${orderId}`)
            .then(res => res.json())
            .then(item => setDetails(item))
    }

    switch(status) {
        case 0:
            statusRus = 'В обработке';
            break;
        case 1:
            statusRus = 'Готов к получению';
            allStatuses.shift();
            break;
        case 2:
            statusRus = 'Получен';
            break;
        case 3:
            statusRus = 'Отменен';
            break;
        default:
            break;
    }

    const setStatus = () => {
        let opts = document.getElementById(selId);
        let status = opts.options[opts.selectedIndex].value;
        switch(status) {
            case 'В обработке':
                break;
            case 'Готов к получению':
                fetch(`/api/admin/orders/changeOrderStatus`,
                    {
                        method: 'POST',
                        headers: {
                            'Authorization': `Bearer ${auth.token}`,
                            'Content-Type' : 'application/json'
                        },
                        body: JSON.stringify({
                            orderId: id,
                            orderStatus: 1
                        })
                    })
                break;
            case 'Получен':
                fetch(`/api/admin/orders/changeOrderStatus`,
                    {
                        method: 'POST',
                        headers: {
                            'Authorization': `Bearer ${auth.token}`,
                            'Content-Type' : 'application/json'
                        },
                        body: JSON.stringify({
                            orderId: id,
                            orderStatus: 2
                        })
                    })
                break;
            case 'Отменен':
                setRejected(true);
                break;
            default:
                break;
        }
    }

    useEffect(() => {
        if(isClicked) {
            getOrderDetails(id)
        }
    }, [id, isClicked])

    console.log(details)

    // let productsName = '';
    // products.map((prod, index) => {
    //     if(index + 1 !== products.length){
    //         productsName += `${prod.productName}, `;
    //     } else productsName += prod.productName;
    //     return '';
    // })

    return (
        <>
            {isSent === true &&
                <div className={styles.modalLayout}>
                    <div className={styles.modalActive}>
                        <h1 className={styles.modalTitle}>Заказ отменен!</h1>
                        <button
                            type='button'
                            onClick={() => {setSent(false); window.location.reload()}}
                            className={styles.modalButton}
                        >Готово</button>
                    </div>
                </div>
            }
            {isError1 &&
                <div className={styles.modalLayout}>
                    <div className={styles.modalActive}>
                        <h1 className={styles.errorModalTitle}>Ошибка заполнения!</h1>
                        <h2 className={styles.errorModalSubTitle}>Заполните причину снова.</h2>
                        <button
                            type='button'
                            onClick={()=>{
                                setRetry(true);
                                setError1(false);
                            }}
                            className={styles.modalButton}
                        >Повторить</button>
                    </div>
                </div>
            }
            {isRetry &&
                <div className={styles.modalLayout}>
                    <div className={styles.denyActive}>
                        <Link to='/orders' className={styles.close} onClick={() => setRetry(false)}>
                            <svg width="23" height="23" viewBox="0 0 23 22" fill="none" xmlns="http://www.w3.org/2000/svg">
                                <path d="M16.7781 5.30322L6.17147 15.9098" stroke="black" strokeWidth="2.5" strokeLinecap="round" strokeLinejoin="round"/>
                                <path d="M16.7781 15.9102L6.17148 5.30355" stroke="black" strokeWidth="2.5" strokeLinecap="round" strokeLinejoin="round"/>
                            </svg>
                        </Link>
                        <h1 className={styles.denyTitle}>Заказ отклонен по причине:</h1>
                        <textarea
                            placeholder='Текст...'
                            className={styles.infoArea}
                            required
                            onChange={(event) => setComment(event.target.value)}/>
                        <button
                            type='button'
                            onClick={() => {
                                if(cancellationComment !== '') {
                                    fetch(`https://localhost:5001/order/cancelOrderByAdmin?idOrder=${id}&cancellationComment=${comment}`,
                                        {
                                            method: 'POST',
                                            headers: {
                                                'Authorization': `Bearer ${auth.token}`
                                            }
                                        })
                                        .then(response => {
                                            if(response.status === 200) {
                                                setError1(false);
                                                setSent(true);
                                                setRetry(false);
                                            } else {
                                                setError1(true);
                                                setRetry(false);
                                                setRejected(false);
                                            }
                                        })
                                        .catch(error => {
                                            console.log(error);
                                            setError1(true);
                                            setRejected(false);
                                        })
                                }
                                setError1(true);
                            }}
                            className={styles.modalButton}
                        >Отправить</button>
                    </div>
                </div>
            }
            {isRejected &&
                <div className={styles.modalLayout}>
                    <div className={styles.denyActive}>
                        <Link to='/orders' className={styles.close} onClick={() => setRejected(false)}>
                            <svg width="23" height="23" viewBox="0 0 23 22" fill="none" xmlns="http://www.w3.org/2000/svg">
                                <path d="M16.7781 5.30322L6.17147 15.9098" stroke="black" strokeWidth="2.5" strokeLinecap="round" strokeLinejoin="round"/>
                                <path d="M16.7781 15.9102L6.17148 5.30355" stroke="black" strokeWidth="2.5" strokeLinecap="round" strokeLinejoin="round"/>
                            </svg>
                        </Link>
                        <h1 className={styles.denyTitle}>Заказ отклонен по причине:</h1>
                        <textarea
                            placeholder='Текст...'
                            className={styles.infoArea}
                            required
                            onChange={(event) => setComment(event.target.value)}/>
                        <button
                            type='button'
                            onClick={() => {
                                if(cancellationComment !== '') {
                                    fetch(`https://localhost:5001/order/cancelOrderByAdmin?idOrder=${id}&cancellationComment=${comment}`,
                                        {
                                            method: 'POST',
                                            headers: {
                                                'Authorization': `Bearer ${auth.token}`
                                            }
                                        })
                                        .then(response => {
                                            if(response.status === 200) {
                                                setError1(false);
                                                setSent(true);
                                                setRejected(false);
                                            } else {
                                                setError1(true);
                                                setRejected(false);
                                            }
                                        })
                                        .catch(error => {
                                            console.log(error);
                                            setError1(true);
                                            setRejected(false);
                                        })
                                }
                                setError1(true);
                            }}
                            className={styles.modalButton}
                        >Отправить</button>
                    </div>
                </div>
            }
            {isHistory ?
                <>
                    {isClicked ?
                        <>
                            <div className={styles.orderPopup} onClick={() => setClicked(false)}>
                                <div className={styles.orderContainer}>
                                    <Link to='/admin/orders/history' className={styles.close}>
                                        <svg width="23" height="23" viewBox="0 0 23 22" fill="none" xmlns="http://www.w3.org/2000/svg">
                                            <path d="M16.7781 5.30322L6.17147 15.9098" stroke="black" strokeWidth="2.5" strokeLinecap="round" strokeLinejoin="round"/>
                                            <path d="M16.7781 15.9102L6.17148 5.30355" stroke="black" strokeWidth="2.5" strokeLinecap="round" strokeLinejoin="round"/>
                                        </svg>
                                    </Link>
                                    <div className={styles.flexCont}>
                                        <div className={styles.detailsTitle}>Подробности заказа</div>
                                    </div>
                                    <div className={styles.flexCont}>
                                        <div className={styles.orderTitle}>ФИО:</div>
                                        <div className={styles.orderInfo}>{fio}</div>
                                    </div>
                                    <div className={styles.flexCont}>
                                        <div className={styles.orderTitle}>Номер заказа:</div>
                                        <div className={styles.orderInfo}>{id}</div>
                                    </div>
                                    <div className={styles.prodCont}>
                                        <div className={styles.orderTitle}>Заказ:</div>
                                        <div className={styles.orderProducts}>
                                            {details?.orderProducts?.map((prod, index) => {
                                                return <div className={styles.orderProducts} key={index}>
                                                    <div className={styles.prodImg}>
                                                        <img src={prod.imageLink} width='90px' height='120px' alt="Фото товара"/>
                                                    </div>
                                                    <div>
                                                        <div className={styles.prodName}>{prod.name}</div>
                                                        {prod.size !== null && prod.size !== 0 && prod.size &&
                                                            <div className={styles.prodSize}>Размер: {prod.size}</div>
                                                        }
                                                        <div className={styles.prodSize}>Количество: {prod.count}</div>
                                                        <div className={styles.prodPrice}>Цена: {prod.price} б.</div>
                                                    </div>
                                                </div>
                                            })}
                                        </div>
                                    </div>
                                    <div className={styles.flexCont}>
                                        <div className={styles.orderTitle}>Статус:</div>
                                        <div className={styles.orderInfo}>{statusRus}</div>
                                    </div>
                                    <div className={styles.flexCont}>
                                        <div className={styles.orderTitle}>Дата заказа:</div>
                                        <div className={styles.orderInfo}>{details?.purchaseDate?.slice(0,10).split('-').reverse().join('.')}</div>
                                    </div>
                                    {cancellationComment !== null && cancellationComment &&
                                        <div>
                                            <div className={styles.orderTitle}>Причина отказа: <span className={styles.orderInfo}>{cancellationComment}</span></div>

                                        </div>
                                    }
                                </div>
                            </div>
                            <div className={styles.order} onClick={() => {setClicked(true)}}>
                                <div style={{width:'104px'}}>{time.slice(0,10).split('-').reverse().join('.')}</div>
                                <div style={{width:'300px'}}>{fio}</div>
                                <div name='name'></div>
                                <div>{statusRus}</div>
                            </div>
                        </>
                        :
                        <div className={styles.order} onClick={() => {setClicked(true)}}>
                            <div style={{width:'104px'}}>{time.slice(0,10).split('-').reverse().join('.')}</div>
                            <div style={{width:'300px'}}>{fio}</div>
                            <div name='name'>{products}</div>
                            <div>{statusRus}</div>
                        </div>
                    }
                </>
                :
                <>
                    {isClicked ?
                        <>
                            <div className={styles.orderPopup} onClick={() => setClicked(false)}>
                                <div className={styles.orderContainer}>
                                    <Link to='/admin/orders' className={styles.close}>
                                        <svg width="23" height="23" viewBox="0 0 23 22" fill="none" xmlns="http://www.w3.org/2000/svg">
                                            <path d="M16.7781 5.30322L6.17147 15.9098" stroke="black" strokeWidth="2.5" strokeLinecap="round" strokeLinejoin="round"/>
                                            <path d="M16.7781 15.9102L6.17148 5.30355" stroke="black" strokeWidth="2.5" strokeLinecap="round" strokeLinejoin="round"/>
                                        </svg>
                                    </Link>
                                    <div className={styles.flexCont}>
                                        <div className={styles.orderTitle}>ФИО:</div>
                                        <div className={styles.orderInfo}>{fio}</div>
                                    </div>
                                    <div className={styles.flexCont}>
                                        <div className={styles.orderTitle}>Номер заказа:</div>
                                        <div className={styles.orderInfo}>{id}</div>
                                    </div>
                                    <div className={styles.prodCont}>
                                        <div className={styles.orderTitle}>Заказ:</div>
                                        <div className={styles.orderProducts}>
                                            {details?.orderProducts?.map((prod, index) => {
                                                return <div className={styles.orderProducts} key={index}>
                                                    <div className={styles.prodImg}>
                                                        <img src={prod.imageLink} width='90px' height='120px' alt="Фото товара"/>
                                                    </div>
                                                    <div>
                                                        <div className={styles.prodName}>{prod.name}</div>
                                                        {prod.size !== null && prod.size !== 0 && prod.size &&
                                                            <div className={styles.prodSize}>Размер: {prod.size}</div>
                                                        }
                                                        <div className={styles.prodSize}>Количество: {prod.count}</div>
                                                        <div className={styles.prodPrice}>Цена: {prod.price} б.</div>
                                                    </div>
                                                </div>
                                            })}
                                        </div>
                                    </div>
                                    <div className={styles.flexCont}>
                                        <div className={styles.orderTitle}>Статус:</div>
                                        <div className={styles.orderInfo}>{statusRus}</div>
                                    </div>
                                    <div className={styles.flexCont}>
                                        <div className={styles.orderTitle}>Дата заказа:</div>
                                        <div className={styles.orderInfo}>{details?.purchaseDate?.slice(0,10).split('-').reverse().join('.')}</div>
                                    </div>
                                </div>
                            </div>
                            <div className={styles.order}>
                                <div onClick={() => {setClicked(true)}} style={{width:'104px'}}>{time.slice(0,10).split('-').reverse().join('.')}</div>
                                <div onClick={() => {setClicked(true)}} style={{width:'300px'}}>{fio}</div>
                                <div name='name' onClick={() => {setClicked(true)}}>{}</div>
                                <select name='statusess' id={selId} onChange={setStatus} className={styles.orderSelect}>
                                    <option id={statusRus}>{statusRus}</option>
                                </select>
                            </div>
                        </>
                        :
                        <>
                            <div className={styles.order}>
                                <div onClick={() => {setClicked(true)}} style={{width:'104px'}}>{time.slice(0,10).split('-').reverse().join('.')}</div>
                                <div onClick={() => {setClicked(true)}} style={{width:'300px'}}>{fio}</div>
                                <div name='name' onClick={() => {setClicked(true)}}>{products}</div>
                                <select name='statusess' id={selId} onChange={setStatus} className={styles.orderSelect}>
                                    <option id={statusRus}>{statusRus}</option>
                                    {allStatuses.map((st) => {
                                        if (st !== statusRus) {
                                            switch (st) {
                                                case 'В обработке':
                                                    setTimeout(() => {
                                                        let select1 = document.getElementById(selId);
                                                        if (select1 !== null && select1.childElementCount !== allStatuses.length) {
                                                            let opt = document.createElement('option');
                                                            opt.id = st;
                                                            opt.textContent = st;
                                                            select1.append(opt);
                                                        }
                                                    }, 1500)
                                                    break;
                                                case 'Принят':
                                                    setTimeout(() => {
                                                        let select2 = document.getElementById(selId);
                                                        if (select2 !== null && select2.childElementCount !== allStatuses.length) {
                                                            let opt = document.createElement('option');
                                                            opt.id = st;
                                                            opt.textContent = st;
                                                            select2.append(opt);
                                                        }
                                                    }, 1500)
                                                    break;
                                                case 'Готов к получению':
                                                    setTimeout(() => {
                                                        let select3 = document.getElementById(selId);
                                                        if (select3 !== null && select3.childElementCount !== allStatuses.length) {
                                                            let opt = document.createElement('option');
                                                            opt.id = st;
                                                            opt.textContent = st;
                                                            select3.append(opt);
                                                        }
                                                    }, 1500)
                                                    break;
                                                case 'Получен':
                                                    setTimeout(() => {
                                                        let select4 = document.getElementById(selId);
                                                        if (select4 !== null && select4.childElementCount !== allStatuses.length) {
                                                            let opt = document.createElement('option');
                                                            opt.id = st;
                                                            opt.textContent = st;
                                                            select4.append(opt);
                                                        }
                                                    }, 1500)
                                                    break;
                                                case 'Отменен':
                                                    setTimeout(() => {
                                                        let select5 = document.getElementById(selId);
                                                        if (select5 !== null && select5.childElementCount !== allStatuses.length) {
                                                            let opt = document.createElement('option');
                                                            opt.id = st;
                                                            opt.textContent = st;
                                                            select5.append(opt);
                                                        }
                                                    }, 1500)
                                                    break;
                                                default:
                                                    break;
                                            }
                                        }
                                        return '';
                                    })}
                                </select>
                            </div>
                        </>
                    }
                </>
            }
        </>
    );
}