import './eventInfo.scss';

export const EventInfo = ({info, handler}) => {
    console.log(info);
    return (
        <div className='eventInfo__portal' onClick={() => handler(false)}>
            <div className='eventInfo__body' onClick={(e) => e.stopPropagation()}>
                <div className='eventInfo__body-title'>{info?.name}</div>
                <div className='eventInfo__body-time__wrapper'>
                    <div className='eventInfo__body-time-cont'>
                        <div className='eventInfo__body-time-title'>Дата:</div>
                        <div className='eventInfo__body-time'>{info?.startDateTime?.slice(0,10).split('-').join('.')}</div>
                    </div>
                    <div className='eventInfo__body-time-cont'>
                        <div className='eventInfo__body-time-title'>Время:</div>
                        <div className='eventInfo__body-time'>
                            {info?.startDateTime?.slice(-8).slice(0,-3)} - {info?.endDateTime?.slice(-8).slice(0,-3)}
                        </div>
                    </div>
                </div>
                <div className='eventInfo__body-time-cont'>
                    <div className='eventInfo__body-time-title'>Тип мероприятия:</div>
                    <div className='eventInfo__body-time'>
                        {info?.eventType === 0 ? 'Внеучебное' : 'Учебное'}
                    </div>
                </div>
                <div className='eventInfo__body-time-cont'>
                    <div className='eventInfo__body-time-title'>Описание:</div>
                    <div className='eventInfo__body-time'>
                        {info?.description}
                    </div>
                </div>
                <div className='eventInfo__body-time-cont'>
                    <div className='eventInfo__body-time-title'>Организаторы:</div>
                    <div className='eventInfo__body-time'>
                        {info?.organizersNames?.join(', ')}
                    </div>
                </div>
                <div className='eventInfo__body-time-cont'>
                    <div className='eventInfo__body-time-title'>Баллы:</div>
                    <div className='eventInfo__body-time'>
                        {info?.coins}
                    </div>
                </div>
            </div>
        </div>
    )
}