import _ from 'lodash'
import moment from 'moment'

export default {
    methods: {
        formatTitleCase(plain) {
            return _.startCase(plain.toLowerCase().replace('_', ' '))
        },
        formatDate(stmtDate, format) {
            return moment(stmtDate).format(format)
        },
        formatMoney(amount) {
            const cfi = new Intl.NumberFormat('en-US', { style: 'currency', currency: 'USD' })
            return cfi.format(amount)
        }
    }
}