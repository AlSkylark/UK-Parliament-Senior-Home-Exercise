import { Inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, Subject } from 'rxjs';
import { EmployeeViewModel } from '../models/employee-view-model';
import { FilterService } from './filter.service';
import { Resource } from '../models/resource';
import { ResourceCollection } from '../models/resource-collection';

@Injectable({
  providedIn: 'root'
})

export class EmployeeService {
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, private filterService: FilterService) { }

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

  public updateEmployee(url: string, employee: EmployeeViewModel) {
    this.http.put<Resource<EmployeeViewModel>>(url, employee).subscribe({
      next: result => {
        this.activeEmployee = result;
        this.employeeSubject.next(this.activeEmployee);
      },
      error: error => {
        console.log(error);
      }
    })
  }

  public deleteEmployee(url: string) {
    this.http.delete<void>(url).subscribe({
      error: e => {
        console.log(e);
      }
    })
  }

}

