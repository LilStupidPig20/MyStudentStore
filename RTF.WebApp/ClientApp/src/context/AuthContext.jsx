import React from 'react'
import { useContext, createContext } from 'react';
import { useAuth } from '../hooks/auth.hook';

function noop() { }

export const AuthContext = createContext({
    firstName: null,
    lastName: null,
    group: null,
    userName: null,
    token: null,
    role: null,
    login: noop,
    logout: noop,
})

export const useAuthContext = () => useContext(AuthContext);

export const AuthContextProvider = ({children}) => {
    const {firstName, lastName, group, userName, token, role, login, logout} = useAuth();

    return <AuthContext.Provider value={{firstName, lastName, group, userName, token, role, login, logout}}>{children}</AuthContext.Provider>
}