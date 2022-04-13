import { createRouter, createWebHistory } from "vue-router"
import Home from '../views/HomePage.vue'
import About from '../views/AboutPage.vue'
import Registration from '../views/RegistrationPage.vue'
import Login from '../views/LoginPage.vue'
import Collections from '../views/CollectionsPage.vue'
import ManageCollection from '../views/ManageCollection.vue'
import NotFound from '../views/NotFoundPage.vue'

const routes = [
    {
        path: '/',
        name: 'Home',
        component: Home
    },
    {
        path: '/about',
        name: 'About',
        component: About
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
        component: Collections
    },
    //przechytywanie niepoprawnych url (404)
    {
        path: '/:catchAll(.*)',
        name: 'NotFound',
        component: NotFound
    },
    {
        path: '/collections/:collName',
        name: 'ManageCollection',
        component: ManageCollection,
        props: true
    }
]

const router = createRouter({
    history: createWebHistory(process.env.BASE_URL),
    routes
})

export default router