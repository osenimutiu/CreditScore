import { Component, ViewChild, Injector, Output, EventEmitter, OnInit } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { QualitativeSetupsServiceProxy, GetQualitativeSetupForViewDto, QualitativeSetupDto } from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ActivatedRoute } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { BreadcrumbItem } from '@app/shared/common/sub-header/sub-header.component';
@Component({
    templateUrl: './view-qualitativeSetup.component.html',
    animations: [appModuleAnimation()]
})
export class ViewQualitativeSetupComponent extends AppComponentBase implements OnInit {

    active = false;
    saving = false;

    item: GetQualitativeSetupForViewDto;

breadcrumbs: BreadcrumbItem[]= [
                        new BreadcrumbItem(this.l("QualitativeSetup"),"/app/main/cooperate/qualitativeSetups"),
                        new BreadcrumbItem(this.l('QualitativeSetups') + '' + this.l('Details')),
                    ];
    constructor(
        injector: Injector,
        private _activatedRoute: ActivatedRoute,
         private _qualitativeSetupsServiceProxy: QualitativeSetupsServiceProxy
    ) {
        super(injector);
        this.item = new GetQualitativeSetupForViewDto();
        this.item.qualitativeSetup = new QualitativeSetupDto();        
    }

    ngOnInit(): void {
        this.show(this._activatedRoute.snapshot.queryParams['id']);
    }

    show(qualitativeSetupId: number): void {
      this._qualitativeSetupsServiceProxy.getQualitativeSetupForView(qualitativeSetupId).subscribe(result => {      
                 this.item = result;
                this.active = true;
            });       
    }
}
