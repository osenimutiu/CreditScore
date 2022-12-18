using Abp.Authorization;
using Abp.Configuration.Startup;
using Abp.Localization;
using Abp.MultiTenancy;

namespace IFRSDemo.Authorization
{
    /// <summary>
    /// Application's authorization provider.
    /// Defines permissions for the application.
    /// See <see cref="AppPermissions"/> for all permission names.
    /// </summary>
    public class AppAuthorizationProvider : AuthorizationProvider
    {
        private readonly bool _isMultiTenancyEnabled;

        public AppAuthorizationProvider(bool isMultiTenancyEnabled)
        {
            _isMultiTenancyEnabled = isMultiTenancyEnabled;
        }

        public AppAuthorizationProvider(IMultiTenancyConfig multiTenancyConfig)
        {
            _isMultiTenancyEnabled = multiTenancyConfig.IsEnabled;
        }

        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            //COMMON PERMISSIONS (FOR BOTH OF TENANTS AND HOST)

            var pages = context.GetPermissionOrNull(AppPermissions.Pages) ?? context.CreatePermission(AppPermissions.Pages, L("Pages"));

           
            var cooperateAppraisals = pages.CreateChildPermission(AppPermissions.Pages_CooperateAppraisals, L("CooperateAppraisals"));
            cooperateAppraisals.CreateChildPermission(AppPermissions.Pages_CooperateAppraisals_Create, L("CreateNewCooperateAppraisal"));
            cooperateAppraisals.CreateChildPermission(AppPermissions.Pages_CooperateAppraisals_Edit, L("EditCooperateAppraisal"));
            cooperateAppraisals.CreateChildPermission(AppPermissions.Pages_CooperateAppraisals_Delete, L("DeleteCooperateAppraisal"));

            var setupQualitatives = pages.CreateChildPermission(AppPermissions.Pages_SetupQualitatives, L("SetupQualitatives"));
            setupQualitatives.CreateChildPermission(AppPermissions.Pages_SetupQualitatives_Create, L("CreateNewSetupQualitative"));
            setupQualitatives.CreateChildPermission(AppPermissions.Pages_SetupQualitatives_Edit, L("EditSetupQualitative"));
            setupQualitatives.CreateChildPermission(AppPermissions.Pages_SetupQualitatives_Delete, L("DeleteSetupQualitative"));

            var setupSubHeadings = pages.CreateChildPermission(AppPermissions.Pages_SetupSubHeadings, L("SetupSubHeadings"));
            setupSubHeadings.CreateChildPermission(AppPermissions.Pages_SetupSubHeadings_Create, L("CreateNewSetupSubHeading"));
            setupSubHeadings.CreateChildPermission(AppPermissions.Pages_SetupSubHeadings_Edit, L("EditSetupSubHeading"));
            setupSubHeadings.CreateChildPermission(AppPermissions.Pages_SetupSubHeadings_Delete, L("DeleteSetupSubHeading"));

            var subHeadingSetups = pages.CreateChildPermission(AppPermissions.Pages_SubHeadingSetups, L("SubHeadingSetups"));
            subHeadingSetups.CreateChildPermission(AppPermissions.Pages_SubHeadingSetups_Create, L("CreateNewSubHeadingSetup"));
            subHeadingSetups.CreateChildPermission(AppPermissions.Pages_SubHeadingSetups_Edit, L("EditSubHeadingSetup"));
            subHeadingSetups.CreateChildPermission(AppPermissions.Pages_SubHeadingSetups_Delete, L("DeleteSubHeadingSetup"));

            var qualitativeSetups = pages.CreateChildPermission(AppPermissions.Pages_QualitativeSetups, L("QualitativeSetups"));
            qualitativeSetups.CreateChildPermission(AppPermissions.Pages_QualitativeSetups_Create, L("CreateNewQualitativeSetup"));
            qualitativeSetups.CreateChildPermission(AppPermissions.Pages_QualitativeSetups_Edit, L("EditQualitativeSetup"));
            qualitativeSetups.CreateChildPermission(AppPermissions.Pages_QualitativeSetups_Delete, L("DeleteQualitativeSetup"));

