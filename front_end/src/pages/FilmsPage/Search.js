//React
import React, { Component } from 'react'
//MaterialUI
import withStyles from '@material-ui/core/styles/withStyles'
import clsx from 'clsx';
import { Button, Drawer, List, ListItem, MenuItem, TextField, Typography } from '@material-ui/core';

const styles = (theme) => ({})

const genres = ['Всі', 'Драма', "Комедія", "Екшин", "Фентезі", "Триллер"]

const rate = ['Всі', 1, 2, 3, 4, 5]

class Search extends Component {

    state = {
        search: '',
        genre: 'Всі',
        rate: 'Всі',
    }

    handleChangeSearch = e => {
        this.setState({
            search: e.target.value
        })
    }

    handleChangeGenre = e => {
        this.setState({
            genre: e.target.value
        }, () => this.updateFilms())
    }

    handleChangeRate = e => {
        this.setState({
            rate: e.target.value
        }, () => this.updateFilms())
    }

    updateFilms = () => {
        const films = this.props.films
        const { search, genre, rate } = this.state

        let result = [...films];

        if (search.length !== 0) {
            result = result.filter(f => f.naming.toLowerCase().includes(search.toLowerCase()))
        }

        if (genre !== 'Всі') {
            result = result.filter(f => f.genre === genre)
        }

        if (rate !== 'Всі') {
            result = result.filter(f => f.rate === rate)
        }

        this.props.updateFilms(result)
    }

    handleClickClearFilters = () => {
        this.setState({
            search: '',
            genre: 'Всі',
            rate: 'Всі',
        }, () => this.updateFilms())
    }

    handleAdmin = () => {
        this.props.history.push('/admin/login')
    }


    render() {

        const { classes } = this.props

        return (
            <Drawer
                variant="permanent"
                style={{
                    zIndex: "10",
                    width: '234px',
                }}
            >
                <List>
                    <ListItem
                        style={{
                            marginTop: "4em"
                        }}
                    >
                        <TextField
                            label="Назва фільму"
                            variant="outlined"
                            margin="dense"
                            color="primary"
                            value={this.state.search}
                            onChange={this.handleChangeSearch}
                        />
                    </ListItem>
                    <ListItem>
                        <Button
                            variant="outlined"
                            color="primary"
                            onClick={this.updateFilms}
                            fullWidth
                        >
                            Пошук
                        </Button>
                    </ListItem>
                    <ListItem>
                        <Typography
                            variant="body2"
                            style={{
                                width: '100%',
                                textAlign: "center",
                            }}
                        >
                            Фільтри
                        </Typography>
                    </ListItem>
                    <ListItem>
                        <Button
                            variant="outlined"
                            color="secondary"
                            onClick={this.handleClickClearFilters}
                            fullWidth
                        >
                            <span
                                style={{
                                    textAlign: "center"
                                }}
                            >
                                Прибрати фільтри
                            </span>
                        </Button>
                    </ListItem>
                    <ListItem>
                        <TextField
                            select
                            fullWidth
                            margin="dense"
                            label="Жанр"
                            value={this.state.genre}
                            onChange={this.handleChangeGenre}
                            variant="outlined"
                        >
                            {genres.map(option => (
                                <MenuItem key={option} value={option}>
                                    {option}
                                </MenuItem>
                            ))}
                        </TextField>
                    </ListItem>
                    <ListItem>
                        <TextField
                            select
                            fullWidth
                            margin="dense"
                            label="Рейтинг"
                            value={this.state.rate}
                            onChange={this.handleChangeRate}
                            variant="outlined"
                        >
                            {rate.map(option => (
                                <MenuItem key={option} value={option}>
                                    {option}
                                </MenuItem>
                            ))}
                        </TextField>
                    </ListItem>
                </List>
                <div
                    style={{
                        flexGrow: "1"
                    }}
                ></div>
                <Button
                    variant="contained"
                    style={{
                        margin: "0 1em",
                        color: "white",
                        background: "black",
                    }}
                    onClick={this.handleAdmin}
                >
                    Для адміністрації
                </Button>
                <div
                    style={{
                        height: '1em'
                    }}
                ></div>
            </Drawer >
        )
    }
}

export default withStyles(styles, { withTheme: true })(Search)