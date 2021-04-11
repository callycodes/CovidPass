export default class TestModel {
  Id: number;
  UserId: string;
  Type: string;
  Result: boolean;
  DateOfTest: Date;

  constructor() {
    this.Id = 0;
    this.UserId = "";
    this.Type = "";
    this.Result = false;
    this.DateOfTest = new Date();
  }

}
