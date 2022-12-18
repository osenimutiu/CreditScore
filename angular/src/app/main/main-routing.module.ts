import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CooperateAppraisalsComponent } from './cooperate/cooperateAppraisals/cooperateAppraisals.component';
import { CreateOrEditCooperateAppraisalComponent } from './cooperate/cooperateAppraisals/create-or-edit-cooperateAppraisal.component';
import { ViewCooperateAppraisalComponent } from './cooperate/cooperateAppraisals/view-cooperateAppraisal.component';
import { SetupQualitativesComponent } from './cooperate/setupQualitatives/setupQualitatives.component';
import { CreateOrEditSetupQualitativeComponent } from './cooperate/setupQualitatives/create-or-edit-setupQualitative.component';
import { ViewSetupQualitativeComponent } from './cooperate/setupQualitatives/view-setupQualitative.component';
import { SetupSubHeadingsComponent } from './cooperate/setupSubHeadings/setupSubHeadings.component';
import { CreateOrEditSetupSubHeadingComponent } from './cooperate/setupSubHeadings/create-or-edit-setupSubHeading.component';
import { ViewSetupSubHeadingComponent } from './cooperate/setupSubHeadings/view-setupSubHeading.component';
import { SubHeadingSetupsComponent } from './cooperate/subHeadingSetups/subHeadingSetups.component';
import { CreateOrEditSubHeadingSetupComponent } from './cooperate/subHeadingSetups/create-or-edit-subHeadingSetup.component';
import { ViewSubHeadingSetupComponent } from './cooperate/subHeadingSetups/view-subHeadingSetup.component';
import { QualitativeSetupsComponent } from './cooperate/qualitativeSetups/qualitativeSetups.component';
import { CreateOrEditQualitativeSetupComponent } from './cooperate/qualitativeSetups/create-or-edit-qualitativeSetup.component';
import { ViewQualitativeSetupComponent } from './cooperate/qualitativeSetups/view-qualitativeSetup.component';
import { SubSectorSetupsComponent } from './cooperate/subSectorSetups/subSectorSetups.component';
import { CreateOrEditSubSectorSetupComponent } from './cooperate/subSectorSetups/create-or-edit-subSectorSetup.component';
import { ViewSubSectorSetupComponent } from './cooperate/subSectorSetups/view-subSectorSetup.component';
import { SectionSetupsComponent } from './cooperate/sectionSetups/sectionSetups.component';
import { CreateOrEditSectionSetupComponent } from './cooperate/sectionSetups/create-or-edit-sectionSetup.component';
import { ViewSectionSetupComponent } from './cooperate/sectionSetups/view-sectionSetup.component';
import { LogisticRegressionInputsComponent } from './logisticRegression/logisticRegressionInputs/logisticRegressionInputs.component';
import { RegressionOutputsComponent } from './regression/regressionOutputs/regressionOutputs.component';
import { ApplicationScoringComponent } from './application-scoring/application-scoring.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { EligibilityComponent } from './eligibility/eligibility.component';
import { FinancialRatioComponent } from './financial-ratio/financial-ratio.component';
import { HistogramComponent } from './histogram/histogram.component';
import { InputDataComponent } from './input-data/input-data.component';
import { LoanRequestsComponent } from './loanRequests/loanRequests.component';
import { FileUploadComponent } from './scoring-input-data/file-upload/file-upload.component';
import { ScoringInputDataComponent } from './scoring-input-data/scoring-input-data.component';
import { SmeLendingComponent } from './sme-lending/sme-lending.component';
import { SubmittedLoanRequestComponent } from './submitted-loan-request/submitted-loan-request.component';
import { ULoanRequestsComponent } from './uLoanRequests/uLoanRequests.component';
import { SetupComponent } from './setup/setup.component';
import { LogRegComponent } from './log-reg/log-reg.component';
import { CurveComponent } from './curve/curve.component';
import { RocCurveComponent } from './roc-curve/roc-curve.component';
import { GiniCurveComponent } from './gini-curve/gini-curve.component';
import { RegOutputComponent } from './reg-output/reg-output.component';
import { PsiComponent } from './psi/psi.component';
import { WoeAgeComponent } from './woe-age/woe-age.component';
import { WoeTimeatjobComponent } from './woe-timeatjob/woe-timeatjob.component';
import { WoePaymentperformanceComponent } from './woe-paymentperformance/woe-paymentperformance.component';
import { ProductComponent } from './product/product.component';
import { CurrAccStatComponent } from './curr-acc-stat/curr-acc-stat.component';
import { LocationComponent } from './location/location.component';
import { ResidentStatusComponent } from './resident-status/resident-status.component';
import { PaymentPerformanceComponent } from './payment-performance/payment-performance.component';
import { AgebinComponent } from './agebin/agebin.component';
import { TimeJobbinComponent } from './time-jobbin/time-jobbin.component';
import { DistriptiveStatisticsComponent } from './distriptive-statistics/distriptive-statistics.component';
import { FeatureSelectionComponent } from './feature-selection/feature-selection.component';
import { AgeDistComponent } from './age-dist/age-dist.component';
import { CaracteristicsComponent } from './caracteristics/caracteristics.component';
import { CurrAccStausComponent } from './curr-acc-staus/curr-acc-staus.component';
import { ProfitAnalysisComponent } from './profit-analysis/profit-analysis.component';
import { ScalingComponent } from './scaling/scaling.component';
import { ScorecardComponent } from './scorecard/scorecard.component';
import { StabilityTrendComponent } from './stability-trend/stability-trend.component';
import { ScoreReportComponent } from './score-report/score-report.component';
import { LogRegOutputComponent } from './log-reg-output/log-reg-output.component';
import { ScorecardScalingComponent } from './scorecard-scaling/scorecard-scaling.component';
import { CreditscoreWoeComponent } from './creditscore-woe/creditscore-woe.component';
import { OutputCurveComponent } from './output-curve/output-curve.component';
import { OutputCurveCastatusComponent } from './output-curve-castatus/output-curve-castatus.component';
import { OutputCurveLocationComponent } from './output-curve-location/output-curve-location.component';
import { OutputCurvePayPerfComponent } from './output-curve-pay-perf/output-curve-pay-perf.component';
import { OutputCurveResStatComponent } from './output-curve-res-stat/output-curve-res-stat.component';
import { QualitativeAnalysisComponent } from './qualitative-analysis/qualitative-analysis.component';
import { RetailScoringComponent } from './retail-scoring/retail-scoring.component';
import { ObligorJudgementalComponent } from './obligor-judgemental/obligor-judgemental.component';
import { QaRatingComponent } from './qa-rating/qa-rating.component';
import { ScMonitoringComponent } from './sc-monitoring/sc-monitoring.component';
import { RiskRatingComponent } from './risk-rating/risk-rating.component';
import { BankAccComponent } from './bank-acc/bank-acc.component';
import { CreditLineComponent } from './credit-line/credit-line.component';
import { CaliberationComponent } from './caliberation/caliberation.component';
import { CaliberationBarComponent } from './caliberation-bar/caliberation-bar.component';
import { GiniInclusiveComponent } from './gini-inclusive/gini-inclusive.component';
import { SetupPageComponent } from './setup-page/setup-page.component';
import { SetupSummaryComponent } from './setup-summary/setup-summary.component';
import { VintageAnalysisComponent } from './vintage-analysis/vintage-analysis.component';
import { DigSetupComponent } from './dig-setup/dig-setup.component';
import { CooperateRatingComponent } from './cooperate-rating/cooperate-rating.component';
import { CooperateScoreComponent } from './cooperate-score/cooperate-score.component';

