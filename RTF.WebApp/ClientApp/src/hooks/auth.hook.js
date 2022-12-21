import { useCallback, useEffect, useState } from "react";


const storageName = 'data';
export const useAuth = () => {
    const [firstName, setFirstName] = useState(null);
    const [lastName, setLastName] = useState(null);
    const [group, setGroup] = useState(null);
    const [userName, setUserName] = useState(null);
    const [token, setToken] = useState(null);
    const [role, setRole] = useState(null);

    const login = useCallback((first, last, gr, user, jwtToken, rl) => {
        setFirstName(first);
        setLastName(last);
        setGroup(gr);
        setUserName(user)
        setToken(jwtToken);
        setRole(rl);

        localStorage.setItem(storageName, JSON.stringify({
            firstName: first,
            lastName: last,
            group: gr,
            userName: user,
            token: jwtToken,
            role: rl
        }))
    }, [])

    const logout = useCallback(() => {
        setFirstName(null);
        setLastName(null);
        setGroup(null);
        setUserName(null)
        setToken(null);
        setRole(null);
        localStorage.removeItem(storageName);
    }, []);
    useEffect(() => {
        const data = JSON.parse(localStorage.getItem(storageName));
        if (data && data.token) {
            login(data.firstName, data.lastName, data.group, data.userName, data.token, data.role);
        };
    }, [login]);

    return { firstName, lastName, group, userName, token, role, login, logout };
}