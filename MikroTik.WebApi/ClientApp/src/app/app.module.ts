import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { ServersComponent } from './components/servers/servers.component';
import { PeopleComponent } from './components/people/people.component';
import {HttpClientModule} from '@angular/common/http';
import {Route, RouterModule} from '@angular/router';

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
    PeopleComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    RouterModule.forRoot(appRoutes)
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
