import React, {useEffect, memo, useState} from 'react'
import './calendarPage.scss';
import 'react-datepicker/dist/react-datepicker.css';
import './datepicker.css';
import right_back from '../../images/shop/back-img.png'
import DatePicker, { registerLocale } from "react-datepicker";
import { useCurrentPageContext } from '../../context/CurrentPageContext';
import ru from "date-fns/locale/ru";
import {useAuthContext} from "../../context/AuthContext";
import {CalendarItem} from "../../components/CalendarItem/CalendarItem";
registerLocale("ru", ru);

export const CalendarPage = memo(() => {
    const pageContext = useCurrentPageContext();
    const authData = useAuthContext();
    const [calendarInfo, setCalendarInfo] = useState({});
    useEffect(() => {
        pageContext.setName('calendar');
    },[pageContext])
    const today = new Date().getMonth() + 1;
    
    useEffect(() => {
        if(authData.role === 'Student') {
            fetch(`/api/events/getCalendarInfo/${today}`, {
                method: 'GET',
                headers: {
                    'Content-Type': 'application/json',
                    'Authorization': `Bearer ${authData.token}`
                }
            }).then(res => res.json())
                .then(items => setCalendarInfo(items))
        }
    }, [authData.role, authData.token, today])
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
    const firstDefaultDay = new Date();
    const lastDefaultDay = new Date(Date.now() + 7 * 24 * 60 * 60 * 1000) ;

    const renderDayContents = (day) => {
        let infoObj = calendarInfo?.dayToEventsList;
        return (
            <>
                <span>{day}</span>
                {
                    Object.keys(calendarInfo).length !== 0 ?
                        <div className='calendarPage__date-small-events'>
                            {infoObj[day]?.map((elem) => {
                                if(elem === 0) {
                                    return (
                                        <div className='calendarPage__date-small-event-green'></div>
                                    )
                                } else {
                                    return (
                                        <div className='calendarPage__date-small-event-purple'></div>
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
            <div className='calendarPage__date-block'>
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
                        renderCustomHeader={({
                                 date,
                                 changeYear,
                                 changeMonth,
                                 decreaseMonth,
                                 increaseMonth,
                                 prevMonthButtonDisabled,
                                 nextMonthButtonDisabled,
                             }) => (
                            <div style={{
                                    display: "flex",
                                    justifyContent: "center"
                                }}
                            >
                                <button className="react-datepicker__navigation react-datepicker__navigation--prev" onClick={decreaseMonth} disabled={prevMonthButtonDisabled}>
                                    <span className="react-datepicker__navigation-icon react-datepicker__navigation-icon--previous">Previous Month</span>
                                </button>
                                <p className="react-datepicker__current-month">{months[date.getMonth()]}, {date.getFullYear()}</p>

                                <button className="react-datepicker__navigation react-datepicker__navigation--next" onClick={increaseMonth} disabled={nextMonthButtonDisabled}>
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
                            <div onClick={() => setDateRange([null, null])}>
                                <svg width="16" height="17" viewBox="0 0 16 17" fill="none" xmlns="http://www.w3.org/2000/svg">
                                    <line x1="1" y1="-1" x2="20" y2="-1" transform="matrix(0.707107 0.707107 -0.657201 0.753715 0 2.0752)" stroke="#4C2C82" strokeWidth="2" strokeLinecap="round"/>
                                    <line x1="1" y1="-1" x2="20" y2="-1" transform="matrix(-0.707107 0.707107 0.657201 0.753715 15.8496 2.0752)" stroke="#4C2C82" strokeWidth="2" strokeLinecap="round"/>
                                </svg>
                            </div>
                        </div>
                        : ''
                }
            </div>
            <div className='calendarPage__date-selected'>
                {firstDefaultDay.toLocaleDateString('ru-RU', options)}
                &nbsp;-&nbsp;
                {lastDefaultDay?.toLocaleDateString('ru-RU', options)}
            </div>
            <div className='calendarPage__events'>
                <div className='calendarPage__events-day'>
                    <div className='calendarPage__events-day-name'>
                        вт
                    </div>
                    <div className='calendarPage__events-day-num'>
                        27
                    </div>
                </div>
                <div className='calendarPage__events-event'>
                    <CalendarItem
                        name='Литературный вечер'
                        time='17:40 - 18:10'
                        disabled={false}
                    />
                </div>
            </div>
        </div>
    )
})