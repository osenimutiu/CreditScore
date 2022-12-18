import { Component, ViewChild, Injector, Output, EventEmitter, OnInit } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { CooperateAppraisalsServiceProxy, GetCooperateAppraisalForViewDto, CooperateAppraisalDto } from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ActivatedRoute } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { BreadcrumbItem } from '@app/shared/common/sub-header/sub-header.component';
@Component({
    templateUrl: './view-cooperateAppraisal.component.html',
    animations: [appModuleAnimation()]
})
export class ViewCooperateAppraisalComponent extends AppComponentBase implements OnInit {

    active = false;
    saving = false;

    item: GetCooperateAppraisalForViewDto;

breadcrumbs: BreadcrumbItem[]= [
                        new BreadcrumbItem(this.l("CooperateAppraisal"),"/app/main/cooperate/cooperateAppraisals"),
                        new BreadcrumbItem(this.l('CooperateAppraisals') + '' + this.l('Details')),
                    ];
    constructor(
        injector: Injector,
        private _activatedRoute: ActivatedRoute,
         private _cooperateAppraisalsServiceProxy: CooperateAppraisalsServiceProxy
    ) {
        super(injector);
        this.item = new GetCooperateAppraisalForViewDto();
        this.item.cooperateAppraisal = new CooperateAppraisalDto();        
    }

    ngOnInit(): void {
        this.show(this._activatedRoute.snapshot.queryParams['id']);
    }

    show(cooperateAppraisalId: number): void {
      this._cooperateAppraisalsServiceProxy.getCooperateAppraisalForView(cooperateAppraisalId).subscribe(result => {      
                 this.item = result;
                this.active = true;
            });       
    }
}
