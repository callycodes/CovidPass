import UserModel from "@/models/UserModel";
import { VuexModule, Module, Mutation, Action } from "vuex-class-modules";

@Module
class StoreModule extends VuexModule {
  // state
  user: UserModel = new UserModel();
  loading = false;


  get getUser(): UserModel {
    return this.user;
  }

  get getLoading(): boolean {
    return this.loading;
  }

  get isLoggedIn(): boolean {
    if (this.user.Id != 0) {
      return true;
    } else {
      return false;
    }
  }

  @Mutation
  setUser(user: UserModel): void {
    this.user = user;
  }
  
  @Mutation
  logout(): void {
    this.user = new UserModel();
  }

  

  


}

// register module (could be in any file)
import store from "./";
export const storeModule = new StoreModule({ store, name: "user" });