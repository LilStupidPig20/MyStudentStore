import React, {useEffect, memo, useState} from 'react'
import './calendarPage.scss';
import 'react-datepicker/dist/react-datepicker.css';
import './datepicker.css';
import right_back from '../../images/shop/back-img.png'
import DatePicker, { registerLocale } from "react-datepicker";
import { useCurrentPageContext } from '../../context/CurrentPageContext';
import ru from "date-fns/locale/ru";
registerLocale("ru", ru);

export const CalendarPage = memo(() => {
    const pageContext = useCurrentPageContext();
    useEffect(() => {
        pageContext.setName('calendar');
    },[pageContext])
    const [dateRange, setDateRange] = useState([null, null]);
    const [startDate, endDate] = dateRange;
    
    return (
        <div className='calendarPage'>
            <img className='calendarPage__back-img' src={right_back} alt='' />
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
                    selectsRange={true}
                    selected={startDate}
                    startDate={startDate}
                    endDate={endDate}
                    onChange={(update) => {
                        setDateRange(update);
                    }}
                    withPortal
                />
            </div>
            <div className='calendarPage__date-selected'>
                26 декабря - 1 января    
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

                </div>
            </div>
        </div>
    )
})