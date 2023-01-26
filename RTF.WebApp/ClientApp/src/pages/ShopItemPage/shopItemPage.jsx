import {Link, useParams} from "react-router-dom";
import React, {useEffect, useState} from "react";
import styles from './shopItemPage.module.scss';
import {useDispatch, useSelector} from "react-redux";
import {showUser} from "../../features/authSlice";
import {ShopLayout} from "../../components/Layouts/ShopLayout/shopLayout";
import OrderAnswer from "../../components/OrderAnswer/orderAnswer";
import {getUserBalanceAsync} from "../../features/userBalanceSlice";

export const ShopItemPage = () => {
    const { itemId } = useParams();
    const authData = useSelector(showUser);
    const dispatch = useDispatch();
    const [itemInfo, setItemInfo] = useState({});
    const [inCart, setInCart] = useState(false);
    const [bought, setBought] = useState(false);
    const [selectedSize, setSelectedSize] = useState(0);
    const [sizes, setSizes] = useState([]);
    const sizesObj = {
        XsSize : 0,
        SSize : 1,
        MSize : 2,
        LSize : 3,
        XlSize : 4,
        XllSize : 5
    }
    useEffect(() => {
        fetch(`/api/store/getProductFullInfo/${itemId}`)
            .then(res => res.json())
            .then(items => setItemInfo(items))
    },[])

    console.log(itemInfo)
    console.log(selectedSize);

    useEffect(() => {
        const arr = document.getElementsByClassName('sizeButton');
        for(let elem of arr) {
            console.log(elem);
        }
    } ,
    [selectedSize])

    useEffect(() => {
        if(itemInfo.sizesToAvailable !== null && itemInfo.sizesToAvailable !== undefined) {
            setSizes(Object.entries(itemInfo.sizesToAvailable))
        }

        console.log(sizes);
    }, [itemInfo])

    const addToCart = () => {
        fetch('/api/basket/add', {
            method: "POST",
            headers: {
                'Content-Type': 'application/json',
                'Authorization': `Bearer ${authData.token}`
            },
            body: JSON.stringify({
                productId: itemId,
                count: 1,
                size: selectedSize
            })
        }).then(res => res.status === 200 ? setInCart(true) : '')
    }

    const makeInOneClickOrder = async () => {
        fetch('/api/store/makeOrderRightNow', {
            method: "POST",
            headers: {
                'Content-Type': 'application/json',
                'Authorization': `Bearer ${authData.token}`
            },
            body: JSON.stringify({
                storeProductId: itemId,
                count: 1,
                size: selectedSize
            })
        }).then(res => res.status === 200 ? setBought(true) : '')
        dispatch(getUserBalanceAsync(authData.token))
    }

    return (
        <div style={{marginRight: '100px', paddingRight: '125px', paddingLeft: '125px'}}>
            <ShopLayout />
            <div className={styles.wrapper}>
                <div>
                    <img src={itemInfo?.image} width={'333px'} alt="" />
                </div>
                <div className={styles.productInfo}>
                    <div className={styles.mainBlock}>
                        <h2 className={styles.productTitle}>{itemInfo?.name}</h2>
                        <p className={styles.price}>{itemInfo?.price} б</p>
                        {
                            itemInfo?.sizesToAvailable !== null && itemInfo?.sizesToAvailable !== undefined
                                ?
                                <div>
                                    <h3>Размер</h3>
                                    <div className={styles.buttonsBlock}>
                                        {
                                            sizes?.map((el, index) => {
                                                if (el[1]) {
                                                    return (
                                                        <button key={index}
                                                                    name="sizeButton"
                                                                    className={styles.sizeButton}
                                                                    // style={{
                                                                    //     backgroundColor: isActive ? 'salmon' : '',
                                                                    //     color: isActive ? 'white' : '',
                                                                    // }}
                                                                    onClick={() => { setSelectedSize(sizesObj[el[0]])}}
                                                        >{el[0].slice(0,-4)}
                                                        </button>
                                                    );
                                                }
                                                else {
                                                    return (
                                                        <button key={index}
                                                                className={styles.disButton}
                                                                disabled
                                                        >{el[0].slice(0,-4)}
                                                        </button>
                                                    );
                                                }
                                            })
                                        }
                                    </div>

                                </div>
                                :
                                null
                        }
                        {window.location.pathname.includes('/admin/shop') ? ''
                            :
                            <div className={styles.actionButtons}>
                                <button className={styles.addButton} onClick={addToCart}>
                                    В корзину
                                </button>

                                <button className={styles.buyButton} onClick={makeInOneClickOrder}>
                                    Купить сейчас
                                </button>
                            </div>
                        }

                    </div>
                    <div className={styles.mainBlock}>
                        <div className={styles.descr}>
                            {itemInfo?.description}
                        </div>
                    </div>
                </div>
            </div>

            {
                inCart
                    ?
                    <div className={styles.popup} onClick={() => setInCart(false)}>
                        <div className={styles.container} onClick={(e) => e.stopPropagation()}>
                            <h1 className={styles.title}>Товар успешно добавлен в корзину!</h1>

                            <div className={styles.buttonContainer}>
                                <button className={styles.popupButton} onClick={() => setInCart(false)}>Готово</button>
                            </div>
                        </div>
                    </div>
                    :
                    null
            }
            {
                bought
                    ?
                    <OrderAnswer
                        setActive={setBought}
                        products={[{
                            img: itemInfo.image,
                            title: itemInfo.name,
                            count: 1,
                            price: itemInfo.price
                        }]}
                        // orderID={orderId}
                        sumPrice={itemInfo.price}
                    />
                    :
                    null
            }
        </div>
    );
}