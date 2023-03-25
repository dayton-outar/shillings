export default {
    fileApiHost: (process.env.NODE_ENV == 'production' ? 'http://harpoon-service:5000/files' : `http://localhost:5000/files`)
}