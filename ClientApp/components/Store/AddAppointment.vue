<template>
    <div>
        <h1>Add New Appointment</h1>
        <hr />
        <b-form @submit="onSubmit" @reset="onReset" v-if="show">
            <b-form-group id="input-group-1"
                          label="Email address:"
                          label-for="input-1"
                          description="We'll never share your email with anyone else.">
                <b-form-input id="input-1"
                              v-model="form.email"
                              type="email"
                              required
                              placeholder="Enter email"></b-form-input>
            </b-form-group>

            <b-form-group id="input-group-2" label="Your Name:" label-for="input-2">
                <b-form-input id="input-2"
                              v-model="form.name"
                              required
                              placeholder="Enter name"></b-form-input>
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
                               required></b-form-select>
            </b-form-group>

            <b-form-group id="input-group-4">
                <b-form-checkbox-group v-model="form.checked" id="checkboxes-4">
                    <b-form-checkbox value="me">Check me out</b-form-checkbox>
                    <b-form-checkbox value="that">Check that out</b-form-checkbox>
                </b-form-checkbox-group>
            </b-form-group>

            <b-button type="submit" variant="primary">Submit</b-button>
            <b-button type="reset" variant="danger">Reset</b-button>
        </b-form>
    </div>
</template>

<script>
    export default {
        data() {
            return {
                form: {
                    email: '',
                    name: '',
                    pet: null,
                    vet: null,
                    checked: []
                },
                foods: [{ text: 'Select One', value: null }, 'Carrots', 'Beans', 'Tomatoes', 'Corn'],
                show: true,
                msg: 'Add Pet',
                petsList: [],
                vetsList: []
            }
        },
        methods: {
            onSubmit(evt) {
                evt.preventDefault()
                alert(JSON.stringify(this.form))
            },
            onReset(evt) {
                evt.preventDefault()
                // Reset our form values
                this.form.email = ''
                this.form.name = ''
                this.form.pet = null
                this.form.vet = null
                this.form.checked = []
                // Trick to reset/clear native browser form validation state
                this.show = false
                this.$nextTick(() => {
                    this.show = true
                })
            },
            LoadData: function () {
                try {
                    this.$http.get('/api/pet').then(result => {
                        this.petsList = result.data.map((item) => ({ value: item.id, text: item.name }));
                        console.log(result);
                    });

                    this.$http.get('/api/vet').then(result => {
                        this.vetsList = result.data.map((item) => ({ value: item.id, text: item.name }));
                        if (this.vetsList.Length != 0)
                            this.form.vet = this.vetsList[0].value;
                        //console.log(this.vetsList);
                        //console.log(this.form.vet);
                    });

                } catch (error) {
                    console.log(error)
                }
            }
        },
        created() {
            this.LoadData();
        }
    }
</script>

<style>
</style>
