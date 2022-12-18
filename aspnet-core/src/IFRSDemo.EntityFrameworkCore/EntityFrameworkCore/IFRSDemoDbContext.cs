using IFRSDemo.Cooperate;
using IFRSDemo.LogisticRegression;
using IFRSDemo.Regression;
using Abp.IdentityServer4;
using Abp.Organizations;
using Abp.Zero.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using IFRSDemo.Authorization.Delegation;
using IFRSDemo.Authorization.Roles;
using IFRSDemo.Authorization.Users;
using IFRSDemo.Chat;
using IFRSDemo.Editions;
using IFRSDemo.Friendships;
using IFRSDemo.MultiTenancy;
using IFRSDemo.MultiTenancy.Accounting;
using IFRSDemo.MultiTenancy.Payments;
using IFRSDemo.Storage;
using IFRSDemo.IfrsLoan;
using IFRSDemo.SMELending;
using IFRSDemo.UserLoanRequest;
using IFRSDemo.AllLoanrequest;
using IFRSDemo.SetUp;
using IFRSDemo.ManualUpload;
using IFRSDemo.Curves;
using IFRSDemo.ScoreCard;
using IFRSDemo.QualitativeAnalysis;
using IFRSDemo.DigitalLending;
using IFRSDemo.Caliberation;
using System.Linq;
using IFRSDemo.DemoAttribute;

namespace IFRSDemo.EntityFrameworkCore
{
    public class IFRSDemoDbContext : AbpZeroDbContext<Tenant, Role, User, IFRSDemoDbContext>, IAbpPersistedGrantDbContext
    {
        public virtual DbSet<CooperateCustomer> Tbl_CooperateCustomer { get; set; }
        public virtual DbSet<CooperateScore> Tbl_CooperateScore { get; set; }
        public virtual DbSet<CooperateAppraisal> CooperateAppraisals { get; set; }
        public virtual DbSet<CooperateCutOff> Tbl_CooperateCutOff { get; set; }

        public virtual DbSet<SetupQualitative> SetupQualitatives { get; set; }

        public virtual DbSet<SetupSubHeading> SetupSubHeadings { get; set; }

        public virtual DbSet<SubHeadingSetup> SubHeadingSetups { get; set; }

        public virtual DbSet<QualitativeSetup> QualitativeSetups { get; set; }

        public virtual DbSet<SubSectorSetup> SubSectorSetups { get; set; }

        public virtual DbSet<SectionSetup> SectionSetups { get; set; }

        public virtual DbSet<LogisticRegressionInput> LogisticRegressionInputs { get; set; }

        public virtual DbSet<RegressionOutput> RegressionOutputs { get; set; }

        /* Define an IDbSet for each entity of the application */

        public virtual DbSet<Histogram> Histograms { get; set; }
        public virtual DbSet<Component> Components { get; set; }
        public virtual DbSet<ScoringInputData> ScoringInputDatas { get; set; }
        public virtual DbSet<ScoringOutput> ScoringOutputs { get; set; }
        //Application Scoring Related
        public virtual DbSet<AgeAttribute> AgeAttributes { get; set; }
        public virtual DbSet<RatingPredictionOutput> RatingPredictionOutputs { get; set; }
        public virtual DbSet<ScoreCDFTable> ScoreCDFTables { get; set; }
        public virtual DbSet<IVTable> IVTables { get; set; }
        public virtual DbSet<AllScore> AllScores { get; set; }
        public virtual DbSet<InputData> DataInput { get; set; }
        public virtual DbSet<ProductTypeAttribute> ProductTypeAttributes { get; set; }
        public virtual DbSet<ApplicationScoring> ApplicationScorings { get; set; }

        public virtual DbSet<IncomeAttribute> IncomeAttributes { get; set; }

        public virtual DbSet<LocationAttribute> LocationAttributes { get; set; }

        public virtual DbSet<RentAttribute> RentAttributes { get; set; }

        public virtual DbSet<RenttoIncomeAttribute> RenttoIncomeAttributes { get; set; }

        public virtual DbSet<ReturnonAssetsAttribute> ReturnonAssetsAttributes { get; set; }
        public virtual DbSet<SubSectorAttribute> SectorSubSectorAttributes { get; set; }
        public virtual DbSet<AccountBalData> AccountBalDatas { get; set; }
        public virtual DbSet<DebtServiceRatio> DebtServiceRatios { get; set; }
        public virtual DbSet<AppAttribute> AppAttributes { get; set; }
        public virtual DbSet<ApplicantAttribute> ApplicantAttributes { get; set; }

