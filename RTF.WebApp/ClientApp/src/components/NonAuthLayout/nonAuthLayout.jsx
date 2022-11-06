import React from 'react'
import { Link } from 'react-router-dom'
import logo from '../../images/main/logo.png'
import './nonAuthLayout.scss'

export const NonAuthLayout = ({children}) => {
    return (
        <div className='layout'>
            <div className='layout__header'>
                <div className='layout__cont'>
                    <img src={logo} alt='Логотип MSS'></img>
                    <Link className='layout__link' to='/shop'>Магазин</Link>
                    <Link className='layout__link' to='/calendar'>Календарь</Link>
                </div>
                <div className='layout__cont'>
                    <Link className='layout__link' to='/'>Вход</Link>
                    <Link className='layout__link' to='/register'>Зарегистрироваться</Link>
                </div>
            </div>
            {children}
        </div>
    )
}