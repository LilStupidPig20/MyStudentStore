import './adminLayout.scss';
import React from "react";
import logo from "../../../images/main/logo.png";
import {Link} from "react-router-dom";
import {useDispatch, useSelector} from "react-redux";
import {logout, showUser} from "../../../features/authSlice";
import {deletePageName, showPageName} from "../../../features/pageNameSlice";

export const AdminLayout = ({children}) => {
    const pageName = useSelector(showPageName);
    const dispatch = useDispatch();
    const userData = useSelector(showUser);

    return (
        <div className='admin-layout'>
            <aside className='admin-layout__side-menu'>
                <div className='admin-layout__side-menu-cont'>
                    <div className='admin-layout__logo-cont'>
                        <div className='admin-layout__logo'>
                            <img src={logo} width='88' alt='Логотип магазина'/>
                        </div>
                        <span className='admin-layout__shop-name'>My<br/>Student Store</span>
                    </div>
                    <div className='admin-layout__admin-name'>
                        Организатор
                    </div>
                </div>
                <div className='admin-layout__links'>
                    <Link to='/admin/calendar' className={pageName === 'calendar' ? 'admin-layout__links-link active' : 'admin-layout__links-link'}>Календарь мероприятий</Link>
                    <Link to='/shop' className={pageName === 'shop' ? 'admin-layout__links-link active' : 'admin-layout__links-link'}>Магазин (склад)</Link>
                    <Link to='/admin/orders' className={pageName === 'orders' ? 'admin-layout__links-link active' : 'admin-layout__links-link'}>Заказы</Link>
                    <Link to='/admin/orders/history' className={pageName === 'rules' ? 'admin-layout__links-link active' : 'admin-layout__links-link'}>История заказов</Link>
                </div>
                <div className='admin-layout__exit' onClick={() => {dispatch(logout(userData)); dispatch(deletePageName)}}>Выйти</div>
            </aside>
            <div style={{gridColumn: '2 / 3', minWidth: '-webkit-fill-available'}}>{children}</div>
        </div>
    )
}