            var subSectorSetups = pages.CreateChildPermission(AppPermissions.Pages_SubSectorSetups, L("SubSectorSetups"));
            subSectorSetups.CreateChildPermission(AppPermissions.Pages_SubSectorSetups_Create, L("CreateNewSubSectorSetup"));
            subSectorSetups.CreateChildPermission(AppPermissions.Pages_SubSectorSetups_Edit, L("EditSubSectorSetup"));
            subSectorSetups.CreateChildPermission(AppPermissions.Pages_SubSectorSetups_Delete, L("DeleteSubSectorSetup"));

            var sectionSetups = pages.CreateChildPermission(AppPermissions.Pages_SectionSetups, L("SectionSetups"));
            sectionSetups.CreateChildPermission(AppPermissions.Pages_SectionSetups_Create, L("CreateNewSectionSetup"));
            sectionSetups.CreateChildPermission(AppPermissions.Pages_SectionSetups_Edit, L("EditSectionSetup"));
            sectionSetups.CreateChildPermission(AppPermissions.Pages_SectionSetups_Delete, L("DeleteSectionSetup"));

            pages.CreateChildPermission(AppPermissions.Pages_DemoUiComponents, L("DemoUiComponents"));

            var tblScoring = pages.CreateChildPermission(AppPermissions.Pages_TblScoring, L("TblScoring"), multiTenancySides: MultiTenancySides.Tenant);
            tblScoring.CreateChildPermission(AppPermissions.Pages_TblScoringGetInputData, L("GetInputData"), multiTenancySides: MultiTenancySides.Tenant);
            tblScoring.CreateChildPermission(AppPermissions.Pages_TblScoringInsertScoring, L("InsertScoring"), multiTenancySides: MultiTenancySides.Tenant);

            var curve = pages.CreateChildPermission(AppPermissions.Pages_Curve, L("Curve"), multiTenancySides: MultiTenancySides.Tenant);

            var demoRetail = pages.CreateChildPermission(AppPermissions.Pages_DemoRetail, L("DemoRetail"), multiTenancySides: MultiTenancySides.Tenant);
            demoRetail.CreateChildPermission(AppPermissions.Pages_ApproveAttr, L("ApproveAttr"), multiTenancySides: MultiTenancySides.Tenant);
            demoRetail.CreateChildPermission(AppPermissions.Pages_DeclineAttr, L("DeclineAttr"), multiTenancySides: MultiTenancySides.Tenant);
            demoRetail.CreateChildPermission(AppPermissions.Pages_GetSubRetailAttrItemEdit, L("GetSubRetailAttrItemEdit"), multiTenancySides: MultiTenancySides.Tenant);
            demoRetail.CreateChildPermission(AppPermissions.Pages_CreateSubRetailAttrItem, L("CreateSubRetailAttrItem"), multiTenancySides: MultiTenancySides.Tenant);
            demoRetail.CreateChildPermission(AppPermissions.Pages_GetDetailScores, L("GetDetailScores"), multiTenancySides: MultiTenancySides.Tenant);
            demoRetail.CreateChildPermission(AppPermissions.Pages_GetRetailScoreItemEdit, L("GetRetailScoreItemEdit"), multiTenancySides: MultiTenancySides.Tenant);
            demoRetail.CreateChildPermission(AppPermissions.Pages_GetDemoRetailAttrItem, L("GetDemoRetailAttrItem"), multiTenancySides: MultiTenancySides.Tenant);
            demoRetail.CreateChildPermission(AppPermissions.Pages_AddCutOff, L("AddCutOff"), multiTenancySides: MultiTenancySides.Tenant);
            demoRetail.CreateChildPermission(AppPermissions.Pages_InsertNewCustomerScore, L("InsertNewCustomerScore"), multiTenancySides: MultiTenancySides.Tenant);
            var inputValueCollector = pages.CreateChildPermission(AppPermissions.Pages_InputDataValueCollector, L("InputDataValueCollector"), multiTenancySides: MultiTenancySides.Tenant);
            inputValueCollector.CreateChildPermission(AppPermissions.Pages_GetInputDataValueCollector, L("GetInputDataValueCollector"), multiTenancySides: MultiTenancySides.Tenant);
            inputValueCollector.CreateChildPermission(AppPermissions.Pages_DeleteSelectedAttributes, L("DeleteSelectedAttributes"), multiTenancySides: MultiTenancySides.Tenant);

