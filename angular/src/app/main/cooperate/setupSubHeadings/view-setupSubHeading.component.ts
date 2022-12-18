import { Component, ViewChild, Injector, Output, EventEmitter, OnInit } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { SetupSubHeadingsServiceProxy, GetSetupSubHeadingForViewDto, SetupSubHeadingDto } from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ActivatedRoute } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { BreadcrumbItem } from '@app/shared/common/sub-header/sub-header.component';
@Component({
    templateUrl: './view-setupSubHeading.component.html',
    animations: [appModuleAnimation()]
})
export class ViewSetupSubHeadingComponent extends AppComponentBase implements OnInit {

    active = false;
    saving = false;

    item: GetSetupSubHeadingForViewDto;

breadcrumbs: BreadcrumbItem[]= [
                        new BreadcrumbItem(this.l("SetupSubHeading"),"/app/main/cooperate/setupSubHeadings"),
                        new BreadcrumbItem(this.l('SetupSubHeadings') + '' + this.l('Details')),
                    ];
    constructor(
        injector: Injector,
        private _activatedRoute: ActivatedRoute,
         private _setupSubHeadingsServiceProxy: SetupSubHeadingsServiceProxy
    ) {
        super(injector);
        this.item = new GetSetupSubHeadingForViewDto();
        this.item.setupSubHeading = new SetupSubHeadingDto();        
    }

    ngOnInit(): void {
        this.show(this._activatedRoute.snapshot.queryParams['id']);
    }

    show(setupSubHeadingId: number): void {
      this._setupSubHeadingsServiceProxy.getSetupSubHeadingForView(setupSubHeadingId).subscribe(result => {      
                 this.item = result;
                this.active = true;
            });       
    }
}
