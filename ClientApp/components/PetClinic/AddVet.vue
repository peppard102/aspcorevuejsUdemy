<template>
    <div>
        <h1>{{msg}}</h1>
        <div class="form-horizontal">
            <fieldset>

                <!-- Form Name -->
                <legend>Add New Vet</legend>

                <!-- Text input-->
                <div class="form-group">
                    <label class="col-md-4 control-label" for="textinput">First Name</label>
                    <div class="col-md-4">
                        <input v-model="Item.firstName" placeholder="Please enter the vet's first name" class="form-control input-md" type="text">

                    </div>
                </div>
                <div class="form-group">
                    <label class="col-md-4 control-label" for="textinput">Last Name</label>
                    <div class="col-md-4">
                        <input v-model="Item.lastName" placeholder="Please enter the vet's last name" class="form-control input-md" type="text">

                    </div>
                </div>

                <!-- Button -->
                <div class="form-group">
                    <label class="col-md-4 control-label" for=""></label>
                    <div class="col-md-4">
                        <button @click="AddData()" class="btn btn-primary">Add</button>
                    </div>
                </div>


            </fieldset>
        </div>


    </div>
</template>

<script>
    export default {
        data() {
            return {
                msg: 'Add Vet',
                Item: {}
            }
        },
        methods: {
            AddData: function () {
                try {
                    this.$http.post('/api/Vet', this.Item).then(result => {
                        console.log(result);
                        alert(`Item ${result.data.firstName} has been added successfully`);
                        this.Item = {};
                    });
                    
                } catch (error) {
                    console.log(error)
                }
            }
        }
    }
</script>

<style>

</style>
