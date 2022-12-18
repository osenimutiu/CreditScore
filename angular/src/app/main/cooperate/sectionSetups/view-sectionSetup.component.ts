import { Component, ViewChild, Injector, Output, EventEmitter, OnInit } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { SectionSetupsServiceProxy, GetSectionSetupForViewDto, SectionSetupDto } from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ActivatedRoute } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { BreadcrumbItem } from '@app/shared/common/sub-header/sub-header.component';
@Component({
    templateUrl: './view-sectionSetup.component.html',
    animations: [appModuleAnimation()]
})
export class ViewSectionSetupComponent extends AppComponentBase implements OnInit {

    active = false;
    saving = false;

    item: GetSectionSetupForViewDto;

breadcrumbs: BreadcrumbItem[]= [
                        new BreadcrumbItem(this.l("SectionSetup"),"/app/main/cooperate/sectionSetups"),
                        new BreadcrumbItem(this.l('SectionSetups') + '' + this.l('Details')),
                    ];
    constructor(
        injector: Injector,
        private _activatedRoute: ActivatedRoute,
         private _sectionSetupsServiceProxy: SectionSetupsServiceProxy
    ) {
        super(injector);
        this.item = new GetSectionSetupForViewDto();
        this.item.sectionSetup = new SectionSetupDto();        
    }

    ngOnInit(): void {
        this.show(this._activatedRoute.snapshot.queryParams['id']);
    }

    show(sectionSetupId: number): void {
      this._sectionSetupsServiceProxy.getSectionSetupForView(sectionSetupId).subscribe(result => {      
                 this.item = result;
                this.active = true;
            });       
    }
}
