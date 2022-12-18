import { Component, ViewChild, Injector, Output, EventEmitter, OnInit} from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { finalize } from 'rxjs/operators';
import { SetupQualitativesServiceProxy, CreateOrEditSetupQualitativeDto ,SetupQualitativeSectionSetupLookupTableDto
					,SetupQualitativeSetupSubHeadingLookupTableDto
					} from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/common/app-component-base';
import * as moment from 'moment';
import { ActivatedRoute, Router } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import {Observable} from "@node_modules/rxjs";
import { BreadcrumbItem } from '@app/shared/common/sub-header/sub-header.component';


@Component({
    templateUrl: './create-or-edit-setupQualitative.component.html',
    animations: [appModuleAnimation()]
})
export class CreateOrEditSetupQualitativeComponent extends AppComponentBase implements OnInit {
    active = false;
    saving = false;
    
    setupQualitative: CreateOrEditSetupQualitativeDto = new CreateOrEditSetupQualitativeDto();

    sectionSetupSection = '';
    setupSubHeadingSubHeading = '';

	allSectionSetups: SetupQualitativeSectionSetupLookupTableDto[];
						allSetupSubHeadings: SetupQualitativeSetupSubHeadingLookupTableDto[];
					
breadcrumbs: BreadcrumbItem[]= [
                        new BreadcrumbItem(this.l("SetupQualitative"),"/app/main/cooperate/setupQualitatives"),
                        new BreadcrumbItem(this.l('Entity_Name_Plural_Here') + '' + this.l('Details')),
                    ];
    constructor(
        injector: Injector,
        private _activatedRoute: ActivatedRoute,        
        private _setupQualitativesServiceProxy: SetupQualitativesServiceProxy,
        private _router: Router
    ) {
        super(injector);
    }

    ngOnInit(): void {
        this.show(this._activatedRoute.snapshot.queryParams['id']);
    }

    show(setupQualitativeId?: number): void {

        if (!setupQualitativeId) {
            this.setupQualitative = new CreateOrEditSetupQualitativeDto();
            this.setupQualitative.id = setupQualitativeId;
            this.sectionSetupSection = '';
            this.setupSubHeadingSubHeading = '';

            this.active = true;
        } else {
            this._setupQualitativesServiceProxy.getSetupQualitativeForEdit(setupQualitativeId).subscribe(result => {
                this.setupQualitative = result.setupQualitative;

                this.sectionSetupSection = result.sectionSetupSection;
                this.setupSubHeadingSubHeading = result.setupSubHeadingSubHeading;

                this.active = true;
            });
        }
        this._setupQualitativesServiceProxy.getAllSectionSetupForTableDropdown().subscribe(result => {						
						this.allSectionSetups = result;
					});
					this._setupQualitativesServiceProxy.getAllSetupSubHeadingForTableDropdown().subscribe(result => {						
						this.allSetupSubHeadings = result;
					});
					
    }
    
    save(): void {
        this.saving = true;
        
        this._setupQualitativesServiceProxy.createOrEdit(this.setupQualitative).subscribe(x => {
             this.saving = false;               
             this.notify.info(this.l('SavedSuccessfully'));
             this._router.navigate( ['/app/main/cooperate/setupQualitatives']);
        })
    }
    
    saveAndNew(): void {
        this.saving = true;
        
        this._setupQualitativesServiceProxy.createOrEdit(this.setupQualitative).subscribe(x => {
            this.saving = false;               
            this.notify.info(this.l('SavedSuccessfully'));
            this.setupQualitative = new CreateOrEditSetupQualitativeDto();
        })
    }







}
