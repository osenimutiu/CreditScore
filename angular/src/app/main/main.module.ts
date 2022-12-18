import { CommonModule, DatePipe } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AppCommonModule } from '@app/shared/common/app-common.module';
import { CooperateAppraisalsComponent } from './cooperate/cooperateAppraisals/cooperateAppraisals.component';
import { ViewCooperateAppraisalComponent } from './cooperate/cooperateAppraisals/view-cooperateAppraisal.component';
import { CreateOrEditCooperateAppraisalComponent } from './cooperate/cooperateAppraisals/create-or-edit-cooperateAppraisal.component';
import { CooperateAppraisalSetupQualitativeLookupTableModalComponent } from './cooperate/cooperateAppraisals/cooperateAppraisal-setupQualitative-lookup-table-modal.component';

import { SetupQualitativesComponent } from './cooperate/setupQualitatives/setupQualitatives.component';
import { ViewSetupQualitativeComponent } from './cooperate/setupQualitatives/view-setupQualitative.component';
import { CreateOrEditSetupQualitativeComponent } from './cooperate/setupQualitatives/create-or-edit-setupQualitative.component';

import { SetupSubHeadingsComponent } from './cooperate/setupSubHeadings/setupSubHeadings.component';
import { ViewSetupSubHeadingComponent } from './cooperate/setupSubHeadings/view-setupSubHeading.component';
import { CreateOrEditSetupSubHeadingComponent } from './cooperate/setupSubHeadings/create-or-edit-setupSubHeading.component';

import { SubHeadingSetupsComponent } from './cooperate/subHeadingSetups/subHeadingSetups.component';
import { ViewSubHeadingSetupComponent } from './cooperate/subHeadingSetups/view-subHeadingSetup.component';
import { CreateOrEditSubHeadingSetupComponent } from './cooperate/subHeadingSetups/create-or-edit-subHeadingSetup.component';

import { QualitativeSetupsComponent } from './cooperate/qualitativeSetups/qualitativeSetups.component';
import { ViewQualitativeSetupComponent } from './cooperate/qualitativeSetups/view-qualitativeSetup.component';
import { CreateOrEditQualitativeSetupComponent } from './cooperate/qualitativeSetups/create-or-edit-qualitativeSetup.component';

import { SubSectorSetupsComponent } from './cooperate/subSectorSetups/subSectorSetups.component';
import { ViewSubSectorSetupComponent } from './cooperate/subSectorSetups/view-subSectorSetup.component';
import { CreateOrEditSubSectorSetupComponent } from './cooperate/subSectorSetups/create-or-edit-subSectorSetup.component';

import { SectionSetupsComponent } from './cooperate/sectionSetups/sectionSetups.component';
import { ViewSectionSetupComponent } from './cooperate/sectionSetups/view-sectionSetup.component';
import { CreateOrEditSectionSetupComponent } from './cooperate/sectionSetups/create-or-edit-sectionSetup.component';

import { LogisticRegressionInputsComponent } from './logisticRegression/logisticRegressionInputs/logisticRegressionInputs.component';
import { ViewLogisticRegressionInputModalComponent } from './logisticRegression/logisticRegressionInputs/view-logisticRegressionInput-modal.component';
import { CreateOrEditLogisticRegressionInputModalComponent } from './logisticRegression/logisticRegressionInputs/create-or-edit-logisticRegressionInput-modal.component';

import { RegressionOutputsComponent } from './regression/regressionOutputs/regressionOutputs.component';
import { ViewRegressionOutputModalComponent } from './regression/regressionOutputs/view-regressionOutput-modal.component';
import { CreateOrEditRegressionOutputModalComponent } from './regression/regressionOutputs/create-or-edit-regressionOutput-modal.component';
import { AutoCompleteModule } from 'primeng/autocomplete';
import { EditorModule } from 'primeng/editor';
import { InputMaskModule } from 'primeng/inputmask';
import { UtilsModule } from '@shared/utils/utils.module';
import { CountoModule } from 'angular2-counto';
import { ModalModule } from 'ngx-bootstrap/modal';
import { TabsModule } from 'ngx-bootstrap/tabs';
import { TooltipModule } from 'ngx-bootstrap/tooltip';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { PopoverModule } from 'ngx-bootstrap/popover';
import { DashboardComponent } from './dashboard/dashboard.component';
import { MainRoutingModule } from './main-routing.module';
import { NgxChartsModule } from '@swimlane/ngx-charts';
//import { NgxPaginationModule } from 'ngx-pagination';888888888
import { PaginatorModule } from 'primeng/paginator';
import { TableModule } from 'primeng/table';
// For MDB Angular Pro
import { ChartsModule, ChartSimpleModule, WavesModule } from 'ng-uikit-pro-standard'
import { ChartModule } from 'angular2-chartjs';

