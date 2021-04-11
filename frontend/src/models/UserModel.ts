export default class UserModel {
  Id: number;
  Uid: string;
  FirstName: string;
  LastName: string;
  DateOfBirth: Date;
  Password: string;
  Email: string;

  constructor() {
    this.Id = 0;
    this.Uid = "";
    this.FirstName = "";
    this.LastName = "";
    this.DateOfBirth = new Date();
    this.Password = "";
    this.Email = "";
  }
}
