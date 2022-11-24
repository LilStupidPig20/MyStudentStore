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
    login: noop,
    logout: noop,
})

export const useAuthContext = () => useContext(AuthContext);

export const AuthContextProvider = ({children}) => {
    const {firstName, lastName, group, userName, token, login, logout} = useAuth();

    return <AuthContext.Provider value={{firstName, lastName, group, userName, token, login, logout}}>{children}</AuthContext.Provider>
}