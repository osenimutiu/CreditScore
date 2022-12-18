import { Component, ViewChild, Injector, Output, EventEmitter, OnInit } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { SubSectorSetupsServiceProxy, GetSubSectorSetupForViewDto, SubSectorSetupDto } from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ActivatedRoute } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { BreadcrumbItem } from '@app/shared/common/sub-header/sub-header.component';
@Component({
    templateUrl: './view-subSectorSetup.component.html',
    animations: [appModuleAnimation()]
})
export class ViewSubSectorSetupComponent extends AppComponentBase implements OnInit {

    active = false;
    saving = false;

    item: GetSubSectorSetupForViewDto;

breadcrumbs: BreadcrumbItem[]= [
                        new BreadcrumbItem(this.l("SubSectorSetup"),"/app/main/cooperate/subSectorSetups"),
                        new BreadcrumbItem(this.l('SubSectorSetups') + '' + this.l('Details')),
                    ];
    constructor(
        injector: Injector,
        private _activatedRoute: ActivatedRoute,
         private _subSectorSetupsServiceProxy: SubSectorSetupsServiceProxy
    ) {
        super(injector);
        this.item = new GetSubSectorSetupForViewDto();
        this.item.subSectorSetup = new SubSectorSetupDto();        
    }

    ngOnInit(): void {
        this.show(this._activatedRoute.snapshot.queryParams['id']);
    }

    show(subSectorSetupId: number): void {
      this._subSectorSetupsServiceProxy.getSubSectorSetupForView(subSectorSetupId).subscribe(result => {      
                 this.item = result;
                this.active = true;
            });       
    }
}
