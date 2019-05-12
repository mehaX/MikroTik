import {Component, Input, OnInit} from '@angular/core';
import {Person} from "../../../models/person";
import {PeopleService} from "../../../services/people.service";

@Component({
  selector: 'app-person',
  templateUrl: './person.component.html',
  styleUrls: ['./person.component.scss']
})
export class PersonComponent implements OnInit {
  @Input('person') person: Person;
  @Input('showConnectedOnly') showConnectedOnly: boolean;

  constructor(private peopleService: PeopleService) { }

  ngOnInit() {
  }

  registerPerson(): void {
    this.person.isRegistering = true;
    this.peopleService.register(this.person).subscribe(result => {
      this.person.id = result.id;
      this.person.devices = result.devices;

      this.person.isRegistering = false;
    });
  }
}
