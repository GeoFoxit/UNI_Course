//React
import React, { Component } from 'react'
//MaterialUI
import withStyles from '@material-ui/core/styles/withStyles'
import clsx from 'clsx';
import { Paper } from '@material-ui/core';

const styles = (theme) => ({})

class Session extends Component {

    render() {

        const { classes, session } = this.props

        return (
            <Paper>
                <Typography>
                    {sessions.datetime}
                    {sessions.filmid}
                </Typography>
            </Paper>
        )
    }
}

export default withStyles(styles, { withTheme: true })(Session)