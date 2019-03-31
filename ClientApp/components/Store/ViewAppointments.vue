<template>
    <div>
        <h1>View Appointments</h1>
        <hr />
        <b-form-input v-model="filter" placeholder="Type to Search"></b-form-input>
        <br />
        <b-table :items="items" :fields="fields" :filter="filter" class="my-table-scroll" striped>
            <template slot="actions" slot-scope="data">
                <b-button size="sm" @click="deleteClicked(data.item.id)">
                    Delete Appointment
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
                items: [],
                filter: null,
            }
        },
        methods: {
            loadData: function () {
                axios.get('/api/appointment/GetGrid').then((results) => {
                    this.items = results.data;
                })
            },
            deleteClicked: function (id) {
                if (confirm("Are you sure you would like to delete this appointment?"))
                    this.deleteAppointment(id);
            },
            deleteAppointment: function (id) {
                axios.delete('/api/appointment/' + id).then((results) => {
                    const index = this.items.findIndex(item => item.id === id) // Find the index of the appointment
                    if (index != -1) // If found
                        this.items.splice(index, 1) // Remove the appointment from the grid
                })
            },
        },
        created() {
            this.loadData();
        }
    }
</script>
<style>
</style>
