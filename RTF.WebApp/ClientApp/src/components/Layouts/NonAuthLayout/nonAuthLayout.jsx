import React from 'react'
import { Link } from 'react-router-dom'
import logo from '../../../images/main/logo.png'
import './nonAuthLayout.scss'

export const NonAuthLayout = ({children}) => {
    return (
        <div className='nonAuthLayout'>
            <div className='nonAuthLayout__header'>
                <div className='nonAuthLayout__cont'>
                    <img src={logo} alt='Логотип MSS'></img>
                    <Link className='nonAuthLayout__link' to='/shop'>Магазин</Link>
                    <Link className='nonAuthLayout__link' to='/calendar'>Календарь</Link>
                </div>
                <div className='nonAuthLayout__cont'>
                    <Link className='nonAuthLayout__link' to='/login'>Вход</Link>
                    <Link className='nonAuthLayout__link' to='/register'>Зарегистрироваться</Link>
                </div>
            </div>
            {children}
        </div>
    )
}