import React from 'react';
import ReactDOM from 'react-dom';
import { BrowserRouter } from 'react-router-dom';
import CssBaseline from '@material-ui/core/CssBaseline'
import { ThemeProvider as Mui, createMuiTheme } from '@material-ui/core/styles';
import './index.css';
import App from './App';


const theme = createMuiTheme({
  palette: {}
});

ReactDOM.render(
  <React.StrictMode>
    <BrowserRouter>
      <Mui theme={theme}>
        <CssBaseline />
        <App />
      </Mui>
    </BrowserRouter>
  </React.StrictMode>,
  document.getElementById('root')
);
