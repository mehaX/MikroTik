import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { ServersComponent } from './components/servers/servers.component';
import { PeopleComponent } from './components/people/people.component';
import {HttpClientModule} from '@angular/common/http';
import {Route, RouterModule} from '@angular/router';
import {FormsModule} from "@angular/forms";
import { DeviceComponent } from './components/people/device/device.component';
import { PersonComponent } from './components/people/person/person.component';
import {BrowserAnimationsModule} from "@angular/platform-browser/animations";
import {
  MatBadgeModule,
  MatButtonModule,
  MatCardModule,
  MatCheckboxModule,
  MatChipsModule,
  MatDividerModule, MatExpansionModule, MatGridListModule, MatIconModule,
  MatInputModule, MatListModule
} from "@angular/material";

const appRoutes: Route[] = [
  {
    path: '',
    pathMatch: 'full',
    component: ServersComponent
  },
  {
    path: 'server/:serverId/people',
    component: PeopleComponent
  }
];

@NgModule({
  declarations: [
    AppComponent,
    ServersComponent,
    PeopleComponent,
    DeviceComponent,
    PersonComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    RouterModule.forRoot(appRoutes),
    FormsModule,

    BrowserAnimationsModule,
    MatDividerModule,
    MatCardModule,
    MatInputModule,
    MatCheckboxModule,
    MatButtonModule,
    MatChipsModule,
    MatListModule,
    MatGridListModule,
    MatExpansionModule,
    MatBadgeModule,
    MatIconModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
