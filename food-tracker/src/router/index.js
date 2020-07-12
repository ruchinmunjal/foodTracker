import Vue from 'vue';
import Router from 'vue-router';
import Auth from '@okta/okta-vue';
import Hello from '@/components/Hello';
import FoodRecords from '@/components/FoodRecords';

Vue.use(Router);
Vue.use(Auth,{
  issuer:'https://dev-400262.okta.com/oauth2/default',
  clientId:'0oajdom8aXOXThUhm4x6',
  redirectUri:'http://localhost:8080/implicit/callback',
  scopes: ['openid', 'profile', 'email'],
  pkce: true
});


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
    },
    {
      path: '/food-records',
      name: 'FoodRecords',
      component: FoodRecords,
      meta: {
        requiresAuth: true
      }
    },
  ]
});

router.beforeEach(Vue.prototype.$auth.authRedirectGuard());

export default router;