            var setup = pages.CreateChildPermission(AppPermissions.Pages_SetUp, L("SetUp"), multiTenancySides: MultiTenancySides.Tenant);
            setup.CreateChildPermission(AppPermissions.Pages_CreateSetUp, L("CreateSetUp"), multiTenancySides: MultiTenancySides.Tenant);
            setup.CreateChildPermission(AppPermissions.Pages_GetSetUpList, L("GetSetUpList"), multiTenancySides: MultiTenancySides.Tenant);
            setup.CreateChildPermission(AppPermissions.Pages_GetSetUpItemEdit, L("GetSetUpItemEdit"), multiTenancySides: MultiTenancySides.Tenant);

            var qualAnalysis = pages.CreateChildPermission(AppPermissions.Pages_QualitativeAnalysis, L("QualitativeAnalysis"), multiTenancySides: MultiTenancySides.Tenant);
            qualAnalysis.CreateChildPermission(AppPermissions.Pages_CreateCutOff, L("CreateCutOff"), multiTenancySides: MultiTenancySides.Tenant);
            qualAnalysis.CreateChildPermission(AppPermissions.Pages_PostQualitativeAnalysis, L("PostQualitativeAnalysis"), multiTenancySides: MultiTenancySides.Tenant);
            qualAnalysis.CreateChildPermission(AppPermissions.Pages_GetSCMonitoring, L("GetSCMonitoring"), multiTenancySides: MultiTenancySides.Tenant);

            var scoreCard = pages.CreateChildPermission(AppPermissions.Pages_ScoreCard, L("ScoreCard"), multiTenancySides: MultiTenancySides.Tenant);
            scoreCard.CreateChildPermission(AppPermissions.Pages_CreateScoreCardCutOff, L("CreateScoreCardCutOff"), multiTenancySides: MultiTenancySides.Tenant);

            var retailScoring = pages.CreateChildPermission(AppPermissions.Pages_RetailScoring, L("RetailScoring"), multiTenancySides: MultiTenancySides.Tenant);
            retailScoring.CreateChildPermission(AppPermissions.Pages_GetRetailCutoff, L("GetRetailCutoff"), multiTenancySides: MultiTenancySides.Tenant);
            retailScoring.CreateChildPermission(AppPermissions.Pages_GetRetailScoring, L("GetRetailScoring"), multiTenancySides: MultiTenancySides.Tenant);
            retailScoring.CreateChildPermission(AppPermissions.Pages_PostRetailCutoff, L("PostRetailCutoff"), multiTenancySides: MultiTenancySides.Tenant);
            retailScoring.CreateChildPermission(AppPermissions.Pages_PostRetailScoring, L("PostRetailScoring"), multiTenancySides: MultiTenancySides.Tenant);

            var logRegression = pages.CreateChildPermission(AppPermissions.Pages_LogRegression, L("LogRegression"), multiTenancySides: MultiTenancySides.Tenant);

            var regOutput = pages.CreateChildPermission(AppPermissions.Pages_RegOutput, L("RegOutput"), multiTenancySides: MultiTenancySides.Tenant);

            var caliberation = pages.CreateChildPermission(AppPermissions.Pages_Caliberation, L("Caliberation"), multiTenancySides: MultiTenancySides.Tenant);
            caliberation.CreateChildPermission(AppPermissions.Pages_SetUpPage, L("SetUpPage"), multiTenancySides: MultiTenancySides.Tenant);
            caliberation.CreateChildPermission(AppPermissions.Pages_VintageAnalysis, L("VintageAnalysis"), multiTenancySides: MultiTenancySides.Tenant);

            var logisticRegressionInputs = pages.CreateChildPermission(AppPermissions.Pages_LogisticRegressionInputs, L("LogisticRegressionInputs"));
            logisticRegressionInputs.CreateChildPermission(AppPermissions.Pages_LogisticRegressionInputs_Create, L("CreateNewLogisticRegressionInput"));
            logisticRegressionInputs.CreateChildPermission(AppPermissions.Pages_LogisticRegressionInputs_Edit, L("EditLogisticRegressionInput"));
            logisticRegressionInputs.CreateChildPermission(AppPermissions.Pages_LogisticRegressionInputs_Delete, L("DeleteLogisticRegressionInput"));

            var regressionOutputs = pages.CreateChildPermission(AppPermissions.Pages_RegressionOutputs, L("RegressionOutputs"));
            regressionOutputs.CreateChildPermission(AppPermissions.Pages_RegressionOutputs_Create, L("CreateNewRegressionOutput"));
            regressionOutputs.CreateChildPermission(AppPermissions.Pages_RegressionOutputs_Edit, L("EditRegressionOutput"));
            regressionOutputs.CreateChildPermission(AppPermissions.Pages_RegressionOutputs_Delete, L("DeleteRegressionOutput"));

