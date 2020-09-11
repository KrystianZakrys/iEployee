import { Component, OnInit, Input } from '@angular/core';
import { FormControl } from '@angular/forms';

@Component({
  selector: 'app-error-messages',
  templateUrl: './error-messages.component.html',
  styleUrls: ['./error-messages.component.css']
})
export class ErrorMessagesComponent implements OnInit {
  @Input('control') control: FormControl;
  @Input('propertyName') propertyName: string;
  @Input('propertyFormat') propertyFormat: string;
  constructor() { }

  ngOnInit(): void {
  }
}
