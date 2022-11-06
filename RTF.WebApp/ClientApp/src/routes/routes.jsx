import React from 'react';
import { NonAuthLayout } from '../components/NonAuthLayout/nonAuthLayout';
import { Route, Routes } from 'react-router-dom';
import { authRoutesBook, nonAuthRoutesBook } from './book';
import { UserLayout } from '../components/UserLayout/userLayout';

export const useRoutes = () => {
    /*return (
        <UserLayout>
            <Routes>
                {authRoutesBook.map((x, index) => {
                    return <Route path={x.path} element={x.element} key={index} />
                })}
            </Routes>
        </UserLayout>
    )
    */
    return (
        <NonAuthLayout>
            <Routes>
                {nonAuthRoutesBook.map((x, index) => {
                    return <Route path={x.path} element={x.element} key={index} />
                })}
            </Routes>
        </NonAuthLayout>
        
    )
    
}