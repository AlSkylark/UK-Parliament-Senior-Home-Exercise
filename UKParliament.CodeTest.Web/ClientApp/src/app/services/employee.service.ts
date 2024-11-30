import { Inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { EmployeeViewModel } from '../models/employee-view-model';

@Injectable({
  providedIn: 'root'
})
export class PersonService {
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  // Below is some sample code to help get you started calling the API
  getById(id: number): Observable<EmployeeViewModel> {
    return this.http.get<EmployeeViewModel>(this.baseUrl + `api/person/${id}`)
  }

  search(): Observable<EmployeeViewModel[]> {
    return this.http.get<EmployeeViewModel[]>(this.baseUrl + "api/employee/")
  }

  get(url: string) {

  }
}
