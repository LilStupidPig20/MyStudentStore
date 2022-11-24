import React from 'react'
import './App.css';
import { AuthContextProvider } from './context/AuthContext';
import { useAuth } from './hooks/auth.hook';
import { useRoutes } from './routes/routes';


function App() {
  const { token } = useAuth();

  return (
    <AuthContextProvider>
      { useRoutes(!!token) }
    </AuthContextProvider>
  )
}

export default App;