import { BsDatepickerConfig, BsDaterangepickerConfig, BsLocaleService } from 'ngx-bootstrap/datepicker';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { NgxBootstrapDatePickerConfigService } from 'assets/ngx-bootstrap/ngx-bootstrap-datepicker-config.service';
import { HistogramComponent } from './histogram/histogram.component';
import { NgxPaginationModule } from 'ngx-pagination';
import { ScoringInputDataComponent } from './scoring-input-data/scoring-input-data.component';
import { ScoringOutputComponent } from './scoring-output/scoring-output.component';
import { ChangebProfilePictureModalComponent } from './scoring-input-data/changeb-profile-picture-modal/changeb-profile-picture-modal.component';
import { ImageCropperModule } from 'ngx-image-cropper';
import { FileUploadModule, FileUploadModule as PrimeNgFileUploadModule } from 'primeng/fileupload';
import { AppBsModalModule } from '@shared/common/appBsModal/app-bs-modal.module';
import { FileUploadComponent } from './scoring-input-data/file-upload/file-upload.component';
import { ApplicationScoringComponent } from './application-scoring/application-scoring.component';
import { CreateApplicationScoringModalComponent } from './application-scoring/create-application-scoring-modal/create-application-scoring-modal.component';
import { ScoringInputDataEditModalComponent } from './scoring-input-data/scoring-input-data-edit-modal/scoring-input-data-edit-modal.component';
import { InputDataComponent } from './input-data/input-data.component';
import { CreateInputDataModalComponent } from './input-data/create-input-data-modal/create-input-data-modal.component';
import { SmeLendingComponent } from './sme-lending/sme-lending.component';
import { EligibilityComponent } from './eligibility/eligibility.component';
import { ULoanRequestsComponent } from './uLoanRequests/uLoanRequests.component';
import { ViewULoanRequestModalComponent } from './uLoanRequests/view-uLoanRequest-modal.component';
import { CreateOrEditULoanRequestModalComponent } from './uLoanRequests/create-or-edit-uLoanRequest-modal.component';
import { LoanRequestsComponent } from './loanRequests/loanRequests.component';
import { ViewLoanRequestModalComponent } from './loanRequests/view-loanRequest-modal.component';
import { CreateOrEditLoanRequestModalComponent } from './loanRequests/create-or-edit-loanRequest-modal.component';
import { SmeLendingModalComponent } from './sme-lending/sme-lending-modal/sme-lending-modal.component';
import { FinancialRatioComponent } from './financial-ratio/financial-ratio.component';
import { CreateFinancialRatioModalComponent } from './financial-ratio/create-financial-ratio-modal/create-financial-ratio-modal.component';
import { SubmittedLoanRequestComponent } from './submitted-loan-request/submitted-loan-request.component';
import { ViewRequestModalComponent } from './submitted-loan-request/view-request-modal/view-request-modal.component';
import { SetupComponent } from './setup/setup.component';
import { CreateSetupModalComponent } from './setup/create-setup-modal/create-setup-modal.component';
import { LogRegComponent } from './log-reg/log-reg.component'
import { CurveComponent } from './curve/curve.component';;
import { RocCurveComponent } from './roc-curve/roc-curve.component';
import { GiniCurveComponent } from './gini-curve/gini-curve.component'
import { RegOutputComponent } from './reg-output/reg-output.component';
import { Ng2OrderModule } from 'ng2-order-pipe';
import { WoeAgeComponent } from './woe-age/woe-age.component';
import { WoeTimeatjobComponent } from './woe-timeatjob/woe-timeatjob.component';
import { WoePaymentperformanceComponent } from './woe-paymentperformance/woe-paymentperformance.component';
import { PsiComponent } from './psi/psi.component';;
import { ProductComponent } from './product/product.component'
;
import { CurrAccStatComponent } from './curr-acc-stat/curr-acc-stat.component'
;
import { LocationComponent } from './location/location.component';
import { ResidentStatusComponent } from './resident-status/resident-status.component';;
import { PaymentPerformanceComponent } from './payment-performance/payment-performance.component';
import { AgebinComponent } from './agebin/agebin.component';
import { TimeJobbinComponent } from './time-jobbin/time-jobbin.component';;
import { DistriptiveStatisticsComponent } from './distriptive-statistics/distriptive-statistics.component'
;
import { FeatureSelectionComponent } from './feature-selection/feature-selection.component';
import { ScalingComponent } from './scaling/scaling.component';
import { ScorecardComponent } from './scorecard/scorecard.component';
import { AgeDistComponent } from './age-dist/age-dist.component'
;
import { CurrAccStausComponent } from './curr-acc-staus/curr-acc-staus.component'
;
import { CaracteristicsComponent } from './caracteristics/caracteristics.component';
import { ProfitAnalysisComponent } from './profit-analysis/profit-analysis.component';
import { StabilityTrendComponent } from './stability-trend/stability-trend.component';;
import { ScoreReportComponent } from './score-report/score-report.component'
;
import { ScorecardScalingComponent } from './scorecard-scaling/scorecard-scaling.component'
;
import { LogRegOutputComponent } from './log-reg-output/log-reg-output.component'
;
;
import { CreditscoreWoeComponent } from './creditscore-woe/creditscore-woe.component'
;
import { OutputCurveComponent } from './output-curve/output-curve.component'
;
import { OutputCurveCastatusComponent } from './output-curve-castatus/output-curve-castatus.component';
import { OutputCurveResStatComponent } from './output-curve-res-stat/output-curve-res-stat.component';
import { OutputCurvePayPerfComponent } from './output-curve-pay-perf/output-curve-pay-perf.component';;
import { OutputCurveLocationComponent } from './output-curve-location/output-curve-location.component'
;
import { SetCutoffModalComponent } from './score-report/set-cutoff-modal/set-cutoff-modal.component'
;
import { QualitativeAnalysisComponent } from './qualitative-analysis/qualitative-analysis.component'
;
import { QtvAnalyModalComponent } from './qualitative-analysis/qtv-analy-modal/qtv-analy-modal.component'
;
import { CutoffModalComponent } from './qualitative-analysis/cutoff-modal/cutoff-modal.component';;
import { RetailScoringComponent } from './retail-scoring/retail-scoring.component'
;
import { RetailScoringModalComponent } from './retail-scoring/retail-scoring-modal/retail-scoring-modal.component'
import { RetailCutoffModalComponent } from './retail-scoring/cutoff-modal/retail-cutoff-modal.component';;
import { QaRatingComponent } from './qa-rating/qa-rating.component'
;
import { ObligorJudgementalComponent } from './obligor-judgemental/obligor-judgemental.component'
;
import { ScMonitoringComponent } from './sc-monitoring/sc-monitoring.component'
;
import { RiskRatingModalComponent } from './obligor-judgemental/risk-rating-modal/risk-rating-modal.component'
;
import { ScMonitoringModalComponent } from './sc-monitoring/sc-monitoring-modal/sc-monitoring-modal.component'
;
import { CreateQaRatingModalComponent } from './qa-rating/create-qa-rating-modal/create-qa-rating-modal.component'
;
import { EditQaRatingModalComponent } from './qa-rating/edit-qa-rating-modal/edit-qa-rating-modal.component'
;
import { PostProfitAnalysisComponent } from './post-profit-analysis/post-profit-analysis.component'
;
import { AddRatingModalComponent } from './qa-rating/add-rating-modal/add-rating-modal.component';;
import { EditSetupModalComponent } from './setup/edit-setup-modal/edit-setup-modal.component'
;
import { EditScalingModalComponent } from './scaling/edit-scaling-modal/edit-scaling-modal.component'
;
import { RiskRatingComponent } from './risk-rating/risk-rating.component'
;
import { InDAppComponent } from './risk-rating/in-d-app/in-d-app.component'
;
import { BankAccComponent } from './bank-acc/bank-acc.component'
;
import { CreditLineComponent } from './credit-line/credit-line.component'
;
import { LendingOutputModalComponent } from './risk-rating/lending-output-modal/lending-output-modal.component'
;
import { ScReportModalComponent } from './score-report/sc-report-modal/sc-report-modal.component'
;
import { GiniInclusiveComponent } from './gini-inclusive/gini-inclusive.component'
;
import { CaliberationComponent } from './caliberation/caliberation.component'
;
import { CaliberationBarComponent } from './caliberation-bar/caliberation-bar.component'
;
import { GiniInclisiveModalComponent } from './gini-inclusive/gini-inclisive-modal/gini-inclisive-modal.component'
;
import { SetupPageComponent } from './setup-page/setup-page.component'
;
import { SetupSummaryComponent } from './setup-summary/setup-summary.component'
;
import { VintageAnalysisComponent } from './vintage-analysis/vintage-analysis.component'
;
import { DigSetupComponent } from './dig-setup/dig-setup.component'
;
import { DigSetupModalComponent } from './dig-setup/dig-setup-modal/dig-setup-modal.component'
;
import { CooperateRatingComponent } from './cooperate-rating/cooperate-rating.component'
;
import { CooperateRatingModalComponent } from './cooperate-rating/cooperate-rating-modal/cooperate-rating-modal.component'
;
import { CooperateScoreComponent } from './cooperate-score/cooperate-score.component'
;
import { CooperateScorecardComponent } from './cooperate-rating/cooperate-scorecard/cooperate-scorecard.component';

