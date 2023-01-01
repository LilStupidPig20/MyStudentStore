import React from 'react'
import './App.css';
import { AuthContextProvider } from './context/AuthContext';
import { CurrentPageContextProvider } from './context/CurrentPageContext';
import { useAuth } from './hooks/auth.hook';
import { useRoutes } from './routes/routes';


function App() {
  const { token } = useAuth();

  return (
    <AuthContextProvider>
      <CurrentPageContextProvider>
        { useRoutes(!!token) }
      </CurrentPageContextProvider>
    </AuthContextProvider>
  )
}

export default App;