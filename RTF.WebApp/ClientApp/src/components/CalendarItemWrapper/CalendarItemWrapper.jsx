import React from "react";
import {CalendarItem} from "../CalendarItem/CalendarItem";
import './calendarItemWrapper.scss';
import {registerLocale} from "react-datepicker";
import ru from "date-fns/locale/ru";
registerLocale("ru", ru);

export const CalendarItemWrapper = ({ eventType, eventId, eventName, startDateTime, endDateTime }) => {
    const today = new Date(startDateTime);

    return(
        <div className='calendarItemWrapper__events'>
            <div className='calendarItemWrapper__events-day'>
                <div className='calendarItemWrapper__events-day-name'>
                    {today?.toLocaleDateString('ru-RU', { weekday : 'short' })}
                </div>
                <div className='calendarItemWrapper__events-day-num'>
                    {today?.getDate()}
                </div>
            </div>
            <div className='calendarItemWrapper__events-event'>
                <CalendarItem
                    id={eventId}
                    name={eventName}
                    startDateTime={startDateTime}
                    endDateTime={endDateTime}
                    disabled={false}
                />
            </div>
        </div>
    )
}