<template>
    <div>
        <h1>Add New Pet</h1>
        <hr />
        <b-form @submit="onSubmit">
            <b-form-group id="input-group-2" label="Name:" label-for="input-2">
                <b-form-input id="input-2"
                              v-model="Item.name"
                              required
                              placeholder="Enter the pet's name"></b-form-input>
            </b-form-group>

            <b-button type="submit" variant="primary">Submit</b-button>
        </b-form>
        <br />
        <transition name="fade">
            <div class="alert alert-success" v-if="showAlert">
                You have successfully added the pet!
            </div>
        </transition>
    </div>
</template>

<script>
    export default {
        data() {
            return {
                Item: {}
            }
        },
        methods: {
            onSubmit: function (evt) {
                evt.preventDefault()

                try {
                    this.$http.post('/api/Pet', this.Item).then(result => {
                        this.showAlert = true;

                        setTimeout(function () {
                            self.showAlert = false;
                        }, 3000);

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