        public virtual DbSet<PreProcessing> PreProcessings { get; set; }
        public virtual DbSet<Operation> Operations { get; set; }
        public virtual DbSet<InputDataValueCollector> InputDataValueCollectors { get; set; }
        //SMELending
        public virtual DbSet<SMELendingApply> SMELendingApplys { get; set; }
        public virtual DbSet<LoanType> LoanTypes { get; set; }
        public virtual DbSet<Bank> Banks { get; set; }
        public virtual DbSet<GenderType> GenderTypes { get; set; }
        public virtual DbSet<SMETitle> SMETitles { get; set; }

        public virtual DbSet<HaveBankAccount> HaveBankAccounts { get; set; }
        public virtual DbSet<HaveNIN> HaveNINs { get; set; }
        public virtual DbSet<Operation_Eligibility> Operation_Eligibilitys { get; set; }
        public virtual DbSet<BusRegNig> BusRegNigs { get; set; }
        public virtual DbSet<AccountAuthorize> AccountAuthorizes { get; set; }
        public virtual DbSet<LoanElibility> LoanElibilities { get; set; }

        public virtual DbSet<ULoanRequest> ULoanRequests { get; set; }

        public virtual DbSet<LoanRequest> LoanRequests { get; set; }

        public virtual DbSet<FinancialRatio> FinancialRatios { get; set; }
        public virtual DbSet<SetUpItem> SetUpItems { get; set; }
        public virtual DbSet<Method> Methods { get; set; }
        public virtual DbSet<LogRegression> LogRegressions { get; set; }

        public virtual DbSet<SplittingMethod> SplittingMethods { get; set; }

        public virtual DbSet<Tbl_ScoringData> Tbl_ScoringDatas { get; set; }
        public virtual DbSet<GoodBad> GoodBads { get; set; }
        public virtual DbSet<KSTestCurve> kSTestCurves { get; set; }
        public virtual DbSet<GiniCurve> GiniCurves { get; set; }
        public virtual DbSet<ROCCurve> ROCCurves { get; set; }
        public virtual DbSet<RegOutput> RegOutputs { get; set; }
        public virtual DbSet<TblWoe_Age> TblWoe_Ages { get; set; }
        public virtual DbSet<TblWoe_TimeatJob> TblWoe_TimeatJobs { get; set; }
        public virtual DbSet<TblWoe_PaymentPerformance> TblWoe_PaymentPerformances { get; set; }
        public virtual DbSet<Tbl_Psi> Tbl_Psis { get; set; }

        public virtual DbSet<Output_Table> Output_Tables { get; set; }

        public virtual DbSet<DescriptiveStatistics> DescriptiveStatisticss { get; set; }
        public virtual DbSet<CreditScore_FeatureSelection> CreditScore_FeatureSelections { get; set; }
        public virtual DbSet<Tbl_GoodBadInput> Tbl_GoodBadInputs { get; set; }
        public virtual DbSet<AgeDistribution> AgDistributions { get; set; }
        public virtual DbSet<CharacteristicsAnalysis> GetCharacteristicsAnalyses { get; set; }
        public virtual DbSet<CurrentAccDist> CurrentAccDists { get; set; }
        public virtual DbSet<ProfitAnalysis> ProfitAnalysis { get; set; }
        public virtual DbSet<Scaling> Scalings { get; set; }
        public virtual DbSet<ScoreCardReport> ScoreCardReports { get; set; }
        public virtual DbSet<StabiltyTrend> StabiltyTrends { get; set; }
        public virtual DbSet<RegOutputRunData> RegOutputRunDatas { get; set; }

        public virtual DbSet<ScoreReport> ScoreReports { get; set; }
        public virtual DbSet<LogisticRegressionOutput> LogisticRegressionOutputs { get; set; }
        public virtual DbSet<ScoreCardScaling> ScoreCardScalings { get; set; }
        public virtual DbSet<CreditScoreWOE> CreditScoreWOEs { get; set; }
        public virtual DbSet<LogisticRegEquation> LogisticRegEquations { get; set; }

