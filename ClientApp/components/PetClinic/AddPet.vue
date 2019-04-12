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
                Item: {},
                showAlert: false,
            }
        },
        methods: {
            onSubmit: function (evt) {
                evt.preventDefault()
                let self = this;

                try {
                    self.$http.post('/api/Pet', self.Item).then(result => {
                        self.showAlert = true;

                        setTimeout(function () {
                            self.showAlert = false;
                        }, 3000);

                        self.Item = {};
                    });
                    
                } catch (error) {
                    console.log(error)
                }
            }
        }
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
