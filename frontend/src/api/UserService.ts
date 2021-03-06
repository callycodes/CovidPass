import http from "./ApiService";
import UserModel from "@/models/UserModel";

class UserService {

  getByUid(uid: string) {
    return http.get(`/user/GetByUid/${uid}`);
  }

  async register(data: UserModel) {
    try {
      return await http.post("/user", data);
    } catch (e) {
      let response = {data: "error"}
      return response;
    }
  }

  update(user: UserModel) {
    return http.put(`/user/${user.Uid}`, user);
  }

  delete(uid: string) {
    return http.delete(`/user/${uid}`);
  }

  async login(user: string, password: string) {
    let data = {email: user, password: password};
    console.log(data);
    try {
      return await http.post("/user/authenticate", data);
    } catch (e) {
      let response = {data: "error"}
      return response;
    }
  }
}

export default new UserService();