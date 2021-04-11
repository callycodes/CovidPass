import http from "./ApiService";
import TestModel from "@/models/TestModel";

class TestService {

  async login(test: TestModel) {
    try {
      return await http.post("/test", test);
    } catch (e) {
      let response = {data: "error"}
      return response;
    }
  }
}

export default new TestService();