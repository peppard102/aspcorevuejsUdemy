<template>
    <div>
        <h1>Add New Appointment</h1>
        <hr />
        <b-form @submit="onSubmit" v-if="show">

            <b-form-group label="Select a Date:" label-for="apptDate">
                <Datepicker id="apptDate" :value="form.date" v-model="form.date" :disabledDates="disabledDates" @closed="onChange"></Datepicker>
            </b-form-group>

            <b-form-group id="input-group-3" label="Select a pet:" label-for="input-3">
                <b-form-select class="form-control" id="input-3"
                               v-model="form.pet"
                               :options="this.petsList"
                               required></b-form-select>
            </b-form-group>

            <b-form-group id="input-group-3" label="Select a vet:" label-for="input-3">
                <b-form-select class="form-control" id="input-3"
                               v-model="form.vet"
                               :options="this.vetsList"
                               required
                               @change="onChange"></b-form-select>
            </b-form-group>

            <b-form-group id="input-group-3" label="Select an appointment length:" label-for="input-3">
                <b-form-select class="form-control" id="input-3"
                               v-model="form.apptLength"
                               :options="this.apptLengthOptions"
                               required
                               @change="onChange"></b-form-select>
            </b-form-group>

            <b-form-group id="input-group-3" label="Select a time:" label-for="input-3">
                <b-form-select class="form-control" id="input-3"
                               v-model="form.apptTime"
                               :options="this.apptTimeOptions"
                               required></b-form-select>
            </b-form-group>

            <b-button type="submit" variant="primary">Submit</b-button>
        </b-form>
        <br />
        <transition name="fade">
            <div class="alert alert-success" v-if="showAlert">
                You have successfully added the appointment!
            </div>
        </transition>
    </div>
</template>

<script>
    import Datepicker from 'vuejs-datepicker';
    import axios from 'axios'
    import moment from 'moment'

    export default {
        components: {
            Datepicker
        },
        data() {
            return {
                form: {
                    date: moment().format('L'),
                    pet: null,
                    vet: null,
                    apptLength: null,
                    apptTime: null,
                },
                show: true,
                petsList: [],
                vetsList: [],
                apptLengthOptions: [],
                apptTimeOptions: [],
                disabledDates: {
                    to: moment().add(-1, 'd').toDate(), // Disable all dates before today
                    days: [6, 0] // Disable weekends 
                    //days: [0] // Disable weekends 
                },
                showAlert: false,
            }
        },
        methods: {
            onSubmit(evt) {
                evt.preventDefault()
                let self = this;
                let selectedDate = moment(self.form.date).format('L') // Get only the date part
                let startTime = moment(selectedDate + ' ' + self.form.apptTime); // Add the selected time to the selected date
                let endTime = moment(startTime).add(self.form.apptLength, 'm').toDate(); // Add the appt length to the start time to get the end time
                
                axios.post('/api/appointment', {
                    PetId: self.form.pet,
                    VetId: self.form.vet,
                    StartTime: startTime,
                    EndTime: endTime,
                })
                .then(result => {
                    return axios.post('/api/appointment/timeOptions', { VetId: self.form.vet, Date: self.form.date, lengthOfAppt: self.form.apptLength });
                })
                .then(result => {
                    self.apptTimeOptions = result.data.map((item) => { return { value: item, text: item } });
                    self.apptTimeOptions.unshift({ value: null, text: 'Please select an option' });

                    if (self.apptTimeOptions.Length != 0)
                        self.form.apptTime = self.apptTimeOptions[0].value;

                    this.showAlert = true;

                    setTimeout(function () {
                        self.showAlert = false
                    }, 3000);
                })
            },
            onChange(evt) {
                let self = this;
                axios.post('/api/appointment/timeOptions', { VetId: self.form.vet, Date: self.form.date, lengthOfAppt: self.form.apptLength })
                    .then(result => {
                        self.apptTimeOptions = result.data.map((item) => { return { value: item, text: item } });
                        self.apptTimeOptions.unshift({ value: null, text: 'Please select an option' });

                        if (self.apptTimeOptions.Length != 0)
                            self.form.apptTime = self.apptTimeOptions[0].value;
                    })
            },
            LoadData: function () {
                this.setDefaultDate();
                try {
                    let self = this;

                    function getVets() {
                        return axios.get('/api/vet')
                    }

                    function getPets() {
                        return axios.get('/api/pet');
                    }

                    function getApptLengths() {
                        return axios.get('/api/appointment/lengthOptions');

                    }

                    axios.all([getPets(), getVets(), getApptLengths()])
                        .then(axios.spread(function (petsResult, vetsResult, ApptLengthsResult) {
                            self.petsList = petsResult.data.map((item) => ({ value: item.id, text: item.name }));
                            self.vetsList = vetsResult.data.map((item) => ({ value: item.id, text: item.name }));
                            self.apptLengthOptions = ApptLengthsResult.data.map((item) => ({ value: item.lengthInMinutes, text: item.lengthInMinutes }));

                            // Set defaults
                            if (self.petsList.Length != 0)
                                self.form.pet = self.petsList[0].value;

                            if (self.vetsList.Length != 0) 
                                self.form.vet = self.vetsList[0].value;

                            if (self.apptLengthOptions.Length != 0)
                                self.form.apptLength = self.apptLengthOptions[0].value;

                            return axios.post('/api/appointment/timeOptions', { VetId: self.form.vet, Date: self.form.date, lengthOfAppt: self.form.apptLength });
                        })).then(result => {
                            self.apptTimeOptions = result.data.map((item) => { return { value: item, text: item } });
                            self.apptTimeOptions.unshift({ value: null, text: 'Please select an option' });

                            if (self.apptTimeOptions.Length != 0)
                                self.form.apptTime = self.apptTimeOptions[0].value;
                        });

                } catch (error) {
                    console.log(error);
                }
            },
            setDefaultDate: function () {
                var defaultDate = moment();
                var day = defaultDate.day();
                if (day == 0)
                    defaultDate.add(1, 'd').toDate()
                else if (day == 6)
                    defaultDate.add(2, 'd').toDate()

                this.form.date = defaultDate.format('L')
            }
        },
        created() {
            this.LoadData();
        },
    }
</script>

<style>
    .fade-enter {
        opacity: 0;
    }

    .fade-enter-active {
        transition: opacity 2s;
    }

    .fade-leave-active {
        transition: opacity 2s;
        opacity: 0;
    }

    .alert-success {
        color: #155724;
        background-color: #d4edda;
        border-color: #c3e6cb;
    }
</style>
