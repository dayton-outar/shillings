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
        formatDateUTC(stmtDate, format) {
            return moment.utc(stmtDate).format(format)
        },
        formatMoney(amount) {
            let amt = parseFloat(amount.toString().replace(/[^0-9.-]+/g,'')) || 0;
            return new Intl.NumberFormat('en-JM', { style: 'currency', currency: 'JMD', currencyDisplay: 'symbol', currencySign: 'accounting' }).format(amt)
        },
        formatPercentage(percentage) {
            return `${ parseFloat(percentage).toFixed(2) }%`
        },
        formatVolume(volume) {
            const nfi = new Intl.NumberFormat('en-US')
            return nfi.format(volume)
        },
        // --
        getLogo(fileContents) {
            return fileContents.filter(f => f.type === "LOGO");
        },
        convertToDate(date) {
            return moment(date).toDate()
        }
    }
}