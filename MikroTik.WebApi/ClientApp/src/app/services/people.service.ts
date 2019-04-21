import { Injectable } from '@angular/core';
import {Observable} from 'rxjs';
import {Person} from '../models/person';
import {environment} from '../../environments/environment';
import {HttpClient} from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class PeopleService {
  constructor(private http: HttpClient) { }

  public getAll(serverId: number): Observable<Person[]> {
    return this.http.get<Person[]>(environment.apiUrl + `servers/${serverId}/people`);
  }

  public register(person: Person): Observable<Person> {
    return this.http.post<Person>(environment.apiUrl + `servers/${person.serverId}/people`, person);
  }
}
