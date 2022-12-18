import React from 'react'
import './calendarItem.scss'

export const CalendarItem = ({name, time, disabled}) => {
    let calendarClass;
    disabled ?
        calendarClass = 'calendarItem calendarItemDisabled' :
        calendarClass = 'calendarItem'
    return (
        <div className={calendarClass}>
            <div>
                <div className='calendarItem__name'>{name}</div>
                <div className='calendarItem__time'>{time}</div>
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