import { CommonModule } from '@angular/common';
import { Component, Input } from '@angular/core';
import { EmployeeViewModel } from 'src/app/models/employee-view-model';
import { Resource } from 'src/app/models/resource';
import { EmployeeService } from 'src/app/services/employee.service';

@Component({
  selector: 'app-card',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './card.component.html',
  styleUrl: './card.component.scss'
})
export class CardComponent {
  @Input({ required: true })
  employee!: Resource<EmployeeViewModel>;

  editorIsOpen = false;
  constructor(private employeeService: EmployeeService) {
    this.employeeService.employeeSubject.subscribe(e => this.editorIsOpen = !!e);
  }

  openEmployeeProfile() {
    this.openProfile("self");
  }

  openManagerProfile(event: Event) {
    event.preventDefault();
    this.openProfile("manager");
  }

  openProfile(type: string) {
    const link = this.employee.links.find(l => l.rel === type)?.href;
    if (link) {
      this.employeeService.selectEmployee(link);
    }
  }
}
