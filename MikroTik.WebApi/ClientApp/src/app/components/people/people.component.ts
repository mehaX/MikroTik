import {Component, Input, OnInit} from '@angular/core';
import {ActivatedRoute} from '@angular/router';
import {Server} from '../../models/server';
import {ServersService} from '../../services/servers.service';
import {Person} from '../../models/person';
import {PeopleService} from '../../services/people.service';
import {Device} from '../../models/device';
import {DevicesService} from '../../services/devices.service';

@Component({
  selector: 'app-people',
  templateUrl: './people.component.html',
  styleUrls: ['./people.component.scss']
})
export class PeopleComponent implements OnInit {
  serverId: number;
  server: Server;
  people: Person[] = [];

  constructor(private route: ActivatedRoute,
              private serversService: ServersService,
              private peopleService: PeopleService,
              private devicesService: DevicesService) { }

  ngOnInit() {
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

  registerPerson(person: Person): void {
    this.peopleService.register(person).subscribe(result => {
      person.id = result.id;
      person.devices = result.devices;
    });
  }

  renameDevice(device: Device): void {
    this.devicesService.renameDevice(device).subscribe(() => {
      device.editable = false;
    });
  }

  renameDeviceKey($event, device: Device): void {
    if ($event.keyCode === 13) {
      this.renameDevice(device);
    }
  }

  registerDevice(device: Device): void {

  }
}
