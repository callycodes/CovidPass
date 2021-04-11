<template>
  <div>
    <h3 class="dela">
      Scan QR Code
    </h3>
    
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
      <span v-if="result == 'allowed'">Allowed: {{val.FirstName}}</span>
      <span v-else>Not Allowed: {{val.FirstName}}</span>
    </h3>

    <button class="dela" @click="toggleShow()">Show Result</button>
    <br>
    <span class="result-text dela" v-if="showResult">Name: {{val.FirstName}} {{val.LastName}}<br>Tests: {{val.Tests.length}}<br>Vaccines: {{val.Vaccines.length}}</span>
  </div>
</template>

<script lang="ts">
import Vue from 'vue';
import { storeModule } from "../store/StoreModule";
import UserModel from "../models/UserModel";
import TestModel from "../models/TestModel";
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
      val: new UserModel(),
      showResult: false
    }
  },
  methods: {
    toggleShow() {
      this.showResult = !this.showResult;
    },
    getName(): string {
      return this.val.FirstName;
    },
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

      await UserService.getByUid(decoded).then(user => {
        this.val = user.data;
      });

      //If person has had a positive result in last 30 days.
      for (let i = 0; i < this.val.Tests.length; i++) {
        let test = this.val.Tests[i] as TestModel;
        if (this.isRecentPositive(test.Result, test.DateOfTest.toString())) {
          access = false;
        }
      }

      //If user has not had both vaccines.
      if (this.val.Vaccines.length < 2) {
        access = false;
      }

      if (access) {
        this.result = "allowed";
      } else {
        this.result = "denied";
      }
      
      this.state = "";
    },

    isRecentPositive(result: boolean, dateOfTest: string): boolean {
    let today = new Date();
      var difference = (Math.abs(today.getTime() - Date.parse(dateOfTest)) / (1000 * 60 * 60 * 24));
      if (result && difference < 30) {
        return true;
      }
      return false;
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

.result-text {
  font-size: 15px;
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
