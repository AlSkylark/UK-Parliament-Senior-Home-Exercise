import { Inject, Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable, Subject } from 'rxjs';
import { EmployeeViewModel } from '../models/employee-view-model';
import { FilterService } from './filter.service';
import { Resource } from '../models/resource';
import { ResourceCollection } from '../models/resource-collection';
import { ErrorService } from './error.service';
import { ErrorBag } from '../models/errors/error-bag';

@Injectable({
  providedIn: 'root'
})

export class EmployeeService {
  constructor(
    private http: HttpClient, @Inject('BASE_URL')
    private baseUrl: string,
    private filterService: FilterService,
    private errorService: ErrorService) { }

  employeeListSubject = new Subject<ResourceCollection<Resource<EmployeeViewModel>>>();

  activeEmployee: Resource<EmployeeViewModel> | null = null;
  employeeSubject = new Subject<Resource<EmployeeViewModel> | null>();

  public fetchEmployees() {
    const filters = this.filterService.getCurrentFilters();
    const params = new URLSearchParams(filters);
    this.http.get<Resource<ResourceCollection<Resource<EmployeeViewModel>>>>(`${this.baseUrl}api/employee?${params}`).subscribe(employees => {
      this.employeeListSubject.next(employees.data);
    })
  }

  public requestManager(url: string) {
    return this.http.get<Resource<EmployeeViewModel>>(url);
  }

  public selectEmployee(url: string) {
    this.http.get<Resource<EmployeeViewModel>>(url).subscribe(resource => {
      this.activeEmployee = resource;
      this.employeeSubject.next(this.activeEmployee);
    })
  }

  public closeEmployeeEditor() {
    this.activeEmployee = null;
    this.employeeSubject.next(null);
  }

  public createEmployee(url: string, employee: EmployeeViewModel) {
    this.sanitiseDates(employee);

    this.http.post<Resource<EmployeeViewModel>>(url, employee).subscribe({
      next: result => {
        this.activeEmployee = result;
        this.employeeSubject.next(this.activeEmployee);
      },
      error: error => {
        console.log(error)
      }
    })
  }

  public deactivateEmployee(url: string, employee: EmployeeViewModel) {
    employee.dateLeft = this.DateOnly("", true);

    this.updateEmployee(url, employee);
  }

  public updateEmployee(url: string, employee: EmployeeViewModel) {
    this.sanitiseDates(employee);

    this.http.put<Resource<EmployeeViewModel>>(url, employee).subscribe({
      next: result => {
        this.activeEmployee = result;
        this.employeeSubject.next(this.activeEmployee);
        this.fetchEmployees();
      },
      error: error => {
        const errorResp = error as HttpErrorResponse;
        console.log(error);
        this.errorService.displayErrors(errorResp.error as ErrorBag);
      }
    })
  }

  public deleteEmployee(url: string) {
    this.http.delete<void>(url).subscribe({
      next: () => {
        this.fetchEmployees();
      },
      error: e => {
        console.log(e);
      }
    });
  }

  private sanitiseDates(employee: EmployeeViewModel) {
    employee.dateJoined = this.DateOnly(employee.dateJoined);
    employee.doB = this.DateOnly(employee.doB);

    if (employee.dateLeft !== null && employee.dateLeft.length > 0) {
      employee.dateLeft = this.DateOnly(employee.dateLeft);
    }
  }

  private DateOnly(date: string, createNew = false) {
    if (createNew) {
      return new Date().toISOString().split("T")[0];
    }

    return new Date(date!).toISOString().split("T")[0];
  }

}