import { DemoRetailComponent } from './demo-retail/demo-retail.component'
;
import { SubAttributeComponent } from './sub-attribute/sub-attribute.component'
;
import { EditdemoModalComponent } from './demo-retail/editdemo-modal/editdemo-modal.component'
;
import { CreateDemoModalComponent } from './demo-retail/create-demo-modal/create-demo-modal.component'
;
import { AddsubattributeModalComponent } from './sub-attribute/addsubattribute-modal/addsubattribute-modal.component'
;
import { EditsubattributeModalComponent } from './sub-attribute/editsubattribute-modal/editsubattribute-modal.component'
;
import { SubatrributeUsepageComponent } from './subatrribute-usepage/subatrribute-usepage.component'
;
import { ApproveModalComponent } from './sub-attribute/approve-modal/approve-modal.component';
import { DeclineModalComponent } from './sub-attribute/decline-modal/decline-modal.component'
;
import { SubAttrModalComponent } from './subatrribute-usepage/sub-attr-modal/sub-attr-modal.component'
;
import { RetailScoreDetailsComponent } from './retail-score-details/retail-score-details.component'
;
import { RetailDetailModalComponent } from './retail-score-details/retail-detail-modal/retail-detail-modal.component'
;
import { CutoffScoreModalComponent } from './retail-score-details/cutoff-score-modal/cutoff-score-modal.component'
;
import { EligibilityModalComponent } from './retail-score-details/eligibility-modal/eligibility-modal.component'
;
import { GenerateCutoffComponent } from './generate-cutoff/generate-cutoff.component';;
import { SeverityComponent } from './severity/severity.component';
import { SeverityListComponent } from './severity-list/severity-list.component'
;
import { GenePointAllComponent } from './gene-point-all/gene-point-all.component'





