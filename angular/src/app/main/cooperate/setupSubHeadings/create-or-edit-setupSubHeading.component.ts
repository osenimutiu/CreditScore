import { Component, ViewChild, Injector, Output, EventEmitter, OnInit} from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { finalize } from 'rxjs/operators';
import { SetupSubHeadingsServiceProxy, CreateOrEditSetupSubHeadingDto ,SetupSubHeadingSectionSetupLookupTableDto
					} from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/common/app-component-base';
import * as moment from 'moment';
import { ActivatedRoute, Router } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import {Observable} from "@node_modules/rxjs";
import { BreadcrumbItem } from '@app/shared/common/sub-header/sub-header.component';


@Component({
    templateUrl: './create-or-edit-setupSubHeading.component.html',
    animations: [appModuleAnimation()]
})
export class CreateOrEditSetupSubHeadingComponent extends AppComponentBase implements OnInit {
    active = false;
    saving = false;
    
    setupSubHeading: CreateOrEditSetupSubHeadingDto = new CreateOrEditSetupSubHeadingDto();

    sectionSetupSection = '';

	allSectionSetups: SetupSubHeadingSectionSetupLookupTableDto[];
					
breadcrumbs: BreadcrumbItem[]= [
                        new BreadcrumbItem(this.l("SetupSubHeading"),"/app/main/cooperate/setupSubHeadings"),
                        new BreadcrumbItem(this.l('Entity_Name_Plural_Here') + '' + this.l('Details')),
                    ];
    constructor(
        injector: Injector,
        private _activatedRoute: ActivatedRoute,        
        private _setupSubHeadingsServiceProxy: SetupSubHeadingsServiceProxy,
        private _router: Router
    ) {
        super(injector);
    }

    ngOnInit(): void {
        this.show(this._activatedRoute.snapshot.queryParams['id']);
    }

    show(setupSubHeadingId?: number): void {

        if (!setupSubHeadingId) {
            this.setupSubHeading = new CreateOrEditSetupSubHeadingDto();
            this.setupSubHeading.id = setupSubHeadingId;
            this.sectionSetupSection = '';

            this.active = true;
        } else {
            this._setupSubHeadingsServiceProxy.getSetupSubHeadingForEdit(setupSubHeadingId).subscribe(result => {
                this.setupSubHeading = result.setupSubHeading;

                this.sectionSetupSection = result.sectionSetupSection;

                this.active = true;
            });
        }
        this._setupSubHeadingsServiceProxy.getAllSectionSetupForTableDropdown().subscribe(result => {						
						this.allSectionSetups = result;
					});
					
    }
    
    save(): void {
        this.saving = true;
        
        this._setupSubHeadingsServiceProxy.createOrEdit(this.setupSubHeading).subscribe(x => {
             this.saving = false;               
             this.notify.info(this.l('SavedSuccessfully'));
             this._router.navigate( ['/app/main/cooperate/setupSubHeadings']);
        })
    }
    
    saveAndNew(): void {
        this.saving = true;
        
        this._setupSubHeadingsServiceProxy.createOrEdit(this.setupSubHeading).subscribe(x => {
            this.saving = false;               
            this.notify.info(this.l('SavedSuccessfully'));
            this.setupSubHeading = new CreateOrEditSetupSubHeadingDto();
        })
    }







}
