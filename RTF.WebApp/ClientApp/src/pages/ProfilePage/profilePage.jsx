import React from 'react';
import './profilePage.scss';
import profile_top from '../../images/profile/profile-top.svg';
import { memo } from 'react';
import { useAuthContext } from '../../context/AuthContext';

export const ProfilePage = memo(() => {
    const profileData = useAuthContext();
    
    return (
        <div className='profile'>
            <img className='profile__pic-top' src={profile_top} alt=''/>
            <div className='profile__cont'>
                <div className='profile__user-info'>
                    <div className='profile__user'>
                        <div className='profile__user-greetings'>
                            Привет, 
                            <div className='profile__user-name'>{profileData.firstName} {profileData.lastName}</div>
                        </div>
                        <span className='profile__user-group'>Группа: {profileData.group}</span>
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
                            <path d="M2 2L9.5 10L17 2" stroke="black" strokeWidth="3" strokeLinecap="round" strokeLinejoin="round"/>
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
                    </table>
                    <div className='profile__attended-meetings__table-body'>
                        <table>
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
        </div>
    )
})