import { Component, OnInit } from '@angular/core';
import {ServersService} from '../../services/servers.service';
import {Server} from '../../models/server';

@Component({
  selector: 'app-servers',
  templateUrl: './servers.component.html',
  styleUrls: ['./servers.component.scss']
})
export class ServersComponent implements OnInit {
  servers: Server[] = [];

  constructor(private serversService: ServersService) { }

  ngOnInit() {
    this.serversService.getAll().subscribe(servers => {
      this.servers = servers;
    });
  }

}
