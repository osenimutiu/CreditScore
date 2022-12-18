import { Component, ViewChild, Injector, Output, EventEmitter, OnInit} from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { finalize } from 'rxjs/operators';
import { SubHeadingSetupsServiceProxy, CreateOrEditSubHeadingSetupDto ,SubHeadingSetupSectionSetupLookupTableDto
					} from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/common/app-component-base';
import * as moment from 'moment';
import { ActivatedRoute, Router } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import {Observable} from "@node_modules/rxjs";
import { BreadcrumbItem } from '@app/shared/common/sub-header/sub-header.component';


@Component({
    templateUrl: './create-or-edit-subHeadingSetup.component.html',
    animations: [appModuleAnimation()]
})
export class CreateOrEditSubHeadingSetupComponent extends AppComponentBase implements OnInit {
    active = false;
    saving = false;
    
    subHeadingSetup: CreateOrEditSubHeadingSetupDto = new CreateOrEditSubHeadingSetupDto();

    sectionSetupSection = '';

	allSectionSetups: SubHeadingSetupSectionSetupLookupTableDto[];
					
breadcrumbs: BreadcrumbItem[]= [
                        new BreadcrumbItem(this.l("SubHeadingSetup"),"/app/main/cooperate/subHeadingSetups"),
                        new BreadcrumbItem(this.l('Entity_Name_Plural_Here') + '' + this.l('Details')),
                    ];
    constructor(
        injector: Injector,
        private _activatedRoute: ActivatedRoute,        
        private _subHeadingSetupsServiceProxy: SubHeadingSetupsServiceProxy,
        private _router: Router
    ) {
        super(injector);
    }

    ngOnInit(): void {
        this.show(this._activatedRoute.snapshot.queryParams['id']);
    }

    show(subHeadingSetupId?: number): void {

        if (!subHeadingSetupId) {
            this.subHeadingSetup = new CreateOrEditSubHeadingSetupDto();
            this.subHeadingSetup.id = subHeadingSetupId;
            this.sectionSetupSection = '';

            this.active = true;
        } else {
            this._subHeadingSetupsServiceProxy.getSubHeadingSetupForEdit(subHeadingSetupId).subscribe(result => {
                this.subHeadingSetup = result.subHeadingSetup;

                this.sectionSetupSection = result.sectionSetupSection;

                this.active = true;
            });
        }
        this._subHeadingSetupsServiceProxy.getAllSectionSetupForTableDropdown().subscribe(result => {						
						this.allSectionSetups = result;
					});
					
    }
    
    save(): void {
        this.saving = true;
        
        this._subHeadingSetupsServiceProxy.createOrEdit(this.subHeadingSetup).subscribe(x => {
             this.saving = false;               
             this.notify.info(this.l('SavedSuccessfully'));
             this._router.navigate( ['/app/main/cooperate/subHeadingSetups']);
        })
    }
    
    saveAndNew(): void {
        this.saving = true;
        
        this._subHeadingSetupsServiceProxy.createOrEdit(this.subHeadingSetup).subscribe(x => {
            this.saving = false;               
            this.notify.info(this.l('SavedSuccessfully'));
            this.subHeadingSetup = new CreateOrEditSubHeadingSetupDto();
        })
    }







}
