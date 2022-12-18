using IFRSDemo.Cooperate.Dtos;
using IFRSDemo.Cooperate;
using IFRSDemo.LogisticRegression.Dtos;
using IFRSDemo.LogisticRegression;
using IFRSDemo.Regression.Dtos;
using IFRSDemo.Regression;
using Abp.Application.Editions;
using Abp.Application.Features;
using Abp.Auditing;
using Abp.Authorization;
using Abp.Authorization.Users;
using Abp.DynamicEntityProperties;
using Abp.EntityHistory;
using Abp.Localization;
using Abp.Notifications;
using Abp.Organizations;
using Abp.UI.Inputs;
using Abp.Webhooks;
using AutoMapper;
using IFRSDemo.Auditing.Dto;
using IFRSDemo.Authorization.Accounts.Dto;
using IFRSDemo.Authorization.Delegation;
using IFRSDemo.Authorization.Permissions.Dto;
using IFRSDemo.Authorization.Roles;
using IFRSDemo.Authorization.Roles.Dto;
using IFRSDemo.Authorization.Users;
using IFRSDemo.Authorization.Users.Delegation.Dto;
using IFRSDemo.Authorization.Users.Dto;
using IFRSDemo.Authorization.Users.Importing.Dto;
using IFRSDemo.Authorization.Users.Profile.Dto;
using IFRSDemo.Chat;
using IFRSDemo.Chat.Dto;
using IFRSDemo.DynamicEntityProperties.Dto;
using IFRSDemo.Editions;
using IFRSDemo.Editions.Dto;
using IFRSDemo.Friendships;
using IFRSDemo.Friendships.Cache;
using IFRSDemo.Friendships.Dto;
using IFRSDemo.Localization.Dto;
using IFRSDemo.MultiTenancy;
using IFRSDemo.MultiTenancy.Dto;
using IFRSDemo.MultiTenancy.HostDashboard.Dto;
using IFRSDemo.MultiTenancy.Payments;
using IFRSDemo.MultiTenancy.Payments.Dto;
using IFRSDemo.Notifications.Dto;
using IFRSDemo.Organizations.Dto;
using IFRSDemo.Sessions.Dto;
using IFRSDemo.WebHooks.Dto;
using IFRSDemo.IfrsLoan.Dto;
using IFRSDemo.IfrsLoan;
using IFRSDemo.SMELending;
using IFRSDemo.SMELending.Dtos;
using IFRSDemo.UserLoanRequest;
using IFRSDemo.UserLoanRequest.Dtos;
using IFRSDemo.AllLoanrequest.Dtos;
using IFRSDemo.AllLoanrequest;
using IFRSDemo.SetUp.Dto;
using IFRSDemo.SetUp;
using IFRSDemo.LogisticRegression.Dto;
using IFRSDemo.ManualUpload.Dto;
using IFRSDemo.ManualUpload;
using IFRSDemo.Curves;
using IFRSDemo.Curves.Dto;
using IFRSDemo.ScoreCard.Dto;
using IFRSDemo.ScoreCard;
using IFRSDemo.QualitativeAnalysis.Dto;
using IFRSDemo.QualitativeAnalysis;
using IFRSDemo.DigitalLending.Dto;
using IFRSDemo.DigitalLending;
using IFRSDemo.Caliberation;
using IFRSDemo.Caliberation.Dto;
using IFRSDemo.DemoAttribute;
using IFRSDemo.DemoAttribute.Dto;

