<template>
  <div id="register-page">
    <h1 class="dela">
      Register
    </h1>
   
    <div class="register">

      <span v-if="success" class="success dela">You have registered, please login <router-link to="/login">here</router-link></span>
      <span v-if="error" class="error dela">{{error}}</span>
      <h4 class="dela">Email</h4>
      <input v-model="email"/>

      <h4 class="dela">First Name</h4>
      <input v-model="firstName"/>

      <h4 class="dela">Last Name</h4>
      <input v-model="lastName"/>

      <h4 class="dela">Password</h4>
      <input v-model="password"/>

      <h4 class="dela">Date of Birth</h4>
      <Datepicker v-model="dob"></Datepicker>

      <button class="dela" @click="register">Register</button>
    </div>
  </div>
</template>

<script lang="ts">
import Vue from 'vue';
import { storeModule } from "../../store/StoreModule";
import UserModel from "../../models/UserModel";
import UserService from '../../api/UserService'
import Datepicker from 'vuejs-datepicker';

export default Vue.extend({
  components: {
    Datepicker
  },
  data () {
    return {
      email: "",
      password: "",
      error:"",
      firstName:"",
      lastName: "",
      dob: new Date(),
      success: false
    }
  },
  methods: {
    
    async register(): Promise<void> {
      let user = new UserModel()
      user.Email = this.email
      user.Password = this.password
      user.DateOfBirth = this.dob
      user.FirstName = this.firstName;
      user.LastName = this.lastName;
      let response = await UserService.register(user);
      if (response.data == "error") {
        this.error = "Error, try again"
      } else {
        let user = response.data as UserModel;
        this.success = true;
        this.error = "";
      }
    }
  }
});
</script>

<style lang="css" scoped>

h1 {
  font-size: 40px;
}

#register-page {
  
}

.register {
margin: auto;

}

.error {
  color: red;
}

.success {
  color:green;
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
