namespace IFRSDemo.Authorization
{
    /// <summary>
    /// Defines string constants for application's permission names.
    /// <see cref="AppAuthorizationProvider"/> for permission definitions.
    /// </summary>
    public static class AppPermissions
    {
       
        public const string Pages_CooperateAppraisals = "Pages.CooperateAppraisals";
        public const string Pages_CooperateAppraisals_Create = "Pages.CooperateAppraisals.Create";
        public const string Pages_CooperateAppraisals_Edit = "Pages.CooperateAppraisals.Edit";
        public const string Pages_CooperateAppraisals_Delete = "Pages.CooperateAppraisals.Delete";

        public const string Pages_SetupQualitatives = "Pages.SetupQualitatives";
        public const string Pages_SetupQualitatives_Create = "Pages.SetupQualitatives.Create";
        public const string Pages_SetupQualitatives_Edit = "Pages.SetupQualitatives.Edit";
        public const string Pages_SetupQualitatives_Delete = "Pages.SetupQualitatives.Delete";

        public const string Pages_SetupSubHeadings = "Pages.SetupSubHeadings";
        public const string Pages_SetupSubHeadings_Create = "Pages.SetupSubHeadings.Create";
        public const string Pages_SetupSubHeadings_Edit = "Pages.SetupSubHeadings.Edit";
        public const string Pages_SetupSubHeadings_Delete = "Pages.SetupSubHeadings.Delete";

        public const string Pages_SubHeadingSetups = "Pages.SubHeadingSetups";
        public const string Pages_SubHeadingSetups_Create = "Pages.SubHeadingSetups.Create";
        public const string Pages_SubHeadingSetups_Edit = "Pages.SubHeadingSetups.Edit";
        public const string Pages_SubHeadingSetups_Delete = "Pages.SubHeadingSetups.Delete";

        public const string Pages_QualitativeSetups = "Pages.QualitativeSetups";
        public const string Pages_QualitativeSetups_Create = "Pages.QualitativeSetups.Create";
        public const string Pages_QualitativeSetups_Edit = "Pages.QualitativeSetups.Edit";
        public const string Pages_QualitativeSetups_Delete = "Pages.QualitativeSetups.Delete";

        public const string Pages_SubSectorSetups = "Pages.SubSectorSetups";
        public const string Pages_SubSectorSetups_Create = "Pages.SubSectorSetups.Create";
        public const string Pages_SubSectorSetups_Edit = "Pages.SubSectorSetups.Edit";
        public const string Pages_SubSectorSetups_Delete = "Pages.SubSectorSetups.Delete";

        public const string Pages_SectionSetups = "Pages.SectionSetups";
        public const string Pages_SectionSetups_Create = "Pages.SectionSetups.Create";
        public const string Pages_SectionSetups_Edit = "Pages.SectionSetups.Edit";
        public const string Pages_SectionSetups_Delete = "Pages.SectionSetups.Delete";

        public const string Pages_LogisticRegressionInputs = "Pages.LogisticRegressionInputs";
        public const string Pages_LogisticRegressionInputs_Create = "Pages.LogisticRegressionInputs.Create";
        public const string Pages_LogisticRegressionInputs_Edit = "Pages.LogisticRegressionInputs.Edit";
        public const string Pages_LogisticRegressionInputs_Delete = "Pages.LogisticRegressionInputs.Delete";

        public const string Pages_RegressionOutputs = "Pages.RegressionOutputs";
        public const string Pages_RegressionOutputs_Create = "Pages.RegressionOutputs.Create";
        public const string Pages_RegressionOutputs_Edit = "Pages.RegressionOutputs.Edit";
        public const string Pages_RegressionOutputs_Delete = "Pages.RegressionOutputs.Delete";

        //COMMON PERMISSIONS (FOR BOTH OF TENANTS AND HOST)

        public const string Pages = "Pages";

        public const string Pages_DemoUiComponents = "Pages.DemoUiComponents";
        public const string Pages_Administration = "Pages.Administration";

        public const string Pages_Administration_Roles = "Pages.Administration.Roles";
        public const string Pages_Administration_Roles_Create = "Pages.Administration.Roles.Create";
        public const string Pages_Administration_Roles_Edit = "Pages.Administration.Roles.Edit";
        public const string Pages_Administration_Roles_Delete = "Pages.Administration.Roles.Delete";

        public const string Pages_Administration_Users = "Pages.Administration.Users";
        public const string Pages_Administration_Users_Create = "Pages.Administration.Users.Create";
        public const string Pages_Administration_Users_Edit = "Pages.Administration.Users.Edit";
        public const string Pages_Administration_Users_Delete = "Pages.Administration.Users.Delete";
        public const string Pages_Administration_Users_ChangePermissions = "Pages.Administration.Users.ChangePermissions";
        public const string Pages_Administration_Users_Impersonation = "Pages.Administration.Users.Impersonation";
        public const string Pages_Administration_Users_Unlock = "Pages.Administration.Users.Unlock";

