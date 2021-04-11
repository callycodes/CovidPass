<template>
  <div :class="[showNavBar() ? 'page-margin' : '']" id="app">
    <div v-show="showMenuButton()" @click="toggleMenu()" id="menu-button">
      <v-icon
        scale="3"
        name="fc-menu"
      />
    </div>

    <NavBar id="navbar" v-show="showNavBar()">
      <span v-if="showingMenu && windowWidth < 1000" @click="toggleMenu()" class="exit-btn dela">X</span>
    </NavBar>
    
    <router-view id="page" />
  </div>
</template>

<script lang="ts">
import Vue from "vue"
import NavBar from "./components/Nav/NavBar.vue";


export default Vue.extend({
  components: {
    NavBar
  },
  data() {
    return {
      windowWidth: window.innerWidth,
      showingMenu: false
    }
  },
  computed: {
    
  },
  mounted() {
    this.$nextTick(() => {
      window.addEventListener('resize', this.onResize);
    })
  },
  methods: {
    onResize() {
      this.windowWidth = window.innerWidth
    },
    toggleMenu() {
      this.showingMenu = !this.showingMenu;
    },
    showNavBar() {
      if (this.windowWidth < 1000) {
        if (this.showingMenu) {
          return true;
        } else {
          return false;
        }
      }
      return true;
    },
    showMenuButton() {
      if (this.windowWidth >= 1000) {
        return false;
      } else {
        if (!this.showingMenu) {
          return true;
        } else {
          return false;
        }
      }
    }
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

#menu-button:hover {
  background-color: var(--pale-silver) !important;
}

.page-margin {
  margin-left: 250px;
}

#app {
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

.exit-btn {
  font-size: 20px;
  color: white;
  border: 3px solid;
  padding: 5px 10px;
}

</style>
