import React from 'react';
import { NonAuthLayout } from '../components/Layouts/NonAuthLayout/nonAuthLayout';
import {Route, Routes} from 'react-router-dom';
import { authRoutesBook, nonAuthRoutesBook, adminRoutesBook } from './book';
import { UserLayout } from '../components/Layouts/UserLayout/userLayout';
import { AdminLayout } from "../components/Layouts/AdminLayout/adminLayout";
import {useSelector} from "react-redux";
import {showUser} from "../features/authSlice";

export const useRoutes = () => {
    const authData = useSelector(showUser);
    console.log(window.location.pathname);

    if(authData.token !== null && authData.token !== undefined && Object.keys(authData).length !== 0 && authData.constructor === Object) {
        if (authData.role === 'Admin') {
            return (
                <AdminLayout>
                    <Routes>
                        {adminRoutesBook.map((x, index) => {
                            return <Route path={x.path} element={x.element} key={index}/>
                        })}
                    </Routes>
                </AdminLayout>
            )
        }
        return (
            <UserLayout>
                <Routes>
                    {authRoutesBook.map((x, index) => {
                        return <Route path={x.path} element={x.element} key={index}/>
                    })}
                </Routes>
            </UserLayout>
        );
    }
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