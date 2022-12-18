import { Component, Injector, OnInit, ViewChild } from '@angular/core';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppConsts } from '@shared/AppConsts';
import { AppComponentBase } from '@shared/common/app-component-base';
import { DemoUiComponentsServiceProxy } from '@shared/service-proxies/service-proxies';
import { ModalDirective } from 'ngx-bootstrap/modal';

@Component({
  selector: 'fileUploadModal',
  templateUrl: './file-upload.component.html',
  animations: [appModuleAnimation()],
  styles: [
  ]
})
export class FileUploadComponent extends AppComponentBase {
  @ViewChild('fileUploadModal', { static: true }) modal: ModalDirective;

    uploadUrl: string;
    uploadedFiles: any[] = [];
    public active = false;
    public saving = false;

  constructor(
    injector: Injector,
    private demoUiComponentsService: DemoUiComponentsServiceProxy
  ) {
    super(injector);
        this.uploadUrl = AppConsts.remoteServiceBaseUrl + '/DemoUiComponents/UploadFiles';
   }

  // ngOnInit(): void {
  // }
  // upload completed event
 
  show(): void {
    this.modal.show();
  }
  
  close(): void {
    this.active = false;
    this.modal.hide();
  }
 
 
  onUpload(event): void {
    for (const file of event.files) {
        this.uploadedFiles.push(file);
    }
  }

onBeforeSend(event): void {
    event.xhr.setRequestHeader('Authorization', 'Bearer ' + abp.auth.getToken());
}

}
