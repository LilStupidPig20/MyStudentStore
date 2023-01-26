import React from 'react';
import styles from './cartItem.module.css'
import {useDispatch, useSelector} from "react-redux";
import {showUser} from "../../features/authSlice";
import {useNavigate} from "react-router-dom";
import {getCart} from "../../features/cartSlice";

export default function CartItem({
                                     img,
                                     title,
                                     description,
                                     price,
                                     count,
                                     storeId,
                                     basketId,
                                     size,
                                 }) {
    // let [countIn, setCountIn] = useState(0);
    const token = useSelector(showUser).token;
    const navigate = useNavigate();
    const dispatch = useDispatch();
    const sizesObj = {
        0: 'XsSize',
        1: 'SSize',
        2: 'MSize',
        3: 'LSize',
        4: 'XlSize',
        5: 'XllSize'
    }
    // useEffect(() => {
    //     setCountIn(count);
    // }, [count])

    const deleteItem = () => {
        fetch('/api/basket/remove', {
            method: 'POST',
            headers: {
                'Authorization': `Bearer ${token}`,
                'Content-Type' : 'application/json'
            },
            body: JSON.stringify({productId: storeId, size: size})
        })
        setTimeout(()=>{
            dispatch(getCart(token))
        },200)
    }

    const decrementCount = () => {
        fetch('/api/basket/decrementProductCount', {
            method: 'POST',
            headers: {
                'Authorization': `Bearer ${token}`,
                'Content-Type' : 'application/json'
            },
            body: JSON.stringify({basketProductId: basketId})
        })
        setTimeout(()=>{
            dispatch(getCart(token))
        },200)
    }

    const incrementCount = () => {
        fetch('/api/basket/incrementProductCount', {
            method: 'POST',
            headers: {
                'Authorization': `Bearer ${token}`,
                'Content-Type' : 'application/json'
            },
            body: JSON.stringify({basketProductId: basketId})
        })
        setTimeout(()=>{
            dispatch(getCart(token))
        },200)
    }

    return (
        <div className={styles.wrapper}>
            <div className={styles.container}>
                <img src={img} alt="Product" width={137} height={187} />
                <div className={styles.subBlock}>
                    <span className={styles.title}>{title}</span>
                    <div className={styles.countBlock}>
                        <div className={styles.countButton} onClick={decrementCount}>
                            <svg width="20" height="20" viewBox="0 0 20 20" fill="none" xmlns="http://www.w3.org/2000/svg">
                                <rect x="0.2" y="0.2" width="19.6" height="19.6" rx="9.8" stroke="black" strokeWidth="0.4"/>
                                <path d="M6 10L14 10" stroke="black" strokeWidth="0.6"/>
                            </svg>
                        </div>
                        <p>{count}</p>
                        <div className={styles.countButton} onClick={incrementCount}>
                            <svg width="20" height="20" viewBox="0 0 20 20" fill="none" xmlns="http://www.w3.org/2000/svg">
                                <rect x="0.2" y="0.2" width="19.6" height="19.6" rx="9.8" stroke="black" strokeWidth="0.4"/>
                                <path d="M10 6V14" stroke="black" strokeWidth="0.6"/>
                                <path d="M6 10L14 10" stroke="black" strokeWidth="0.6"/>
                            </svg>
                        </div>
                    </div>
                    {
                        size !== null && size !== 0
                            ?
                            <p className={styles.size}>Размер: {sizesObj[size].slice(0,-4)}</p>
                            :
                            null
                    }
                    <span className={styles.price}>{price * count} баллов</span>

                </div>
            </div>
            <div className={styles.garbage} onClick={deleteItem}>
                <svg width="24" height="24" viewBox="0 0 24 24" fill="none" xmlns="http://www.w3.org/2000/svg">
                    <path d="M6 7V18C6 18.5304 6.21071 19.0391 6.58579 19.4142C6.96086 19.7893 7.46957 20 8 20H16C16.5304 20 17.0391 19.7893 17.4142 19.4142C17.7893 19.0391 18 18.5304 18 18V7M9 7C9 6.20435 9.31607 5.44129 9.87868 4.87868C10.4413 4.31607 11.2044 4 12 4V4C12.7956 4 13.5587 4.31607 14.1213 4.87868C14.6839 5.44129 15 6.20435 15 7V7H9ZM9 7H15H9ZM9 7H6H9ZM15 7H18H15ZM20 7H18H20ZM4 7H6H4Z" stroke="black" strokeWidth="2" strokeLinecap="round" strokeLinejoin="round"/>
                </svg>
            </div>
        </div>
    );
}