namespace IFRSDemo
{
    internal static class CustomDtoMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
          configuration.CreateMap<CreateOrEditCooperateAppraisalDto, CooperateAppraisal>().ReverseMap();
            configuration.CreateMap<CooperateAppraisalDto, CooperateAppraisal>().ReverseMap();
            configuration.CreateMap<CreateOrEditSetupQualitativeDto, SetupQualitative>().ReverseMap();
            configuration.CreateMap<SetupQualitativeDto, SetupQualitative>().ReverseMap();
            configuration.CreateMap<CreateOrEditSetupSubHeadingDto, SetupSubHeading>().ReverseMap();
            configuration.CreateMap<SetupSubHeadingDto, SetupSubHeading>().ReverseMap();
            configuration.CreateMap<CreateOrEditSubHeadingSetupDto, SubHeadingSetup>().ReverseMap();
            configuration.CreateMap<SubHeadingSetupDto, SubHeadingSetup>().ReverseMap();
            configuration.CreateMap<CreateOrEditQualitativeSetupDto, QualitativeSetup>().ReverseMap();
            configuration.CreateMap<QualitativeSetupDto, QualitativeSetup>().ReverseMap();
            configuration.CreateMap<CreateOrEditSubSectorSetupDto, SubSectorSetup>().ReverseMap();
            configuration.CreateMap<SubSectorSetupDto, SubSectorSetup>().ReverseMap();
            configuration.CreateMap<CreateOrEditSectionSetupDto, SectionSetup>().ReverseMap();
            configuration.CreateMap<SectionSetupDto, SectionSetup>().ReverseMap();
            configuration.CreateMap<CreateOrEditLogisticRegressionInputDto, LogisticRegressionInput>().ReverseMap();
            configuration.CreateMap<LogisticRegressionInputDto, LogisticRegressionInput>().ReverseMap();
            configuration.CreateMap<CreateOrEditRegressionOutputDto, RegressionOutput>().ReverseMap();
            configuration.CreateMap<RegressionOutputDto, RegressionOutput>().ReverseMap();
            //Inputs
            configuration.CreateMap<CheckboxInputType, FeatureInputTypeDto>();
            configuration.CreateMap<SingleLineStringInputType, FeatureInputTypeDto>();
            configuration.CreateMap<ComboboxInputType, FeatureInputTypeDto>();
            configuration.CreateMap<IInputType, FeatureInputTypeDto>()
                .Include<CheckboxInputType, FeatureInputTypeDto>()
                .Include<SingleLineStringInputType, FeatureInputTypeDto>()
                .Include<ComboboxInputType, FeatureInputTypeDto>();
            configuration.CreateMap<StaticLocalizableComboboxItemSource, LocalizableComboboxItemSourceDto>();
            configuration.CreateMap<ILocalizableComboboxItemSource, LocalizableComboboxItemSourceDto>()
                .Include<StaticLocalizableComboboxItemSource, LocalizableComboboxItemSourceDto>();
            configuration.CreateMap<LocalizableComboboxItem, LocalizableComboboxItemDto>();
            configuration.CreateMap<ILocalizableComboboxItem, LocalizableComboboxItemDto>()
                .Include<LocalizableComboboxItem, LocalizableComboboxItemDto>();

            //Histogram
            configuration.CreateMap<Histogram, HistogramListDto>();
            //configuration.CreateMap<Histogram, HistogramListDto>();
            configuration.CreateMap<CreateHistogramInput, Histogram>();
            configuration.CreateMap<CreateHistogramInput, Histogram>();
            configuration.CreateMap<Histogram, GetHistogramForEditOutput>();
            configuration.CreateMap<ComponentTableDto, Histogram>();

            //ScoringInputData
            configuration.CreateMap<ScoringInputData, ScoringInputDataListDto>();
            configuration.CreateMap<ScoringInputData, CreateScoringInputDataDto>();
            //configuration.CreateMap<ScoringInputData, ScoringInputDataListDto>();
            configuration.CreateMap<CreateScoringInputDataInput, ScoringInputData>();
            configuration.CreateMap<CreateScoringInputDataInput, ScoringInputData>();
            configuration.CreateMap<ScoringInputData, GetScoringInputDataForEditOutput>();

            //ScoringOutput
            configuration.CreateMap<ScoringOutput, ScoringOutputListDto>();
            //configuration.CreateMap<ScoringOutput, ScoringOutputListDto>();
            configuration.CreateMap<CreateScoringOutputInput, ScoringOutput>();
            configuration.CreateMap<CreateScoringOutputInput, ScoringOutput>();
            configuration.CreateMap<ScoringOutput, GetScoringOutputForEditOutput>();
            configuration.CreateMap<ComponentTableDto, ScoringOutput>();

            //Component
            configuration.CreateMap<Component, ComponentListDto>();

            //AgeAttribute
            configuration.CreateMap<AgeAttribute, AgeAttributeListDto>();

            //AccountBalData
            configuration.CreateMap<AccountBalData, AccountBalDataListDto>();

            //CreditPreprocessing
            configuration.CreateMap<CreditPreprocessing, CreditPreprocessingListDto>();

            //AllScore
            configuration.CreateMap<AllScore, AllScoreListDto>();

            //RatingPredictionOutput
            configuration.CreateMap<RatingPredictionOutput, RatingPredictionOutputListDto>();

            //ProductTypeAttribute
            configuration.CreateMap<ProductTypeAttribute, ProductTypeAttributeListDto>();

