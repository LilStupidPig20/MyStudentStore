import {useAuthContext} from "../../../context/AuthContext";
import './adminLayout.scss';
import {useCurrentPageContext} from "../../../context/CurrentPageContext";
import React from "react";
import logo from "../../../images/main/logo.png";
import {Link, useNavigate} from "react-router-dom";

export const AdminLayout = ({children}) => {
    const profileData = useAuthContext();
    console.log(profileData);
    const pageName = useCurrentPageContext().name;
    const navigate = useNavigate();

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
                    <Link to='/calendar' className={pageName === 'calendar' ? 'admin-layout__links-link active' : 'admin-layout__links-link'}>Календарь мероприятий</Link>
                    <Link to='/shop' className={pageName === 'shop' ? 'admin-layout__links-link active' : 'admin-layout__links-link'}>Магазин (склад)</Link>
                    <Link to='/orders' className={pageName === 'orders' ? 'admin-layout__links-link active' : 'admin-layout__links-link'}>Заказы</Link>
                    <Link to='/orders/history' className={pageName === 'rules' ? 'admin-layout__links-link active' : 'admin-layout__links-link'}>История заказов</Link>
                    <Link to='/rules' className={pageName === 'rules' ? 'admin-layout__links-link active' : 'admin-layout__links-link'}>Правила начисления баллов</Link>
                </div>
                <div className='admin-layout__exit' onClick={() => {profileData.logout(); navigate(0);}}>Выйти</div>
            </aside>
            <div style={{gridColumn: '2 / 3', minWidth: '-webkit-fill-available'}}>{children}</div>
        </div>
    )
}