            var administration = pages.CreateChildPermission(AppPermissions.Pages_Administration, L("Administration"));

            var roles = administration.CreateChildPermission(AppPermissions.Pages_Administration_Roles, L("Roles"));
            roles.CreateChildPermission(AppPermissions.Pages_Administration_Roles_Create, L("CreatingNewRole"));
            roles.CreateChildPermission(AppPermissions.Pages_Administration_Roles_Edit, L("EditingRole"));
            roles.CreateChildPermission(AppPermissions.Pages_Administration_Roles_Delete, L("DeletingRole"));

            var users = administration.CreateChildPermission(AppPermissions.Pages_Administration_Users, L("Users"));
            users.CreateChildPermission(AppPermissions.Pages_Administration_Users_Create, L("CreatingNewUser"));
            users.CreateChildPermission(AppPermissions.Pages_Administration_Users_Edit, L("EditingUser"));
            users.CreateChildPermission(AppPermissions.Pages_Administration_Users_Delete, L("DeletingUser"));
            users.CreateChildPermission(AppPermissions.Pages_Administration_Users_ChangePermissions, L("ChangingPermissions"));
            users.CreateChildPermission(AppPermissions.Pages_Administration_Users_Impersonation, L("LoginForUsers"));
            users.CreateChildPermission(AppPermissions.Pages_Administration_Users_Unlock, L("Unlock"));

            var languages = administration.CreateChildPermission(AppPermissions.Pages_Administration_Languages, L("Languages"));
            languages.CreateChildPermission(AppPermissions.Pages_Administration_Languages_Create, L("CreatingNewLanguage"), multiTenancySides: _isMultiTenancyEnabled ? MultiTenancySides.Host : MultiTenancySides.Tenant);
            languages.CreateChildPermission(AppPermissions.Pages_Administration_Languages_Edit, L("EditingLanguage"), multiTenancySides: _isMultiTenancyEnabled ? MultiTenancySides.Host : MultiTenancySides.Tenant);
            languages.CreateChildPermission(AppPermissions.Pages_Administration_Languages_Delete, L("DeletingLanguages"), multiTenancySides: _isMultiTenancyEnabled ? MultiTenancySides.Host : MultiTenancySides.Tenant);
            languages.CreateChildPermission(AppPermissions.Pages_Administration_Languages_ChangeTexts, L("ChangingTexts"));

            administration.CreateChildPermission(AppPermissions.Pages_Administration_AuditLogs, L("AuditLogs"));

            var organizationUnits = administration.CreateChildPermission(AppPermissions.Pages_Administration_OrganizationUnits, L("OrganizationUnits"));
            organizationUnits.CreateChildPermission(AppPermissions.Pages_Administration_OrganizationUnits_ManageOrganizationTree, L("ManagingOrganizationTree"));
            organizationUnits.CreateChildPermission(AppPermissions.Pages_Administration_OrganizationUnits_ManageMembers, L("ManagingMembers"));
            organizationUnits.CreateChildPermission(AppPermissions.Pages_Administration_OrganizationUnits_ManageRoles, L("ManagingRoles"));

            administration.CreateChildPermission(AppPermissions.Pages_Administration_UiCustomization, L("VisualSettings"));

            var webhooks = administration.CreateChildPermission(AppPermissions.Pages_Administration_WebhookSubscription, L("Webhooks"));
            webhooks.CreateChildPermission(AppPermissions.Pages_Administration_WebhookSubscription_Create, L("CreatingWebhooks"));
            webhooks.CreateChildPermission(AppPermissions.Pages_Administration_WebhookSubscription_Edit, L("EditingWebhooks"));
            webhooks.CreateChildPermission(AppPermissions.Pages_Administration_WebhookSubscription_ChangeActivity, L("ChangingWebhookActivity"));
            webhooks.CreateChildPermission(AppPermissions.Pages_Administration_WebhookSubscription_Detail, L("DetailingSubscription"));
            webhooks.CreateChildPermission(AppPermissions.Pages_Administration_Webhook_ListSendAttempts, L("ListingSendAttempts"));
            webhooks.CreateChildPermission(AppPermissions.Pages_Administration_Webhook_ResendWebhook, L("ResendingWebhook"));

