<template>
  <div id="navbar">

    <div class="exit-button">
      <slot></slot>
    </div>

    <h1 class="dela logo">
      CovidPass
    </h1>

    <ul>
      <li>
        <router-link to="/">
          Home
        </router-link>
      </li>
      <li>
        <router-link to="/log">
          Log
        </router-link>
      </li>
      <li>
        <router-link to="/passport">
          Passport
        </router-link>
      </li>
      <li>
        <router-link to="/profile">
          Profile
        </router-link>
      </li>
      <li>
        <router-link to="/scan">
          Scan
        </router-link>
      </li>
    </ul>

    <div id="profile">
      <div v-if="isUserLoggedIn()">
        <h3 class="dela logged-in-text">Logged in: {{getName()}}</h3>
        <button class="dela" @click="logout()">Logout</button>
      </div>

      <div class="links" v-else>
        <router-link to="/login">
          <button class="dela">Login</button>
        </router-link>
        <br>
        <router-link to="/register">
        <button class="dela">Register</button>
        </router-link>
      </div>
    </div>

  </div>
</template>

<script lang="ts">
import Vue from 'vue';
import { storeModule } from "../../store/StoreModule";

export default Vue.extend({
  data () {
    return {
      test: "",
    }
  },
  mounted () {
    console.log("nav");
  },
  methods: {
    logout(): void {
      storeModule.logout();
    },
    isUserLoggedIn(): boolean {
      return storeModule.isLoggedIn;
    },
    getName(): string {
      return storeModule.getUser.FirstName;
    }
  }
});
</script>

<style lang="css" scoped>
#navbar {
  top: 0px;
  left: 0px;
  position: fixed;
  width: 250px;
  height: 100%;
  background-color: var(--jet);
}

.logo {
  text-align: center;
  color: var(--pale-silver);
  margin: 50px 0px;
}

ul li {
  color: white;
  font-weight: 700;
  font-family: 'Roboto', sans-serif;
  font-size: 25px;
  margin-bottom: 5px;
  list-style-type: none;
}


a:hover, a:visited, a:link {
color: white;
    text-decoration: none!important;
}

a:active {
  color: var(--nickel);
  text-decoration: none!important;
}

#profile {
  position: absolute;
  bottom: 0px;
  left: 0px;
  width: 100%;
  background-color: var(--nickel);
  height: 120px;
  text-align: center;
}

#profile .links {
  margin-top: 20px;
}

.logged-in-text {
  color: var(--jet);
}

#profile button {
  width: 90%;
  color: var(--jet);
  background-color: rgba(0, 0, 0, 0);
  border: 3px solid;
  box-shadow: none;
  font-size: 20px;
  margin-bottom: 5px;
}

#profile button:hover {
  color: var(--nickel);
  background-color: var(--jet);
}

.exit-button {
  position: absolute;
  top: 10px;
  right: 5px;
}

</style>
