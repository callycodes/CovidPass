import http from "./ApiService";
import VaccineModel from "@/models/VaccineModel";

class VaccineService {

  async login(vaccine: VaccineModel) {
    try {
      return await http.post("/vaccine", vaccine);
    } catch (e) {
      let response = {data: "error"}
      return response;
    }
  }
}

export default new VaccineService();