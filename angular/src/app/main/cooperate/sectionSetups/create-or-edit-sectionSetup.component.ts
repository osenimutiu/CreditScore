import { Component, ViewChild, Injector, Output, EventEmitter, OnInit} from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { finalize } from 'rxjs/operators';
import { SectionSetupsServiceProxy, CreateOrEditSectionSetupDto } from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/common/app-component-base';
import * as moment from 'moment';
import { ActivatedRoute, Router } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import {Observable} from "@node_modules/rxjs";
import { BreadcrumbItem } from '@app/shared/common/sub-header/sub-header.component';


@Component({
    templateUrl: './create-or-edit-sectionSetup.component.html',
    animations: [appModuleAnimation()]
})
export class CreateOrEditSectionSetupComponent extends AppComponentBase implements OnInit {
    active = false;
    saving = false;
    
    sectionSetup: CreateOrEditSectionSetupDto = new CreateOrEditSectionSetupDto();



breadcrumbs: BreadcrumbItem[]= [
                        new BreadcrumbItem(this.l("SectionSetup"),"/app/main/cooperate/sectionSetups"),
                        new BreadcrumbItem(this.l('Entity_Name_Plural_Here') + '' + this.l('Details')),
                    ];
    constructor(
        injector: Injector,
        private _activatedRoute: ActivatedRoute,        
        private _sectionSetupsServiceProxy: SectionSetupsServiceProxy,
        private _router: Router
    ) {
        super(injector);
    }

    ngOnInit(): void {
        this.show(this._activatedRoute.snapshot.queryParams['id']);
    }

    show(sectionSetupId?: number): void {

        if (!sectionSetupId) {
            this.sectionSetup = new CreateOrEditSectionSetupDto();
            this.sectionSetup.id = sectionSetupId;

            this.active = true;
        } else {
            this._sectionSetupsServiceProxy.getSectionSetupForEdit(sectionSetupId).subscribe(result => {
                this.sectionSetup = result.sectionSetup;


                this.active = true;
            });
        }
        
    }
    
    save(): void {
        this.saving = true;
        
        this._sectionSetupsServiceProxy.createOrEdit(this.sectionSetup).subscribe(x => {
             this.saving = false;               
             this.notify.info(this.l('SavedSuccessfully'));
             this._router.navigate( ['/app/main/cooperate/sectionSetups']);
        })
    }
    
    saveAndNew(): void {
        this.saving = true;
        
        this._sectionSetupsServiceProxy.createOrEdit(this.sectionSetup).subscribe(x => {
            this.saving = false;               
            this.notify.info(this.l('SavedSuccessfully'));
            this.sectionSetup = new CreateOrEditSectionSetupDto();
        })
    }







}
