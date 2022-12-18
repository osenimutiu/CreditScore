import { Component, ViewChild, Injector, Output, EventEmitter, OnInit} from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { finalize } from 'rxjs/operators';
import { QualitativeSetupsServiceProxy, CreateOrEditQualitativeSetupDto } from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/common/app-component-base';
import * as moment from 'moment';
import { ActivatedRoute, Router } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import {Observable} from "@node_modules/rxjs";
import { BreadcrumbItem } from '@app/shared/common/sub-header/sub-header.component';


@Component({
    templateUrl: './create-or-edit-qualitativeSetup.component.html',
    animations: [appModuleAnimation()]
})
export class CreateOrEditQualitativeSetupComponent extends AppComponentBase implements OnInit {
    active = false;
    saving = false;
    
    qualitativeSetup: CreateOrEditQualitativeSetupDto = new CreateOrEditQualitativeSetupDto();



breadcrumbs: BreadcrumbItem[]= [
                        new BreadcrumbItem(this.l("QualitativeSetup"),"/app/main/cooperate/qualitativeSetups"),
                        new BreadcrumbItem(this.l('Entity_Name_Plural_Here') + '' + this.l('Details')),
                    ];
    constructor(
        injector: Injector,
        private _activatedRoute: ActivatedRoute,        
        private _qualitativeSetupsServiceProxy: QualitativeSetupsServiceProxy,
        private _router: Router
    ) {
        super(injector);
    }

    ngOnInit(): void {
        this.show(this._activatedRoute.snapshot.queryParams['id']);
    }

    show(qualitativeSetupId?: number): void {

        if (!qualitativeSetupId) {
            this.qualitativeSetup = new CreateOrEditQualitativeSetupDto();
            this.qualitativeSetup.id = qualitativeSetupId;

            this.active = true;
        } else {
            this._qualitativeSetupsServiceProxy.getQualitativeSetupForEdit(qualitativeSetupId).subscribe(result => {
                this.qualitativeSetup = result.qualitativeSetup;


                this.active = true;
            });
        }
        
    }
    
    save(): void {
        this.saving = true;
        
        this._qualitativeSetupsServiceProxy.createOrEdit(this.qualitativeSetup).subscribe(x => {
             this.saving = false;               
             this.notify.info(this.l('SavedSuccessfully'));
             this._router.navigate( ['/app/main/cooperate/qualitativeSetups']);
        })
    }
    
    saveAndNew(): void {
        this.saving = true;
        
        this._qualitativeSetupsServiceProxy.createOrEdit(this.qualitativeSetup).subscribe(x => {
            this.saving = false;               
            this.notify.info(this.l('SavedSuccessfully'));
            this.qualitativeSetup = new CreateOrEditQualitativeSetupDto();
        })
    }







}
