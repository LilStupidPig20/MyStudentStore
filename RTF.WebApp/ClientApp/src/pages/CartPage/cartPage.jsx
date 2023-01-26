import React, {useEffect, useState} from 'react';
import styles from './cartPage.module.css';
import CartItem from "../../components/CartItem/cartItem";
import right_back from "../../images/shop/back-img.png";
import {Link} from "react-router-dom";
import {useDispatch, useSelector} from "react-redux";
import {showUserBalance} from "../../features/userBalanceSlice";
import {showUser} from "../../features/authSlice";
import {getCart, showCartInfo} from "../../features/cartSlice";
import {ShopLayout} from "../../components/Layouts/ShopLayout/shopLayout";
import OrderAnswer from "../../components/OrderAnswer/orderAnswer";

export default function CartPage() {
    const balance = useSelector(showUserBalance);
    const dispatch = useDispatch();
    const cart = useSelector(showCartInfo);
    const [itemsIds, setItemsIds] = useState([]);
    const [itemsCount, setItemsCount] = useState(0);
    const token = useSelector(showUser).token;
    let [ordered, setOrdered] = useState(false);

    useEffect(() => {
        dispatch(getCart(token))
    }, [dispatch])

    useEffect(() => {
        let count = 0;
        if(cart.basketProducts !== null && cart.basketProducts !== undefined) {
            cart?.basketProducts.map((item) => {
                return count += item.count
            })
        }
        setItemsCount(count);
    }, [cart])

    console.log(cart);

    const makeAnOrder = () => {
        fetch('/api/store/makeAnOrder', {
            method: "POST",
            headers: {
                'Content-Type': 'application/json',
                'Authorization': `Bearer ${token}`
            },
            body: JSON.stringify({
                basketProductsIds: itemsIds
            })
        }).then(res => res.status === 200 ? setOrdered(true) : '')
    }

    useEffect(() => {
        let ids = [];
        if(cart.basketProducts !== null && cart.basketProducts !== undefined) {
            cart.basketProducts.map((item) => {
                ids.push(item.basketProductId)
            })
        }
        setItemsIds(ids);
        console.log(ids)
    }, [cart.basketProducts])

    return (
        <div style={{marginRight: '100px', paddingRight: '125px', paddingLeft: '125px'}}>
            <img className='shopPage__back-img' src={right_back} alt='' />
            <ShopLayout />
            {
            cart?.totalPrice === 0
            ?
            <div className={styles.emptyCart}>
                <div className={styles.title}>В корзине пока ничего нет</div>
                <p className={styles.subTitle}>Перейдите в <Link to='/shop' className={styles.link}>магазин</Link>, чтобы купить мерч</p>
            </div>
            :
            <div className={styles.wrapper}>
                <div className={styles.cartItems}>
                    <div className={styles.header}>
                        <span className={styles.headerTitle}>Ваша корзина</span>
                        <span className={styles.small_counter}>всего: {cart?.basketProducts?.length}</span>
                    </div>
                    <div>
                        {cart?.basketProducts?.map((product, index) => {
                            return <CartItem
                                img={product.imageUrl}
                                key={index}
                                title={product.name}
                                description={product.description}
                                price={product.productPrice}
                                storeId={product.storeProductId}
                                basketId={product.basketProductId}
                                count={product.count}
                                size={product.size} />
                        })}
                    </div>
                </div>
                <div className={styles.summaryBlock}>
                    <div>
                        <div className={styles.header}>
                            <span className={styles.headerTitle}>Итого</span>
                            <span className={styles.sumCoins}>{cart?.totalPrice} баллов</span>
                        </div>
                        <p className={styles.counter}>Товары, {itemsCount} шт.</p>
                    </div>

                    <div className={styles.bottomBlock}>
                        <div className={styles.balance}>Ваш баланс: {balance} баллов</div>
                        <button className={styles.addButton} onClick={makeAnOrder}>Оплатить</button>
                    </div>
                </div>
            </div>

            }
            {
                ordered
                    ?
                    <OrderAnswer
                        setActive={setOrdered}
                        products={cart.basketProducts}
                        sumPrice={cart.totalPrice}
                    />
                    :
                    null
            }
        </div>
    );
}