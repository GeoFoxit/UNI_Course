//React
import React, { Component } from 'react'
//MaterialUI
import withStyles from '@material-ui/core/styles/withStyles'
import clsx from 'clsx';

const styles = (theme) => ({})

class CodePage extends Component {

    state = {}

    render() {

        const { classes } = this.props

        return (
            <>
                CodePage
            </>
        )
    }
}

export default withStyles(styles, { withTheme: true })(CodePage)