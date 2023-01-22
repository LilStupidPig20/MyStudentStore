import React, {useEffect, useState} from "react";
import {CalendarItem} from "../CalendarItem/CalendarItem";
import './calendarItemWrapper.scss';
import {registerLocale} from "react-datepicker";
import ru from "date-fns/locale/ru";
import {EventInfo} from "../EventInfo/eventInfo";
registerLocale("ru", ru);

export const CalendarItemWrapper = ({eventsInfo}) => {
    const [id, setId] = useState('');
    const [showDetails, setShowDetails] = useState(false);
    const [eventInfo, setEventInfo] = useState({});
    eventsInfo = JSON.parse(JSON.stringify(eventsInfo))
    eventsInfo.sort((a, b) => new Date(a.startDateTime) - new Date(b.startDateTime))
    let prevDate;
    let dividerMargin;

    useEffect(() => {
        if(showDetails) {
            fetch(`/api/events/getExtendedEventInfo/${id}`)
                .then((res) => res.json())
                .then((info) => setEventInfo(info))
        }
    }, [id, showDetails])
    
    return(
        <>
            <div className='calendarItemWrapper__events__wrapper'>
                {eventsInfo.map((x, index) => {
                    const today = new Date(x.startDateTime);
                    let isEqual = true;
                    let copyIsEqual = isEqual;
                    if(prevDate !== undefined) {
                        isEqual = (today.getDate() === prevDate.getDate());
                    } else {
                        isEqual = false;
                    }

                    if (isEqual !== copyIsEqual) {
                        dividerMargin = '50px';
                    } else {
                        dividerMargin = '25px';
                    }

                    prevDate = today;
                    return(
                            <div className='calendarItemWrapper__event' key={index} style={{marginTop: dividerMargin}}>
                                <div className='calendarItemWrapper__event-day'>
                                    <div className='calendarItemWrapper__event-day-name'>
                                        {isEqual ? '' : today?.toLocaleDateString('ru-RU', { weekday : 'short' })}
                                    </div>
                                    <div className='calendarItemWrapper__event-day-num'>
                                        {isEqual ? '' : today?.getDate()}
                                    </div>
                                </div>
                                <div className='calendarItemWrapper__event-event' onClick={() => {setShowDetails(true); setId(x.id)}}>
                                    <CalendarItem
                                        key={index}
                                        id={x.id}
                                        name={x.name}
                                        startDateTime={x.startDateTime}
                                        endDateTime={x.endDateTime}
                                        disabled={false}
                                    />
                                </div>
                            </div>)
                })}
            </div>
            {showDetails ? <div>
                <EventInfo info={eventInfo} handler={setShowDetails}/>
            </div> : ''}
        </>

    )
}