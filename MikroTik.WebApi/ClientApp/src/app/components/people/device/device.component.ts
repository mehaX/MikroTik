import {Component, ElementRef, Input, OnInit, ViewChild} from '@angular/core';
import {Device} from "../../../models/device";
import {DevicesService} from "../../../services/devices.service";

@Component({
  selector: 'app-device',
  templateUrl: './device.component.html',
  styleUrls: ['./device.component.scss']
})
export class DeviceComponent implements OnInit {
  @Input() device: Device;
  @ViewChild('rename') renameField: ElementRef;

  constructor(private devicesService: DevicesService) { }

  ngOnInit() {
  }

  saveRenameDevice(): void {
    this.devicesService.renameDevice(this.device).subscribe(() => {
      this.device.name = this.device.newName;
      this.cancelEditableDevice();
    });
  }

  saveRenameDeviceKey(event): void {
    switch(event.key)
    {
      case "Enter":
        this.saveRenameDevice();
        break;

      case "Escape":
        this.cancelEditableDevice();
        break;
    }
  }

  get isEditableDevice(): boolean {
    return this.device.isEditable;
  }

  makeEditableDevice(): void {
    this.device.newName = this.device.name || this.device.address.value;
    this.device.isEditable = true;

    setTimeout(() => {
      this.renameField.nativeElement.focus();
    }, 100); // autofocus after the animation is complete
  }

  cancelEditableDevice(): void {
    this.device.newName = null;
    this.device.isEditable = false;
  }

}
