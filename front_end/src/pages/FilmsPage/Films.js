//React
import React, { Component } from 'react'
//MaterialUI
import withStyles from '@material-ui/core/styles/withStyles'
import Progress from '../../utils/Progress'
import Film from './Film'

const styles = (theme) => ({})

class Films extends Component {

    render() {

        const { films, pending } = this.props

        if (pending) return (
            <div
                style={{
                    width: "100%",
                    height: "100vh",
                    position: "relative"
                }}
            >
                <Progress />
            </div>
        )

        if (films.length === 0) return (
            <h2
                style={{
                    margin: "4em 0",
                    width: "100%",
                    textAlign: "center"
                }}
            >
                Фільмів не знайдено
            </h2>
        )

        return (
            <div
                style={{
                    display: 'flex',
                    flexWrap: "wrap",
                    margin: "0.5em auto",
                    padding: "0 0.5em",
                    maxWidth: "800px",
                    justifyContent: "center"
                }}
            >
                {films.map(film => <Film {...this.props} key={film.id} film={film} />)}
            </div>
        )
    }
}

export default withStyles(styles, { withTheme: true })(Films)