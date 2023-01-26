import React, {useEffect, memo, useState} from 'react'
import './calendarPage.scss';
import 'react-datepicker/dist/react-datepicker.css';
import './datepicker.css';
import right_back from '../../images/shop/back-img.png'
import DatePicker, { registerLocale } from "react-datepicker";
import ru from "date-fns/locale/ru";
import {useDispatch, useSelector} from "react-redux";
import {getCalendarInfoAsync, showCalendarInfo} from "../../features/calendarSlice";
import {showUser} from "../../features/authSlice";
import {setPageName} from "../../features/pageNameSlice";
import {CreateEvent} from "../../components/CreateEvent/createEvent";
import {getEventsAsync, showEventsInfo} from "../../features/eventsSlice";
import {CalendarItemWrapper} from "../../components/CalendarItemWrapper/CalendarItemWrapper";
registerLocale("ru", ru);


export const CalendarPage = memo(() => {
    const authData = useSelector(showUser);
    const calendarInfo = useSelector(showCalendarInfo);
    const eventsInfo = useSelector(showEventsInfo);
    const dispatch = useDispatch();
    const [createEvent, setCreateEvent] = useState(false);
    useEffect(()=> {
        dispatch(setPageName('calendar'));
    },[dispatch])
    const [month, setMonth] = useState(new Date().getMonth() + 1);

    useEffect(() => {
        dispatch(getCalendarInfoAsync(month, authData.token));
    }, [authData.role, authData.token, dispatch, month])
    
    
    const months = [
        "январь",
        "февраль",
        "март",
        "апрель",
        "май",
        "июнь",
        "июль",
        "август",
        "сентябрь",
        "октябрь",
        "ноябрь",
        "декабрь",
    ];

    const [dateRange, setDateRange] = useState([null, null]);
    const [startDate, endDate] = dateRange;
    const options = { month: 'long', day: 'numeric' };
    const firstDefaultDay = new Date(Date.now());
    const lastDefaultDay = new Date(Date.now() + 7 * 24 * 60 * 60 * 1000) ;
    let dateWidth;
    if (startDate !== null && endDate !== null)
        dateWidth = '1150px'
    else dateWidth = '800px';
    if(window.location.pathname === '/user/calendar') {
        dateWidth = '800px';
    }

    useEffect(() => {
        const addDay = function(str) {
            let myDate = new Date(str);
            myDate.setDate(myDate.getDate() + 1);
            return myDate;
        }
        if(dateRange[0] !== null && dateRange[1] !== null) {
            dispatch(getEventsAsync(addDay(dateRange[0]), addDay(dateRange[1])));
        }

    },[dateRange, dispatch])

    useEffect(() => {
        dispatch(getEventsAsync(firstDefaultDay, lastDefaultDay))
    }, [])
    
    const renderDayContents = (day) => {
        let infoObj = calendarInfo?.dayToEventsList;
        return (
            <>
                <span>{day}</span>
                {
                    Object.keys(calendarInfo).length !== 0 ?
                        <div className='calendarPage__date-small-events'>
                            {infoObj[day]?.map((elem, index) => {
                                if(elem === 0) {
                                    return (
                                        <div className='calendarPage__date-small-event-green' key={index}></div>
                                    )
                                } else {
                                    return (
                                        <div className='calendarPage__date-small-event-purple' key={index}></div>
                                    )
                                }
                                })
                            }
                        </div>
                    : ''
                }
            </>);
    };
    return (
        <div className='calendarPage'>
            <img className='calendarPage__back-img' src={right_back} alt='' />
            <div className='calendarPage__date-block' style={{width: dateWidth}}>
                <div className='calendarPage__date'>
                    <label htmlFor='datepicker'>Выберите дату
                        <svg width="11" height="11" viewBox="0 0 11 11" fill="none" style={{'marginLeft':'30px'}} xmlns="http://www.w3.org/2000/svg">
                            <path d="M5.5 11L0 0H11L5.5 11Z" fill="#666666"/>
                        </svg>
                    </label>
                    <DatePicker
                        id='datepicker'
                        dateFormat="dd.MM.yy"
                        locale={"ru"}
                        onMonthChange={(data) => {setMonth(data.getMonth() + 1)}}
                        renderCustomHeader={({
                                 date,
                                 decreaseMonth,
                                 increaseMonth,
                             }) => (
                            <div style={{
                                    display: "flex",
                                    justifyContent: "center"
                                }}
                            >
                                <button className="react-datepicker__navigation react-datepicker__navigation--prev" onClick={() => {decreaseMonth(); dispatch(getCalendarInfoAsync(month, authData.token))}}>
                                    <span className="react-datepicker__navigation-icon react-datepicker__navigation-icon--previous">Previous Month</span>
                                </button>
                                <p className="react-datepicker__current-month">{months[date.getMonth()]}, {date.getFullYear()}</p>

                                <button className="react-datepicker__navigation react-datepicker__navigation--next" onClick={() => {increaseMonth(); dispatch(getCalendarInfoAsync(month, authData.token))}}>
                                    <span className="react-datepicker__navigation-icon react-datepicker__navigation-icon--next">Next Month</span>
                                </button>
                            </div>
                        )}
                        selectsRange={true}
                        selected={startDate}
                        startDate={startDate}
                        endDate={endDate}
                        renderDayContents={renderDayContents}
                        formatWeekDay={d => {
                            return d.slice(0,1);
                        }}
                        onChange={(update) => {
                            setDateRange(update);
                        }}
                        withPortal
                    />
                </div>
                {
                    startDate !== null && endDate !== null ?
                        <div className='calendarPage__date-filter'>
                            <div>
                                {dateRange[0].toLocaleDateString('ru-RU') + ' - ' + dateRange[1].toLocaleDateString('ru-RU')}
                            </div>
                            <div onClick={() => { setDateRange([null, null]); dispatch(getEventsAsync(firstDefaultDay, lastDefaultDay)) }}>
                                <svg width="16" height="17" viewBox="0 0 16 17" fill="none" xmlns="http://www.w3.org/2000/svg">
                                    <line x1="1" y1="-1" x2="20" y2="-1" transform="matrix(0.707107 0.707107 -0.657201 0.753715 0 2.0752)" stroke="#4C2C82" strokeWidth="2" strokeLinecap="round"/>
                                    <line x1="1" y1="-1" x2="20" y2="-1" transform="matrix(-0.707107 0.707107 0.657201 0.753715 15.8496 2.0752)" stroke="#4C2C82" strokeWidth="2" strokeLinecap="round"/>
                                </svg>
                            </div>
                        </div>
                        : ''
                }
                {
                    authData.role === "Admin" ?
                        <>
                            <div className='calendarPage__date-create-event' onClick={() => setCreateEvent(true)}>
                                Создать мероприятие
                            </div>
                            {createEvent ?
                                <CreateEvent eventHandler={setCreateEvent}/>
                            : ''}
                        </>

                        : ''
                }
            </div>
            <div className='calendarPage__date-selected'>
                {firstDefaultDay.toLocaleDateString('ru-RU', options)}
                &nbsp;-&nbsp;
                {lastDefaultDay?.toLocaleDateString('ru-RU', options)}
            </div>
            <CalendarItemWrapper
                eventsInfo={eventsInfo}
            />
        </div>
    )
})