            //ApplicationScoring
            configuration.CreateMap<CreateApplicationScoringInput, ApplicationScoring>();
            configuration.CreateMap<ApplicationScoring, ApplicationScoringListDto>();

            //IncomeAttribute
            configuration.CreateMap<IncomeAttribute, IncomeAttributeListDto>();

            //LocationAttribute
            configuration.CreateMap<LocationAttribute, LocationAttributeListDto>();

            //RentAttribute
            configuration.CreateMap<RentAttribute, RentAttributeListDto>();

            //RenttoIncomeAttribute
            configuration.CreateMap<RenttoIncomeAttribute, RenttoIncomeAttributeListDto>();

            //SubSectorAttribute
            configuration.CreateMap<SubSectorAttribute, SubSectorAttributeListDto>();

            //AppAttribute
            configuration.CreateMap<AppAttribute, AppAttributeListDto>();

            //ApplicantAttribute
            configuration.CreateMap<ApplicantAttribute, ApplicantAttributeListDto>();

            //Histogram
            //configuration.CreateMap<Histogram, HistogramListDto>();

            //PreProcessing
            configuration.CreateMap<PreProcessing, PreProcessingListDto>();

            //Operation
            configuration.CreateMap<Operation, OperationListDto>();

            //InputDataValueCollector
            configuration.CreateMap<CreateInputDataValueCollectorInput, InputDataValueCollector>();
            configuration.CreateMap<InputDataValueCollector, InputDataValueCollectorListDto>();

            //InputData
            configuration.CreateMap<CreateInputDataInput, InputData>();
            configuration.CreateMap<InputDataListDto, InputData>();

            //Bank
            configuration.CreateMap<Bank, BankListDto>();

            //GenderType
            configuration.CreateMap<GenderType, GenderTypeListDto>();

            //LoanType
            configuration.CreateMap<LoanType, LoanTypeListDto>();

            //SMELendingApply
            configuration.CreateMap<SMELendingApply, SMELendingApplyListDto>();
            configuration.CreateMap<CreateSMELendingApplyInput, SMELendingApply>();

            //SMETitle
            configuration.CreateMap<SMETitle, SMETitleListDto>();

            //Operation_Eligibility
            configuration.CreateMap<Operation_Eligibility, OperationEligibilityListDto>();

            //BusRegNig
            configuration.CreateMap<BusRegNig, SMETitleListDto>();

            //AccountAuthorize
            configuration.CreateMap<AccountAuthorize, AccountAuthorizeListDto>();

            //HaveBankAccount
            configuration.CreateMap<HaveBankAccount, HaveBankAccountListDto>();

            //HaveNIN
            configuration.CreateMap<HaveNIN, HaveNINListDto>();

            //UserLoanRequest 
            configuration.CreateMap<CreateOrEditULoanRequestDto, ULoanRequest>().ReverseMap();
            configuration.CreateMap<ULoanRequestDto, ULoanRequest>().ReverseMap();
            //AllLoanRequest
            configuration.CreateMap<CreateOrEditLoanRequestDto, LoanRequest>().ReverseMap();
            configuration.CreateMap<LoanRequestDto, LoanRequest>().ReverseMap();

            //FinancialRatio
            configuration.CreateMap<FinancialRatio, FinancialRatioListDto>();
            //configuration.CreateMap<FinancialRatio, FinancialRatioListDto>();
            configuration.CreateMap<CreateFinancialRatioInput, FinancialRatio>();
            configuration.CreateMap<FinancialRatio, GetFinancialRatioForEditOutput>();

            //SetUpItem
            configuration.CreateMap<CreateSetUpItemDto, SetUpItem>();
            configuration.CreateMap<SetUpItem, SetUpItemListDto>();
            configuration.CreateMap<SetUpItem, GetSetUpItemForEditOutput>();
            //Method
            configuration.CreateMap<Method, MethodListDto>();
            //LogRegression
            configuration.CreateMap<LogRegression, GetLogRegressionForViewDto>();

            //SplittingMethod
            configuration.CreateMap<SplittingMethod, SplittingMethodListDto>();

            //GoodBad
            configuration.CreateMap<GoodBad, GoodBadDto>();

            //RegOutput
            configuration.CreateMap<RegOutput, RegOutputDto>();

            //TblWoe_Age
            configuration.CreateMap<TblWoe_Age, TblWoe_AgeDto>();

            //TblWoe_TimeatJob
            configuration.CreateMap<TblWoe_TimeatJob, TblWoe_TimeatJobDto>();

