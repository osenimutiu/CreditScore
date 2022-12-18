import { Component, EventEmitter, Injector, OnInit, Output } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import { RetailCutoffDto, RetailScoringDto, RetailScoringServiceProxy } from '@shared/service-proxies/service-proxies';
import Chart from 'chart.js/auto';
import * as _ from 'lodash';

@Component({
  selector: 'app-retail-scoring',
  animations: [appModuleAnimation()],
  templateUrl: './retail-scoring.component.html',
  styles: [
  ]
})
export class RetailScoringComponent  extends AppComponentBase implements OnInit {
  retailScoring: RetailScoringDto[] = [];
  listCutOff: RetailCutoffDto[] = [];
  p:number = 1;
  totalWeighted: number;
totalCutOff: number;
overallWeight: number;
totalMaxScore: number;
totalAttributeScore: number;
decision:string;
WeightedScore = [];
Attribte= [];
barchart:any = [];
chartTile:string= 'Chart';
eligibilityCheck:boolean = false;
@Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

  constructor(
    private inj: Injector,
    private _service: RetailScoringServiceProxy,
    private route: ActivatedRoute,
    private router: Router
  ) {
    super(inj);
  }

  ngOnInit(): void {
    this.getRetailScoring();
    this.getCuOff();
  }

  getRetailScoring(){
    this._service.getRetailScoring().subscribe(res=>{
      this.retailScoring = res;
      this.getTotal();
      this.getTotalWeight();
      this.getTotalMaxScore();
      this.getTotalAttibuteScore();
      this.retailScoring.forEach(x => {
        this.WeightedScore.push(x.weightedAttribute);
        this.Attribte.push(x.attribute);
      });
      this
      this.barchart = new Chart('chart', {
        type: 'bar',
        data: {
          labels: this.Attribte,
          datasets: [
            {
            data: this.WeightedScore,  
            label: 'Score',
            borderColor: '#cc2904',  
            backgroundColor: ["#cc2904",
                  "#0000FF",  
                  "#9966FF",  
                  "#4C4CFF",  
                  "#00FFFF",  
                  "#f990a7",  
                  "#aad2ed",  
                  "#FF00FF",  
                  "Blue",  
                  "Red",  
                  "Blue"  
                ]
            }
          
          ]
  
        },
        options: {  
          // legend: {  
          //   display: true  
          // }, 
          scales: {  
            xAxes: {  
              display: true  
            },  
            yAxes: {  
              display: true  
            },  
          }  
        } 
      });
    });
  }

  reload() {
    this.router.routeReuseStrategy.shouldReuseRoute = () => false;
    this.router.onSameUrlNavigation = 'reload';
    this.router.navigate(['./'], { relativeTo: this.route });
  }

  getTotal() {
    let total = 0;
    for (var i = 0; i < this.retailScoring.length; i++) {
        if (this.retailScoring[i].weightedAttribute) {
            total += this.retailScoring[i].weightedAttribute;
            this.totalWeighted = total;
        }
    }
    return total;
  }

  getTotalWeight() {
    let total = 0;
    for (var i = 0; i < this.retailScoring.length; i++) {
        if (this.retailScoring[i].weight) {
            total += this.retailScoring[i].weight;
            this.overallWeight = total;
        }
    }
    return total;
  }
  getTotalMaxScore() {
    let total = 0;
    for (var i = 0; i < this.retailScoring.length; i++) {
        if (this.retailScoring[i].maxScore) {
            total += this.retailScoring[i].maxScore;
            this.totalMaxScore = total;
        }
    }
    return total;
  }

  getTotalAttibuteScore() {
    let total = 0;
    for (var i = 0; i < this.retailScoring.length; i++) {
        if (this.retailScoring[i].attributeScore) {
            total += this.retailScoring[i].attributeScore;
            this.totalAttributeScore = total;
        }
    }
    return total;
  }

  getCuOff(){
    this._service.getRetailCutoff().subscribe(res=> {
      this.listCutOff = res;
      this.getTotalCutOff();
    });
  }
    
  getTotalCutOff() {
    let total = 0;
    for (var i = 0; i < this.listCutOff.length; i++) {
        if (this.listCutOff[i].cutoffValue) {
            total += this.listCutOff[i].cutoffValue;
            this.totalCutOff = total;
            if(this.totalCutOff == this.totalWeighted || this.totalCutOff < this.totalWeighted ){
              this.decision = 'Eligible';
            }else{
              this.decision = 'Ineligible';
            }
        }
    }
    return total;
  }
  getColorDecision(recommend){ (1)
    switch (recommend){
      case 'Eligible' :
        return '#128a38';
      case 'Ineligible' :
        return '#fc030b';
    }
  }

  delete(del: RetailScoringDto){
    this.message.confirm(
      '',
      this.l('Are you sure to delete this record?'),
      (isConfirmed) => {
          if (isConfirmed) {
              this._service.deteteRetailScoring(del.id)
              .subscribe(() => {
                      this.notify.success(this.l('Successfully Deleted'));
                      _.remove(this.retailScoring, del);
                      this.reload();
                  });
          }
      }
  );
  }

  eligibilityStatus(){
    this.eligibilityCheck = !this.eligibilityCheck;
  }
  cancelEligibility(){
    this.eligibilityCheck = false;
    this.reload();
  }
}
