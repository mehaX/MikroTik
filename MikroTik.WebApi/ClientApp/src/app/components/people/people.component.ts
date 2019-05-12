import {Component, OnInit} from '@angular/core';
import {ActivatedRoute} from '@angular/router';
import {Server} from '../../models/server';
import {ServersService} from '../../services/servers.service';
import {Person} from '../../models/person';
import {PeopleService} from '../../services/people.service';

@Component({
  selector: 'app-people',
  templateUrl: './people.component.html',
  styleUrls: ['./people.component.scss']
})
export class PeopleComponent implements OnInit {
  serverId: number;
  server: Server;
  people: Person[] = [];

  showConnectedOnly: boolean = false;

  constructor(private route: ActivatedRoute,
              private serversService: ServersService,
              private peopleService: PeopleService) { }

  ngOnInit() {
    this.peopleService.getConnectedOnlyValue().subscribe(value => {
      this.showConnectedOnly = value;
    });

    this.route.params.subscribe(params => {
      this.serverId = params.serverId || 1;

      this.serversService.get(this.serverId).subscribe(server => {
        this.server = server;

        this.peopleService.getAll(this.server.id).subscribe(people => {
          this.people = people;
        });
      });
    });
  }

  isConnectedPerson(person: Person): boolean {
    return person.devices.filter(device => {
      return device.isConnected;
    }).length > 0;
  }

  updateConnectedOnlyCheckbox(): void {
    this.peopleService.saveConnectedOnlyValue(this.showConnectedOnly);
  }
}
