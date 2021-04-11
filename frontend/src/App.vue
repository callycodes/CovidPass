<template>
  <div id="app">
    <div id="menu-button">
      <v-icon
        scale="3"
        name="fc-menu"
      />
    </div>

    <NavBar id="navbar" />
    
    <router-view id="page" />
  </div>
</template>

<script lang="ts">
import Vue from "vue"
import NavBar from "./components/Nav/NavBar.vue";


export default Vue.extend({
  components: {
    NavBar
  }

});

</script>

<style>

#menu-button {
  position: fixed;
  top: 5px;
  right: 5px;
  width: 80px;
  height: 80px;
  background-color: var(--jet);
  border-radius: 10px;
  color: var(--nickel);
  font-size: 10px;
  text-align: center;
  line-height: 115px;
}

#app {
  margin-left: 250px;
  transition: transform 1s;
}

#page {
  padding: 10px;
}

#nav {
  padding: 30px;
}

#nav a {
  font-weight: bold;
  color: #2c3e50;
}

#nav a.router-link-exact-active {
  color: #42b983;
}
</style>