            var dynamicProperties = administration.CreateChildPermission(AppPermissions.Pages_Administration_DynamicProperties, L("DynamicProperties"));
            dynamicProperties.CreateChildPermission(AppPermissions.Pages_Administration_DynamicProperties_Create, L("CreatingDynamicProperties"));
            dynamicProperties.CreateChildPermission(AppPermissions.Pages_Administration_DynamicProperties_Edit, L("EditingDynamicProperties"));
            dynamicProperties.CreateChildPermission(AppPermissions.Pages_Administration_DynamicProperties_Delete, L("DeletingDynamicProperties"));

            var dynamicPropertyValues = dynamicProperties.CreateChildPermission(AppPermissions.Pages_Administration_DynamicPropertyValue, L("DynamicPropertyValue"));
            dynamicPropertyValues.CreateChildPermission(AppPermissions.Pages_Administration_DynamicPropertyValue_Create, L("CreatingDynamicPropertyValue"));
            dynamicPropertyValues.CreateChildPermission(AppPermissions.Pages_Administration_DynamicPropertyValue_Edit, L("EditingDynamicPropertyValue"));
            dynamicPropertyValues.CreateChildPermission(AppPermissions.Pages_Administration_DynamicPropertyValue_Delete, L("DeletingDynamicPropertyValue"));

            var dynamicEntityProperties = dynamicProperties.CreateChildPermission(AppPermissions.Pages_Administration_DynamicEntityProperties, L("DynamicEntityProperties"));
            dynamicEntityProperties.CreateChildPermission(AppPermissions.Pages_Administration_DynamicEntityProperties_Create, L("CreatingDynamicEntityProperties"));
            dynamicEntityProperties.CreateChildPermission(AppPermissions.Pages_Administration_DynamicEntityProperties_Edit, L("EditingDynamicEntityProperties"));
            dynamicEntityProperties.CreateChildPermission(AppPermissions.Pages_Administration_DynamicEntityProperties_Delete, L("DeletingDynamicEntityProperties"));

            var dynamicEntityPropertyValues = dynamicProperties.CreateChildPermission(AppPermissions.Pages_Administration_DynamicEntityPropertyValue, L("EntityDynamicPropertyValue"));
            dynamicEntityPropertyValues.CreateChildPermission(AppPermissions.Pages_Administration_DynamicEntityPropertyValue_Create, L("CreatingDynamicEntityPropertyValue"));
            dynamicEntityPropertyValues.CreateChildPermission(AppPermissions.Pages_Administration_DynamicEntityPropertyValue_Edit, L("EditingDynamicEntityPropertyValue"));
            dynamicEntityPropertyValues.CreateChildPermission(AppPermissions.Pages_Administration_DynamicEntityPropertyValue_Delete, L("DeletingDynamicEntityPropertyValue"));

            //TENANT-SPECIFIC PERMISSIONS

            pages.CreateChildPermission(AppPermissions.Pages_Tenant_Dashboard, L("Dashboard"), multiTenancySides: MultiTenancySides.Tenant);

            //Histogram 
            var histogram = pages.CreateChildPermission(AppPermissions.Pages_Tenant_IfrsLoanHistogram, L("IfrsLoanHistogram"), multiTenancySides: MultiTenancySides.Tenant);
            histogram.CreateChildPermission(AppPermissions.Pages_Tenant_IfrsLoan_CreateHistogram, L("CreateNewHistogram"), multiTenancySides: MultiTenancySides.Tenant);
            histogram.CreateChildPermission(AppPermissions.Pages_Tenant_IfrsLoan_DeleteHistogram, L("DeleteHistogram"), multiTenancySides: MultiTenancySides.Tenant);
            histogram.CreateChildPermission(AppPermissions.Pages_Tenant_IfrsLoan_EditHistogram, L("EditHistogram"), multiTenancySides: MultiTenancySides.Tenant);

