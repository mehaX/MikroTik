import { Injectable } from '@angular/core';
import {environment} from '../../environments/environment';
import {Observable} from 'rxjs';
import {Server} from '../models/server';
import {HttpClient} from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ServersService {
  private baseUrl = environment.apiUrl + 'servers';

  constructor(private http: HttpClient) { }

  public getAll(): Observable<Server[]> {
    return this.http.get<Server[]>(this.baseUrl);
  }

  public get(serverId: number): Observable<Server> {
    return this.http.get<Server>(`${this.baseUrl}/${serverId}`);
  }
}