            //TblWoe_PaymentPerformance
            configuration.CreateMap<TblWoe_PaymentPerformance, TblWoe_PaymentPerformanceDto>();

            //TblWoe_PaymentPerformance
            configuration.CreateMap<Tbl_Psi, Tbl_PsiDto>();

            //Qualitative Analysis
            configuration.CreateMap<CreateCutOffDto, Cutoff>();
            configuration.CreateMap<CreateQualitativeAnalysisDto, Tbl_QualitativeAnalysis>();

            //ScoreReport
            configuration.CreateMap<CreateTblCutOffDto, TblCutOff>();
            configuration.CreateMap<Scaling, GetScalingForEditOutput>();

            //RetailScoring
            configuration.CreateMap<CreateRetailCutOff, RetailCutoff>();
            configuration.CreateMap<CreateRetailScoring, RetailScoring>();
            //Qualitative Analysis Rating CreateProfit_AnalysisDto
            configuration.CreateMap<CreateQARatingDto, QARating>();
            //configuration.CreateMap<CreateRiskRatingDto, RiskRating>(); 
            configuration.CreateMap<CreateSCMonitoringDto, SCMonitoring>();
            configuration.CreateMap<EditQARatingInput, QARating>();
            configuration.CreateMap<QARating, GetQARatingForEditOutput>();
            configuration.CreateMap<CreateProfit_AnalysisDto, CreateProfit_Analysis>();
            configuration.CreateMap<Createtbl_scoreDto, tbl_score>();
            configuration.CreateMap<CreateRatingAttributeDto, RatingAttribute>();

            //DigitalLending
            configuration.CreateMap<CreateIndAppDto, IndividualApp>();
            //TblScoreReport
            configuration.CreateMap<TblScoreReport, GetTblScoreReportForEditOutput>();

            //SetUPDto
            configuration.CreateMap<CreateSetUPDto, SetupPage>();

            configuration.CreateMap<CreateDemoRetailAttrDto, DemoRetailAttrItem>();
            configuration.CreateMap<DemoRetailAttrItem, GetDemoRetailAttrForEditOutput>();
            configuration.CreateMap<EditDemoRetailAttrInput, DemoRetailAttrItem>();
            configuration.CreateMap<CreateSubRetailAttrItemDto, SubRetailAttrItem>();
            configuration.CreateMap<SubRetailAttrItem, GetSubRetailAttrItemForEditOutput>();
            configuration.CreateMap<EditSubRetailAttrItemInput, SubRetailAttrItem>();
            configuration.CreateMap<CreateRetailScoreDto, RetailScore>();
            configuration.CreateMap<RetailScore, GetRetailScoreForEditOutput>();
            configuration.CreateMap<EditRetailScoreInput, RetailScore>();
            configuration.CreateMap<DemoRetailCutOffDto, DemoRetailCutOff>();
            configuration.CreateMap<RetailCustomerDetail, RetailCustomerDetailForEditOutput>();

            //DigSetUp
            configuration.CreateMap<DigSetUp, GetDigSetUpForEditOutput>();
            configuration.CreateMap<EditDigSetUpInput, DigSetUp>();


            //CooperateScore
            configuration.CreateMap<CreateCooperateScoreDto, CooperateScore>();

            configuration.CreateMap<CooperateScore, GetCooperateScoreForEditOutput>();

            //Chat
            configuration.CreateMap<ChatMessage, ChatMessageDto>();
            configuration.CreateMap<ChatMessage, ChatMessageExportDto>();

            //Feature
            configuration.CreateMap<FlatFeatureSelectDto, Feature>().ReverseMap();
            configuration.CreateMap<Feature, FlatFeatureDto>();

            //Role
            configuration.CreateMap<RoleEditDto, Role>().ReverseMap();
            configuration.CreateMap<Role, RoleListDto>();
            configuration.CreateMap<UserRole, UserListRoleDto>();

            //Edition
            configuration.CreateMap<EditionEditDto, SubscribableEdition>().ReverseMap();
            configuration.CreateMap<EditionCreateDto, SubscribableEdition>();
            configuration.CreateMap<EditionSelectDto, SubscribableEdition>().ReverseMap();
            configuration.CreateMap<SubscribableEdition, EditionInfoDto>();

            configuration.CreateMap<Edition, EditionInfoDto>().Include<SubscribableEdition, EditionInfoDto>();

