import React, {useEffect, useState} from 'react';
import './profilePage.scss';
import profile_top from '../../images/profile/profile-top.svg';
import { memo } from 'react';
import {useDispatch, useSelector} from "react-redux";
import {showUser} from "../../features/authSlice";
import {setPageName} from "../../features/pageNameSlice";
import {showUserBalance} from "../../features/userBalanceSlice";
import QRCode from "react-qr-code";
import {ProfileEvent} from "../../components/ProfileEvent/profileEvent";

export const ProfilePage = memo(() => {
    const profileData = useSelector(showUser);
    const userBalance = useSelector(showUserBalance);
    const dispatch = useDispatch();
    const [qrCodeValue, setQrCodeValue] = useState('');
    const [isClicked, setClicked] = useState(false);
    const [visitedEvents, setVisitedEvents] = useState([])
    useEffect(()=> {
        dispatch(setPageName('profile'));
    },[dispatch])

    useEffect(() => {
        fetch('/api/qrCode/getActualQrCodeId')
            .then(res => res.json())
            .then(value => setQrCodeValue(value))

        fetch('/api/events/getVisited', {
            headers: {
                'Authentication': `Bearer ${profileData.token}`
            }
        })
            .then(res => res.json())
            .then(items => setVisitedEvents(items))
    }, [])

    console.log(visitedEvents)
    let typeOfEvent;
    const eventClasses = {
        green: 'profile__attended-meetings__table-body-green', 
        purple: 'profile__attended-meetings__table-body-purple'
    };

    const QrCont = () => {
        return( <div>
            <QRCode value={qrCodeValue} size={182}/>
        </div>)
    }
    
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
                        <div className='profile__user-qr-cont' style={isClicked ? {flexDirection: 'column'} : {}}>
                            <div style={{display: 'flex', gap: '12px',}}>
                                Мой QR-код
                                <div style={{cursor: 'pointer'}}>
                                    <svg width="19" height="12" viewBox="0 0 19 12" fill="none" xmlns="http://www.w3.org/2000/svg" onClick={()=>setClicked(!isClicked)}>
                                        <path d="M2 2L9.5 10L17 2" stroke="black" strokeWidth="3" strokeLinecap="round" strokeLinejoin="round"/>
                                    </svg>
                                </div>
                            </div>
                            {isClicked ? <QrCont/> : ''}
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
                                <th style={{textAlign: 'left', width: '316px', paddingLeft: '24px'}}>Дата</th>
                                <th style={{textAlign: 'left', width: '292px', paddingLeft: '28px'}}>Баллы</th>
                            </tr>
                        </thead>
                    </table>
                    <div className='profile__attended-meetings__table-body'>
                        <table>
                            <tbody>
                            {visitedEvents?.map((event, index) => {
                                return <ProfileEvent
                                    key={index}
                                    name={event.name}
                                    date={event.startDateTime}
                                    eventType={event.eventType}
                                    coins={event.coins}
                                />
                            })}
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    )
})