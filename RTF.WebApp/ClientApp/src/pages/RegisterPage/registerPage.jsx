import React, { memo, useState } from 'react';
import './registerPage.scss';


export const RegisterPage = memo(() => {
    const [form, setForm] = useState({firstName: '', lastName: '', group: '', email: '', password: '', confirmPassword: ''});
    const [fail, setFail] = useState(false);
    const changeHandler = (event) => {
        setForm({ ...form, [event.target.name]: event.target.value });
    };

    const registerHandler = async () => {
        const response = await fetch("api/account/register", {
            method: 'POST',
            headers: { 
                'Content-Type': 'application/json' 
            },
            body: JSON.stringify(form)
        }).catch(err => console.log(err), setFail(true))

        const data = await response.json();
    };
    console.log(form);

    return (
        <>
        <div className='register'>
            <div className='register__halfCont'>
                <div className='register__title'>Регистрация<br/>в <span>My Student Store</span></div>
                <div className='register__form'>
                    <label className='register__form-input-cont'>Имя
                        <input
                            className='register__input'
                            type='text'
                            name='firstName'
                            onInput={changeHandler}
                        />
                    </label>
                    <label className='register__form-input-cont'>Фамилия
                        <input
                            className='register__input'
                            type='text'
                            name='lastName'
                            onInput={changeHandler}
                        />
                    </label>
                    <label className='register__form-input-cont'>Академическая группа
                        <input
                            className='register__input'
                            type='text'
                            name='group'
                            onInput={changeHandler}
                        />
                    </label>
                    <label className='register__form-input-cont'>Почта
                        <input
                            className='register__input'
                            type='email'
                            name='email'
                            onInput={changeHandler}
                        />
                    </label>
                    <label className='register__form-input-cont'>Новый пароль
                        <input
                            className='register__input'
                            name='password'
                            type='password'
                            onInput={changeHandler}
                        />
                    </label>
                    <label className='register__form-input-cont'>Повторите пароль
                        <input
                            className='register__input'
                            name='confirmPassword'
                            type='password'
                            onInput={changeHandler}
                        />
                    </label>
                    <button className='register__button' onClick={registerHandler}>Зарегистрироваться</button>
                </div>
            </div>
        </div>
        </>
    )
})