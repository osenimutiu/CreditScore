import {PermissionCheckerService} from 'abp-ng2-module';
import {AppSessionService} from '@shared/common/session/app-session.service';

import {Injectable} from '@angular/core';
import {AppMenu} from './app-menu';
import {AppMenuItem} from './app-menu-item';

@Injectable()
export class AppNavigationService {

    constructor(
        private _permissionCheckerService: PermissionCheckerService,
        private _appSessionService: AppSessionService
    ) {

    }

    getMenu(): AppMenu {
        return new AppMenu('MainMenu', 'MainMenu', [
            new AppMenuItem('Dashboard', 'Pages.Administration.Host.Dashboard', 'flaticon-line-graph', '/app/admin/hostDashboard'),
            new AppMenuItem('Dashboard', 'Pages.Tenant.Dashboard', 'flaticon-line-graph', '/app/main/dashboard'),
            // new AppMenuItem('Data Consumption', 'Pages.Tenant.ScoringInputData', 'fas fa-border-none', '/app/main/scoring-input-data'),
            new AppMenuItem('Setup', 'Pages.Tenant.SetUpPage', 'flaticon-app', '/app/main/setup-page'),
            new AppMenuItem('Credit Scoring', null, 'flaticon-interface-8', '', [], [
                new AppMenuItem('Data Acquisition', 'Pages.Tenant.TblScoring', 'fas fa-border-none', '/app/main/scoring-input-data'),
                new AppMenuItem('Data Sampling', 'Pages.Tenant.Histogram', 'fas fa-chart-bar', '/app/main/histogr'),
                new AppMenuItem('Preprocessing', 'Pages.Tenant.Histogram', 'fas fa-chart-bar', '/app/main/histogram'),
                new AppMenuItem('Descriptive Statistics ', null, 'fas fa-chart-bar', '/app/main/distriptive-statistics'),
                new AppMenuItem('Target Variables', 'Pages.Tenant.InputDataValueCollector', 'fas fa-border-none', '/app/main/input-data'),
                new AppMenuItem('Data Visualisation', 'Pages.Tenant.Curve', 'flaticon-interface-8', '', [], [
                    new AppMenuItem('Attributes', 'Pages.Tenant.Curve', 'flaticon-interface-8', '', [], [
                        new AppMenuItem('Product', 'Pages.Tenant.Curve', 'fas fa-border-none', '/app/main/output-curve'),
                        new AppMenuItem('Current Account Status', 'Pages.Tenant.Curve', 'fas fa-border-none', '/app/main/output-curve-castatus'),
                        new AppMenuItem('Location', 'Pages.Tenant.Curve', 'fas fa-border-none', '/app/main/output-curve-location'),
                        new AppMenuItem('Resident Status', 'Pages.Tenant.Curve', 'fas fa-border-none', '/app/main/output-curve-res-stat'),
                        new AppMenuItem('Payment Performance', 'Pages.Tenant.Curve', 'fas fa-border-none', '/app/main/output-curve-pay-perf'),
                    ]),
                ]),

                new AppMenuItem('Feature Selection ', null, 'fas fa-chart-bar', '/app/main/feature-selection'),
                new AppMenuItem('Training and Validation', 'Pages.Tenant.SetUp', 'fas fa-wrench', '/app/main/setup'),
                new AppMenuItem('Algorithm', 'Pages.Tenant.LogRegression', 'fas fa-wrench', '/app/main/log-reg'),
                new AppMenuItem('Logical Trend', 'Pages.Tenant.Curve', 'flaticon-interface-8', '', [], [
                    new AppMenuItem('With weight of evidence', 'Pages.Tenant.Curve', 'flaticon-app', '/app/main/creditscore-woe'),
                    new AppMenuItem('With Binning', 'Pages.Tenant.Curve', 'flaticon-app', '/app/main/stability-trend'),
                ]),
                new AppMenuItem('Run Process', 'Pages.Tenant.RegOutput', 'fas fa-chart-line', '/app/main/reg-output'),
                new AppMenuItem('Logistic Regression Output', null, 'fas fa-wrench', '/app/main/log-reg-output'),
                new AppMenuItem('Scaling', 'Pages.Tenant.ScoreCard', 'flaticon-interface-8', '', [], [
                    new AppMenuItem('Input', 'Pages.Tenant.ScoreCard', 'flaticon-app', '/app/main/scaling'),
                    new AppMenuItem('Output', 'Pages.Tenant.ScoreCard', 'flaticon-app', '/app/main/scorecard'),
                ]),
                new AppMenuItem('Point Allocation', 'Pages.Tenant.ScoreCard', 'flaticon-app', '/app/main/age-dist'),
                new AppMenuItem('Scorecard Report', 'Pages.Tenant.ScoreCard', 'flaticon-interface-8', '', [], [
                    new AppMenuItem('scorecard point', 'Pages.Tenant.ScoreCard', 'flaticon-app', '/app/main/scorecard-scaling'),
                    new AppMenuItem('Scorecard final', 'Pages.Tenant.ScoreCard', 'flaticon-app', '/app/main/score-report'),
                ]),
                new AppMenuItem('Scorecard Monitoring', null, 'flaticon-interface-8', '', [], [
                    new AppMenuItem('System', 'Pages.Tenant.Curve', 'flaticon-interface-8', '', [], [
                        new AppMenuItem('ROC Curve', 'Pages.Tenant.Curve', 'flaticon-app', '/app/main/roc-curve'),
                        new AppMenuItem('Gini Curve', 'Pages.Tenant.Curve', 'flaticon-app', '/app/main/gini-curve'),
                        new AppMenuItem('Kolmogorov–Smirnov Test', 'Pages.Tenant.Curve', 'flaticon-app', '/app/main/curve'),

                    ]),
                    new AppMenuItem('Portfolio', null, 'flaticon-interface-8', '', [], [
                        new AppMenuItem('Profit Analysis', 'Pages.Tenant.ScoreCard', 'flaticon-app', '/app/main/profit-analysis'),
                        new AppMenuItem('Characteristic Analysis', 'Pages.Tenant.ScoreCard', 'flaticon-app', '/app/main/caracteristics'),
                        new AppMenuItem('Population Stability Index', 'Pages.Tenant.Curve', 'fa fa-chart-area', '/app/main/psi'),
                        new AppMenuItem('Account Quality', 'Pages.Tenant.Curve', 'fa fa-chart-area', '/app/main/ps'),
                        new AppMenuItem('Override Report', 'Pages.Tenant.Curve', 'fa fa-chart-area', '/app/main/ps'),
                        new AppMenuItem('Scorecard Accuracy', 'Pages.Tenant.Curve', 'fa fa-chart-area', '/app/main/ps'),
                        new AppMenuItem('System Stability Trend', 'Pages.Tenant.Curve', 'fa fa-chart-area', '/app/main/ps'),
                        new AppMenuItem('Final Scorecard Report', 'Pages.Tenant.Curve', 'fa fa-chart-area', '/app/main/ps'),
                        new AppMenuItem('Deliquency Migration Report', 'Pages.Tenant.Curve', 'fa fa-chart-area', '/app/main/ps'),
                        new AppMenuItem('Deliquency Performance Report', 'Pages.Tenant.Curve', 'fa fa-chart-area', '/app/main/ps'),
                    ]),
                        // new AppMenuItem('Stability Trend', null, 'flaticon-app', '/app/main/stability-trend'),
                ]),
            ]),

            new AppMenuItem('Qualitative Analysis', 'Pages.Tenant.QualitativeAnalysis', 'flaticon-interface-8', '', [], [
                new AppMenuItem('SME', 'Pages.Tenant.QualitativeAnalysis', 'flaticon-app', '/app/main/qualitative-analysis'),
                new AppMenuItem('Retail', 'Pages.Tenant.RetailScoring', 'flaticon-app', '/app/main/retail-scoring'),
                // new AppMenuItem('Monitoring', 'Pages.QualitativeAnalysis.Tenant.GetSCMonitoring', 'flaticon-app', '/app/main/sc-monitoring'),
                // new AppMenuItem('Qualitative Analysis Rating', 'Pages.Tenant.QualitativeAnalysis', 'flaticon-app', '/app/main/qa-rating'),
                // new AppMenuItem('Risk Rating', 'Pages.Tenant.QualitativeAnalysis', 'flaticon-app', '/app/main/obligor-judgemental')
            ]),
            new AppMenuItem('Risk Rating', 'Pages.Tenant.QualitativeAnalysis', 'flaticon-interface-8', '', [], [
                new AppMenuItem('Qualitative Analysis Rating', 'Pages.Tenant.QualitativeAnalysis', 'flaticon-app', '/app/main/qa-rating'),
                new AppMenuItem('Rating', 'Pages.Tenant.QualitativeAnalysis', 'flaticon-app', '/app/main/obligor-judgemental')
            ]),
            new AppMenuItem('Digital Lending', null, 'flaticon-app', '', [], [
                new AppMenuItem('Overview', null, 'flaticon-app', '/app/main/risk-rating'),
                new AppMenuItem('Setup', null, 'flaticon-app', '/app/main/dig-setup'),
                new AppMenuItem('Severity', null, 'flaticon-app', '/app/main/severity'),
                new AppMenuItem('Generate Point Allocation', null, 'flaticon-app', '/app/main/gene-point-all'),
            ]),
            // new AppMenuItem('Digital Lending', null, 'flaticon-app', '/app/main/risk-rating'),
           new AppMenuItem('SME Lending', null, 'flaticon-interface-8', '', [], [
              new AppMenuItem('Apply Now', null, 'flaticon-app', '/app/main/sme-lending'),
              new AppMenuItem('Sent Request', null, 'flaticon-app', '/app/main/submitted-loan-request'),
              new AppMenuItem('Loan Request', null, 'flaticon-app', '/app/main/loanRequests'),
              new AppMenuItem('User Loan Request', null, 'flaticon-app', '/app/main/uLoanRequests'),
              new AppMenuItem('Financial Ratio', null, 'flaticon-app', '/app/main/financial-ratio')
            ]),
           new AppMenuItem('Caliberation', 'Pages.Tenant.Caliberation', 'flaticon-interface-8', '', [], [
              new AppMenuItem('Gini Inclusive', 'Pages.Tenant.Caliberation', 'flaticon-app', '/app/main/gini-inclusive'),
              new AppMenuItem('Score to Rating', 'Pages.Tenant.Caliberation', 'flaticon-interface-8', '', [], [
                new AppMenuItem('Data', 'Pages.Tenant.Caliberation', 'flaticon-app', '/app/main/caliberation'),
                new AppMenuItem('Curve', 'Pages.Tenant.Caliberation', 'flaticon-app', '/app/main/caliberation-bar')
              ])
            ]),
            new AppMenuItem('Final Score', 'Pages.Tenant.SetUpPage', 'flaticon-app', '/app/main/setup-summary'),
            new AppMenuItem('Vintage Analysis', 'Pages.Tenant.VintageAnalysis', 'flaticon-app', '/app/main/vintage-analysis'),

            new AppMenuItem('Retail', 'Pages.Tenant.DemoRetail', 'flaticon-interface-8', '', [], [
                new AppMenuItem('Setup', 'Pages.DemoRetail.Tenant.GetDemoRetailAttrItem', 'flaticon-app', '/app/main/demo-retail'),
                new AppMenuItem('SubAttribute', 'Pages.Tenant.DemoRetail', 'flaticon-app', '/app/main/sub-attribute'),
                new AppMenuItem('Apply', 'Pages.DemoRetail.Tenant.InsertNewCustomerScore', 'flaticon-app', '/app/main/subatrribute-usepage'),
                new AppMenuItem('CutOff Setup', 'Pages.DemoRetail.Tenant.AddCutOff', 'flaticon-app', '/app/main/generate-cutoff'),
                new AppMenuItem('Scores', 'Pages.DemoRetail.Tenant.GetDetailScores', 'flaticon-app', '/app/main/retail-score-details'),
                new AppMenuItem('Application Scoring', 'Pages.Tenant.ApplicationScoring', 'fas fa-check', '/app/main/application-scoring'),
              ]),
                // new AppMenuItem('Bank Account', null, 'flaticon-app', '/app/main/bank-acc'),
                // new AppMenuItem('Credit Line Condition', null, 'flaticon-app', '/app/main/credit-line')

            //   new AppMenuItem('Counts', null, 'flaticon-interface-8', '', [], [
            //     new AppMenuItem('Product', null, 'flaticon-app', '/app/main/product'),
            //     new AppMenuItem('Current Account Status', null, 'flaticon-app', '/app/main/curr-acc-stat'),
            //     new AppMenuItem('Location', null, 'flaticon-app', '/app/main/location'),
            //     new AppMenuItem('Resident Status', null, 'flaticon-app', '/app/main/resident-status'),
            //     new AppMenuItem('Payment Performance', null, 'flaticon-app', '/app/main/payment-performance'),
            //     new AppMenuItem('Age Bin', null, 'flaticon-app', '/app/main/agebin'),
            //     new AppMenuItem('Time at Job Bin', null, 'flaticon-app', '/app/main/time-jobbin'),

            // ]),
            //   new AppMenuItem('ScoreCard', null, 'flaticon-interface-8', '', [], [
            //     new AppMenuItem('Age Distribution', null, 'flaticon-app', '/app/main/age-dist'),
            //     new AppMenuItem('Current Account Status', null, 'flaticon-app', '/app/main/curr-acc-staus'),
            //     new AppMenuItem('Characteristic Analysis', null, 'flaticon-app', '/app/main/caracteristics'),
            //     new AppMenuItem('Profit Analysis', null, 'flaticon-app', '/app/main/profit-analysis'),
            //     new AppMenuItem('Scaling', null, 'flaticon-app', '/app/main/scaling'),
            //     new AppMenuItem('Scaling', null, 'flaticon-app', '/app/main/scorecard'),
            //     new AppMenuItem('scorecard Scaling', null, 'flaticon-app', '/app/main/scorecard-scaling'),
            //     new AppMenuItem('Score Report', null, 'flaticon-app', '/app/main/score-report'),

            // ]),
            //   new AppMenuItem('Curves', null, 'fal fa-chart-line-down', '/app/main/curve'),
			// new AppMenuItem('Regression', null, 'fas fa-chart-bar', '/app/main/logistic-regression-inputs'),

			// new AppMenuItem('Regression Output', null, 'fas fa-chart-line', '/app/main/reg-output'),
            // new AppMenuItem('Application Scoring', 'Pages.Tenant.ApplicationScoring', 'fas fa-check', '/app/main/application-scoring'),

            // //new AppMenuItem('SME Lending', null, 'fas fa-border-none', '/app/main/sme-lending'),
            // //
            // new AppMenuItem('SME Lending', null, 'flaticon-interface-8', '', [], [
            //   new AppMenuItem('Apply Now', null, 'flaticon-app', '/app/main/sme-lending'),
            //   new AppMenuItem('Sent Request', null, 'flaticon-app', '/app/main/submitted-loan-request'),
            //   new AppMenuItem('Loan Request', null, 'flaticon-app', '/app/main/loanRequests'),
            //   new AppMenuItem('User Loan Request', null, 'flaticon-app', '/app/main/uLoanRequests'),
            //   new AppMenuItem('Financial Ratio', null, 'flaticon-app', '/app/main/financial-ratio')

            // ]),
            //
            new AppMenuItem('Tenants', 'Pages.Tenants', 'flaticon-list-3', '/app/admin/tenants'),
            new AppMenuItem('Editions', 'Pages.Editions', 'flaticon-app', '/app/admin/editions'),

            // new AppMenuItem('RegressionOutputs', 'Pages.RegressionOutputs', 'flaticon-more', '/app/main/regression/regressionOutputs'),

            // new AppMenuItem('LogisticRegressionInputs', 'Pages.LogisticRegressionInputs', 'flaticon-more', '/app/main/logisticRegression/logisticRegressionInputs'),
            new AppMenuItem('Cooperate Setup', '', 'flaticon-interface-8', '', [], [

            new AppMenuItem('SectionSetups', 'Pages.SectionSetups', 'flaticon-more', '/app/main/cooperate/sectionSetups'),
            new AppMenuItem('SetupSubHeadings', 'Pages.SetupSubHeadings', 'flaticon-more', '/app/main/cooperate/setupSubHeadings'),
            new AppMenuItem('SetupQualitatives', 'Pages.SetupQualitatives', 'flaticon-more', '/app/main/cooperate/setupQualitatives')

            //new AppMenuItem('SubSectorSetups', 'Pages.SubSectorSetups', 'flaticon-more', '/app/main/cooperate/subSectorSetups'),

            //new AppMenuItem('QualitativeSetups', 'Pages.QualitativeSetups', 'flaticon-more', '/app/main/cooperate/qualitativeSetups'),

            //new AppMenuItem('SubHeadingSetups', 'Pages.SubHeadingSetups', 'flaticon-more', '/app/main/cooperate/subHeadingSetups'),

            ]),

            new AppMenuItem('Cooperate Rating', '', 'flaticon-interface-8', '', [], [

            new AppMenuItem('Rating', null, 'flaticon-more', '/app/main/cooperate-rating'),
            new AppMenuItem('Cooperate-Score', null, 'flaticon-more', '/app/main/cooperate-score'),


            new AppMenuItem('CooperateAppraisals', 'Pages.CooperateAppraisals', 'flaticon-more', '/app/main/cooperate/cooperateAppraisals'),

                ]),

            new AppMenuItem('Administration', '', 'flaticon-interface-8', '', [], [
                new AppMenuItem('OrganizationUnits', 'Pages.Administration.OrganizationUnits', 'flaticon-map', '/app/admin/organization-units'),
                new AppMenuItem('Roles', 'Pages.Administration.Roles', 'flaticon-suitcase', '/app/admin/roles'),
                new AppMenuItem('Users', 'Pages.Administration.Users', 'flaticon-users', '/app/admin/users'),
                new AppMenuItem('Languages', 'Pages.Administration.Languages', 'flaticon-tabs', '/app/admin/languages', ['/app/admin/languages/{name}/texts']),
                new AppMenuItem('AuditLogs', 'Pages.Administration.AuditLogs', 'flaticon-folder-1', '/app/admin/auditLogs'),
                new AppMenuItem('Maintenance', 'Pages.Administration.Host.Maintenance', 'flaticon-lock', '/app/admin/maintenance'),
                new AppMenuItem('Subscription', 'Pages.Administration.Tenant.SubscriptionManagement', 'flaticon-refresh', '/app/admin/subscription-management'),
                new AppMenuItem('VisualSettings', 'Pages.Administration.UiCustomization', 'flaticon-medical', '/app/admin/ui-customization'),
                new AppMenuItem('WebhookSubscriptions', 'Pages.Administration.WebhookSubscription', 'flaticon2-world', '/app/admin/webhook-subscriptions'),
                new AppMenuItem('DynamicProperties', 'Pages.Administration.DynamicProperties', 'flaticon-interface-8', '/app/admin/dynamic-property'),
                new AppMenuItem('Settings', 'Pages.Administration.Host.Settings', 'flaticon-settings', '/app/admin/hostSettings'),
                new AppMenuItem('Settings', 'Pages.Administration.Tenant.Settings', 'flaticon-settings', '/app/admin/tenantSettings')
            ]),
            new AppMenuItem('DemoUiComponents', 'Pages.DemoUiComponents', 'flaticon-shapes', '/app/admin/demo-ui-components')
        ]);
    }

