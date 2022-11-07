import React from 'react'
import { Link } from 'react-router-dom'
import logo from '../../../images/main/logo.png'
import './nonAuthLayout.scss'

export const NonAuthLayout = ({children}) => {
    return (
        <div className='admin-layout'>
            <div className='admin-layout__header'>
                <div className='admin-layout__cont'>
                    <img src={logo} alt='Логотип MSS'></img>
                    <Link className='admin-layout__link' to='/shop'>Магазин</Link>
                    <Link className='admin-layout__link' to='/calendar'>Календарь</Link>
                </div>
                <div className='admin-layout__cont'>
                    <Link className='admin-layout__link' to='/'>Вход</Link>
                    <Link className='admin-layout__link' to='/register'>Зарегистрироваться</Link>
                </div>
            </div>
            {children}
        </div>
    )
}