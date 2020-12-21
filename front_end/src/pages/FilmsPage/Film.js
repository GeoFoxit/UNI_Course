//React
import React, { Component } from 'react'
//MaterialUI
import withStyles from '@material-ui/core/styles/withStyles'
import Rating from '@material-ui/lab/Rating';
import { Button, Card, CardActionArea, CardActions, CardContent, CardMedia, Typography } from '@material-ui/core'

const styles = (theme) => ({})

class Film extends Component {

    handleClick = () => {
        const { history, film } = this.props

        history.push('/films/' + film.id)
    }


    render() {

        const { classes, film } = this.props

        const naming = film.naming.replace(" ", ",");

        return (
            <Card
                style={{
                    height: "18em",
                    width: "31.4%",
                    margin: "0.5em",
                    minWidth: "200px"
                }}
            >
                <CardActionArea
                    onClick={this.handleClick}
                    style={{
                        display: "flex",
                        flexDirection: "column",
                        justifyContent: 'start',
                        height: "100%"
                    }}
                >
                    <CardMedia
                        style={{
                            width: "100%",
                            height: "10em"
                        }}
                        title={film.naming}
                        image={"https://source.unsplash.com/1600x900/?" + naming}
                    />
                    <CardContent
                        style={{
                            width: "100%"
                        }}
                    >
                        <Typography
                            gutterBottom
                            variant='h6'
                            component='h2'
                            style={{
                                textAlign: "left"
                            }}
                        >
                            {film.naming}
                        </Typography>
                        <Rating size="small" name="read-only" value={film.rate} readOnly />
                    </CardContent>
                </CardActionArea>
            </Card>
        )
    }
}

export default withStyles(styles, { withTheme: true })(Film)