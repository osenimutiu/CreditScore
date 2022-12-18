import { Component, ViewChild, Injector, Output, EventEmitter, OnInit } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { SetupQualitativesServiceProxy, GetSetupQualitativeForViewDto, SetupQualitativeDto } from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ActivatedRoute } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { BreadcrumbItem } from '@app/shared/common/sub-header/sub-header.component';
@Component({
    templateUrl: './view-setupQualitative.component.html',
    animations: [appModuleAnimation()]
})
export class ViewSetupQualitativeComponent extends AppComponentBase implements OnInit {

    active = false;
    saving = false;

    item: GetSetupQualitativeForViewDto;

breadcrumbs: BreadcrumbItem[]= [
                        new BreadcrumbItem(this.l("SetupQualitative"),"/app/main/cooperate/setupQualitatives"),
                        new BreadcrumbItem(this.l('SetupQualitatives') + '' + this.l('Details')),
                    ];
    constructor(
        injector: Injector,
        private _activatedRoute: ActivatedRoute,
         private _setupQualitativesServiceProxy: SetupQualitativesServiceProxy
    ) {
        super(injector);
        this.item = new GetSetupQualitativeForViewDto();
        this.item.setupQualitative = new SetupQualitativeDto();        
    }

    ngOnInit(): void {
        this.show(this._activatedRoute.snapshot.queryParams['id']);
    }

    show(setupQualitativeId: number): void {
      this._setupQualitativesServiceProxy.getSetupQualitativeForView(setupQualitativeId).subscribe(result => {      
                 this.item = result;
                this.active = true;
            });       
    }
}
