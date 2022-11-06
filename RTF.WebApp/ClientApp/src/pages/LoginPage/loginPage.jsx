import React from 'react';
import './loginPage.scss';
import login_picture from '../../images/login/login-picture.jpg';
import login_bottom from '../../images/login/login-bottom.png';

export const LoginPage = () => {
    return (
        <>
        <div className='login'>
            <div className='login__halfCont'>
                <div className='login__title'>My<br/>Student Store</div>
                <div className='login__form'>
                    <div className='login__formTitle'>Авторизация</div>
                    <input
                        className='login__input'
                        type='text'
                        placeholder='Почта'
                    />
                    <input
                        className='login__input'
                        type='password'
                        placeholder='Пароль'
                    />
                    <button className='login__button'>Войти</button>
                </div>
            </div>
            <div className='login__halfCont'>
                <img src={login_picture} alt='' />
            </div>
            
        </div>
        <div className='login__pic-bottom'>
            <img src={login_bottom} alt=''/>
        </div>
        </>
        )
}