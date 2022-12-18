import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { GiniInclusiveServiceProxy, VintageAnalysisDto } from '@shared/service-proxies/service-proxies';

@Component({
  selector: 'app-vintage-analysis',
  templateUrl: './vintage-analysis.component.html',
  animations: [appModuleAnimation()],
  styles: [
  ]
})
export class VintageAnalysisComponent implements OnInit {
  vintages: VintageAnalysisDto[] = [];
  p:number = 1;
 
  constructor(private _service: GiniInclusiveServiceProxy,
    private route: ActivatedRoute,
    private router: Router) { }
  ngOnInit(): void {
    this.getVintageAnalysis();
  }
  getVintageAnalysis(){
    this._service.getVintageAnalysis().subscribe(res => {
       this.vintages = res;
    });
  }

  reload() {
    this.router.routeReuseStrategy.shouldReuseRoute = () => false;
    this.router.onSameUrlNavigation = 'reload';
    this.router.navigate(['./'], { relativeTo: this.route });
  }
}
