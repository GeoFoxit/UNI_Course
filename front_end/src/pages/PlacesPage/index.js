//React
import React, { Component } from 'react'
//MaterialUI
import withStyles from '@material-ui/core/styles/withStyles'
import clsx from 'clsx';
import { API } from '../../utils/API';
import Progress from '../../shared/Progress'
import { ButtonBase, Button, Paper, Typography } from '@material-ui/core';

const styles = (theme) => ({})

class PlacesPage extends Component {

    state = {
        places: null,
        isPending: true,
        selected: 0,
        result: null

    }

    componentDidMount = () => {
        API
            .get('/seats/bysession/' + this.props.match.params.sessionId)
            .then(data => {
                this.setState({
                    places: data.data,
                    isPending: false
                })
            })
            .catch(err => {
                console.log(err)
                this.setState({
                    isPending: false
                })
            })
    }

    select = place => {
        this.setState({
            selected: place
        })
    }

    goForward = () => {
        API
            .put('/seats/' + this.state.selected.id)
            .then(data => {
                this.setState({
                    result: data.data
                })
            })
            .catch(err => console.log(err))
    }

    goBack = () => {
        this.props.history.goBack()
    }


    render() {

        const { classes } = this.props

        const { isPending, result } = this.state

        if (isPending) return <Progress />

        if (result) return (
            <div
                style={{
                    maxWidth: '500px',
                    margin: "auto",
                    textAlign: "center"
                }}
            >
                <h1>
                    Вітаємо! Ви забронювали квиток з кодовим номером <b>{result.id}</b>!
                    Ваше місце <b1>{result.seatId}</b1>
                </h1>
                <h4>
                    Щоб використати бронювання, покажіть кодовий номер при оплаті квитка в кінотеатрі.
                </h4>
                <Button
                    fullWidth
                    style={{
                        margin: "0.2em 0"
                    }}
                    color="secondary"
                    variant="outlined"
                    onClick={this.goBack}
                >
                    Назад
                </Button>
            </div>
        )

        return (
            <div
                style={{
                    display: "flex",
                    flexDirection: "row",
                    justifyContent: "center",
                    marginTop: "5em"
                }}
            >
                <div
                    style={{
                        display: "grid",
                        gridTemplateColumns: "1fr 1fr 1fr 1fr 1fr 1fr",
                        gridTemplateRows: "1fr 1fr 1fr 1fr 1fr 1fr",
                        gridGap: "10px",
                        maxWidth: "350px",
                        outline: "px silver dotted",
                        padding: "1em"
                    }}
                >
                    {this.state.places.sort((a, b) => a.number - b.number).map((place, i) => (
                        <ButtonBase
                            disabled={!place.isFree}
                            onClick={() => this.select(place)}
                            style={{
                                display: "inline-block",
                                width: "3em",
                                height: "3em",
                                background: (!place.isFree ? "rgb(255,90,90)" : this.state.selected.id === place.id ? "rgb(0,255,0)" : "silver")
                            }}
                        >
                            <b>{place.number}</b>
                        </ButtonBase>
                    ))}
                </div>
                <Paper
                    style={{
                        padding: "1em",
                        margin: "2em",
                        minWidth: "200px",
                        display: 'flex',
                        flexDirection: "column",
                        justifyContent: "flex-start",
                        alignItems: "center",
                    }}
                >
                    <Typography
                        variant="body2"
                    >
                        Обране місце:
                    </Typography>
                    <div
                        style={{
                            width: "3em",
                            height: "3em",
                            margin: "1em",
                            display: "flex",
                            justifyContent: "center",
                            alignItems: "center",
                            background: "rgb(0,255,0)"
                        }}
                    >
                        {this.state.selected.number}
                    </div>
                    <Typography
                        variant="body2"
                    >
                        Вартість:
                    </Typography>
                    <div
                        style={{
                            width: "3em",
                            height: "3em",
                            display: "flex",
                            justifyContent: "center",
                            alignItems: "center",
                        }}
                    >
                        {this.state.selected.price} $
                    </div>
                    <Button
                        fullWidth
                        style={{
                            margin: "0.2em 0"
                        }}
                        color="primary"
                        variant="outlined"
                        onClick={this.goForward}
                        disabled={!this.state.selected}
                    >
                        Бронювати
                    </Button>
                    <Button
                        fullWidth
                        style={{
                            margin: "0.2em 0"
                        }}
                        color="secondary"
                        variant="outlined"
                        onClick={this.goBack}
                    >
                        Назад
                    </Button>
                </Paper>
            </div>
        )
    }
}

export default withStyles(styles, { withTheme: true })(PlacesPage)