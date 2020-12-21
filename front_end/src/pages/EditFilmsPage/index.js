//React
import React, { Component } from 'react'
//MaterialUI
import withStyles from '@material-ui/core/styles/withStyles'
import clsx from 'clsx';

const styles = (theme) => ({})

class EditFilmsPage extends Component {

    state = {}

    render() {

        const { classes } = this.props

        return (
            <>
                EditFilmsPage
            </>
        )
    }
}

export default withStyles(styles, { withTheme: true })(EditFilmsPage)