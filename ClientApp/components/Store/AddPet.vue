<template>
    <div>
        <h1>{{msg}}</h1>
        <div class="form-horizontal">
            <fieldset>

                <!-- Form Name -->
                <legend>Add New Pet</legend>

                <!-- Text input-->
                <div class="form-group">
                    <label class="col-md-4 control-label" for="textinput">Name</label>
                    <div class="col-md-4">
                        <input v-model="Item.Name" placeholder="Mouse, Keyborad, etc." class="form-control input-md" type="text">

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
                msg: 'Add Pet',
                Item: {}
            }
        },
        methods: {
            AddData: function () {
                try {
                    this.$http.post('/api/Pet', this.Item).then(result => {
                        console.log(result);
                        alert(`Pet ${result.data.name} has been added successfully`);
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