        public virtual DbSet<CreditScore_PointAllocation> CreditScore_PointAllocations { get; set; }
        public virtual DbSet<Tbl_GoodBadInputRaw> Tbl_GoodBadInputRaws { get; set; }
        public virtual DbSet<collectAttribute> collectAttributes { get; set; }
        public virtual DbSet<TblCutOff> TblCuttOffs { get; set; }
        public virtual DbSet<Viewbincountpercentage> Viewbincountpercentages { get; set; }
        //QA
        public virtual DbSet<AttributeItem> AttributeItems { get; set; }
        public virtual DbSet<Cutoff> Tbl_QualityAnalysisCutOff { get; set; }
        public virtual DbSet<Tbl_QualitativeAnalysis> Tbl_QualityAnalysis { get; set; }

        //Retail

        public virtual DbSet<RetailScoring> Tbl_RetailScorings { get; set; }
        public virtual DbSet<RetailAttrItem> RetailAttrItems { get; set; }
        public virtual DbSet<RetailCutoff> Tbl_RetailCutoff { get; set; }

        //RiskRating
        public virtual DbSet<SCMonitoring> SCMonitorings { get; set; }
        public virtual DbSet<BinRange> Tbl_BinRanges { get; set; }
        public virtual DbSet<QARating> Tbl_QARatings { get; set; }
        public virtual DbSet<RatingAttribute> Tbl_RatingAttributes { get; set; }
        public virtual DbSet<RiskRating> RiskRatings { get; set; }
        public virtual DbSet<RiskRatingItem> Tbl_RiskRatingItems { get; set; }
        public virtual DbSet<CreateProfit_Analysis> Profit_Analysis { get; set; }
        public virtual DbSet<tbl_score> tbl_score { get; set; }
        public virtual DbSet<PositionInIdustry> Tbl_PositionInIdustry { get; set; }
        public virtual DbSet<Ownership> Tbl_Ownership { get; set; }
        public virtual DbSet<ProductCont> Tbl_ProductCont { get; set; }
        public virtual DbSet<Legal> Tbl_Legal { get; set; }
        public virtual DbSet<Tbl_Rating> Tbl_Rating { get; set; }
        public virtual DbSet<Tbl_AttributeCount> Tbl_AttributeCount { get; set; }
        public virtual DbSet<IndividualApp> Tbl_IndividualApp { get; set; }
        public virtual DbSet<RiskAssessment> Tbl_RiskAssessment { get; set; }
        public virtual DbSet<BankAccount> Tbl_BankAccount { get; set; }
        public virtual DbSet<CreditLineCondition> Tbl_CreditLineCondition { get; set; }
        public virtual DbSet<LendingOutput> Tbl_LendingOutputs { get; set; }
        public virtual DbSet<TblScoreReport> Tbl_ScoreReports { get; set; }

        //Caliberation
        public virtual DbSet<GiniInclusive> Tbl_CAP { get; set; }
        public virtual DbSet<CalibrationC> Tbl_CalibrationCs { get; set; }
        public virtual DbSet<SetupPage> Tbl_SetupPage { get; set; }
        public virtual DbSet<VintageAnalysis> Tbl_VintageAnalysis { get; set; }
        public virtual DbSet<DigSetUp> Tbl_DigSetUp { get; set; }
        //DigitalLending
        public virtual DbSet<Tbl_Severity> Tbl_Severity { get; set; }

        public virtual DbSet<DemoRetailAttrItem> Tbl_DemoRetailAttrItem { get; set; }
        public virtual DbSet<SubRetailAttrItem> Tbl_SubRetailAttrItem { get; set; }
        public virtual DbSet<RetailCustomer> Tbl_RetailCustomer { get; set; }
        public virtual DbSet<RetailScore> Tbl_RetailScore { get; set; }
        public virtual DbSet<DemoRetailCutOff> Tbl_DemoRetailCutOff { get; set; }
        public virtual DbSet<RetailCustomerDetail> Tbl_RetailCustomerDetail { get; set; }
        public virtual DbSet<PointAllocationByDetail> Tbl_PointAllocationByDetail { get; set; }
        public virtual DbSet<PointAllocationByScore> Tbl_PointAllocationByScore { get; set; }


