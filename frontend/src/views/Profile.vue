<template>
  <div id="profile-page">
  

        <h1 class="dela">Profile</h1>
        <h2 class="dela">First Name</h2>
        <input v-model="user.FirstName"/>

        <h2 class="dela">Last Name</h2>
        <input v-model="user.LastName"/>

        <h2 class="dela">Date of Birth</h2>
        <Datepicker v-model="user.DateOfBirth"></Datepicker>

        <button class="dela" @click="update">Update</button>
      
      

  </div>
</template>

<script lang="ts">
import Vue from 'vue';
import { storeModule } from "../store/StoreModule";
import UserService from '../api/UserService'
import Datepicker from 'vuejs-datepicker';
import UserModel from '../models/UserModel';

export default Vue.extend({
  data () {
    return {
      user: new UserModel()
    }
  },
  components: {
    Datepicker
  },
  mounted () {
    this.user = this.getUser();
  },
  methods: {
    getUser(): UserModel {
      return storeModule.getUser;
    },
    setUser(): void {
      storeModule.setUser(this.user);
    },
    async update(): Promise<void> {
      await UserService.update(this.user);
      this.setUser();
    },


  }
});
</script>

<style lang="css" scoped>

h1 {
  font-size: 40px;
}

h2 {
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
  margin-top: 5px;
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
