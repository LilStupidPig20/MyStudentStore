import React, { useState } from 'react';
import './loginPage.scss';
import login_picture from '../../images/login/login-picture.jpg';
import wave from '../../images/main/wave.svg';
import { memo } from 'react';
import { useAuthContext } from '../../context/AuthContext';
import { useNavigate } from 'react-router-dom';

export const LoginPage = memo((redirect) => {
    const auth = useAuthContext();
    const [form, setForm] = useState({email: '', password: ''});
    const [fail, setFail] = useState(false);
    const navigate = useNavigate();
    
    const changeHandler = (event) => {
        setForm({ ...form, [event.target.name]: event.target.value });
    };
    
    const loginHandler = async () => {
        const response = await fetch("api/account/login", {
            method: 'POST',
            headers: { 
                'Content-Type': 'application/json' 
            },
            body: JSON.stringify(form)
        }).then((res) => {
            if(res.status !== 200) {
                return setFail(true);
            } else {
                return res.json()
            }
        })

        auth.login(response.firstName, response.lastName, response.group, response.userName, response.token, response.role);
        navigate('/profile');
        navigate(0);
    };

    let wrongStyle = fail ? { border: '2px solid #FF5D5D' } : {};
    let wrongStyleBtn = fail ? { marginTop: '17px' } : {};

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
                        fail 
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