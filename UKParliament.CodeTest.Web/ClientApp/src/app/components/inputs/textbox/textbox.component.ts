import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-textbox',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './textbox.component.html',
  styleUrl: './textbox.component.scss'
})
export class TextboxComponent {
  @Input({ required: true })
  label!: string;

  @Input({ required: true })
  id!: string;

  @Input()
  showLabel = true;

  @Input()
  autopopulate = "";

  @Input()
  placeholder = "";

  @Input()
  value?: string;

  @Output()
  valueChange = new EventEmitter<string>();

  onInput(event: Event): void {
    const inputValue = (event.target as HTMLInputElement).value;
    this.valueChange.emit(inputValue);
  }
}
