import { CommonModule } from '@angular/common';
import { Component, Input } from '@angular/core';
import { EmployeeViewModel } from 'src/app/models/employee-view-model';
import { Resource } from 'src/app/models/resource';

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

  openManagerProfile(event: Event) {
    event.preventDefault();

    console.log(this.employee.links.find(l => l.rel === "manager")?.href)
  }
}
