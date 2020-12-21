//React
import React, { Component } from 'react'
//MaterialUI
import withStyles from '@material-ui/core/styles/withStyles'
import { withRouter } from "react-router";
import { AppBar, Button, Toolbar, Typography } from '@material-ui/core';

const styles = (theme) => ({})

class Header extends Component {

    render() {

        const { classes } = this.props

        return (
            <AppBar
                style={{
                    background: "url('https://images.unsplash.com/photo-1542204165-65bf26472b9b?ixid=MXwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHw%3D&ixlib=rb-1.2.1&auto=format&fit=crop&w=967&q=80')",
                    backgroundPosition: "center",
                    backgroundSize: "cover",
                }}
            >
                <Toolbar
                    style={{
                        background: "rgba(0,0,0,0.4)",
                        backdropFilter: 'blur(2px)'
                    }}
                >
                    <Typography
                        component="h1"
                        variant="h4"
                        style={{
                            textAlign: 'center',
                            width: "100%",
                        }}
                    >
                        BCinema
                    </Typography>
                    {this.props.auth.isAuth ? (
                        <Button
                            variant="contained"
                            color="secondary"
                            onClick={this.props.auth.logout}
                        >
                            Вихід
                        </Button>
                    ) : null}
                </Toolbar>
            </AppBar>
        )
    }
}

export default withStyles(styles, { withTheme: true })(withRouter(Header))