<template>
  <div id="log-page">
  
    <div class="log">

      <button class="dela" @click="change('test')">Test</button>
      <button class="dela" @click="change('vaccine')">Vaccine</button>

      <span v-if="result" class="success dela">{{result}}</span>

      <div v-if="current=='test'">
        <h1 class="dela">Log Test</h1>
        <h2 class="dela">UID</h2>
        <input v-model="testData.uid"/>

        <h2 class="dela">Type of Test</h2>
        <select v-model="testData.type" name="testType">
          <option>Postal</option>
          <option>Vaccination Centre</option>
          <option>Rapid</option>
        </select>

        <h2 class="dela">Result</h2>
        <select v-model="testData.result" name="testResult">
          <option :value="true">True</option>
          <option :value="false">False</option>
        </select>

        <h2 class="dela">Date of Test</h2>
        <Datepicker v-model="testData.date"></Datepicker>

        <button class="dela" @click="addTest">Log Test</button>
      </div>

      <div v-else>
        <h1 class="dela">Log Vaccine</h1>
        <h2 class="dela">UID</h2>
        <input v-model="vaccineData.uid"/>

        <h2 class="dela">Type of Vaccine</h2>
        <select v-model="vaccineData.type" name="vaccineType">
          <option>AstraZeneca</option>
          <option>Pfizer</option>
        </select>

        <h2 class="dela">Count</h2>
        <select v-model="vaccineData.count" name="vaccineCount">
          <option :value="1">1</option>
          <option :value="2">2</option>
        </select>

        <h2 class="dela">Date of Vaccine</h2>
        <Datepicker v-model="vaccineData.date"></Datepicker>

        <button class="dela" @click="addVaccine">Log Vaccine</button>
      </div>

    </div>
  </div>
</template>

<script lang="ts">
import Vue from 'vue';
import VaccineModel from "../models/VaccineModel";
import TestModel from "../models/TestModel";
import TestService from '../api/TestService';
import VaccineService from '../api/VaccineService'
import Datepicker from 'vuejs-datepicker';

export default Vue.extend({
  data () {
    return {
      current: "test",
      testData: {
        uid: "",
        type: "",
        result: false,
        date: new Date()
      },
      vaccineData: {
        uid: "",
        type: "",
        count: 1,
        date: new Date()
      },
      result:""
    }
  },
  components: {
    Datepicker
  },
  methods: {
    change(type: string) {
      this.current = type;
    },
    async addTest(): Promise<void> {
      let test = new TestModel();
      test.UserId = this.testData.uid;
      test.Type = this.testData.type;
      test.Result = this.testData.result;
      test.DateOfTest = this.testData.date;

      let response = await TestService.add(test);
      this.setResult("Test", this.testData.uid);
    },

    async addVaccine(): Promise<void> {
      let vaccine = new VaccineModel();
      vaccine.UserId = this.vaccineData.uid;
      vaccine.Type = this.vaccineData.type;
      vaccine.Count = this.vaccineData.count;
      vaccine.DateOfVaccine = this.vaccineData.date;

      let response = await VaccineService.add(vaccine);
      this.setResult("Vaccine", this.vaccineData.uid);
    },

    setResult(type: string, uid: string): void {
      this.result = new Date().toTimeString() + ": " + type + " has been added for " + uid + ".";
    }
  }
});
</script>

<style lang="css" scoped>

h1 {
  font-size: 40px;
}

#log-page {
  
}

.log {
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
  margin-top: -10px;
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
