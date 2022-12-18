import { Component, EventEmitter, Injector, OnInit, Output } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import { DigSetUpDto, DigSetUpServiceProxy } from '@shared/service-proxies/service-proxies';

@Component({
  selector: 'app-dig-setup',
  templateUrl: './dig-setup.component.html',
  styleUrls: ['./dig-setup.component.css'],
  animations: [appModuleAnimation()] 
  // styles: [
  // ]
})
export class DigSetupComponent extends AppComponentBase implements OnInit {
setUpList: DigSetUpDto[] = [];
exportsetUpList: DigSetUpDto[] = [];
p:number=1;
@Output() modalSave: EventEmitter<any> = new EventEmitter<any>();
  constructor(private _service: DigSetUpServiceProxy,
    private inj: Injector,
    private route: ActivatedRoute,
    private router: Router) { super(inj)}

  ngOnInit(): void {
    this.getSetUp();
    this.getSetUpForExort();
  }
  getSetUp(){
    this._service.getDigLendSetUp().subscribe(res=>{
      this.setUpList = res;
    });
  }
  getSetUpForExort(){
    this._service.getDigLendSetUpForExport().subscribe(res=>{
      this.exportsetUpList = res;
    });
  }
  reload() {
    this.router.routeReuseStrategy.shouldReuseRoute = () => false;
    this.router.onSameUrlNavigation = 'reload';
    this.router.navigate(['./'], { relativeTo: this.route });
  }

  exportExcel() {
    import("xlsx").then(xlsx => {
        const worksheet = xlsx.utils.json_to_sheet(this.exportsetUpList); // Sale Data
        const workbook = { Sheets: { 'data': worksheet }, SheetNames: ['data'] };
        const excelBuffer: any = xlsx.write(workbook, { bookType: 'xlsx', type: 'array' });
        this.saveAsExcelFile(excelBuffer, "DigitalLending");
    });
  }
  saveAsExcelFile(buffer: any, fileName: string): void {
    import("file-saver").then(FileSaver => {
      let EXCEL_TYPE =
        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet;charset=UTF-8";
      let EXCEL_EXTENSION = ".xlsx";
      const data: Blob = new Blob([buffer], {
        type: EXCEL_TYPE
      });
      FileSaver.saveAs(
        data,
        fileName +  EXCEL_EXTENSION +"_export_" + new Date().getTime() + EXCEL_EXTENSION
        // fileName + EXCEL_EXTENSION
      );
    });
  }
}
