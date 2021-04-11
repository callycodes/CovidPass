<template>
  <div id="login-page">
    <h1 class="dela">
      Login
    </h1>
   
    <div class="login">

      <span v-if="error" class="error dela">{{error}}</span>
      <h4 class="dela">Email</h4>
      <input v-model="email"/>

      <h4 class="dela">Password</h4>
      <input v-model="password"/>

      <button class="dela" @click="login">Login</button>
    </div>
  </div>
</template>

<script lang="ts">
import Vue from 'vue';
import { storeModule } from "../../store/StoreModule";
import UserModel from "../../models/UserModel";
import UserService from '../../api/UserService'

export default Vue.extend({
  data () {
    return {
      email: "",
      password: "",
      error:""
    }
  },
  methods: {
    
    async login(): Promise<void> {
      let response = await UserService.login(this.email, this.password)
      if (response.data == "error") {
        this.error = "Invalid credentials"
      } else {
        let user = response.data as UserModel;
        storeModule.setUser(user);
        this.$router.push('/')
      }
    }
  }
});
</script>

<style lang="css" scoped>

h1 {
  font-size: 40px;
}

#login-page {
  
}

.login {
margin: auto;

}

.error {
  color: red;
}

h4 {
  font-size: 30px;
  margin-bottom: 0px;
  margin-top: 20px;
}

input {
  border: 3px solid;
  color: var(--jet);
  background-color: rgba(0, 0, 0, 0);
  font-size: 30px;
  margin-bottom: -10px;
  width: 100%;
  max-width: 500px;
  min-width: 300px;
}

button {
  margin-top: 40px;
  width: 300px;
  color: black;
  background-color: rgba(0, 0, 0, 0);
  border: 3px solid;
  box-shadow: none;
  font-size: 30px;
  margin-bottom: 5px;
}

</style>
