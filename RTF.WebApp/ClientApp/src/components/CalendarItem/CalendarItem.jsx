import React from 'react'
import './calendarItem.scss'

export const CalendarItem = ({name, id, startDateTime, endDateTime, disabled}) => {
    let calendarClass;
    disabled ?
        calendarClass = 'calendarItem calendarItemDisabled' :
        calendarClass = 'calendarItem';
    startDateTime = new Date(startDateTime);
    endDateTime = new Date(endDateTime);
    return (
        <div className={calendarClass} id={id}>
            <div>
                <div className='calendarItem__name'>{name}</div>
                <div className='calendarItem__time'>{String(startDateTime.getHours()).padStart(2, "0") + ':' +
                    String(startDateTime.getMinutes()).padStart(2, "0")} - {String(endDateTime.getHours()).padStart(2, "0")
                    + ':' + String(endDateTime.getMinutes()).padStart(2, "0")}</div>
            </div>
            <div>
                <svg width="35" height="9" viewBox="0 0 35 9" fill="none" xmlns="http://www.w3.org/2000/svg">
                    <circle cx="4.10352" cy="4.06738" r="4" fill="black"/>
                    <circle cx="17.1035" cy="4.06738" r="4" fill="black"/>
                    <circle cx="30.1035" cy="4.06738" r="4" fill="black"/>
                </svg>
            </div>
        </div>
    )
}