        public const string Pages_Administration_Languages = "Pages.Administration.Languages";
        public const string Pages_Administration_Languages_Create = "Pages.Administration.Languages.Create";
        public const string Pages_Administration_Languages_Edit = "Pages.Administration.Languages.Edit";
        public const string Pages_Administration_Languages_Delete = "Pages.Administration.Languages.Delete";
        public const string Pages_Administration_Languages_ChangeTexts = "Pages.Administration.Languages.ChangeTexts";

        public const string Pages_Administration_AuditLogs = "Pages.Administration.AuditLogs";

        public const string Pages_Administration_OrganizationUnits = "Pages.Administration.OrganizationUnits";
        public const string Pages_Administration_OrganizationUnits_ManageOrganizationTree = "Pages.Administration.OrganizationUnits.ManageOrganizationTree";
        public const string Pages_Administration_OrganizationUnits_ManageMembers = "Pages.Administration.OrganizationUnits.ManageMembers";
        public const string Pages_Administration_OrganizationUnits_ManageRoles = "Pages.Administration.OrganizationUnits.ManageRoles";

        public const string Pages_Administration_HangfireDashboard = "Pages.Administration.HangfireDashboard";

        public const string Pages_Administration_UiCustomization = "Pages.Administration.UiCustomization";

        public const string Pages_Administration_WebhookSubscription = "Pages.Administration.WebhookSubscription";
        public const string Pages_Administration_WebhookSubscription_Create = "Pages.Administration.WebhookSubscription.Create";
        public const string Pages_Administration_WebhookSubscription_Edit = "Pages.Administration.WebhookSubscription.Edit";
        public const string Pages_Administration_WebhookSubscription_ChangeActivity = "Pages.Administration.WebhookSubscription.ChangeActivity";
        public const string Pages_Administration_WebhookSubscription_Detail = "Pages.Administration.WebhookSubscription.Detail";
        public const string Pages_Administration_Webhook_ListSendAttempts = "Pages.Administration.Webhook.ListSendAttempts";
        public const string Pages_Administration_Webhook_ResendWebhook = "Pages.Administration.Webhook.ResendWebhook";

        public const string Pages_Administration_DynamicProperties = "Pages.Administration.DynamicProperties";
        public const string Pages_Administration_DynamicProperties_Create = "Pages.Administration.DynamicProperties.Create";
        public const string Pages_Administration_DynamicProperties_Edit = "Pages.Administration.DynamicProperties.Edit";
        public const string Pages_Administration_DynamicProperties_Delete = "Pages.Administration.DynamicProperties.Delete";

        public const string Pages_Administration_DynamicPropertyValue = "Pages.Administration.DynamicPropertyValue";
        public const string Pages_Administration_DynamicPropertyValue_Create = "Pages.Administration.DynamicPropertyValue.Create";
        public const string Pages_Administration_DynamicPropertyValue_Edit = "Pages.Administration.DynamicPropertyValue.Edit";
        public const string Pages_Administration_DynamicPropertyValue_Delete = "Pages.Administration.DynamicPropertyValue.Delete";

        public const string Pages_Administration_DynamicEntityProperties = "Pages.Administration.DynamicEntityProperties";
        public const string Pages_Administration_DynamicEntityProperties_Create = "Pages.Administration.DynamicEntityProperties.Create";
        public const string Pages_Administration_DynamicEntityProperties_Edit = "Pages.Administration.DynamicEntityProperties.Edit";
        public const string Pages_Administration_DynamicEntityProperties_Delete = "Pages.Administration.DynamicEntityProperties.Delete";

        public const string Pages_Administration_DynamicEntityPropertyValue = "Pages.Administration.DynamicEntityPropertyValue";
        public const string Pages_Administration_DynamicEntityPropertyValue_Create = "Pages.Administration.DynamicEntityPropertyValue.Create";
        public const string Pages_Administration_DynamicEntityPropertyValue_Edit = "Pages.Administration.DynamicEntityPropertyValue.Edit";
        public const string Pages_Administration_DynamicEntityPropertyValue_Delete = "Pages.Administration.DynamicEntityPropertyValue.Delete";
        //TENANT-SPECIFIC PERMISSIONS

        public const string Pages_Tenant_Dashboard = "Pages.Tenant.Dashboard";

        //Histogram
        public const string Pages_Tenant_IfrsLoanHistogram = "Pages.Tenant.Histogram";
        public const string Pages_Tenant_IfrsLoan_CreateHistogram = "Pages.Tenant.IfrsLoan.CreateHistogram";
        public const string Pages_Tenant_IfrsLoan_DeleteHistogram = "Pages.Tenant.IfrsLoan.DeleteHistogram";
        public const string Pages_Tenant_IfrsLoan_EditHistogram = "Pages.Tenant.IfrsLoan.EditHistogram";

