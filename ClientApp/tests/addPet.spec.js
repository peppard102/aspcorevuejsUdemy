import { shallowMount } from '@vue/test-utils'
import { mount } from '@vue/test-utils'
import AddPet from '@/components/PetClinic/AddPet.vue'
import { createLocalVue } from '@vue/test-utils'
import BootstrapVue from 'bootstrap-vue'


// create an extended `Vue` constructor
const localVue = createLocalVue()

// install plugins as normal
localVue.use(BootstrapVue)

describe('AddPet.vue', () => {
    const wrapper = mount(AddPet, {
        localVue
    })

    it('Displays correct title', () => {
        expect(wrapper.text()).toMatch('Add New Pet')
    })

    it('has a button', () => {
        expect(wrapper.contains('button')).toBe(true)
    })

    test('renders correctly', () => {
        expect(wrapper.element).toMatchSnapshot()
    })
})
