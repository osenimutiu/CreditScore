import { Component, ViewChild, Injector, Output, EventEmitter, OnInit} from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { finalize } from 'rxjs/operators';
import { SubSectorSetupsServiceProxy, CreateOrEditSubSectorSetupDto } from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/common/app-component-base';
import * as moment from 'moment';
import { ActivatedRoute, Router } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import {Observable} from "@node_modules/rxjs";
import { BreadcrumbItem } from '@app/shared/common/sub-header/sub-header.component';


@Component({
    templateUrl: './create-or-edit-subSectorSetup.component.html',
    animations: [appModuleAnimation()]
})
export class CreateOrEditSubSectorSetupComponent extends AppComponentBase implements OnInit {
    active = false;
    saving = false;
    
    subSectorSetup: CreateOrEditSubSectorSetupDto = new CreateOrEditSubSectorSetupDto();



breadcrumbs: BreadcrumbItem[]= [
                        new BreadcrumbItem(this.l("SubSectorSetup"),"/app/main/cooperate/subSectorSetups"),
                        new BreadcrumbItem(this.l('Entity_Name_Plural_Here') + '' + this.l('Details')),
                    ];
    constructor(
        injector: Injector,
        private _activatedRoute: ActivatedRoute,        
        private _subSectorSetupsServiceProxy: SubSectorSetupsServiceProxy,
        private _router: Router
    ) {
        super(injector);
    }

    ngOnInit(): void {
        this.show(this._activatedRoute.snapshot.queryParams['id']);
    }

    show(subSectorSetupId?: number): void {

        if (!subSectorSetupId) {
            this.subSectorSetup = new CreateOrEditSubSectorSetupDto();
            this.subSectorSetup.id = subSectorSetupId;

            this.active = true;
        } else {
            this._subSectorSetupsServiceProxy.getSubSectorSetupForEdit(subSectorSetupId).subscribe(result => {
                this.subSectorSetup = result.subSectorSetup;


                this.active = true;
            });
        }
        
    }
    
    save(): void {
        this.saving = true;
        
        this._subSectorSetupsServiceProxy.createOrEdit(this.subSectorSetup).subscribe(x => {
             this.saving = false;               
             this.notify.info(this.l('SavedSuccessfully'));
             this._router.navigate( ['/app/main/cooperate/subSectorSetups']);
        })
    }
    
    saveAndNew(): void {
        this.saving = true;
        
        this._subSectorSetupsServiceProxy.createOrEdit(this.subSectorSetup).subscribe(x => {
            this.saving = false;               
            this.notify.info(this.l('SavedSuccessfully'));
            this.subSectorSetup = new CreateOrEditSubSectorSetupDto();
        })
    }







}
