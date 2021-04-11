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

  isRecentPositive(): boolean {
    let today = new Date();
    var difference = (Math.abs(today.getTime() - this.DateOfTest.getTime())) / (1000 * 60 * 60 * 24);
    if (this.Result && difference < 30) {
      return true;
    }
    return false;
  }

}
