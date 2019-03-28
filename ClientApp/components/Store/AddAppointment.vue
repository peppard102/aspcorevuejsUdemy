<template>
    <div>
        <b-col cols="1">
            <b-form>
                <b-form-group class="form-group col-sm-12 col-md-6">
                    <b-form-select v-model="SelectedVet" :options="vetsList" />
                </b-form-group>
            </b-form>
            </b-col>

            <h1>{{msg}}</h1>
            <div class="form-horizontal">
                <fieldset>

                    <!-- Form Name -->
                    <legend>Add New Appointment</legend>

                    <!-- Text input-->
                    <div class="form-group col-sm-12 col-md-6">
                        <label class="control-label" for="textinput">Name</label>
                        <div class="">
                            <input v-model="Item.Name" placeholder="Mouse, Keyborad, etc." class="form-control input-md" type="text">

                        </div>
                        <br />
                        <label for="exampleFormControlSelect1">Select a vet: </label>
                        <select class="form-control" id="exampleFormControlSelect1">
                            <option>1</option>
                            <option>2</option>
                            <option>3</option>
                            <option>4</option>
                            <option>5</option>
                        </select>
                        <br />
                        <label for="exampleFormControlSelect1">Select a time:</label>
                        <select class="form-control" id="exampleFormControlSelect1">
                            <option>1</option>
                            <option>2</option>
                            <option>3</option>
                            <option>4</option>
                            <option>5</option>
                        </select>
                        <br />
                        <b-form-select v-model="SelectedVet" :options="vetsList" />
                        <br />
                        <label class="control-label" for=""></label>
                        <div>
                            <button @click="AddData()" class="btn btn-primary">Add</button>
                        </div>
                    </div>

                    <!-- Button -->
                    <!--<div class="form-group">
                    <label class="col-md-4 control-label" for=""></label>
                    <div class="col-md-4">
                        <button @click="AddData()" class="btn btn-primary">Add</button>
                    </div>
                </div>-->


                </fieldset>
            </div>


    </div>
</template>

<script>
    import 'bootstrap/dist/css/bootstrap.css'
    import 'bootstrap-vue/dist/bootstrap-vue.css'
    export default {
        data() {
            return {
                msg: 'Add Appointment',
                Item: {},
                SelectedVet: {},
                vetsList: []
            }
        },
        methods: {
            AddData: function () {
                try {
                    this.$http.post('/api/Appointment', this.Item).then(result => {
                        console.log(result);
                        alert(`Appointment ${result.data.name} has been added successfully`);
                        this.Item = {};
                    });
                    
                } catch (error) {
                    console.log(error)
                }
            },
            LoadVetsList: function () {
                try {
                    this.$http.get('/api/Vet').then(result => {
                        //this.vetsList = result.data.map(result => {
                        //    let vet = {};

                        //    vet[value] = result.id;
                        //    vet[text] = result.name;

                        //    return vet;
                        //});
                        this.vetsList = result.data.map(result => ({ value: result.id, text: result.name }));

                        console.log(result);
                    });

                } catch (error) {
                    console.log(error)
                }
            }
        },
        mounted() {
            this.LoadVetsList();
        }
    }
</script>

<style>
</style>
