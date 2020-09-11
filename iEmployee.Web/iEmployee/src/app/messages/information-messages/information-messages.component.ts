import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-information-messages',
  templateUrl: './information-messages.component.html',
  styleUrls: ['./information-messages.component.css']
})
export class InformationMessagesComponent implements OnInit {
  @Input() successMessages: string[];
  @Input() errorMessages: string[]
  constructor() { }

  ngOnInit(): void {
  }

  closeerrorMessages(): void{
    this.errorMessages = null;
  }
  closesuccessMessages(): void{
    this.successMessages = null;
  }
}
