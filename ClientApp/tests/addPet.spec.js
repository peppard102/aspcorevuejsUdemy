import { shallowMount } from '@vue/test-utils'
import AddPet from '@/components/PetClinic/AddPet.vue'
import { createLocalVue } from '@vue/test-utils'

import BootstrapVue from 'bootstrap-vue'


// create an extended `Vue` constructor
const localVue = createLocalVue()

// install plugins as normal
localVue.use(BootstrapVue)

describe('AddPet.vue', () => {
    it('renders props.msg when passed', () => {
        const msg = 'new message'
        const wrapper = shallowMount(AddPet, {
            localVue
        })
        expect(wrapper.text()).toMatch('Add New Pet')
    })
})
