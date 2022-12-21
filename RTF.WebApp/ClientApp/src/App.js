import React from 'react'
import './App.css';
import { AuthContextProvider } from './context/AuthContext';
import { CurrentPageContextProvider } from './context/CurrentPageContext';
import { useAuth } from './hooks/auth.hook';
import { useRoutes } from './routes/routes';


function App() {
  const { token, role } = useAuth();

  return (
    <AuthContextProvider>
      <CurrentPageContextProvider>
        { useRoutes(!!token, role) }
      </CurrentPageContextProvider>
    </AuthContextProvider>
  )
}

export default App;