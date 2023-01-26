import React from "react";

export const ProfileEvent = ({
                                eventType,
                                name,
                                date,
                                coins
                             }) => {
    const eventClasses = {
        green: 'profile__attended-meetings__table-body-green',
        purple: 'profile__attended-meetings__table-body-purple'
    };
    function getNoun(number, one, two, five) {
        let n = Math.abs(number);
        n %= 100;
        if (n >= 5 && n <= 20) {
            return five;
        }
        n %= 10;
        if (n === 1) {
            return one;
        }
        if (n >= 2 && n <= 4) {
            return two;
        }
        return five;
    }
    return (<tr>
        <td className={eventType === 0 ? eventClasses.green : eventClasses.purple}></td>
        <td>{name}</td>
        <td>{date.slice(0,10).split('-').reverse().join('.')}</td>
        <td>{coins} {getNoun(Math.trunc(coins), 'баллы', 'балла', 'баллов')}</td>
    </tr>)
}