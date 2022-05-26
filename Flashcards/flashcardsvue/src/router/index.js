import { createRouter, createWebHistory } from "vue-router"
import Home from '../views/HomePage.vue'
import Registration from '../views/RegistrationPage.vue'
import Login from '../views/LoginPage.vue'
import Collections from '../views/CollectionsPage.vue'
import ManageCollection from '../views/ManageCollection.vue'
import NotFound from '../views/NotFoundPage.vue'
import LearningMode from '../views/LearningMode.vue'
import SharedLearningMode from '../views/SharedLearningMode.vue'
import NoPermissionPage from '../views/NoPermissionPage.vue'


const routes = [
    {
        path: '/',
        name: 'Home',
        component: Home
    },
    {
        path: '/registration',
        name: 'Registration',
        component: Registration
    },
    {
        path: '/login',
        name: 'Login',
        component: Login
    },
    {
        path: '/collections',
        name: 'Collections',
        component: Collections,
        props: true,
    },
    //przechytywanie niepoprawnych url (404)
    {
        path: '/:catchAll(.*)',
        name: 'NotFound',
        component: NotFound
    },
    {
        path: '/collections/:collName-:collId',
        name: 'ManageCollection',
        component: ManageCollection,
        props: true
    },
    {
        path: '/collections/learn/:collName-:collId',
        name: 'LearningMode',
        component: LearningMode,
        props: true
    },
    {
        path: '/:collName-:collId-:admixture',
        name: 'SharedLearningMode',
        component: SharedLearningMode,
        props: true
    },
    {
        path: '/nopermission',
        name: 'NoPermissionPage',
        component: NoPermissionPage,
        
    }


]

const router = createRouter({
    history: createWebHistory(process.env.BASE_URL),
    routes
})

export default router