    checkChildMenuItemPermission(menuItem): boolean {

        for (let i = 0; i < menuItem.items.length; i++) {
            let subMenuItem = menuItem.items[i];

            if (subMenuItem.permissionName === '' || subMenuItem.permissionName === null) {
                if (subMenuItem.route) {
                    return true;
                }
            } else if (this._permissionCheckerService.isGranted(subMenuItem.permissionName)) {
                return true;
            }

            if (subMenuItem.items && subMenuItem.items.length) {
                let isAnyChildItemActive = this.checkChildMenuItemPermission(subMenuItem);
                if (isAnyChildItemActive) {
                    return true;
                }
            }
        }
        return false;
    }

    showMenuItem(menuItem: AppMenuItem): boolean {
        if (menuItem.permissionName === 'Pages.Administration.Tenant.SubscriptionManagement' && this._appSessionService.tenant && !this._appSessionService.tenant.edition) {
            return false;
        }

        let hideMenuItem = false;

        if (menuItem.requiresAuthentication && !this._appSessionService.user) {
            hideMenuItem = true;
        }

        if (menuItem.permissionName && !this._permissionCheckerService.isGranted(menuItem.permissionName)) {
            hideMenuItem = true;
        }

        if (this._appSessionService.tenant || !abp.multiTenancy.ignoreFeatureCheckForHostUsers) {
            if (menuItem.hasFeatureDependency() && !menuItem.featureDependencySatisfied()) {
                hideMenuItem = true;
            }
        }

        if (!hideMenuItem && menuItem.items && menuItem.items.length) {
            return this.checkChildMenuItemPermission(menuItem);
        }

        return !hideMenuItem;
    }

    /**
     * Returns all menu items recursively
     */
    getAllMenuItems(): AppMenuItem[] {
        let menu = this.getMenu();
        let allMenuItems: AppMenuItem[] = [];
        menu.items.forEach(menuItem => {
            allMenuItems = allMenuItems.concat(this.getAllMenuItemsRecursive(menuItem));
        });

        return allMenuItems;
    }

    private getAllMenuItemsRecursive(menuItem: AppMenuItem): AppMenuItem[] {
        if (!menuItem.items) {
            return [menuItem];
        }

        let menuItems = [menuItem];
        menuItem.items.forEach(subMenu => {
            menuItems = menuItems.concat(this.getAllMenuItemsRecursive(subMenu));
        });

        return menuItems;
    }
}
