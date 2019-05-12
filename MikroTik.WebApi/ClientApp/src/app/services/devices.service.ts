import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {environment} from '../../environments/environment';
import {Device} from '../models/device';

@Injectable({
  providedIn: 'root'
})
export class DevicesService {

  constructor(private http: HttpClient) { }

  public renameDevice(device: Device): Observable<boolean> {
    return new Observable<boolean>(observer => {
      this.http.patch(environment.apiUrl +
        `people/${device.personId}/devices/${device.id}/rename`, {name: device.newName}).subscribe(() => {
        observer.next(true);
      }, () => {
        observer.next(false);
      }, () => {
        observer.complete();
      });
    });
  }
}
