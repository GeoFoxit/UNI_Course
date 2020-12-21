import Axios from 'axios'
import React, { Component } from 'react'

export default class App extends Component {


    state = {
        films: []
    }

    componentDidMount = () => {
        Axios
            .get("http://localhost:50271/api/films")
            .then(data => {
                console.dir(data)
                this.setState({
                    films: data.data
                })
            })
    }

    render() {
        return (
            <div>
                {this.state.films.map(film => <h1 key={film.id}>{film.naming}</h1>)}
            </div>
        )
    }
}
