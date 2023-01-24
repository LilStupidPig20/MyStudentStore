import { Navigate } from "react-router-dom";
import { CalendarPage } from "../pages/CalendarPage/calendarPage";
import { LoginPage } from "../pages/LoginPage/loginPage";
import { ProfilePage } from "../pages/ProfilePage/profilePage";
import { RegisterPage } from "../pages/RegisterPage/registerPage";
import { ShopPage } from "../pages/ShopPage/shopPage";
import { OrderPage } from "../pages/OrdersPage/orderPage";
import {ShopItemPage} from "../pages/ShopItemPage/shopItemPage";
import CartPage from "../pages/CartPage/cartPage";

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
        element: <Navigate to="/login" />
    }
]

const authRoutesBook = [
    {
        path: '/user/profile',
        element: <ProfilePage />,
    },
    {
        path: '/shop',
        element: <ShopPage />
    },
    {
        path: '/shop/:itemId',
        element: <ShopItemPage />
    },
    {
        path: '/shop/cart',
        element: <CartPage />
    },
    {
        path: '/user/calendar',
        element: <CalendarPage />
    },
    {
        path: '/user/orders',
        element: <OrderPage />
    },
    {
        path: '*',
        element: <Navigate to="/user/profile" replace={true} />
    }
]

const adminRoutesBook = [
    {
        path: '/admin/calendar',
        element: <CalendarPage />
    },
    {
        path: '/shop',
        element: <ShopPage />
    },
    {
        path: '/admin/orders',
        element: <OrderPage />
    },
    {
        path: '*',
        element: <Navigate to="/admin/calendar" replace={true} />
    }
]

export {nonAuthRoutesBook, authRoutesBook, adminRoutesBook}