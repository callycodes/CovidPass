<template>
  <div>
    <h3 class="dela">
      Your Passport
    </h3>
    <!--<QrcodeVue :value="getQRValue"></QrcodeVue>-->
    <VueQrcode :width="400" :value="getQRValue()" />
  </div>
</template>

<script lang="ts">
import Vue from 'vue';
import { storeModule } from "../store/StoreModule";

import VueQrcode from 'vue-qrcode'

export default Vue.extend({
  components: {
    VueQrcode
  },
  data () {
    return {
      
    }
  },
  methods: {
    
    getQRValue(): string {
      console.log(storeModule.user);
      return storeModule.getUser.Uid;
    }
  }
});
</script>

<style lang="css" scoped>
div {
  font-size: 40px;
}
</style>
