import React from "react";
import {CalendarItem} from "../CalendarItem/CalendarItem";
import './calendarItemWrapper.scss';

export const CalendarItemWrapper = ({ currentDay, duration, eventType, eventId, eventName, startDateTime}) => {
    return(
        <div className='calendarItemWrapper__events'>
            <div className='calendarItemWrapper__events-day'>
                <div className='calendarItemWrapper__events-day-name'>
                    вт
                </div>
                <div className='calendarItemWrapper__events-day-num'>
                    27
                </div>
            </div>
            <div className='calendarItemWrapper__events-event'>
                <CalendarItem
                    id={eventId}
                    name={eventName}
                    time={startDateTime}
                    disabled={false}
                />
            </div>
        </div>
    )
}