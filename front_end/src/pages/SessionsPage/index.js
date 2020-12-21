//React
import React, { Component } from 'react'
//MaterialUI
import withStyles from '@material-ui/core/styles/withStyles'
import clsx from 'clsx';
import Progress from '../../shared/Progress';
import { API } from '../../utils/API';

const styles = (theme) => ({})

class SessionsPage extends Component {

    state = {
        isPending: true,
        sessions: []
    }

    componentDidMount = () => {
        API
            .get('/sessions/byfilm/' + this.props.match.params.filmId)
            .then(resp => {
                this.setState({
                    isPending: false,
                    sessions: resp.data
                })
            })
            .catch(err => {
                console.log(err)
            })
    }


    render() {

        if (this.state.isPending) return < Progress />

        const { classes } = this.props

        return (
            this.state.sessions.map(session => (
                <h1 key={session.id}>
                    {session.datetime}
                </h1>
            ))
        )
    }
}

export default withStyles(styles, { withTheme: true })(SessionsPage)