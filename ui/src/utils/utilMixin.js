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
            let amt = parseFloat(amount.toString().replace(/[^0-9.-]+/g,'')) || 0;
            const cfi = new Intl.NumberFormat('en-US', { style: 'currency', currency: 'USD' })
            return cfi.format(amt)
        }
    }
}