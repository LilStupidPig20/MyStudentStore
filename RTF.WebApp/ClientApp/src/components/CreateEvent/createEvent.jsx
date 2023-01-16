import {useEffect, useState} from "react";
import './createEvent.scss';
import 'react-datepicker/dist/react-datepicker.css';
import '../../pages/CalendarPage/datepicker.css';
import DatePicker, {registerLocale} from "react-datepicker";
import ru from "date-fns/locale/ru";
import {useSelector} from "react-redux";
import {showUser} from "../../features/authSlice";
import Select from 'react-select';
import makeAnimated from 'react-select/animated';
registerLocale("ru", ru);

export const CreateEvent = ({eventHandler}) => {
    const [ids, setIds] = useState([]);
    const [form, setForm] = useState({name: '', startDateTime: '', description: '', organizers: [], coins: 0});
    const authData = useSelector(showUser);
    const [startDate, setStartDate] = useState(new Date());
    const [timeForm, setTimeForm] = useState({eventHour: '', eventMin: '', date: startDate})
    const [adminsList, setAdminsList] = useState(new Set());
    const eventOptions = [
        {
            label: 'Учебное',
            value: 0
        },{
            label : 'Внеучебное',
            value: 1
        }]

    const animatedComponents = makeAnimated();

    useEffect(() => {
        if(authData.role === 'Admin') {
            fetch('/api/adminEvent/getOrganizers', {
                headers: {
                    'Authorization': `Bearer ${authData.token}`
                }
            }).then(res => res.json())
                .then((items) => {
                    for(let i = 0; i < items.length; i++) {
                        setAdminsList([{
                            label: items[i].fullName,
                            value: items[i].id
                        }]
                        )
                    }
                })
        }
    },[authData.role, authData.token])

    useEffect(() => {
        timeForm.date.setHours(timeForm.eventHour, timeForm.eventMin, 0o0);
        console.log(timeForm.date)
        form.startDateTime = String(timeForm.date.toISOString());
    },[form, timeForm])

    const changeHandler = (event) => {
        setForm({ ...form, [event.target.name]: event.target.value });
    };

    const setAdmins = (event) => {
        let arr = []
        for(let i = 0; i < event.length; i++) {
            arr.push(event[i].value);
        }
        setForm({ ...form, 'organizers' : arr});
        setIds(arr);
    }

    const sendRequest = async () => {
        console.log(timeForm);
        console.log(form);
        await fetch('/api/adminEvent/createEvent', {
            method: "POST",
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(form)
        })
    }

    console.log(timeForm)
    console.log(form);
    console.log(ids);

    const changeTimeHandler = (event) => {
        if(parseInt(event.target.value) > parseInt(event.target.max) || event.target.value.length > 2) {
            event.target.value = event.target.max;
        }
        if(parseInt(event.target.value) < parseInt(event.target.min) || event.target.value.length > 2) {
            event.target.value = event.target.min;
        }
        if(event.target.name === 'eventHourEnd' && parseInt(event.target.value) < timeForm.eventHour) {
            event.target.value = timeForm.eventHour;
        }
        timeForm.date = startDate;
        setTimeForm({...timeForm, [event.target.name]: event.target.value});
    }

    return (
        <div className='create-event__portal' onClick={() => eventHandler(false)}>
            <div className='create-event__body' onClick={(e) => e.stopPropagation()}>
                <div className='create-event__body-title'>Новое мероприятие</div>
                <div className='create-event__body-input-cont'>
                    <label>Название:</label>
                    <input
                        name='name'
                        type='text'
                        onInput={changeHandler}
                        placeholder='Введите название'
                        required
                        className='create-event__body-input'/>
                </div>
                <div style={{display:'flex', gap: '78px'}}>
                    <div className='create-event__body-input-cont'>
                        <label htmlFor='event-datepicker'>Дата:</label>
                        <label htmlFor='event-datepicker' className='create-event__body-input-date' style={{fontWeight: '500'}}>
                            {startDate?.toISOString().split('T')[0]}
                            <svg width="23" height="24" viewBox="0 0 23 24" fill="none" xmlns="http://www.w3.org/2000/svg">
                                <path d="M16.7708 13.9167C16.3896 13.9167 16.024 13.7652 15.7544 13.4956C15.4848 13.226 15.3333 12.8604 15.3333 12.4792C15.3333 12.0979 15.4848 11.7323 15.7544 11.4627C16.024 11.1931 16.3896 11.0417 16.7708 11.0417C17.1521 11.0417 17.5177 11.1931 17.7873 11.4627C18.0569 11.7323 18.2083 12.0979 18.2083 12.4792C18.2083 12.8604 18.0569 13.226 17.7873 13.4956C17.5177 13.7652 17.1521 13.9167 16.7708 13.9167ZM15.3333 17.2708C15.3333 17.6521 15.4848 18.0177 15.7544 18.2873C16.024 18.5569 16.3896 18.7083 16.7708 18.7083C17.1521 18.7083 17.5177 18.5569 17.7873 18.2873C18.0569 18.0177 18.2083 17.6521 18.2083 17.2708C18.2083 16.8896 18.0569 16.524 17.7873 16.2544C17.5177 15.9848 17.1521 15.8333 16.7708 15.8333C16.3896 15.8333 16.024 15.9848 15.7544 16.2544C15.4848 16.524 15.3333 16.8896 15.3333 17.2708ZM11.5 18.7083C11.1188 18.7083 10.7531 18.5569 10.4835 18.2873C10.214 18.0177 10.0625 17.6521 10.0625 17.2708C10.0625 16.8896 10.214 16.524 10.4835 16.2544C10.7531 15.9848 11.1188 15.8333 11.5 15.8333C11.8812 15.8333 12.2469 15.9848 12.5165 16.2544C12.786 16.524 12.9375 16.8896 12.9375 17.2708C12.9375 17.6521 12.786 18.0177 12.5165 18.2873C12.2469 18.5569 11.8812 18.7083 11.5 18.7083ZM10.0625 12.4792C10.0625 12.8604 10.214 13.226 10.4835 13.4956C10.7531 13.7652 11.1188 13.9167 11.5 13.9167C11.8812 13.9167 12.2469 13.7652 12.5165 13.4956C12.786 13.226 12.9375 12.8604 12.9375 12.4792C12.9375 12.0979 12.786 11.7323 12.5165 11.4627C12.2469 11.1931 11.8812 11.0417 11.5 11.0417C11.1188 11.0417 10.7531 11.1931 10.4835 11.4627C10.214 11.7323 10.0625 12.0979 10.0625 12.4792ZM6.22917 13.9167C5.84792 13.9167 5.48228 13.7652 5.2127 13.4956C4.94312 13.226 4.79167 12.8604 4.79167 12.4792C4.79167 12.0979 4.94312 11.7323 5.2127 11.4627C5.48228 11.1931 5.84792 11.0417 6.22917 11.0417C6.61042 11.0417 6.97605 11.1931 7.24563 11.4627C7.51522 11.7323 7.66667 12.0979 7.66667 12.4792C7.66667 12.8604 7.51522 13.226 7.24563 13.4956C6.97605 13.7652 6.61042 13.9167 6.22917 13.9167ZM23 5.29167C23 4.02084 22.4952 2.80206 21.5966 1.90345C20.6979 1.00483 19.4792 0.5 18.2083 0.5H4.79167C3.52084 0.5 2.30206 1.00483 1.40345 1.90345C0.504835 2.80206 0 4.02084 0 5.29167V18.7083C0 19.9792 0.504835 21.1979 1.40345 22.0966C2.30206 22.9952 3.52084 23.5 4.79167 23.5H18.2083C19.4792 23.5 20.6979 22.9952 21.5966 22.0966C22.4952 21.1979 23 19.9792 23 18.7083V5.29167ZM18.2083 2.41667C18.9708 2.41667 19.7021 2.71957 20.2413 3.25873C20.7804 3.7979 21.0833 4.52917 21.0833 5.29167V6.25H1.91667V5.29167C1.91667 4.52917 2.21957 3.7979 2.75873 3.25873C3.2979 2.71957 4.02917 2.41667 4.79167 2.41667H18.2083ZM21.0833 18.7083C21.0833 19.4708 20.7804 20.2021 20.2413 20.7413C19.7021 21.2804 18.9708 21.5833 18.2083 21.5833H4.79167C4.02917 21.5833 3.2979 21.2804 2.75873 20.7413C2.21957 20.2021 1.91667 19.4708 1.91667 18.7083V8.16667H21.0833V18.7083Z" fill="#4C2C82"/>
                            </svg>
                        </label>
                        <DatePicker
                            selected={startDate}
                            onChange={(date) => setStartDate(date)}
                            id='event-datepicker'
                            dateFormat="dd.MM.yy"
                            locale={"ru"}/>
                    </div>
                    <div className='create-event__body-input-cont'>
                        <label htmlFor='event-datepicker'>Время:</label>
                        <div className='create-event__body-input-time__wrapper'>
                            <div className='create-event__body-input-time-cont'>
                                <input
                                    name='eventHour'
                                    type='number'
                                    pattern="[0-9]*"
                                    onInput={changeTimeHandler}
                                    required
                                    className='create-event__body-input-time'
                                    min='00'
                                    max='23'
                                />
                                <span>:</span>
                                <input
                                    name='eventMin'
                                    type='number'
                                    pattern="[0-9]*"
                                    onInput={changeTimeHandler}
                                    required
                                    className='create-event__body-input-time'
                                    min='00'
                                    max='59'
                                />
                            </div>
                            -
                            <div className='create-event__body-input-time-cont'>
                                <input
                                    name='eventHourEnd'
                                    type='number'
                                    pattern="[0-9]*"
                                    onInput={changeTimeHandler}
                                    required
                                    className='create-event__body-input-time'
                                    min='00'
                                    max='23'
                                />
                                <span>:</span>
                                <input
                                    name='eventMinEnd'
                                    type='number'
                                    pattern="[0-9]*"
                                    onInput={changeTimeHandler}
                                    required
                                    className='create-event__body-input-time'
                                    min='00'
                                    max='59'
                                />
                            </div>
                        </div>

                    </div>

                </div>
                <div className='create-event__body-input-cont'>
                    <label>Описание:</label>
                    <textarea
                        name='description'
                        onInput={changeHandler}
                        placeholder='Введите текст'
                        rows={4}
                        required
                        className='create-event__body-input'
                        style={{resize: 'none'}}
                    />
                </div>
                <div className='create-event__body-input-cont'>
                    <label>Организаторы:</label>
                    <Select
                        options={adminsList}
                        name='organizers'
                        closeMenuOnSelect={false}
                        components={animatedComponents}
                        isMulti
                        isSearchable
                        noOptionsMessage={()=>'Нет опций'}
                        placeholder={'Выберите организаторов'}
                        onChange={setAdmins}
                        styles={{
                            control: (baseStyles, state) => ({
                                ...baseStyles,
                                border: state.isFocused ? '2px solid #000000' : '2px solid #C7C7C7',
                                borderRadius: '9px',
                                boxShadow: 'none',
                                "&:hover": {
                                    border: state.isFocused ? '2px solid #000000' : '2px solid #C7C7C7',

                                },
                            }),
                        }}
                    />
                </div>
                <div className='create-event__body-input-cont'>
                    <label htmlFor='event-datepicker'>Баллы:</label>
                    <div className='create-event__body-input-coins-cont'>
                        <input
                            name='coins'
                            type='number'
                            pattern="[0-9]*"
                            onInput={changeHandler}
                            required
                            className='create-event__body-input-coins'
                        />
                    </div>
                </div>
                <div className='create-event__submit-cont'>
                    <button className='create-event__submit-button' onClick={()=> sendRequest()}>Создать</button>
                </div>

            </div>
        </div>
    )
}