        //PreProcessing
        public const string Pages_Tenant_PreProcessing = "Pages.Tenant.PreProcessing";

        //ScoringInputData
        public const string Pages_Tenant_IfrsLoanScoringInputData = "Pages.Tenant.ScoringInputData";
        public const string Pages_Tenant_IfrsLoan_CreateScoringInputData = "Pages.Tenant.IfrsLoan.CreateScoringInputData";
        public const string Pages_Tenant_IfrsLoan_DeleteScoringInputData = "Pages.Tenant.IfrsLoan.DeleteScoringInputData";
        public const string Pages_Tenant_IfrsLoan_EditScoringInputData = "Pages.Tenant.IfrsLoan.EditScoringInputData";

        //ScoringOutput
        public const string Pages_Tenant_IfrsLoanScoringOutput = "Pages.Tenant.ScoringOutput";
        public const string Pages_Tenant_IfrsLoan_CreateScoringOutput = "Pages.Tenant.IfrsLoan.CreateScoringOutput";
        public const string Pages_Tenant_IfrsLoan_DeleteScoringOutput = "Pages.Tenant.IfrsLoan.DeleteScoringOutput";
        public const string Pages_Tenant_IfrsLoan_EditScoringOutput = "Pages.Tenant.IfrsLoan.EditScoringOutput";

        //AgeAttribute
        public const string Pages_Tenant_AgeAttribute = "Pages.Tenant.AgeAttribute";
        //CreditPreprocessing
        public const string Pages_Tenant_CreditPreprocessing = "Pages.Tenant.CreditPreprocessing";
        //AllScore
        public const string Pages_Tenant_AllScore = "Pages.Tenant.AllScore";
        //RatingPredictionOutput
        public const string Pages_Tenant_RatingPredictionOutput = "Pages.Tenant.RatingPredictionOutput";

        //ProductTypeAttribute
        public const string Pages_Tenant_ProductTypeAttribute = "Pages.Tenant.ProductTypeAttribute";

        //ApplicationScoring
        public const string Pages_Tenant_ApplicationScoring = "Pages.Tenant.ApplicationScoring";
        //LocationAttribute
        public const string Pages_Tenant_LocationAttribute = "Pages.Tenant.LocationAttribute";
        //RentAttribute
        public const string Pages_Tenant_RentAttribute = "Pages.Tenant.RentAttribute";
        //IncomeAttribute
        public const string Pages_Tenant_IncomeAttribute = "Pages.Tenant.IncomeAttribute";
        //RenttoIncomeAttribute
        public const string Pages_Tenant_RenttoIncomeAttribute = "Pages.Tenant.RenttoIncomeAttribute";
        //ReturnonAssetsAttribute
        public const string Pages_Tenant_ReturnonAssetsAttribute = "Pages.Tenant.ReturnonAssetsAttribute";
        //SubSectorAttributeAppService
        public const string Pages_Tenant_SubSectorAttributeAppService = "Pages.Tenant.SubSectorAttributeAppService";

        //LoanRequest
        public const string Pages_ULoanRequests = "Pages.ULoanRequests";
        public const string Pages_ULoanRequests_Create = "Pages.ULoanRequests.Create";
        public const string Pages_ULoanRequests_Edit = "Pages.ULoanRequests.Edit";
        public const string Pages_ULoanRequests_Delete = "Pages.ULoanRequests.Delete";

        public const string Pages_LoanRequests = "Pages.LoanRequests";
        public const string Pages_LoanRequests_Create = "Pages.LoanRequests.Create";
        public const string Pages_LoanRequests_Edit = "Pages.LoanRequests.Edit";
        public const string Pages_LoanRequests_Delete = "Pages.LoanRequests.Delete";

        //Tbl_ScoringData
        public const string Pages_TblScoring = "Pages.Tenant.TblScoring";
        public const string Pages_TblScoringGetInputData = "Pages.TblScoring.Tenant.GetInputData";
        public const string Pages_TblScoringInsertScoring = "Pages.TblScoring.Tenant.InsertScoring";

        //Curve
        public const string Pages_Curve = "Pages.Tenant.Curve";

