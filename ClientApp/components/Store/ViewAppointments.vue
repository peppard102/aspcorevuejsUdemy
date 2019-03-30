<template>
    <div>
        <h1>View Appointments</h1>
        <hr />
        <b-table :items="items" :fields="fields" class="my-table-scroll" striped>
            <template slot="actions" slot-scope="data">
                <b-button size="sm" @click="CancelAppointment(data.item.id)" class="mr-2">
                    Cancel Appointment
                </b-button>
            </template>
        </b-table>
    </div>
</template>

<script>
    import axios from 'axios'

    export default {
        data() {
            return {
                fields: [
                    { key: 'vetName', sortable: true },
                    { key: 'petName', sortable: true },
                    { key: 'startTime', sortable: true },
                    { key: 'endTime', sortable: true },
                    { key: 'actions' },
                ],
                items: []
            }
        },
        methods: {
            LoadData: function () {
                axios.get('/api/appointment/GetGrid').then((results) => {
                    this.items = results.data;
                })
            },
            CancelAppointment: function (id) {
                axios.delete('/api/appointment/' + id).then((results) => {
                    const index = this.items.findIndex(item => item.id === id) // Find the index of the appointment
                    if (index != -1) // If found
                        this.items.splice(index, 1) // Remove the appointment from the grid
                })
            },
        },
        created() {
            this.LoadData();
        }
    }
</script>
<style>
    /*table.my-table-scroll,
    table.my-table-scroll > thead,
    table.my-table-scroll > tbody,
    table.my-table-scroll > tfoot,
    table.my-table-scroll > tbody > tr,
    table.my-table-scroll > thead > tr {
        width: 100%;
        display: block;
    }*/

        /*table.my-table-scroll > thead,
        table.my-table-scroll > tbody,
        table.my-table-scroll > tfoot {
            display: block;
            width: 100%;
            overflow-y: scroll;
        }*/

        /*table.my-table-scroll > thead,
        table.my-table-scroll > tfoot {
            height: auto;
        }

        table.my-table-scroll > tbody {
            max-height: 135px;
        }

            table.my-table-scroll > thead > tr > th,
            table.my-table-scroll > thead > tr > td,
            table.my-table-scroll > tbody > tr > th,
            table.my-table-scroll > tbody > tr > td,
            table.my-table-scroll > tfoot > tr > th,
            table.my-table-scroll > tfoot > tr > td {
                display: inline-block;
                width: 25%;
            }*/

</style>
