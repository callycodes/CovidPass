export default class VaccineModel {
  Id: number;
  UserId: string;
  Type: string;
  Count: number;
  DateOfVaccine: Date;

  constructor() {
    this.Id = 0;
    this.UserId = "";
    this.Type = "";
    this.Count = 0;
    this.DateOfVaccine = new Date();
  }
}