            //ScoringInputData
            var scoringInputData = pages.CreateChildPermission(AppPermissions.Pages_Tenant_IfrsLoanScoringInputData, L("IfrsLoanScoringInputData"), multiTenancySides: MultiTenancySides.Tenant);
            scoringInputData.CreateChildPermission(AppPermissions.Pages_Tenant_IfrsLoan_CreateScoringInputData, L("CreateNewScoringInputData"), multiTenancySides: MultiTenancySides.Tenant);
            scoringInputData.CreateChildPermission(AppPermissions.Pages_Tenant_IfrsLoan_DeleteScoringInputData, L("DeleteScoringInputData"), multiTenancySides: MultiTenancySides.Tenant);
            scoringInputData.CreateChildPermission(AppPermissions.Pages_Tenant_IfrsLoan_EditScoringInputData, L("EditScoringInputData"), multiTenancySides: MultiTenancySides.Tenant);

            //ScoringOutput 
            var scoringOutput = pages.CreateChildPermission(AppPermissions.Pages_Tenant_IfrsLoanScoringOutput, L("IfrsLoanScoringOutput"), multiTenancySides: MultiTenancySides.Tenant);
            scoringOutput.CreateChildPermission(AppPermissions.Pages_Tenant_IfrsLoan_CreateScoringOutput, L("CreateNewScoringOutput"), multiTenancySides: MultiTenancySides.Tenant);
            scoringOutput.CreateChildPermission(AppPermissions.Pages_Tenant_IfrsLoan_DeleteScoringOutput, L("DeleteScoringOutput"), multiTenancySides: MultiTenancySides.Tenant);
            scoringOutput.CreateChildPermission(AppPermissions.Pages_Tenant_IfrsLoan_EditScoringOutput, L("EditScoringOutput"), multiTenancySides: MultiTenancySides.Tenant);

            //AgeAttribute 
            var ageAttribute = pages.CreateChildPermission(AppPermissions.Pages_Tenant_AgeAttribute, L("AgeAttribute"), multiTenancySides: MultiTenancySides.Tenant);

            //CreditPreprocessing 
            var creditPreprocessing = pages.CreateChildPermission(AppPermissions.Pages_Tenant_CreditPreprocessing, L("CreditPreprocessing"), multiTenancySides: MultiTenancySides.Tenant);
            //AllScore 
            var allScore = pages.CreateChildPermission(AppPermissions.Pages_Tenant_AllScore, L("AllScore"), multiTenancySides: MultiTenancySides.Tenant);
            //RatingPredictionOutput 
            var ratingPredictionOutput = pages.CreateChildPermission(AppPermissions.Pages_Tenant_RatingPredictionOutput, L("RatingPredictionOutput"), multiTenancySides: MultiTenancySides.Tenant);

            //ProductTypeAttribute 
            var productTypeAttribute = pages.CreateChildPermission(AppPermissions.Pages_Tenant_ProductTypeAttribute, L("ProductTypeAttribute"), multiTenancySides: MultiTenancySides.Tenant);

            //ApplicationScoring 
            var applicationScoring = pages.CreateChildPermission(AppPermissions.Pages_Tenant_ApplicationScoring, L("ApplicationScoring"), multiTenancySides: MultiTenancySides.Tenant);

            //LocationAttribute 
            var locationAttribute = pages.CreateChildPermission(AppPermissions.Pages_Tenant_LocationAttribute, L("LocationAttribute"), multiTenancySides: MultiTenancySides.Tenant);

            //RentAttribute 
            var rentAttribute = pages.CreateChildPermission(AppPermissions.Pages_Tenant_RentAttribute, L("RentAttribute"), multiTenancySides: MultiTenancySides.Tenant);

            //IncomeAttribute 
            var incomeAttribute = pages.CreateChildPermission(AppPermissions.Pages_Tenant_IncomeAttribute, L("IncomeAttribute"), multiTenancySides: MultiTenancySides.Tenant);

            //RenttoIncomeAttribute 
            var renttoIncomeAttribute = pages.CreateChildPermission(AppPermissions.Pages_Tenant_RenttoIncomeAttribute, L("RenttoIncomeAttribute"), multiTenancySides: MultiTenancySides.Tenant);

            //ReturnonAssetsAttribute 
            var returnonAssetsAttribute = pages.CreateChildPermission(AppPermissions.Pages_Tenant_ReturnonAssetsAttribute, L("ReturnonAssetsAttribute"), multiTenancySides: MultiTenancySides.Tenant);

            //SubSectorAttributeAppService 
            var subSectorAttributeAppService = pages.CreateChildPermission(AppPermissions.Pages_Tenant_SubSectorAttributeAppService, L("SubSectorAttributeAppService"), multiTenancySides: MultiTenancySides.Tenant);