        public virtual DbSet<BinaryObject> BinaryObjects { get; set; }
        public virtual DbSet<Friendship> Friendships { get; set; }
        public virtual DbSet<ChatMessage> ChatMessages { get; set; }
        public virtual DbSet<SubscribableEdition> SubscribableEditions { get; set; }
        public virtual DbSet<SubscriptionPayment> SubscriptionPayments { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<PersistedGrantEntity> PersistedGrants { get; set; }
        public virtual DbSet<SubscriptionPaymentExtensionData> SubscriptionPaymentExtensionDatas { get; set; }

        public virtual DbSet<UserDelegation> UserDelegations { get; set; }

        public IFRSDemoDbContext(DbContextOptions<IFRSDemoDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            foreach (var foreignkey in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                foreignkey.DeleteBehavior = DeleteBehavior.Restrict;
            }
            //

            modelBuilder.Entity<CooperateAppraisal>(c =>
                       {
                           c.HasIndex(e => new { e.TenantId });
                       });
            modelBuilder.Entity<SetupQualitative>(s =>
                       {
                           s.HasIndex(e => new { e.TenantId });

                       });
            modelBuilder.Entity<SetupSubHeading>(s =>
                       {
                           s.HasIndex(e => new { e.TenantId });
                       });
            modelBuilder.Entity<SubHeadingSetup>(s =>
                       {
                           s.HasIndex(e => new { e.TenantId });
                       });
            modelBuilder.Entity<QualitativeSetup>(q =>
                       {
                           q.HasIndex(e => new { e.TenantId });
                       });
            modelBuilder.Entity<SubSectorSetup>(s =>
                       {
                           s.HasIndex(e => new { e.TenantId });
                       });
            modelBuilder.Entity<SectionSetup>(s =>
                       {
                           s.HasIndex(e => new { e.TenantId });
                       });
            modelBuilder.Entity<LogisticRegressionInput>(l =>
                       {
                           l.HasIndex(e => new { e.TenantId });
                       });
            modelBuilder.Entity<RegressionOutput>(r =>
                       {
                           r.HasIndex(e => new { e.TenantId });
                       });
            modelBuilder.Entity<InputDataValueCollector>();
            //.Property<string>("_inputValues");
            // .HasField("InputValues");

            //modelBuilder.Entity<InputData>().
            //    HasNoKey();
            //modelBuilder.Entity<tbl_score>().
            //    HasNoKey();
            modelBuilder.Entity<BinaryObject>(b =>
            {
                b.HasIndex(e => new { e.TenantId });
            });

            modelBuilder.Entity<ChatMessage>(b =>
            {
                b.HasIndex(e => new { e.TenantId, e.UserId, e.ReadState });
                b.HasIndex(e => new { e.TenantId, e.TargetUserId, e.ReadState });
                b.HasIndex(e => new { e.TargetTenantId, e.TargetUserId, e.ReadState });
                b.HasIndex(e => new { e.TargetTenantId, e.UserId, e.ReadState });
            });

            modelBuilder.Entity<Friendship>(b =>
            {
                b.HasIndex(e => new { e.TenantId, e.UserId });
                b.HasIndex(e => new { e.TenantId, e.FriendUserId });
                b.HasIndex(e => new { e.FriendTenantId, e.UserId });
                b.HasIndex(e => new { e.FriendTenantId, e.FriendUserId });
            });

            modelBuilder.Entity<Tenant>(b =>
            {
                b.HasIndex(e => new { e.SubscriptionEndDateUtc });
                b.HasIndex(e => new { e.CreationTime });
            });

            modelBuilder.Entity<SubscriptionPayment>(b =>
            {
                b.HasIndex(e => new { e.Status, e.CreationTime });
                b.HasIndex(e => new { PaymentId = e.ExternalPaymentId, e.Gateway });
            });

            modelBuilder.Entity<SubscriptionPaymentExtensionData>(b =>
            {
                b.HasQueryFilter(m => !m.IsDeleted)
                    .HasIndex(e => new { e.SubscriptionPaymentId, e.Key, e.IsDeleted })
                    .IsUnique();
            });

            modelBuilder.Entity<UserDelegation>(b =>
            {
                b.HasIndex(e => new { e.TenantId, e.SourceUserId });
                b.HasIndex(e => new { e.TenantId, e.TargetUserId });
            });

            modelBuilder.ConfigurePersistedGrantEntity();
        }
    }
}