import {IpAddress} from './ip-address';
import {TransferData} from './transfer-data';
import {Uptime} from './uptime';

export class Device {
  id?: number;
  personId?: number;
  name: string;
  hostName?: string;
  address: IpAddress;
  connected: boolean;
  uptime: string;
  macAddress: string;
  transferData: TransferData;
  editable: boolean;
}
