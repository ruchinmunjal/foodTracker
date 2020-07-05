import Vue from 'vue'
import Router from 'vue-router'
import Auth from '@okta/okta-vue'
import Hello from '@/components/Hello'


Vue.use(Auth,{
  issuer:'https://teenbhaiinc.okta.com/oauth2/default',
  client_id:'0oajdom8aXOXThUhm4x6',
  redirect_uri:'http://localhost:8080/implicit/callback',
  scope:'openid proile email'
})

Vue.use(Router)
let router= new Router({
  mode:'history',
  routes: [
    {
      path: '/',
      name: 'Hello',
      component: Hello
    },{
      path:'/implicit/callback',
      component:Auth.handleCallback()
    }
  ]
})

router.beforeEach(Vue.prototype.$auth.authRedirectGuard())

export default router
