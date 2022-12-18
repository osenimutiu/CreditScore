import { Component, ViewChild, Injector, Output, EventEmitter, OnInit } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { SubHeadingSetupsServiceProxy, GetSubHeadingSetupForViewDto, SubHeadingSetupDto } from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ActivatedRoute } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { BreadcrumbItem } from '@app/shared/common/sub-header/sub-header.component';
@Component({
    templateUrl: './view-subHeadingSetup.component.html',
    animations: [appModuleAnimation()]
})
export class ViewSubHeadingSetupComponent extends AppComponentBase implements OnInit {

    active = false;
    saving = false;

    item: GetSubHeadingSetupForViewDto;

breadcrumbs: BreadcrumbItem[]= [
                        new BreadcrumbItem(this.l("SubHeadingSetup"),"/app/main/cooperate/subHeadingSetups"),
                        new BreadcrumbItem(this.l('SubHeadingSetups') + '' + this.l('Details')),
                    ];
    constructor(
        injector: Injector,
        private _activatedRoute: ActivatedRoute,
         private _subHeadingSetupsServiceProxy: SubHeadingSetupsServiceProxy
    ) {
        super(injector);
        this.item = new GetSubHeadingSetupForViewDto();
        this.item.subHeadingSetup = new SubHeadingSetupDto();        
    }

    ngOnInit(): void {
        this.show(this._activatedRoute.snapshot.queryParams['id']);
    }

    show(subHeadingSetupId: number): void {
      this._subHeadingSetupsServiceProxy.getSubHeadingSetupForView(subHeadingSetupId).subscribe(result => {      
                 this.item = result;
                this.active = true;
            });       
    }
}
