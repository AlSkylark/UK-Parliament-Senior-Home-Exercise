import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { LookupItem } from 'src/app/models/lookup-item';
import { LookupItemsEnum } from 'src/app/models/lookup-items-enum';
import { LookupService } from 'src/app/services/lookup.service';

@Component({
  selector: 'app-filter-select',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './filter-select.component.html',
  styleUrl: './filter-select.component.scss'
})
export class FilterSelectComponent implements OnInit {
  @Input({ required: true })
  text!: string;

  @Input({ required: true })
  id!: string;

  @Input({ required: true })
  itemToLook!: LookupItemsEnum;

  itemList: LookupItem[] = [];

  @Input()
  value?: string;

  @Output()
  valueChange = new EventEmitter<string | undefined>();

  loading = false;

  constructor(private lookupService: LookupService) { }
  ngOnInit(): void {
    this.lookupService.lookUpItem(this.itemToLook).subscribe(item => {
      this.itemList = item;
      this.loading = false;
    })
  }

  getLookupItems() {
    this.loading = this.lookupService.getLookupItems(this.itemToLook);
  }

  updateValue() {
    this.valueChange.next(this.value);
  }
}
