export default { // Credit: https://youtu.be/LyG_l5UoeHI
    data() {
        return {
            sort: ['name', 'asc'],
            sortIcon: 'arrow-up',
            sortIconSize: 'is-small',
            searchWord: '',
            page: 10,
            pageLengths: [10, 20, 50, 100],
            currentPage: 1,
            forward: true,
            isCreatePanelActive: false,
            isLoading: false,
            filterQuery: null,
            fetchTitle: '[Fetching Data]',
            deleteTitle: '[Delete Data]'
        }
    },
    created() {
        this.get()
    },
    methods: {
        get() {
            this.isLoading = true

            this.fetch({
                first: this.page,
                last: null,
                next: null,
                previous: null,
                filter: this.filterQuery,
                ordering: [{ [this.sort[0]]: this.sort[1].toUpperCase() }]
            }).then(() => {
                this.isLoading = false
                this.currentPage = 1
            }).catch(err => {
                this.isLoading = false

                this.$buefy.dialog.alert({
                    title: this.fetchTitle,
                    message: `${err.message}`,
                    confirmText: 'OK',
                    type: 'is-danger',
                    hasIcon: true,
                    iconPack: 'fas',
                    icon: 'bug',
                    onConfirm: () => {
                        this.isLoading = false
                    }
                })
            })
        },
        find(q) {
            this.searchWord = q.searchWord
            this.filterQuery = { name: { startsWith: this.searchWord } }
            this.get()
        },
        create() {
            this.isCreatePanelActive = true
        },
        close(e) {
            this.isCreatePanelActive = false

            if (e === 'created') {
                //this.get()
            }
        },
        deleteRow(row) {

            this.$buefy.dialog.confirm({
                title: this.deleteTitle,
                message: `<p>Are you sure you want to <b>delete</b> ${row.name}?</p><p>This action cannot be undone.</p>`,
                confirmText: 'OK',
                type: 'is-warning',
                hasIcon: true,
                iconPack: 'fas',
                icon: 'circle-exclamation',
                onConfirm: () => {
                    this.isLoading = true

                    this.delete(row)
                        .then(success => {
                            this.isLoading = false

                            if (success) {
                                this.$buefy.dialog.alert({
                                    title: this.deleteTitle,
                                    message: `Successfully deleted ${row.name}`,
                                    confirmText: 'OK',
                                    type: 'is-success',
                                    hasIcon: true,
                                    iconPack: 'fas',
                                    icon: 'circle-check',
                                    onConfirm: () => {
                                        this.$emit('close')
                                        //this.get()
                                    }
                                })
                            } else {
                                this.$buefy.dialog.alert({
                                    title: this.deleteTitle,
                                    message: `Failed to delete ${row.name}`,
                                    confirmText: 'OK',
                                    type: 'is-danger',
                                    hasIcon: true,
                                    iconPack: 'fas',
                                    icon: 'bomb'
                                })
                            }
                        })
                        .catch(err => {
                            this.isLoading = false

                            this.$buefy.dialog.alert({
                                title: this.deleteTitle,
                                message: `${err.message}`,
                                confirmText: 'OK',
                                type: 'is-danger',
                                hasIcon: true,
                                iconPack: 'fas',
                                icon: 'bug'
                            })
                        })
                }
            })

        },
        sortTable(field, order) {
            this.sort = [field, order]

            this.get()
        },
        pageChange(page) { // Credit: https://github.com/buefy/buefy/issues/50
            this.isLoading = true

            this.forward = (page > this.currentPage)

            this.fetch({
                first: this.forward ? this.page : null,
                last: !this.forward ? this.page : null,
                next: this.forward ? this.data.pageInfo.endCursor : null,
                previous: !this.forward ? this.data.pageInfo.startCursor : null,
                filter: this.filterQuery,
                ordering: [{ [this.sort[0]]: this.sort[1].toUpperCase() }]
            }).then(() => {
                this.isLoading = false
                this.currentPage = page
            }).catch(err => {
                this.isLoading = false

                this.$buefy.dialog.alert({
                    title: this.fetchTitle,
                    message: `${err.message}`,
                    confirmText: 'OK',
                    type: 'is-danger',
                    hasIcon: true,
                    iconPack: 'fas',
                    icon: 'triangle-exclamation',
                    onConfirm: () => {
                        this.isLoading = false
                    }
                })
            })
        },
        changeLen(l) {
            this.page = l

            this.get()
        }
    }
}