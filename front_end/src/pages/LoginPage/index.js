//React
import React, { Component } from 'react'
//MaterialUI
import withStyles from '@material-ui/core/styles/withStyles'
import { Button, Snackbar, Slide, TextField, Typography } from '@material-ui/core';
import { API } from '../../utils/API'
import { Alert, AlertTitle } from '@material-ui/lab'

const styles = (theme) => ({})

const regexp = /^([A-z0-9]{6,8})$/

class LoginPage extends Component {

    state = {
        login: "",
        password: "",
        login_error: null,
        password_error: null,
        isInvalidCredentials: false
    }

    handleClickBack = () => {
        this.props.history.goBack()
    }

    handleClickForward = () => {

        const { login, password } = this.state

        const authData = {
            login, password
        }

        API
            .post('auth/token', authData)
            .then(res => {
                if (res.status === 200) {
                    localStorage.setItem('username', res.data.username)
                    localStorage.setItem('token', res.data.access_token)
                }
            })
            .then(() => {
                this.props.history.push('/admin/films')
            })
            .catch(err => {
                this.setState({
                    isInvalidCredentials: true
                })
            })

    }

    handleChange = e => {

        const { name, value } = e.target

        let error = null

        if (!value.match(regexp)) {
            error = "Поле повинно містити лише від 6 до 8 латинських літери та/або цифри."
        }

        this.setState({
            [name]: value,
            [name + '_error']: error
        })

    }

    closeAlert = () => {
        this.setState({
            isInvalidCredentials: false
        })
    }

    render() {

        const { classes } = this.props

        return (
            <div
                style={{
                    maxWidth: "500px",
                    margin: "5em auto 0em"
                }}
            >
                <Typography
                    variant="h6"
                    align="center"
                >
                    Вхід
                </Typography>
                <Typography
                    style={{
                        margin: "1em 0"
                    }}
                    variant="body2"
                    align="center"
                >
                    Ця сторінка інсує виключно для адміністрування, якщо ви звичайний користувач і потрапили сюди випадково, просто натисніть кнопку “Назад” щоб повернутися до головного меню.
                </Typography>
                <TextField
                    style={{
                        margin: "1em 0"
                    }}
                    variant="outlined"
                    required
                    fullWidth
                    value={this.state.login}
                    name="login"
                    label="Логін"
                    error={!!this.state.login_error}
                    helperText={this.state.login_error}
                    onChange={this.handleChange}
                />
                <TextField
                    style={{
                        margin: "1em 0"
                    }}
                    variant="outlined"
                    required
                    fullWidth
                    value={this.state.password}
                    name="password"
                    label="Пароль"
                    type="password"
                    error={!!this.state.password_error}
                    helperText={this.state.password_error}
                    onChange={this.handleChange}
                />
                <div
                    style={{
                        display: "flex",
                        flexDirection: "row",
                        justifyContent: "space-between",
                        margin: "1em 0"
                    }}
                >
                    <Button
                        style={{
                            width: "49%",
                            height: "4em"
                        }}
                        variant="outlined"
                        color="secondary"
                        onClick={this.handleClickBack}
                    >
                        Назад
                    </Button>
                    <Button
                        style={{
                            width: "49%"
                        }}
                        variant="outlined"
                        color="primary"
                        disabled={
                            !!this.state.login_error ||
                            !!this.state.password_error ||
                            this.state.login.length === 0 ||
                            this.state.password.length === 0
                        }
                        onClick={this.handleClickForward}
                    >
                        Далі
                    </Button>
                </div>
                <Snackbar
                    open={this.state.isInvalidCredentials}
                    autoHideDuration={3000}
                    onClose={this.closeAlert}
                >
                    <Alert
                        severity="error"
                        variant="filled"
                    >
                        <AlertTitle><strong>Помилка</strong></AlertTitle>
                            Задано невірний <strong>логін</strong> або <strong>пароль</strong>!
                        </Alert>
                </Snackbar>
            </div>
        )
    }
}

export default withStyles(styles, { withTheme: true })(LoginPage)


const ErrorAlert = props => <Slide {...props} direction="up" />