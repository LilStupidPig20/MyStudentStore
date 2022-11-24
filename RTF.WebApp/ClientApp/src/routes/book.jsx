import { Navigate } from "react-router-dom";
import { CalendarPage } from "../pages/CalendarPage/calendarPage";
import { LoginPage } from "../pages/LoginPage/loginPage";
import { ProfilePage } from "../pages/ProfilePage/profilePage";
import { RegisterPage } from "../pages/RegisterPage/registerPage";
import { ShopPage } from "../pages/ShopPage/shopPage";

const nonAuthRoutesBook = [
    {
        path: '/login',
        element: <LoginPage />
    },
    {
        path: '/register',
        element: <RegisterPage />
    },
    {
        path: '/shop',
        element: <ShopPage />
    },
    {
        path: '/calendar',
        element: <CalendarPage />
    },
    {
        path: '*',
        element: <Navigate to="/login" replace={true} />
    }
]

const authRoutesBook = [
    {
        path: '/profile',
        element: <ProfilePage />,
    },
    {
        path: '/shop',
        element: <ShopPage />
    },
    {
        path: '/calendar',
        element: <CalendarPage />
    },
    {
        path: '*',
        element: <Navigate to="/profile" replace={true} />
    }
]

export {nonAuthRoutesBook, authRoutesBook}