            //PreProcessing 
            var preProcessing = pages.CreateChildPermission(AppPermissions.Pages_Tenant_PreProcessing, L("PreProcessing"), multiTenancySides: MultiTenancySides.Tenant);

            //ULoanRequests
            var uLoanRequests = pages.CreateChildPermission(AppPermissions.Pages_ULoanRequests, L("ULoanRequests"));
            uLoanRequests.CreateChildPermission(AppPermissions.Pages_ULoanRequests_Create, L("CreateNewULoanRequest"));
            uLoanRequests.CreateChildPermission(AppPermissions.Pages_ULoanRequests_Edit, L("EditULoanRequest"));
            uLoanRequests.CreateChildPermission(AppPermissions.Pages_ULoanRequests_Delete, L("DeleteULoanRequest"));

            //LoanRequests
            var loanRequests = pages.CreateChildPermission(AppPermissions.Pages_LoanRequests, L("LoanRequests"));
            loanRequests.CreateChildPermission(AppPermissions.Pages_LoanRequests_Create, L("CreateNewLoanRequest"));
            loanRequests.CreateChildPermission(AppPermissions.Pages_LoanRequests_Edit, L("EditLoanRequest"));
            loanRequests.CreateChildPermission(AppPermissions.Pages_LoanRequests_Delete, L("DeleteLoanRequest"));

            administration.CreateChildPermission(AppPermissions.Pages_Administration_Tenant_Settings, L("Settings"), multiTenancySides: MultiTenancySides.Tenant);
            administration.CreateChildPermission(AppPermissions.Pages_Administration_Tenant_SubscriptionManagement, L("Subscription"), multiTenancySides: MultiTenancySides.Tenant);

            //HOST-SPECIFIC PERMISSIONS

            var editions = pages.CreateChildPermission(AppPermissions.Pages_Editions, L("Editions"), multiTenancySides: MultiTenancySides.Host);
            editions.CreateChildPermission(AppPermissions.Pages_Editions_Create, L("CreatingNewEdition"), multiTenancySides: MultiTenancySides.Host);
            editions.CreateChildPermission(AppPermissions.Pages_Editions_Edit, L("EditingEdition"), multiTenancySides: MultiTenancySides.Host);
            editions.CreateChildPermission(AppPermissions.Pages_Editions_Delete, L("DeletingEdition"), multiTenancySides: MultiTenancySides.Host);
            editions.CreateChildPermission(AppPermissions.Pages_Editions_MoveTenantsToAnotherEdition, L("MoveTenantsToAnotherEdition"), multiTenancySides: MultiTenancySides.Host);

            var tenants = pages.CreateChildPermission(AppPermissions.Pages_Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);
            tenants.CreateChildPermission(AppPermissions.Pages_Tenants_Create, L("CreatingNewTenant"), multiTenancySides: MultiTenancySides.Host);
            tenants.CreateChildPermission(AppPermissions.Pages_Tenants_Edit, L("EditingTenant"), multiTenancySides: MultiTenancySides.Host);
            tenants.CreateChildPermission(AppPermissions.Pages_Tenants_ChangeFeatures, L("ChangingFeatures"), multiTenancySides: MultiTenancySides.Host);
            tenants.CreateChildPermission(AppPermissions.Pages_Tenants_Delete, L("DeletingTenant"), multiTenancySides: MultiTenancySides.Host);
            tenants.CreateChildPermission(AppPermissions.Pages_Tenants_Impersonation, L("LoginForTenants"), multiTenancySides: MultiTenancySides.Host);

            administration.CreateChildPermission(AppPermissions.Pages_Administration_Host_Settings, L("Settings"), multiTenancySides: MultiTenancySides.Host);
            administration.CreateChildPermission(AppPermissions.Pages_Administration_Host_Maintenance, L("Maintenance"), multiTenancySides: _isMultiTenancyEnabled ? MultiTenancySides.Host : MultiTenancySides.Tenant);
            administration.CreateChildPermission(AppPermissions.Pages_Administration_HangfireDashboard, L("HangfireDashboard"), multiTenancySides: _isMultiTenancyEnabled ? MultiTenancySides.Host : MultiTenancySides.Tenant);
            administration.CreateChildPermission(AppPermissions.Pages_Administration_Host_Dashboard, L("Dashboard"), multiTenancySides: MultiTenancySides.Host);
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, IFRSDemoConsts.LocalizationSourceName);
        }
    }
}