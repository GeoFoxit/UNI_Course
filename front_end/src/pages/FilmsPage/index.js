//React
import React, { Component } from 'react'
//MaterialUI
import withStyles from '@material-ui/core/styles/withStyles'
import Films from './Films';
import Search from './Search';
import { API } from '../../utils/API'

const styles = (theme) => ({})

class FilmsPage extends Component {

    state = {
        films: [],
        filteredFilms: [],
        pending: true
    }

    updateFilteredFilms = films => {
        this.setState({
            filteredFilms: films
        })
    }

    componentDidMount = () => {
        API
            .get("/films")
            .then(data => {
                this.setState({
                    films: data.data,
                    filteredFilms: data.data,
                    pending: false
                })
            })
            .catch(error => {
                this.setState({
                    pending: false
                }, () => console.dir(error))
            })
    }

    render() {

        const { films, filteredFilms, pending } = this.state

        return (
            <div
                style={{
                    display: "flex",
                    flexDirection: "row"
                }}
            >
                <Search
                    {...this.props}
                    films={films}
                    updateFilms={this.updateFilteredFilms}
                />
                <Films
                    {...this.props}
                    films={filteredFilms}
                    pending={pending}
                />
            </div>
        )
    }
}

export default withStyles(styles, { withTheme: true })(FilmsPage)