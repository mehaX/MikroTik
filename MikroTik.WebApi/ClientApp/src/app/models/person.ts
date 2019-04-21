import {IpAddress} from './ip-address';
import {TransferData} from './transfer-data';
import {Device} from './device';

export class Person {
  id?: number;
  serverId: number;
  name: string;
  address: IpAddress;
  transferData: TransferData;

  devices: Device[];
}