import { DemoRetailComponent } from './demo-retail/demo-retail.component';
import { SubAttributeComponent } from './sub-attribute/sub-attribute.component';
import { SubatrributeUsepageComponent } from './subatrribute-usepage/subatrribute-usepage.component';
import { RetailScoreDetailsComponent } from './retail-score-details/retail-score-details.component';
import { GenerateCutoffComponent } from './generate-cutoff/generate-cutoff.component';
import { SeverityComponent } from './severity/severity.component';
import { SeverityListComponent } from './severity-list/severity-list.component';
import { GenePointAllComponent } from './gene-point-all/gene-point-all.component';


const routes: Routes = [];
@NgModule({
    imports: [
        RouterModule.forChild([
            {
                path: '',
                children: [
                  { path: 'cooperate/cooperateAppraisals', component: CooperateAppraisalsComponent, data: { permission: 'Pages.CooperateAppraisals' }  },
                    { path: 'cooperate/cooperateAppraisals/createOrEdit', component: CreateOrEditCooperateAppraisalComponent, data: { permission: 'Pages.CooperateAppraisals.Create' }  },
                    { path: 'cooperate/cooperateAppraisals/view', component: ViewCooperateAppraisalComponent, data: { permission: 'Pages.CooperateAppraisals' }  },
                    { path: 'cooperate/setupQualitatives', component: SetupQualitativesComponent, data: { permission: 'Pages.SetupQualitatives' }  },
                    { path: 'cooperate/setupQualitatives/createOrEdit', component: CreateOrEditSetupQualitativeComponent, data: { permission: 'Pages.SetupQualitatives.Create' }  },
                    { path: 'cooperate/setupQualitatives/view', component: ViewSetupQualitativeComponent, data: { permission: 'Pages.SetupQualitatives' }  },
                    { path: 'cooperate/setupSubHeadings', component: SetupSubHeadingsComponent, data: { permission: 'Pages.SetupSubHeadings' }  },
                    { path: 'cooperate/setupSubHeadings/createOrEdit', component: CreateOrEditSetupSubHeadingComponent, data: { permission: 'Pages.SetupSubHeadings.Create' }  },
                    { path: 'cooperate/setupSubHeadings/view', component: ViewSetupSubHeadingComponent, data: { permission: 'Pages.SetupSubHeadings' }  },
                    { path: 'cooperate/subHeadingSetups', component: SubHeadingSetupsComponent, data: { permission: 'Pages.SubHeadingSetups' }  },
                    { path: 'cooperate/subHeadingSetups/createOrEdit', component: CreateOrEditSubHeadingSetupComponent, data: { permission: 'Pages.SubHeadingSetups.Create' }  },
                    { path: 'cooperate/subHeadingSetups/view', component: ViewSubHeadingSetupComponent, data: { permission: 'Pages.SubHeadingSetups' }  },
                    { path: 'cooperate/qualitativeSetups', component: QualitativeSetupsComponent, data: { permission: 'Pages.QualitativeSetups' }  },
                    { path: 'cooperate/qualitativeSetups/createOrEdit', component: CreateOrEditQualitativeSetupComponent, data: { permission: 'Pages.QualitativeSetups.Create' }  },
                    { path: 'cooperate/qualitativeSetups/view', component: ViewQualitativeSetupComponent, data: { permission: 'Pages.QualitativeSetups' }  },
                    { path: 'cooperate/subSectorSetups', component: SubSectorSetupsComponent, data: { permission: 'Pages.SubSectorSetups' }  },
                    { path: 'cooperate/subSectorSetups/createOrEdit', component: CreateOrEditSubSectorSetupComponent, data: { permission: 'Pages.SubSectorSetups.Create' }  },
                    { path: 'cooperate/subSectorSetups/view', component: ViewSubSectorSetupComponent, data: { permission: 'Pages.SubSectorSetups' }  },
                    { path: 'cooperate/sectionSetups', component: SectionSetupsComponent, data: { permission: 'Pages.SectionSetups' }  },
                    { path: 'cooperate/sectionSetups/createOrEdit', component: CreateOrEditSectionSetupComponent, data: { permission: 'Pages.SectionSetups.Create' }  },
                    { path: 'cooperate/sectionSetups/view', component: ViewSectionSetupComponent, data: { permission: 'Pages.SectionSetups' }  },
                    { path: 'logisticRegression/logisticRegressionInputs', component: LogisticRegressionInputsComponent, data: { permission: 'Pages.LogisticRegressionInputs' }  },
                    { path: 'regression/regressionOutputs', component: RegressionOutputsComponent, data: { permission: 'Pages.RegressionOutputs' }  },
                    { path: 'dashboard', component: DashboardComponent, data: { permission: 'Pages.Tenant.Dashboard' } },
                    { path: 'histogram', component: HistogramComponent, data: { permission: 'Pages.Tenant.Histogram' } },
                    // { path: 'scoring-input-data', component: ScoringInputDataComponent, data: { permission: 'Pages.Tenant.ScoringInputData' } },
                    { path: 'scoring-input-data', component: ScoringInputDataComponent, data: { permission: 'Pages.Tenant.TblScoring' } },
                    { path: 'application-scoring', component: ApplicationScoringComponent, data: { permission: 'Pages.Tenant.ApplicationScoring' } },
                    { path: 'input-data', component: InputDataComponent, data: { permission: 'Pages.Tenant.InputDataValueCollector' } },
                    { path: 'sme-lending', component: SmeLendingComponent },
                    { path: 'financial-ratio', component: FinancialRatioComponent },
                    { path: 'submitted-loan-request', component: SubmittedLoanRequestComponent },
                    { path: 'uLoanRequests', component: ULoanRequestsComponent, data: { permission: 'Pages.ULoanRequests' } },
                    { path: 'loanRequests', component: LoanRequestsComponent, data: { permission: 'Pages.LoanRequests' }  },
                    { path: 'setup', component: SetupComponent, data: { permission: 'Pages.Tenant.SetUp' } },
					{ path: 'logistic-regression-inputs', component: LogisticRegressionInputsComponent },
					{ path: 'log-reg', component: LogRegComponent, data: { permission: 'Pages.Tenant.LogRegression' } },
                    { path: 'curve', component: CurveComponent, data: { permission: 'Pages.Tenant.Curve' } },
                    { path: 'roc-curve', component: RocCurveComponent },
                    { path: 'gini-curve', component: GiniCurveComponent },
                    { path: 'reg-output', component: RegOutputComponent, data: { permission: 'Pages.Tenant.RegOutput' } },
					{ path: 'woe-age', component: WoeAgeComponent },
                    { path: 'woe-timeatjob', component: WoeTimeatjobComponent },
                    { path: 'woe-paymentperformance', component: WoePaymentperformanceComponent },
                    { path: 'psi', component:PsiComponent, data: { permission: 'Pages.Tenant.Curve' } },
                    { path: 'product', component:ProductComponent, data: { permission: 'Pages.Tenant.Curve' } },
                    { path: 'curr-acc-stat', component:CurrAccStatComponent, data: { permission: 'Pages.Tenant.Curve' } },
                    { path: 'location', component:LocationComponent, data: { permission: 'Pages.Tenant.Curve' }},
                    { path: 'resident-status', component:ResidentStatusComponent, data: { permission: 'Pages.Tenant.Curve' } },
                    { path: 'payment-performance', component:PaymentPerformanceComponent },
                    { path: 'agebin', component:AgebinComponent, data: { permission: 'Pages.Tenant.Curve' } },
                    { path: 'time-jobbin', component:TimeJobbinComponent, data: { permission: 'Pages.Tenant.Curve' } },
                    { path: 'distriptive-statistics', component:DistriptiveStatisticsComponent },
                    { path: 'feature-selection', component:FeatureSelectionComponent },
                    { path: 'age-dist', component:AgeDistComponent, data: { permission: 'Pages.Tenant.ScoreCard' } },
                    { path: 'caracteristics', component:CaracteristicsComponent, data: { permission: 'Pages.Tenant.ScoreCard' } },
                    { path: 'curr-acc-staus', component:CurrAccStausComponent, data: { permission: 'Pages.Tenant.ScoreCard' } },
                    { path: 'profit-analysis', component:ProfitAnalysisComponent, data: { permission: 'Pages.Tenant.ScoreCard' } },
                    { path: 'scaling', component:ScalingComponent, data: { permission: 'Pages.Tenant.ScoreCard' } },
                    { path: 'scorecard', component:ScorecardComponent, data: { permission: 'Pages.Tenant.ScoreCard' } },
                    { path: 'stability-trend', component:StabilityTrendComponent, data: { permission: 'Pages.Tenant.ScoreCard' } },
                    { path: 'score-report', component:ScoreReportComponent, data: { permission: 'Pages.Tenant.ScoreCard' } },
                    { path: 'log-reg-output', component:LogRegOutputComponent },
                    { path: 'scorecard-scaling', component:ScorecardScalingComponent, data: { permission: 'Pages.Tenant.ScoreCard' } },
                    { path: 'creditscore-woe', component:CreditscoreWoeComponent, data: { permission: 'Pages.Tenant.Curve' } },
                    { path: 'output-curve', component:OutputCurveComponent, data: { permission: 'Pages.Tenant.Curve' } },
                    { path: 'output-curve-castatus', component:OutputCurveCastatusComponent, data: { permission: 'Pages.Tenant.Curve' } },
                    { path: 'output-curve-location', component:OutputCurveLocationComponent, data: { permission: 'Pages.Tenant.Curve' } },
                    { path: 'output-curve-res-stat', component:OutputCurveResStatComponent, data: { permission: 'Pages.Tenant.Curve' } },
                    { path: 'output-curve-pay-perf', component:OutputCurvePayPerfComponent, data: { permission: 'Pages.Tenant.Curve' } },
                    { path: 'qualitative-analysis', component:QualitativeAnalysisComponent, data: { permission: 'Pages.Tenant.QualitativeAnalysis' } },
                    { path: 'retail-scoring', component:RetailScoringComponent, data: { permission: 'Pages.Tenant.RetailScoring' } },
                    { path: 'sc-monitoring', component:ScMonitoringComponent, data: { permission: 'Pages.QualitativeAnalysis.Tenant.GetSCMonitoring' } },
                    { path: 'qa-rating', component:QaRatingComponent, data: { permission: 'Pages.Tenant.QualitativeAnalysis' } },
                    { path: 'obligor-judgemental', component:ObligorJudgementalComponent, data: { permission: 'Pages.Tenant.QualitativeAnalysis'} },
                    { path: 'risk-rating', component:RiskRatingComponent },
                    { path: 'bank-acc', component:BankAccComponent },
                    { path: 'credit-line', component:CreditLineComponent },
                    { path: 'caliberation', component:CaliberationComponent, data: { permission: 'Pages.Tenant.Caliberation' } },
                    { path: 'caliberation-bar', component:CaliberationBarComponent, data: { permission: 'Pages.Tenant.Caliberation' } },
                    { path: 'gini-inclusive', component:GiniInclusiveComponent, data: { permission: 'Pages.Tenant.Caliberation' } },
                    { path: 'setup-page', component:SetupPageComponent, data: { permission: 'Pages.Tenant.SetUpPage' } },
                    { path: 'setup-summary', component:SetupSummaryComponent, data: { permission: 'Pages.Tenant.SetUpPage' } },
                    { path: 'vintage-analysis', component:VintageAnalysisComponent, data: { permission: 'Pages.Tenant.VintageAnalysis' } },
                    { path: 'dig-setup', component:DigSetupComponent },
                    { path: 'cooperate-rating', component: CooperateRatingComponent },
                    { path: 'cooperate-score', component: CooperateScoreComponent },
                    { path: 'demo-retail', component:DemoRetailComponent, data: { permission: 'Pages.DemoRetail.Tenant.GetDemoRetailAttrItem' } },
                    { path: 'sub-attribute', component:SubAttributeComponent, data: { permission: 'Pages.Tenant.DemoRetail' } },
                    { path: 'subatrribute-usepage', component:SubatrributeUsepageComponent, data: { permission: 'Pages.DemoRetail.Tenant.InsertNewCustomerScore' } },
                    { path: 'retail-score-details', component:RetailScoreDetailsComponent, data: { permission: 'Pages.DemoRetail.Tenant.GetDetailScores' } },
                    { path: 'generate-cutoff', component:GenerateCutoffComponent, data: { permission: 'Pages.DemoRetail.Tenant.AddCutOff' } },
                    { path: 'severity', component:SeverityComponent, children: [{path: '', component: SeverityListComponent}]},
                    { path: 'severity-list', component:SeverityListComponent },
                    { path: 'gene-point-all', component:GenePointAllComponent },


                    { path: '', redirectTo: 'dashboard', pathMatch: 'full' },
                    { path: '**', redirectTo: 'dashboard' },

                ]
            }
        ])
    ],
    exports: [
        RouterModule
    ]
})
export class MainRoutingModule { }
