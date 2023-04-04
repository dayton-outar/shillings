export default {
    fileApiHost: (process.env.NODE_ENV == 'production' ? `https://api.shillings.info/files` : `http://localhost:5000/files`)
}