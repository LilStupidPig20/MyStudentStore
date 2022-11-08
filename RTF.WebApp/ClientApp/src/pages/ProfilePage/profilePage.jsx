import React from 'react';
import './profilePage.scss';
import profile_top from '../../images/profile/profile-top.svg';

export const ProfilePage = () => {
    return (
        <div className='profile'>
            <img className='profile__pic-top' src={profile_top} alt=''/>
            <div className='profile__cont'>
                <div className='profile__user-info'>
                    <div className='profile__user'>
                        <div className='profile__user-greetings'>
                            Привет, 
                            <div className='profile__user-name'>Александр Иванов</div>
                        </div>
                        <span className='profile__user-group'>Группа: РИ-490002</span>
                    </div>
                    <div className='profile__user-balance'>
                        Твой баланс:
                        <div className='profile__user-balance-count'>
                            7 баллов
                        </div>
                    </div>
                    <div className='profile__user-qr'>
                        Мой QR-код
                        <div>
                            <svg width="19" height="12" viewBox="0 0 19 12" fill="none" xmlns="http://www.w3.org/2000/svg">
                            <path d="M2 2L9.5 10L17 2" stroke="black" stroke-width="3" stroke-linecap="round" stroke-linejoin="round"/>
                            </svg>
                        </div>
                    </div>
                </div>
                <div className='profile__attended-meetings'>
                    <div className='profile__attended-meetings__title'>Посещенные мероприятия</div>
                    <table className='profile__attended-meetings__table'>
                        <thead>
                            <tr>
                                <th>Название</th>
                                <th>Баллы</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>Неделя первокурсника</td>
                                <td>5 баллов</td>
                            </tr>
                            <tr>
                                <td>Караоке</td>
                                <td>5.5 баллов</td>
                            </tr>
                            <tr>
                                <td>СМП</td>
                                <td>4 балла</td>
                            </tr>
                            <tr>
                                <td>Киноклуб «35мм»</td>
                                <td>2 балла</td>
                            </tr>
                            <tr>
                                <td>Киноклуб «35мм»</td>
                                <td>2 балла</td>
                            </tr>
                            <tr>
                                <td>Киноклуб «35мм»</td>
                                <td>2 балла</td>
                            </tr>
                            <tr>
                                <td>Киноклуб «35мм»</td>
                                <td>2 балла</td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    )
}