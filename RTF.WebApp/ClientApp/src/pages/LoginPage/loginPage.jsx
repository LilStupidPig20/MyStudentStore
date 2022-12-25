import React, { useState } from 'react';
import './loginPage.scss';
import login_picture from '../../images/login/login-picture.jpg';
import wave from '../../images/main/wave.svg';
import { memo } from 'react';
import {useDispatch, useSelector} from "react-redux";
import {setUserAsync, showUser} from "../../features/authSlice";

export const LoginPage = memo(() => {
    const [form, setForm] = useState({email: '', password: ''});
    const isFail = useSelector(showUser).isFail;
    console.log(isFail);
    const dispatch = useDispatch();
    
    const changeHandler = (event) => {
        setForm({ ...form, [event.target.name]: event.target.value });
    };
    
    const loginHandler = async () => {
        dispatch(setUserAsync(form));
    };

    let wrongStyle = isFail ? { border: '2px solid #FF5D5D' } : {};
    let wrongStyleBtn = isFail ? { marginTop: '17px' } : {};

    return (
        <>
        <div className='login'>
            <div className='login__halfCont'>
                <div className='login__title'>My<br/>Student Store</div>
                <div className='login__form'>
                    <div className='login__formTitle'>Авторизация</div>
                    <input
                        className='login__input'
                        type='email'
                        name='email'
                        onInput={changeHandler}
                        placeholder='Почта'
                        style={wrongStyle}
                    />
                    <input
                        className='login__input'
                        name='password'
                        type='password'
                        onInput={changeHandler}
                        placeholder='Пароль'
                        style={wrongStyle}
                    />
                    {
                        isFail
                        ? 
                        <span className='login__wrong'>Неверный логин или пароль. Повторите попытку</span>
                    : ''
                    }
                    <button className='login__button' onClick={loginHandler} style={wrongStyleBtn}>Войти</button>
                </div>
            </div>
            <div className='login__halfCont'>
                <img src={login_picture} alt='' />
            </div>
            
        </div>
        <div className='login__pic-bottom'>
            <img src={wave} alt=''/>
        </div>
        </>
        )
})