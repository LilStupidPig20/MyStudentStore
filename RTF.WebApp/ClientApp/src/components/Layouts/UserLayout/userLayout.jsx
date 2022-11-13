import React from 'react';
import './userLayout.scss';
import logo from '../../../images/main/logo.png'
import {Link} from "react-router-dom";

export const UserLayout = ({children}) => {
    return (
        <div className='user-layout'>
            <aside className='user-layout__side-menu'>
                <div className='user-layout__logo-cont'>
                    <div className='user-layout__logo'>
                        <img src={logo} width='88' alt='Логотип магазина'/>
                    </div>
                    <span className='user-layout__shop-name'>My<br/>Student Store</span>
                </div>
                <div className='user-layout__user'>
                    <div className='user-layout__user-logo'>Д</div>
                    <span className='user-layout__user-name'>Александр<br/>Иванов</span>
                </div>
                <div className='user-layout__balance'>
                    <div className='user-layout__balance-name'>Баланс</div>
                    <div className='user-layout__balance-count'>7 баллов</div>
                </div>
                <div className='user-layout__links'>
                    <Link to='/profile' className='user-layout__links-link'>Мой профиль</Link>
                    <Link to='/shop' className='user-layout__links-link'>Магазин</Link>
                    <Link to='/profile' className='user-layout__links-link'>Календарь мероприятий</Link>
                    <Link to='/profile' className='user-layout__links-link'>Мои заказы</Link>
                    <Link to='/profile' className='user-layout__links-link'>Правила начисления баллов</Link>
                </div>
                <div className='user-layout__exit'>Выйти</div>
            </aside>
            {children}
        </div>
    )
}