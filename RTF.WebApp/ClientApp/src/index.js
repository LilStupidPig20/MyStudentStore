import React from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
import App from './App';
import { BrowserRouter } from 'react-router-dom';

const baseUrl = document.getElementsByTagName('base')[0].getAttribute('href');
const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(
  <React.StrictMode>
    <BrowserRouter basename={baseUrl}>
      <App /> 
    </BrowserRouter>
  </React.StrictMode>
);