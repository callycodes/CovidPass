<template>
  <div>
    <h3 class="dela">
      Scan QR Code
    </h3>
    
    <p>{{ get() }}</p>
    <QrcodeStream @decode="onDecode">
      <div
        v-if="state == 'pending'"
        class="pending dela"
      >
        Validating
      </div>
    </QrcodeStream>


    <h3
      v-if="result != ''"
      :class="[result == 'allowed' ? 'allowed' : 'not-allowed', 'dela', 'result']"
    >
      <span v-if="result == 'allowed'">Allowed</span>
      <span v-else>Not Allowed</span>
    </h3>
  </div>
</template>

<script lang="ts">
import Vue from 'vue';
import { storeModule } from "../store/StoreModule";
import UserModel from "../models/UserModel";
import { QrcodeStream } from "vue-qrcode-reader";
import UserService from '../api/UserService'

export default Vue.extend({
  components: {
    QrcodeStream
  },
  data () {
    return {
      state: "",
      result: "",
      cool: "",
      val: new UserModel()
    }
  },
  methods: {
    set(): void {
      let user:UserModel = new UserModel();
      user.FirstName = this.cool;
      user.Id = 3;
      storeModule.setUser(user);
    },
    get(): UserModel {
      return storeModule.getUser;
    },

    async onDecode(decoded: string) {
      this.state = "pending";
      await this.timeout(3000)
      await this.getResult(decoded)
    },

    async getResult(decoded: string) {
      let access = true;

      console.log(await UserService.getByUid(decoded));

      if (access) {
        this.result = "allowed";
      } else {
        this.result = "denied";
      }
      
      this.state = "";
    },

    getUid(): string {
      return storeModule.getUser.Uid || "";
    },
    timeout (ms) {
      return new Promise(resolve => {
        window.setTimeout(resolve, ms)
      })
    }
  }
});
</script>

<style lang="css" scoped>
div {
  font-size: 40px;
}

.allowed {
  color: green;
}

.not-allowed {
  color: red;
}

.result {
  text-align: center;
}

.pending {
  position: absolute;
  width: 100%;
  height: 100%;
  color: white;
  background-color: rgba(0, 0, 0, .8);
  text-align: center;
  font-weight: bold;
  font-size: 1.6rem;
  padding: 10px;

  display: flex;
  flex-flow: column nowrap;
  justify-content: center;
}
</style>
