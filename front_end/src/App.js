//React
import React, { Component } from 'react'
//MaterialUI
import withStyles from '@material-ui/core/styles/withStyles'
import Header from './shared/Header'
import FilmsPage from './pages/FilmsPage'
import SessionsPage from './pages/SessionsPage'
import EditFilmsPage from './pages/EditFilmsPage'
import EditSessionsPage from './pages/EditSessionsPage'
import {
    Switch,
    Route,
    Redirect
} from "react-router-dom";
import LoginPage from './pages/LoginPage';
import { Toolbar } from '@material-ui/core';

const styles = (theme) => ({})

class App extends Component {

    render() {
        return (
            <>
                <Header />
                {/* For margin */}
                <Toolbar />
                <Switch>
                    <Route exact path="/films" component={FilmsPage} />
                    <Route path="/films/:filmId" component={SessionsPage} />
                    {/* <Route path="/sessions/:sessionId" component={PlacesPage} /> */}
                    {/* <Route path="/code" component={CodePage} /> */}
                    <Route path="/admin/login" component={LoginPage} />
                    <Route path="/admin/films" component={EditFilmsPage} />
                    <Route path="/admin/sessions" component={EditSessionsPage} />
                    <Redirect exact path="/" to="/films" />
                </Switch>
            </>
        )
    }
}

export default withStyles(styles, { withTheme: true })(App)