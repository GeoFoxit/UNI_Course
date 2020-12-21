//React
import React, { Component } from 'react'
//MaterialUI
import withStyles from '@material-ui/core/styles/withStyles'
import clsx from 'clsx';

const styles = (theme) => ({})

class SessionsPage extends Component {

    state = {}

    render() {

        const { classes } = this.props

        return (
            <>
                SessionsPage
            </>
        )
    }
}

export default withStyles(styles, { withTheme: true })(SessionsPage)