        //DemoRetail
        public const string Pages_DemoRetail = "Pages.Tenant.DemoRetail";
        public const string Pages_ApproveAttr = "Pages.DemoRetail.Tenant.ApproveAttr";
        public const string Pages_DeclineAttr = "Pages.DemoRetail.Tenant.DeclineAttr";
        public const string Pages_GetSubRetailAttrItemEdit = "Pages.DemoRetail.Tenant.GetSubRetailAttrItemEdit";
        public const string Pages_CreateSubRetailAttrItem = "Pages.DemoRetail.Tenant.CreateSubRetailAttrItem";
        public const string Pages_GetDetailScores = "Pages.DemoRetail.Tenant.GetDetailScores";
        public const string Pages_GetRetailScoreItemEdit = "Pages.DemoRetail.Tenant.GetRetailScoreItemEdit";
        public const string Pages_GetDemoRetailAttrItem = "Pages.DemoRetail.Tenant.GetDemoRetailAttrItem";
        public const string Pages_AddCutOff = "Pages.DemoRetail.Tenant.AddCutOff";
        public const string Pages_InsertNewCustomerScore = "Pages.DemoRetail.Tenant.InsertNewCustomerScore";

        //InputDataValueCollector
        public const string Pages_InputDataValueCollector = "Pages.Tenant.InputDataValueCollector";
        public const string Pages_GetInputDataValueCollector = "Pages.InputDataValueCollector.Tenant.GetInputDataValueCollector";
        public const string Pages_DeleteSelectedAttributes = "Pages.InputDataValueCollector.Tenant.DeleteSelectedAttributes";

        //SetUp
        public const string Pages_SetUp = "Pages.Tenant.SetUp";
        public const string Pages_CreateSetUp = "Pages.SetUp.Tenant.CreateSetUp";
        public const string Pages_GetSetUpList = "Pages.SetUp.Tenant.GetSetUpList";
        public const string Pages_GetSetUpItemEdit = "Pages.SetUp.Tenant.GetSetUpItemEdit";

        //QualitativeAnalysis  
        public const string Pages_QualitativeAnalysis = "Pages.Tenant.QualitativeAnalysis";
        public const string Pages_CreateCutOff = "Pages.QualitativeAnalysis.Tenant.CreateCutOff";
        public const string Pages_PostQualitativeAnalysis = "Pages.QualitativeAnalysis.Tenant.PostQualitativeAnalysis";
        public const string Pages_GetSCMonitoring = "Pages.QualitativeAnalysis.Tenant.GetSCMonitoring";

        //ScoreCard
        public const string Pages_ScoreCard = "Pages.Tenant.ScoreCard";
        public const string Pages_CreateScoreCardCutOff = "Pages.ScoreCard.Tenant.CreateScoreCardCutOff";

        //RetailScoring
        public const string Pages_RetailScoring = "Pages.Tenant.RetailScoring";
        public const string Pages_GetRetailCutoff = "Pages.RetailScoring.Tenant.GetRetailCutoff";
        public const string Pages_GetRetailScoring = "Pages.RetailScoring.Tenant.GetRetailScoring";
        public const string Pages_PostRetailCutoff = "Pages.RetailScoring.Tenant.PostRetailCutoff";
        public const string Pages_PostRetailScoring = "Pages.RetailScoring.Tenant.PostRetailScoring";

        //LogRegression
        public const string Pages_LogRegression = "Pages.Tenant.LogRegression";

        //RegOutput
        public const string Pages_RegOutput = "Pages.Tenant.RegOutput";

        //Caliberation
        public const string Pages_Caliberation = "Pages.Tenant.Caliberation";
        public const string Pages_SetUpPage = "Pages.Tenant.SetUpPage";
        public const string Pages_VintageAnalysis = "Pages.Tenant.VintageAnalysis";

        public const string Pages_Administration_Tenant_Settings = "Pages.Administration.Tenant.Settings";

        public const string Pages_Administration_Tenant_SubscriptionManagement = "Pages.Administration.Tenant.SubscriptionManagement";

        //HOST-SPECIFIC PERMISSIONS

        public const string Pages_Editions = "Pages.Editions";
        public const string Pages_Editions_Create = "Pages.Editions.Create";
        public const string Pages_Editions_Edit = "Pages.Editions.Edit";
        public const string Pages_Editions_Delete = "Pages.Editions.Delete";
        public const string Pages_Editions_MoveTenantsToAnotherEdition = "Pages.Editions.MoveTenantsToAnotherEdition";

        public const string Pages_Tenants = "Pages.Tenants";
        public const string Pages_Tenants_Create = "Pages.Tenants.Create";
        public const string Pages_Tenants_Edit = "Pages.Tenants.Edit";
        public const string Pages_Tenants_ChangeFeatures = "Pages.Tenants.ChangeFeatures";
        public const string Pages_Tenants_Delete = "Pages.Tenants.Delete";
        public const string Pages_Tenants_Impersonation = "Pages.Tenants.Impersonation";

        public const string Pages_Administration_Host_Maintenance = "Pages.Administration.Host.Maintenance";
        public const string Pages_Administration_Host_Settings = "Pages.Administration.Host.Settings";
        public const string Pages_Administration_Host_Dashboard = "Pages.Administration.Host.Dashboard";

    }
}