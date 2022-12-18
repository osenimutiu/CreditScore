import { Component, ViewChild, Injector, Output, EventEmitter, OnInit} from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { finalize } from 'rxjs/operators';
import { CooperateAppraisalsServiceProxy, CreateOrEditCooperateAppraisalDto } from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/common/app-component-base';
import * as moment from 'moment';
import { CooperateAppraisalSetupQualitativeLookupTableModalComponent } from './cooperateAppraisal-setupQualitative-lookup-table-modal.component';
import { ActivatedRoute, Router } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import {Observable} from "@node_modules/rxjs";
import { BreadcrumbItem } from '@app/shared/common/sub-header/sub-header.component';


@Component({
    templateUrl: './create-or-edit-cooperateAppraisal.component.html',
    animations: [appModuleAnimation()]
})
export class CreateOrEditCooperateAppraisalComponent extends AppComponentBase implements OnInit {
    active = false;
    saving = false;
        @ViewChild('cooperateAppraisalSetupQualitativeLookupTableModal', { static: true }) cooperateAppraisalSetupQualitativeLookupTableModal: CooperateAppraisalSetupQualitativeLookupTableModalComponent;

    cooperateAppraisal: CreateOrEditCooperateAppraisalDto = new CreateOrEditCooperateAppraisalDto();

    setupQualitativeQualitative = '';


breadcrumbs: BreadcrumbItem[]= [
                        new BreadcrumbItem(this.l("CooperateAppraisal"),"/app/main/cooperate/cooperateAppraisals"),
                        new BreadcrumbItem(this.l('Entity_Name_Plural_Here') + '' + this.l('Details')),
                    ];
    constructor(
        injector: Injector,
        private _activatedRoute: ActivatedRoute,        
        private _cooperateAppraisalsServiceProxy: CooperateAppraisalsServiceProxy,
        private _router: Router
    ) {
        super(injector);
    }

    ngOnInit(): void {
        this.show(this._activatedRoute.snapshot.queryParams['id']);
    }

    show(cooperateAppraisalId?: number): void {

        if (!cooperateAppraisalId) {
            this.cooperateAppraisal = new CreateOrEditCooperateAppraisalDto();
            this.cooperateAppraisal.id = cooperateAppraisalId;
            this.setupQualitativeQualitative = '';

            this.active = true;
        } else {
            this._cooperateAppraisalsServiceProxy.getCooperateAppraisalForEdit(cooperateAppraisalId).subscribe(result => {
                this.cooperateAppraisal = result.cooperateAppraisal;

                this.setupQualitativeQualitative = result.setupQualitativeQualitative;

                this.active = true;
            });
        }
        
    }
    
    save(): void {
        this.saving = true;
        
        this._cooperateAppraisalsServiceProxy.createOrEdit(this.cooperateAppraisal).subscribe(x => {
             this.saving = false;               
             this.notify.info(this.l('SavedSuccessfully'));
             this._router.navigate( ['/app/main/cooperate/cooperateAppraisals']);
        })
    }
    
    saveAndNew(): void {
        this.saving = true;
        
        this._cooperateAppraisalsServiceProxy.createOrEdit(this.cooperateAppraisal).subscribe(x => {
            this.saving = false;               
            this.notify.info(this.l('SavedSuccessfully'));
            this.cooperateAppraisal = new CreateOrEditCooperateAppraisalDto();
        })
    }

    openSelectSetupQualitativeModal() {
        this.cooperateAppraisalSetupQualitativeLookupTableModal.id = this.cooperateAppraisal.setupQualitativeId;
        this.cooperateAppraisalSetupQualitativeLookupTableModal.displayName = this.setupQualitativeQualitative;
        this.cooperateAppraisalSetupQualitativeLookupTableModal.show();
    }


    setSetupQualitativeIdNull() {
        this.cooperateAppraisal.setupQualitativeId = null;
        this.setupQualitativeQualitative = '';
    }


    getNewSetupQualitativeId() {
        this.cooperateAppraisal.setupQualitativeId = this.cooperateAppraisalSetupQualitativeLookupTableModal.id;
        this.setupQualitativeQualitative = this.cooperateAppraisalSetupQualitativeLookupTableModal.displayName;
    }


}
