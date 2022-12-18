import { Component, EventEmitter, Injector, OnInit, Output, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import { IndividualServiceProxy, RecommendationDto } from '@shared/service-proxies/service-proxies';
import { ModalDirective } from 'ngx-bootstrap/modal';

@Component({
  selector: 'lendingOutputModal',
  templateUrl: './lending-output-modal.component.html',
  animations: [appModuleAnimation()],
  styles: [
  ]
})
export class LendingOutputModalComponent extends AppComponentBase implements OnInit {
  saving: boolean = false;
  active: boolean = false;
  recommendations: RecommendationDto[] = [];
  totalScore: number;
  @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();
  @ViewChild('modal') modal: ModalDirective;
  constructor(
    injector: Injector,
    private _service: IndividualServiceProxy, 
    private route: ActivatedRoute,
    private router: Router
  ) { 
    super(injector)
  }
  ngOnInit(): void {
  }
  getLendingOutPut(): void{
    this._service.getRecommendation().subscribe((result) => {
      this.recommendations = result;
      this.getTotalScore();
    });
  }

  reload() {
    this.router.routeReuseStrategy.shouldReuseRoute = () => false;
    this.router.onSameUrlNavigation = 'reload';
    this.router.navigate(['./'], { relativeTo: this.route });
  }
  show(): void { 
    this.active = true;
    this.getLendingOutPut();
    this.modal.show();
}

close(): void {
  this.modal.hide();
  this.active = false;
}

getTotalScore() {
  let total = 0;
  for (var i = 0; i < this.recommendations.length; i++) {
      if (this.recommendations[i].score) {
          total += this.recommendations[i].score;
          this.totalScore = total;
      }
  }
  return total;
}
getColorDecision(recommend){ (1)
  switch (recommend){
    case 'Approved' :
      return '#128a38';
    case 'Rejected' :
      return '#fc030b';
  }
}
}
