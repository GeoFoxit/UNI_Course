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
import { Rating } from '@material-ui/lab';

const styles = (theme) => ({})

const genres = ['Драма', "Комедія", "Екшин", "Фентезі", "Триллер"]

class EditFilmsPage extends Component {

    state = {
        isPending: true,
        films: [],
        naming: "",
        rate: 0,
        genre: ""
    }

    componentDidMount = () => {
        API
            .get("/films")
            .then(data => {
                this.setState({
                    films: data.data,
                    isPending: false
                })
            })
            .catch(error => {
                this.setState({
                    isPending: false
                }, () => console.dir(error))
            })
    }

    addFilm = e => {
        const token = localStorage.getItem('token')
        const options = {
            headers: {
                'Authorization': `Bearer ${token}`
            }
        }
        const { naming, genre, rate } = this.state
        const filmData = {
            naming, genre, rate
        }

        API
            .post('/films', filmData, options)
            .then(resp => {
                if (resp.status === 200) {
                    const updateFilms = [...this.state.films]
                    updateFilms.push(resp.data)
                    this.setState({
                        films: updateFilms
                    })
                }
            })
            .catch(err => console.log(err))

    }

    deleteFilm = e => {
        const token = localStorage.getItem('token')
        const options = {
            headers: {
                'Authorization': `Bearer ${token}`
            }
        }

        API
            .delete('/films/' + e, options)
            .then(resp => {
                if (resp.status === 200) {

                    const { films } = this.state
                    const element = films.find(x => x.id === e)
                    const index = films.indexOf(element)
                    const updatedFilms = [...films]
                    updatedFilms.splice(index, 1)

                    this.setState({
                        films: updatedFilms
                    })
                }
            })
            .catch(err => console.log(err))
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
                            variant="outlined"
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
                            variant="text"
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
                        {this.state.films.length === 0 ? (
                            <Typography
                                variant="h6"
                                style={{
                                    margin: "1em 1em 0em",
                                }}
                            >
                                Немає фільмів
                            </Typography>
                        ) : null}
                        <List>
                            {this.state.films.map((film, i) => (
                                <ListItem
                                    key={i}
                                    style={{
                                        background: (i % 2 === 0 ? "white" : "#f8f8f8")
                                    }}
                                >
                                    <ListItemText>
                                        {film.naming}
                                    </ListItemText>
                                    <div
                                        style={{
                                            width: "3em"
                                        }}
                                    ></div>
                                    <ListItemSecondaryAction>
                                        <IconButton
                                            onClick={() => this.deleteFilm(film.id)}
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
                            fullWidth
                            margin="dense"
                            id="film_naming"
                            value={this.state.naming}
                            onChange={e => {
                                this.setState({
                                    naming: e.target.value
                                })
                            }}
                            label="Назва фільму"
                            variant="outlined"
                        />
                        <TextField
                            select
                            fullWidth
                            margin="dense"
                            label="Жанр"
                            value={this.state.genre}
                            onChange={e => {
                                this.setState({
                                    genre: e.target.value
                                })
                            }}
                            variant="outlined"
                        >
                            {genres.map(option => (
                                <MenuItem key={option.id} value={option}>
                                    {option}
                                </MenuItem>
                            ))}
                        </TextField>
                        <Rating
                            style={{
                                margin: "1em 0"
                            }}
                            name="film_rate"
                            value={this.state.rate}
                            onChange={(event, newValue) => {
                                this.setState({
                                    rate: newValue
                                })
                            }}
                        />
                        <Button
                            fullWidth
                            variant="outlined"
                            color="primary"
                            onClick={this.addFilm}
                        >
                            Додати
                        </Button>
                    </Paper>
                </div>
            </div>
        )
    }
}

export default withStyles(styles, { withTheme: true })(EditFilmsPage)