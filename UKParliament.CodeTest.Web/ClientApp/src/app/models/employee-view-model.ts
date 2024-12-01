import { Address } from "./address";
import { BaseViewModel } from "./base-view-model";
import { ShortManagerViewModel } from "./short-manager-view-model";

export interface EmployeeViewModel extends BaseViewModel {
  firstName: string;
  lastName: string;
  employeeType: string;
  doB: Date,
  payBand: string,
  department: string,
  salary: number,
  bankAccount: string,

  dateJoined: Date,
  dateLeft: Date,

  manager: ShortManagerViewModel,

  address: Address,

  inactive: boolean,
  hasManager: boolean,
  isManager: boolean,
  hasIrregularities: boolean
}
