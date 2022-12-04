import Vue from 'vue'
import Router from 'vue-router'

import Auth from '@okta/okta-vue'

import Hello from '@/components/Hello'
import FoodRecords from '@/components/FoodRecords'

Vue.use(Auth, {
  issuer: 'https://dev-65498888.okta.com/oauth2/default',
  client_id: '0oa7i5ytj0Dqfhk9a5d7',
  redirect_uri: 'http://localhost:8080/implicit/callback',
  scope: 'openid profile email'
})

Vue.use(Router)

let router = new Router({
  routes: [
    {
      path: '/',
      name: 'Hello',
      component: Hello
    },
    {
      path: '/food-records',
      name: 'FoodRecords',
      component: FoodRecords,
      meta: {
        requiresAuth: true
      }
    },
    {
      path: '/implicit/callback',
      component: Auth.handleCallback()
    }
  ]
})

router.beforeEach(Vue.prototype.$auth.authRedirectGuard())

export default router
