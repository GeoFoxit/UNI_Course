//React
import React, { Component } from 'react'
//MaterialUI
import withStyles from '@material-ui/core/styles/withStyles'
import clsx from 'clsx';

const styles = (theme) => ({})

class PlacesPage extends Component {

    state = {}

    render() {

        const { classes } = this.props

        return (
            <>
                PlacesPage
            </>
        )
    }
}

export default withStyles(styles, { withTheme: true })(PlacesPage)