@NgModule({
    imports: [
		AutoCompleteModule,
		EditorModule,
		InputMaskModule,
        CommonModule,
        FormsModule,
        ModalModule,
        TabsModule,
        TooltipModule,
        AppCommonModule,
        UtilsModule,
        MainRoutingModule,
        CountoModule,
        NgxChartsModule,
        BsDatepickerModule.forRoot(),
        BsDropdownModule.forRoot(),
        PopoverModule.forRoot(),
        NgxPaginationModule,
        ImageCropperModule,
        FileUploadModule,
        ModalModule.forRoot(),
        AppBsModalModule,
        PrimeNgFileUploadModule,
        ReactiveFormsModule,
        PaginatorModule,
        TableModule,
        ChartsModule,
        ChartSimpleModule,
        WavesModule,
        ChartModule,
        Ng2OrderModule
        
        
    ],
    declarations: [
		CooperateAppraisalsComponent,

		ViewCooperateAppraisalComponent,
		CreateOrEditCooperateAppraisalComponent,
    CooperateAppraisalSetupQualitativeLookupTableModalComponent,
		SetupQualitativesComponent,

		ViewSetupQualitativeComponent,
		CreateOrEditSetupQualitativeComponent,
		SetupSubHeadingsComponent,

		ViewSetupSubHeadingComponent,
		CreateOrEditSetupSubHeadingComponent,
		SubHeadingSetupsComponent,

		ViewSubHeadingSetupComponent,
		CreateOrEditSubHeadingSetupComponent,
		QualitativeSetupsComponent,

		ViewQualitativeSetupComponent,
		CreateOrEditQualitativeSetupComponent,
		SubSectorSetupsComponent,

		ViewSubSectorSetupComponent,
		CreateOrEditSubSectorSetupComponent,
		SectionSetupsComponent,

		ViewSectionSetupComponent,
		CreateOrEditSectionSetupComponent,
	LogisticRegressionInputsComponent,
	ViewLogisticRegressionInputModalComponent,
	CreateOrEditLogisticRegressionInputModalComponent,
	RegressionOutputsComponent,
	ViewRegressionOutputModalComponent,
	CreateOrEditRegressionOutputModalComponent,
        DashboardComponent,
        HistogramComponent,
        ScoringInputDataComponent,
        ScoringOutputComponent,
        ChangebProfilePictureModalComponent,
        FileUploadComponent,
        ApplicationScoringComponent,
        CreateApplicationScoringModalComponent,
        ScoringInputDataEditModalComponent,
        InputDataComponent,
        CreateInputDataModalComponent,
        SmeLendingComponent,
        EligibilityComponent,
        ULoanRequestsComponent,
	ViewULoanRequestModalComponent,
	CreateOrEditULoanRequestModalComponent,
	LoanRequestsComponent,
	ViewLoanRequestModalComponent,
	CreateOrEditLoanRequestModalComponent,
	SmeLendingModalComponent,
	FinancialRatioComponent	,
	CreateFinancialRatioModalComponent,
	SubmittedLoanRequestComponent,
	ViewRequestModalComponent,
	SetupComponent,
	CreateSetupModalComponent,
	LogisticRegressionInputsComponent,
	LogRegComponent,
        CurveComponent,
        RocCurveComponent,
        GiniCurveComponent,
        RegOutputComponent,
        WoeAgeComponent,
        WoeTimeatjobComponent,
        WoePaymentperformanceComponent,
        PsiComponent,
        ProductComponent,
        CurrAccStatComponent,
        LocationComponent,
        ResidentStatusComponent,
        PaymentPerformanceComponent,
        AgebinComponent,
        TimeJobbinComponent,
        DistriptiveStatisticsComponent,
        FeatureSelectionComponent,
        ScalingComponent,
        ScorecardComponent,
        AgeDistComponent,
        StabilityTrendComponent,
        ProfitAnalysisComponent,
        CaracteristicsComponent,
        CurrAccStausComponent,
        ScoreReportComponent,
        ScorecardScalingComponent,
        LogRegOutputComponent,
        // LoadRawDataComponent,
        CreditscoreWoeComponent,
        OutputCurveComponent,
        OutputCurveCastatusComponent,
        OutputCurvePayPerfComponent,
        OutputCurveResStatComponent,
        OutputCurveLocationComponent,
        SetCutoffModalComponent,
        QualitativeAnalysisComponent,
        QtvAnalyModalComponent,
        CutoffModalComponent,
        RetailScoringComponent,
        RetailScoringModalComponent,
        RetailCutoffModalComponent,
        QaRatingComponent,
        ObligorJudgementalComponent,
        ScMonitoringComponent,
        RiskRatingModalComponent,
        ScMonitoringModalComponent,
        CreateQaRatingModalComponent,
        EditQaRatingModalComponent,
        PostProfitAnalysisComponent,
        AddRatingModalComponent,
        EditSetupModalComponent,
        EditScalingModalComponent,
        RiskRatingComponent,
        InDAppComponent,
        BankAccComponent,
        CreditLineComponent
,
        LendingOutputModalComponent
,
        ScReportModalComponent
,
        GiniInclusiveComponent
,
        CaliberationComponent
,
        CaliberationBarComponent
,
        GiniInclisiveModalComponent
,
        SetupPageComponent
,
        SetupSummaryComponent
,
        VintageAnalysisComponent,
        DigSetupComponent,
        DigSetupModalComponent
,
        CooperateRatingComponent
,
        CooperateRatingModalComponent
,
        CooperateScoreComponent
,
        CooperateScorecardComponent,

        DemoRetailComponent
,
        SubAttributeComponent
,
        EditdemoModalComponent
,
        CreateDemoModalComponent
,
        AddsubattributeModalComponent
,
        EditsubattributeModalComponent
,
        SubatrributeUsepageComponent
,
        ApproveModalComponent
,
        DeclineModalComponent
,
        SubAttrModalComponent
,
        RetailScoreDetailsComponent
,
        RetailDetailModalComponent,
        CutoffScoreModalComponent
,
        EligibilityModalComponent
,
        GenerateCutoffComponent,
        SeverityComponent
,
        SeverityListComponent,
        GenePointAllComponent
],
        
        
      
        
    providers: [
        { provide: BsDatepickerConfig, useFactory: NgxBootstrapDatePickerConfigService.getDatepickerConfig },
        { provide: BsDaterangepickerConfig, useFactory: NgxBootstrapDatePickerConfigService.getDaterangepickerConfig },
        { provide: BsLocaleService, useFactory: NgxBootstrapDatePickerConfigService.getDatepickerLocale },DatePipe
    ]
})
export class MainModule { }
