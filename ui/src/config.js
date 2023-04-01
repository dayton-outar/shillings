export default {
    fileApiHost: (process.env.NODE_ENV == 'production' ? `http://45-79-244-66.ip.linodeusercontent.com:5000/files` : `http://localhost:5000/files`)
}