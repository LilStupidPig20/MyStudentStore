import React, {useEffect} from 'react';
import './profilePage.scss';
import profile_top from '../../images/profile/profile-top.svg';
import { memo } from 'react';
import {useDispatch, useSelector} from "react-redux";
import {showUser} from "../../features/authSlice";
import {setPageName} from "../../features/pageNameSlice";
import {showUserBalance} from "../../features/userBalanceSlice";

export const ProfilePage = memo(() => {
    const profileData = useSelector(showUser);
    const userBalance = useSelector(showUserBalance);
    const dispatch = useDispatch();
    useEffect(()=> {
        dispatch(setPageName('profile'));
    },[dispatch])
    let typeOfEvent;
    const eventClasses = {
        green: 'profile__attended-meetings__table-body-green', 
        purple: 'profile__attended-meetings__table-body-purple'
    };
    
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
                            {userBalance} баллов
                        </div>
                    </div>
                    <div className='profile__user-qr'>
                        <div className='profile__user-qr-cont'>
                            Мой QR-код
                            <div>
                                <svg width="19" height="12" viewBox="0 0 19 12" fill="none" xmlns="http://www.w3.org/2000/svg">
                                <path d="M2 2L9.5 10L17 2" stroke="black" strokeWidth="3" strokeLinecap="round" strokeLinejoin="round"/>
                                </svg>
                            </div>
                        </div>
                        <ul className="profile__user-qr-text">
                            <li>
                            Используй свой QR-код на мероприятиях для регистрации. Он обновляется каждый день.
                            </li>
                        </ul>
                    </div>
                </div>
                <div className='profile__attended-meetings'>
                    <div className='profile__attended-meetings__title'>Посещенные мероприятия</div>
                    <table className='profile__attended-meetings__table'>
                        <thead>
                            <tr>
                                <th></th>
                                <th style={{textAlign: 'left', paddingLeft: '40px'}}>Название</th>
                                <th style={{textAlign: 'left', width: '230px'}}>Дата</th>
                                <th style={{textAlign: 'left', width: '337px', paddingLeft: '28px'}}>Баллы</th>
                            </tr>
                        </thead>
                    </table>
                    <div className='profile__attended-meetings__table-body'>
                        <table>
                            <tbody>
                                <tr>
                                    <td className={eventClasses.green}></td>
                                    <td>Неделя первокурсника</td>
                                    <td>20.12.22</td>
                                    <td>5 баллов</td>
                                </tr>
                                <tr>
                                    <td className={eventClasses.green}></td>
                                    <td>Караоке</td>
                                    <td>20.12.22</td>
                                    <td>5.5 баллов</td>
                                </tr>
                                <tr>
                                    <td className={eventClasses.purple}></td>
                                    <td>Хакатон</td>
                                    <td>23.12.22</td>
                                    <td>4 балла</td>
                                </tr>
                                <tr>
                                    <td className={eventClasses.green}></td>
                                    <td>Литературный вечер</td>
                                    <td>24.12.22</td>
                                    <td>2 балла</td>
                                </tr>
                                <tr>
                                    <td className={eventClasses.purple}></td>
                                    <td>Хакатон</td>
                                    <td>25.12.22</td>
                                    <td>2 балла</td>
                                </tr>
                                <tr>
                                    <td className={eventClasses.green}></td>
                                    <td>Концерт</td>
                                    <td>28.12.22</td>
                                    <td>2 балла</td>
                                </tr>
                                <tr>
                                    <td className={eventClasses.green}></td>
                                    <td>Киноклуб «35мм»</td>
                                    <td>28.12.22</td>
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