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
            return new Intl.NumberFormat('en-JM', { style: 'currency', currency: 'JMD', currencyDisplay: 'symbol', currencySign: 'accounting' }).format(amt)
        }
    }
}