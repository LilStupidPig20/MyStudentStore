import React from 'react';
import { Link } from 'react-router-dom';
import './productItem.scss';

export const ProductItem = ({
    imgSrc,
    availability,
    title,
    price,
    id
}) => {
    return (
        <>
            {
                ! availability
                    ?
                    window.location.pathname === '/admin/shop' ?
                        <Link to={`/admin/shop/${id}`} style={{ textDecoration: 'none' }}>
                            <div className='productItem'>
                                <img src={imgSrc} alt="" className='productItem__image' />
                                <div className='productItem__title'>{title}</div>
                                <div className='productItem__price'>Цена: {price} </div>
                            </div>
                        </Link>
                        :
                    <Link to={`/shop/${id}`} style={{ textDecoration: 'none' }}>
                        <div className='productItem'>
                            <img src={imgSrc} alt="" className='productItem__image' />
                            <div className='productItem__title'>{title}</div>
                            <div className='productItem__price'>Цена: {price} </div>
                        </div>
                    </Link>
                    :
                    <div className='productItem productItem__deactivated'>
                        <img src={imgSrc} alt="" className='productItem__image' />
                        <div className='productItem__title'>{title}</div>
                        <div className='productItem.price'>Нет в наличии</div>
                    </div>
            }
        </>
    )
}