import { AbpHttpInterceptor, RefreshTokenService, AbpHttpConfigurationService } from 'abp-ng2-module';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { NgModule } from '@angular/core';
import * as ApiServiceProxies from './service-proxies';
import { ZeroRefreshTokenService } from '@account/auth/zero-refresh-token.service';
import { ZeroTemplateHttpConfigurationService } from './zero-template-http-configuration.service';

@NgModule({
    providers: [
        ApiServiceProxies.CooperateAppraisalsServiceProxy,
        ApiServiceProxies.SetupSubHeadingsServiceProxy,
        ApiServiceProxies.SubHeadingSetupsServiceProxy,
        ApiServiceProxies.QualitativeSetupsServiceProxy,
        ApiServiceProxies.SubSectorSetupsServiceProxy,
        ApiServiceProxies.SectionSetupsServiceProxy,
        ApiServiceProxies.LogisticRegressionInputsServiceProxy,
        ApiServiceProxies.RegressionOutputsServiceProxy,
        ApiServiceProxies.AuditLogServiceProxy,
        ApiServiceProxies.CachingServiceProxy,
        ApiServiceProxies.ChatServiceProxy,
        ApiServiceProxies.CommonLookupServiceProxy,
        ApiServiceProxies.EditionServiceProxy,
        ApiServiceProxies.FriendshipServiceProxy,
        ApiServiceProxies.HostSettingsServiceProxy,
        ApiServiceProxies.InstallServiceProxy,
        ApiServiceProxies.LanguageServiceProxy,
        ApiServiceProxies.NotificationServiceProxy,
        ApiServiceProxies.OrganizationUnitServiceProxy,
        ApiServiceProxies.PermissionServiceProxy,
        ApiServiceProxies.ProfileServiceProxy,
        ApiServiceProxies.RoleServiceProxy,
        ApiServiceProxies.SessionServiceProxy,
        ApiServiceProxies.TenantServiceProxy,
        //
        ApiServiceProxies.AgeAttributeServiceProxy,
        ApiServiceProxies.PreProcessingServiceProxy,
        ApiServiceProxies.OperationServiceProxy,
        ApiServiceProxies.AllScoreServiceProxy,
        ApiServiceProxies.RatingPredictionOutputServiceProxy,
        ApiServiceProxies.ApplicantAttributeServiceProxy,
        ApiServiceProxies.AppAttributeServiceProxy,
        ApiServiceProxies.RatingPredictionOutputServiceProxy,
        ApiServiceProxies.InputDataValueCollectorServiceProxy,
        ApiServiceProxies.AccountBalDataServiceProxy,
        //
        //SMELending
        ApiServiceProxies.BankServiceProxy,
        ApiServiceProxies.GenderTypeServiceProxy,
        ApiServiceProxies.LoanTypeServiceProxy,
        ApiServiceProxies.SMELendingApplyServiceProxy,
        ApiServiceProxies.SMETitleServiceProxy,
        ApiServiceProxies.HaveNINServiceProxy,
        ApiServiceProxies.BusRegNigServiceProxy,
        ApiServiceProxies.AccountAuthorizeServiceProxy,
        ApiServiceProxies.HaveBankAccountServiceProxy,
        ApiServiceProxies.OperationEligibilityServiceProxy,
        ApiServiceProxies.FinancialRatioServiceProxy,
		ApiServiceProxies.SetUpItemServiceProxy,
		ApiServiceProxies.LogRegressionServiceProxy,

		ApiServiceProxies.GoodBadServiceProxy,
        ApiServiceProxies.CurveServiceProxy,
        ApiServiceProxies.RegOutputServiceProxy,
        ApiServiceProxies.ScoreCardServiceProxy,
        //LoanRequest
        ApiServiceProxies.LoanRequestsServiceProxy,
        //ULoanRequest
        ApiServiceProxies.ULoanRequestsServiceProxy,
		ApiServiceProxies.Tbl_ScoringDataAppSeriviceServiceProxy,

        ApiServiceProxies.ProductTypeAttributeServiceProxy,
        ApiServiceProxies.IncomeAttributeServiceProxy,
        ApiServiceProxies.ApplicationScoringServiceProxy,
        ApiServiceProxies.LocationAttributeServiceProxy,
        ApiServiceProxies.RentAttributeServiceProxy,
        ApiServiceProxies.RenttoIncomeAttributeServiceProxy,
        ApiServiceProxies.ReturnonAssetsAttributeServiceProxy,
        ApiServiceProxies.SubSectorAttributeServiceProxy,
         ApiServiceProxies.ScoringInputDataServiceProxy,
        ApiServiceProxies.ComponentServiceProxy,
        ApiServiceProxies.InputDataServiceProxy,
        ApiServiceProxies.HistogramServiceProxy,
        ApiServiceProxies.ScoringOutputServiceProxy,
        ApiServiceProxies.QualitativeAnalysisServiceProxy,
        ApiServiceProxies.RetailScoringServiceProxy,
        ApiServiceProxies.IndividualServiceProxy,
        ApiServiceProxies.GiniInclusiveServiceProxy,
        ApiServiceProxies.DigSetUpServiceProxy,
        ApiServiceProxies.DemoRetailServiceProxy,
        ApiServiceProxies.SetupQualitativesServiceProxy,
        ApiServiceProxies.SeverityServiceProxy,
        ApiServiceProxies.PointAllocationServiceProxy,




        ApiServiceProxies.TenantDashboardServiceProxy,
        ApiServiceProxies.TenantSettingsServiceProxy,
        ApiServiceProxies.TimingServiceProxy,
        ApiServiceProxies.UserServiceProxy,
        ApiServiceProxies.UserLinkServiceProxy,
        ApiServiceProxies.UserLoginServiceProxy,
        ApiServiceProxies.WebLogServiceProxy,
        ApiServiceProxies.AccountServiceProxy,
        ApiServiceProxies.TokenAuthServiceProxy,
        ApiServiceProxies.TenantRegistrationServiceProxy,
        ApiServiceProxies.HostDashboardServiceProxy,
        ApiServiceProxies.PaymentServiceProxy,
        ApiServiceProxies.DemoUiComponentsServiceProxy,
        ApiServiceProxies.InvoiceServiceProxy,
        ApiServiceProxies.SubscriptionServiceProxy,
        ApiServiceProxies.InstallServiceProxy,
        ApiServiceProxies.UiCustomizationSettingsServiceProxy,
        ApiServiceProxies.PayPalPaymentServiceProxy,
        ApiServiceProxies.StripePaymentServiceProxy,
        ApiServiceProxies.DashboardCustomizationServiceProxy,
        ApiServiceProxies.WebhookEventServiceProxy,
        ApiServiceProxies.WebhookSubscriptionServiceProxy,
        ApiServiceProxies.WebhookSendAttemptServiceProxy,
        ApiServiceProxies.UserDelegationServiceProxy,
        ApiServiceProxies.DynamicPropertyServiceProxy,
        ApiServiceProxies.DynamicEntityPropertyDefinitionServiceProxy,
        ApiServiceProxies.DynamicEntityPropertyServiceProxy,
        ApiServiceProxies.DynamicPropertyValueServiceProxy,
        ApiServiceProxies.DynamicEntityPropertyValueServiceProxy,
        ApiServiceProxies.TwitterServiceProxy,
        { provide: RefreshTokenService, useClass: ZeroRefreshTokenService },
        { provide: AbpHttpConfigurationService, useClass: ZeroTemplateHttpConfigurationService },
        { provide: HTTP_INTERCEPTORS, useClass: AbpHttpInterceptor, multi: true }
    ]
})
export class ServiceProxyModule { }
