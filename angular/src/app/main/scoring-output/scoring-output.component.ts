import { Component, ElementRef, EventEmitter, Injector, OnInit, Output, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import { CreateScoringOutputInput, RatingPredictionOutputListDto, RatingPredictionOutputServiceProxy, ScoringOutputListDto, ScoringOutputServiceProxy } from '@shared/service-proxies/service-proxies';
import * as _ from 'lodash';
import { BsModalService, ModalDirective } from 'ngx-bootstrap/modal';
import { Paginator } from 'primeng/paginator';
import { Table } from 'primeng/table';
import { finalize } from 'rxjs/operators';
import { LazyLoadEvent } from 'primeng/public_api';

@Component({
  selector: 'scoringOutputModal',
  templateUrl: './scoring-output.component.html',
  animations: [appModuleAnimation()],
  styles: [
  ]
})
export class ScoringOutputComponent extends AppComponentBase {
  p: number = 1;
  scoringOutputs: ScoringOutputListDto[] = [];
  rPOutputs: RatingPredictionOutputListDto[] = [];
  filter: string = '';
  app_TypeFilter = '';

  @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();
  @ViewChild('scoringOutputModal') modal: ModalDirective;
  @ViewChild('app_TypeInput') app_TypeInput: ElementRef;
  
  @ViewChild('dataTable', { static: true }) dataTable: Table;
    @ViewChild('paginator', { static: true }) paginator: Paginator;
  scoringOutput: CreateScoringOutputInput = new CreateScoringOutputInput();
  active: boolean = false;
  saving: boolean = false;
  closeResult = ''; 
  id: number;
  app_Type: string;
  editingScoringOutput: ScoringOutputListDto = null;

  getColor(recommend){ (2)
    switch (recommend){
      case 'Grant without further Assement' :
        return '#89eb34';
      case 'Grant with Reservation' :
        return 'yellow';
      case 'Deny' :
        return '#fc030b';
    }
  }
 
  

  constructor(
    injector: Injector,
    private _scoringOutputService: ScoringOutputServiceProxy,
    private _rPOutputService:RatingPredictionOutputServiceProxy,
    private _modalService: BsModalService,
    private route: ActivatedRoute,
    private router: Router
  ) {
    super(injector);
   }

  ngOnInit(): void {
    this.getScoringOutput(); 
    //this.getScoringOutputB(); 
    //this.getRatingPredictionOutput(); 
  }

  
  getScoringOutput(){
    this._scoringOutputService.getScoringOutput(
      this.filter,
      this.app_TypeFilter
    ).subscribe((result) => {
      this.scoringOutputs = result.items;
    });
  }

  getScoringOutputB(event?: LazyLoadEvent){
    if (this.primengTableHelper.shouldResetPaging(event)) {
      this.paginator.changePage(0);
      return;
  }

  this.primengTableHelper.showLoadingIndicator();

    this._scoringOutputService.getScoringOutputB(
      this.filter,
      this.app_TypeFilter,
      // this.primengTableHelper.getSorting(this.dataTable),
      //       this.primengTableHelper.getSkipCount(this.paginator, event),
      //       this.primengTableHelper.getMaxResultCount(this.paginator, event)
      ).subscribe((result) => {
        //this.primengTableHelper.totalRecordsCount = result.totalCount;
            this.primengTableHelper.records = result.items;
            this.primengTableHelper.hideLoadingIndicator();
      //this.scoringOutputs = result.items;
    });
  }

  reloadPage(): void {
    this.paginator.changePage(this.paginator.getPage());
}


  Search(){
    if(this.app_Type != ""){
      this.scoringOutputs = this.scoringOutputs.filter(res=>{ 
        return res.app_Type.toLocaleLowerCase().match(this.app_Type.toLocaleLowerCase());
      });
    }else if(this.app_Type == ""){
      this.ngOnInit();
    }
    
  }

  show(): void {
    this.modal.show();
  }
  
  close(): void {
    this.active = false;
    this.modal.hide();
  }

  // close(): void{
  //   this.modal.hide();
  //   this.active = false;
  // }

  save(): void {
    let input = new CreateScoringOutputInput();
    this.saving = true;
    this._scoringOutputService.createScoringOutput(input)
        .pipe(finalize(() => { this.saving = false; }))
        .subscribe(() => {
            this.notify.info(this.l('SavedSuccessfully'));
            this.close();
            this.modalSave.emit(null);
        });
 }

 deleteScoringOutput(scoringOutput: ScoringOutputListDto): void {
  this.message.confirm(
      '',
      this.l('Are you sure to delete this record?'),
      (isConfirmed) => {
          if (isConfirmed) {
              this._scoringOutputService.deleteScoringOutput(scoringOutput.id)
                  .subscribe(() => {
                      
                      this.notify.error(this.l('Successfully Deleted'));
                      _.remove(this.scoringOutputs, scoringOutput);
                  });
          }
      }
  );
}

reload() {
  this.router.routeReuseStrategy.shouldReuseRoute = () => false;
  this.router.onSameUrlNavigation = 'reload';
  this.router.navigate(['./'], { relativeTo: this.route });
}



getRatingPredictionOutput(): void{
  this._rPOutputService.getRatingPredictionOutput(this.filter).subscribe((result) => {
    this.rPOutputs = result.items;
  });
}


}
