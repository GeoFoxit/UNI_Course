import CircularProgress from '@material-ui/core/CircularProgress'


const Progress = () => (
    <div
        style={{
            display: "inline-block",
            position: "absolute",
            top: "50%",
            left: "50%",
            transform: "translate(-50%,-50%)"
        }}
    >
        <CircularProgress size={100} />
    </div>
)

export default Progress