            configuration.CreateMap<SubscribableEdition, EditionListDto>();
            configuration.CreateMap<Edition, EditionEditDto>();
            configuration.CreateMap<Edition, SubscribableEdition>();
            configuration.CreateMap<Edition, EditionSelectDto>();

            //Payment
            configuration.CreateMap<SubscriptionPaymentDto, SubscriptionPayment>().ReverseMap();
            configuration.CreateMap<SubscriptionPaymentListDto, SubscriptionPayment>().ReverseMap();
            configuration.CreateMap<SubscriptionPayment, SubscriptionPaymentInfoDto>();

            //Permission
            configuration.CreateMap<Permission, FlatPermissionDto>();
            configuration.CreateMap<Permission, FlatPermissionWithLevelDto>();

            //Language
            configuration.CreateMap<ApplicationLanguage, ApplicationLanguageEditDto>();
            configuration.CreateMap<ApplicationLanguage, ApplicationLanguageListDto>();
            configuration.CreateMap<NotificationDefinition, NotificationSubscriptionWithDisplayNameDto>();
            configuration.CreateMap<ApplicationLanguage, ApplicationLanguageEditDto>()
                .ForMember(ldto => ldto.IsEnabled, options => options.MapFrom(l => !l.IsDisabled));

            //Tenant
            configuration.CreateMap<Tenant, RecentTenant>();
            configuration.CreateMap<Tenant, TenantLoginInfoDto>();
            configuration.CreateMap<Tenant, TenantListDto>();
            configuration.CreateMap<TenantEditDto, Tenant>().ReverseMap();
            configuration.CreateMap<CurrentTenantInfoDto, Tenant>().ReverseMap();

            //User
            configuration.CreateMap<User, UserEditDto>()
                .ForMember(dto => dto.Password, options => options.Ignore())
                .ReverseMap()
                .ForMember(user => user.Password, options => options.Ignore());
            configuration.CreateMap<User, UserLoginInfoDto>();
            configuration.CreateMap<User, UserListDto>();
            configuration.CreateMap<User, ChatUserDto>();
            configuration.CreateMap<User, OrganizationUnitUserListDto>();
            configuration.CreateMap<Role, OrganizationUnitRoleListDto>();
            configuration.CreateMap<CurrentUserProfileEditDto, User>().ReverseMap();
            configuration.CreateMap<UserLoginAttemptDto, UserLoginAttempt>().ReverseMap();
            configuration.CreateMap<ImportUserDto, User>();

            //AuditLog
            configuration.CreateMap<AuditLog, AuditLogListDto>();
            configuration.CreateMap<EntityChange, EntityChangeListDto>();
            configuration.CreateMap<EntityPropertyChange, EntityPropertyChangeDto>();

            //Friendship
            configuration.CreateMap<Friendship, FriendDto>();
            configuration.CreateMap<FriendCacheItem, FriendDto>();

            //OrganizationUnit
            configuration.CreateMap<OrganizationUnit, OrganizationUnitDto>();

            //Webhooks
            configuration.CreateMap<WebhookSubscription, GetAllSubscriptionsOutput>();
            configuration.CreateMap<WebhookSendAttempt, GetAllSendAttemptsOutput>()
                .ForMember(webhookSendAttemptListDto => webhookSendAttemptListDto.WebhookName,
                    options => options.MapFrom(l => l.WebhookEvent.WebhookName))
                .ForMember(webhookSendAttemptListDto => webhookSendAttemptListDto.Data,
                    options => options.MapFrom(l => l.WebhookEvent.Data));

            configuration.CreateMap<WebhookSendAttempt, GetAllSendAttemptsOfWebhookEventOutput>();

            configuration.CreateMap<DynamicProperty, DynamicPropertyDto>().ReverseMap();
            configuration.CreateMap<DynamicPropertyValue, DynamicPropertyValueDto>().ReverseMap();
            configuration.CreateMap<DynamicEntityProperty, DynamicEntityPropertyDto>()
                .ForMember(dto => dto.DynamicPropertyName,
                    options => options.MapFrom(entity => entity.DynamicProperty.PropertyName));
            configuration.CreateMap<DynamicEntityPropertyDto, DynamicEntityProperty>();

            configuration.CreateMap<DynamicEntityPropertyValue, DynamicEntityPropertyValueDto>().ReverseMap();

            //User Delegations
            configuration.CreateMap<CreateUserDelegationDto, UserDelegation>();

            /* ADD YOUR OWN CUSTOM AUTOMAPPER MAPPINGS HERE */
        }
    }
}