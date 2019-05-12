import {IpAddress} from './ip-address';
import {TransferData} from './transfer-data';
import {Uptime} from './uptime';

export interface Device {
  id?: number;
  personId?: number;
  name: string;
  hostName?: string;
  address: IpAddress;
  isConnected: boolean;
  uptime: string;
  macAddress: string;
  transferData: TransferData;

  newName?: string;
  isEditable?: boolean;
}
