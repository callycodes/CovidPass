import TestModel from './TestModel';
import VaccineModel from './VaccineModel';

export default class UserModel {
  Id: number;
  Uid: string;
  FirstName: string;
  LastName: string;
  DateOfBirth: Date;
  Password: string;
  Email: string;
  Tests: Array<TestModel>;
  Vaccines: Array<VaccineModel>;

  constructor() {
    this.Id = 0;
    this.Uid = "";
    this.FirstName = "";
    this.LastName = "";
    this.DateOfBirth = new Date();
    this.Password = "";
    this.Email = "";
    this.Tests = new Array<TestModel>();
    this.Vaccines = new Array<VaccineModel>();
  }
}
