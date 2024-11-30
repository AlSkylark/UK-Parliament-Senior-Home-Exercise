import { Component } from '@angular/core';
import { PersonService } from '../../services/employee.service';
import { EmployeeViewModel } from 'src/app/models/employee-view-model';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent {
  test: string = "";

  people: EmployeeViewModel[] = [];

  constructor(private personService: PersonService) {
    this.getPersonById(1);
  }

  search() {
    this.personService.search().subscribe((e) => {
      this.people = e;
    })
  }

  getPersonById(id: number): void {
    this.personService.getById(id).subscribe({
      next: (result) => console.info(`User returned: ${JSON.stringify(result)}`),
      error: (e) => console.error(`Error: ${e}`)
    });
  }
}
