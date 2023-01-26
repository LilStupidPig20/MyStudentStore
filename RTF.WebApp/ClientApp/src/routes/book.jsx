import { Navigate } from "react-router-dom";
import { CalendarPage } from "../pages/CalendarPage/calendarPage";
import { LoginPage } from "../pages/LoginPage/loginPage";
import { ProfilePage } from "../pages/ProfilePage/profilePage";
import { RegisterPage } from "../pages/RegisterPage/registerPage";
import { ShopPage } from "../pages/ShopPage/shopPage";
import { OrderPage } from "../pages/OrdersPage/orderPage";
import {ShopItemPage} from "../pages/ShopItemPage/shopItemPage";
import CartPage from "../pages/CartPage/cartPage";
import {AdminOrdersHistoryPage} from "../pages/AdminOrdersHistoryPage/adminOrdersHistoryPage";
import {AdminOrdersPage} from "../pages/AdminOrdersPage/adminOrdersPage";

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
        path: '/admin/shop',
        element: <ShopPage />
    },
    {
        path: '/admin/shop/:itemId',
        element: <ShopItemPage />
    },
    {
        path: '/admin/orders',
        element: <AdminOrdersPage />
    },
    {
        path: '/admin/orders/history',
        element: <AdminOrdersHistoryPage />
    },
    {
        path: '*',
        element: <Navigate to="/admin/calendar" replace={true} />
    }
]

export {nonAuthRoutesBook, authRoutesBook, adminRoutesBook}