//React
import React, { Component } from 'react'
//MaterialUI
import withStyles from '@material-ui/core/styles/withStyles'
import clsx from 'clsx';
import { API } from '../../utils/API';
import { Button, List, TextField, ListItem, Paper, ListItemSecondaryAction, ListItemText, Toolbar, Typography, MenuItem } from '@material-ui/core';
import { NavLink } from 'react-router-dom';
import Progress from '../../shared/Progress';
import DeleteIcon from '@material-ui/icons/Delete';
import IconButton from '@material-ui/core/IconButton';
import DateFnsUtils from '@date-io/date-fns';
import {
    MuiPickersUtilsProvider,
    KeyboardDateTimePicker
} from '@material-ui/pickers';

const styles = (theme) => ({})

class EditSessionsPage extends Component {

    state = {
        isPending: true,
        films: [],
        sessions: [],
        filmId: null,
        dateTime: new Date("2021-01-01T00:00:00.000Z"),
    }

    componentDidMount = () => {
        const token = localStorage.getItem('token')
        const options = {
            headers: {
                'Authorization': `Bearer ${token}`
            }
        }

        API
            .get("/films")
            .then(data => {
                this.setState({
                    films: data.data,
                })
            })
            .then(() => {
                API
                    .get("/sessions", options)
                    .then(data => {
                        this.setState({
                            sessions: data.data,
                            isPending: false
                        })
                    })
            })
            .catch(error => {
                this.setState({
                    isPending: false
                }, () => console.dir(error))
            })
    }

    addSession = e => {
        const token = localStorage.getItem('token')
        const options = {
            headers: {
                'Authorization': `Bearer ${token}`
            }
        }
        const { filmId, dateTime } = this.state
        const sessionData = {
            filmId,
            dateTime: new Date(dateTime)
        }

        console.dir(sessionData)

        API
            .post('/sessions', sessionData, options)
            .then(resp => {
                if (resp.status === 200) {
                    const updatedSessions = [...this.state.sessions]
                    updatedSessions.push(resp.data)
                    this.setState({
                        sessions: updatedSessions
                    })
                }
            })
            .catch(err => console.log(err))

    }

    deleteSession = e => {
        const token = localStorage.getItem('token')
        const options = {
            headers: {
                'Authorization': `Bearer ${token}`
            }
        }

        API
            .delete('/sessions/' + e, options)
            .then(resp => {
                if (resp.status === 200) {

                    const { sessions } = this.state
                    const element = sessions.find(x => x.id === e)
                    const index = sessions.indexOf(element)
                    const updatedSessions = [...sessions]
                    updatedSessions.splice(index, 1)

                    this.setState({
                        sessions: updatedSessions
                    })
                }
            })
            .catch(err => console.log(err))
    }

    handleChangeDate = (e, value) => {
        this.setState({
            dateTime: value
        })
    }

    render() {

        const { classes } = this.props

        if (this.state.isPending) return <Progress />

        return (
            <div>
                <Typography
                    variant="h5"
                    align="center"
                    style={{
                        margin: "1em 0"
                    }}
                >
                    Редагування
                </Typography>
                <div
                    style={{
                        background: '#dfdfdf',
                        width: "100%",
                    }}
                >
                    <Toolbar
                        style={{
                            display: "flex",
                            flexDirection: "row",
                            justifyContent: "center"
                        }}
                    >
                        <Button
                            variant="text"
                        >
                            <NavLink
                                to="/admin/films"
                                style={{
                                    outline: "none",
                                    textDecoration: "none",
                                    color: "inherit"
                                }}
                            >
                                Фільми
                            </NavLink>
                        </Button>
                        <div style={{ width: '2em' }}></div>
                        <Button
                            variant="outlined"
                        >
                            <NavLink
                                to="/admin/sessions"
                                style={{
                                    outline: "none",
                                    textDecoration: "none",
                                    color: "inherit"
                                }}
                            >
                                Сеанси
                            </NavLink>
                        </Button>
                    </Toolbar>
                </div>
                <div
                    style={{
                        display: "flex",
                        flexDirection: "row",
                        justifyContent: "space-around",
                        alignItems: "flex-start",
                        margin: "2em",
                    }}
                >
                    <Paper
                        style={{
                            minWidth: "45%"
                        }}
                    >
                        {this.state.sessions.length === 0 ? (
                            <Typography
                                variant="h6"
                                style={{
                                    margin: "1em 1em 0em",
                                }}
                            >
                                Немає сеансів
                            </Typography>
                        ) : null}

                        <List>
                            {this.state.sessions.map((session, i) => (
                                <ListItem
                                    key={i}
                                    style={{
                                        background: (i % 2 === 0 ? "white" : "#f8f8f8")
                                    }}
                                >
                                    <ListItemText>
                                        {session.dateTime}
                                        {/* {this.state.films ? "-----" + this.state.films.find(x => x.id === session.filmId).naming : null} */}
                                    </ListItemText>
                                    <div
                                        style={{
                                            width: "3em"
                                        }}
                                    ></div>
                                    <ListItemSecondaryAction>
                                        <IconButton
                                            onClick={() => this.deleteSession(session.id)}
                                            color="secondary"
                                            size="large"
                                            edge="end"
                                            aria-label="delete"
                                        >
                                            <DeleteIcon />
                                        </IconButton>
                                    </ListItemSecondaryAction>
                                </ListItem>
                            ))}
                        </List>
                    </Paper>
                    <Paper
                        style={{
                            width: "45%",
                            display: "flex",
                            flexDirection: "column",
                            alignItems: "center",
                            padding: "1em",
                            position: "sticky",
                            top: "7em"
                        }}
                    >
                        <TextField
                            select
                            fullWidth
                            margin="dense"
                            label="Назва фільму"
                            value={this.state.filmId}
                            onChange={e => {
                                this.setState({
                                    filmId: e.target.value
                                })
                            }}
                            variant="outlined"
                        >
                            {this.state.films.map(option => (
                                <MenuItem key={option.id} value={option.id}>
                                    {option.naming}
                                </MenuItem>
                            ))}
                        </TextField>
                        <MuiPickersUtilsProvider utils={DateFnsUtils}>
                            <KeyboardDateTimePicker
                                variant="inline"
                                fullWidth
                                ampm={false}
                                margin="normal"
                                label="Дата та час"
                                onError={console.log}
                                disablePast
                                value={this.state.dateTime}
                                onChange={this.handleChangeDate}
                                format="yyyy/MM/dd HH:mm"
                            />
                        </MuiPickersUtilsProvider>
                        <Button
                            style={{
                                margin: "1em 0"
                            }}
                            fullWidth
                            variant="outlined"
                            color="primary"
                            onClick={this.addSession}
                        >
                            Додати
                        </Button>
                    </Paper>
                </div>
            </div>
        )
    }
}

export default withStyles(styles, { withTheme: true })(EditSessionsPage)