//import HomePage from 'components/home-page'
//import Routes from 'components/Routes'
//import Child from 'components/Child/Child'
import ListRendering from 'components/Advanced/ListRendering'
import Computed from 'components/Advanced/Computed'
import Mixins from 'components/Advanced/Mixins'
import Custom from 'components/Deep/Custom'
import Transition from 'components/Deep/Transition'
import Filters from 'components/Deep/Filters'
import Vuex from 'components/Deep/Vuex'
import AddPet from 'components/PetClinic/AddPet'
import AddVet from 'components/PetClinic/AddVet'
import AddAppointment from 'components/PetClinic/AddAppointment'
import ViewAppointments from 'components/PetClinic/ViewAppointments'

export const routes = [
    { path: '/', component: ViewAppointments, display: 'View Appointments', style: 'glyphicon glyphicon-home' },
    { path: '/PetClinic/AddPet', component: AddPet, display: 'Add Pet', style: 'glyphicon glyphicon-duplicate' },
    { path: '/PetClinic/AddVet', component: AddVet, display: 'Add Vet', style: 'glyphicon glyphicon-duplicate' },
    { path: '/PetClinic/AddAppointment', component: AddAppointment, display: 'Add Appointment', style: 'glyphicon glyphicon-duplicate' },
    //{
    //    path: '/Routes',
    //    component: Routes,
    //    display: 'Routes',
    //    style: 'glyphicon glyphicon-sort',
    //    children: [
    //        { path: 'Child/:id', component: Child }
    //    ]
    //},
    {
        path: '/Advanced/ListRendering',
        component: ListRendering
    },
    {
        path: '/Advanced/Computed',
        component: Computed
    },
    {
        path: '/Advanced/Mixins',
        component: Mixins
    }
    ,
    {
        path: '/Deep/Custom',
        component: Custom
    } ,
    {
        path: '/Deep/Transition',
        component: Transition
    },
    {
        path: '/Deep/Filters',
        component: Filters
    },
    {
        path: '/Deep/Vuex',
        component: Vuex
    }
];
