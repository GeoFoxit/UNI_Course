//React
import React, { Component } from 'react'
//MaterialUI
import withStyles from '@material-ui/core/styles/withStyles'
import clsx from 'clsx';
import Progress from '../../shared/Progress';
import { API } from '../../utils/API';
import { Button, ButtonBase, Paper } from '@material-ui/core'
import Film from '../FilmsPage/Film'

const styles = (theme) => ({})

class SessionsPage extends Component {

    state = {
        isPending: true,
        sessions: [],
        selected: null,
        film: null
    }

    goBack = () => {
        this.props.history.push('/')
    }

    goForward = () => {
        this.props.history.push('/sessions/' + this.state.selected)
    }

    componentDidMount = () => {
        API
            .get('/sessions/byfilm/' + this.props.match.params.filmId)
            .then(resp => {
                this.setState({
                    isPending: false,
                    sessions: resp.data
                })
            })
            .then(() => {
                API
                    .get('/films/' + this.props.match.params.filmId)
                    .then(data => {
                        this.setState({
                            film: data.data
                        })
                    })
                    .catch(err => console.log(err))
            })
            .catch(err => console.log(err))
    }

    select = id => {
        this.setState({
            selected: id
        })
    }

    render() {

        if (this.state.isPending) return < Progress />

        const { classes } = this.props

        return (
            <div
                style={{
                    display: "flex",
                    flexDirection: "row",
                    justifyContent: "space-around",
                    alignItems: "center",
                }}
            >
                <div
                    style={{
                        display: "flex",
                        flexDirection: "column",
                        width: "50%",
                    }}
                >
                    {this.state.sessions.map((session, i) => (
                        <ButtonBase
                            key={i}
                            onClick={() => this.select(session.id)}
                            style={{
                                margin: "1em",
                            }}
                        >
                            <Paper
                                style={{
                                    width: "100%",
                                    padding: "2em",
                                    background: session.id === this.state.selected ? "rgba(0,255,0,0.7)" : "white"
                                }}
                                key={session.id}
                            >
                                {session.dateTime}
                            </Paper>
                        </ButtonBase>
                    ))}
                    {this.state.sessions.length === 0 ? <h1 align='center'>Сеансів немає</h1> : null}
                </div>
                <div
                    style={{
                        display: "flex",
                        flexDirection: "column",
                        width: "50%",
                    }}
                >

                    <div
                        style={{
                            display: "flex",
                            flexDirection: "column",
                            margin: "2em"
                        }}
                    >
                        {this.state.film ? (
                            <Film disabled width="auto" film={this.state.film} />
                        ) : null}
                        <Button
                            style={{
                                margin: "0.5em 0"
                            }}
                            color="primary"
                            variant="outlined"
                            onClick={this.goForward}
                            disabled={!this.state.selected}
                        >
                            Обрати місце
                        </Button>
                        <Button
                            style={{
                                margin: "0.5em 0"
                            }}
                            onClick={this.goBack}
                            color="secondary"
                            variant="outlined"
                        >
                            Назад
                        </Button>
                    </div>
                </div>
            </div >
        )
    }
}

export default withStyles(styles, { withTheme: true })(SessionsPage)