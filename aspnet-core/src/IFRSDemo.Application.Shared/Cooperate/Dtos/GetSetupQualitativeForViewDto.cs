namespace IFRSDemo.Cooperate.Dtos
{
    public class GetSetupQualitativeForViewDto
    {
        public SetupQualitativeDto SetupQualitative { get; set; }

        public string SectionSetupSection { get; set; }

        public string SetupSubHeadingSubHeading { get; set; }

    }
    public class ApiResponseDto
    {
        public int Status { get; set; }
        public string Message { get; set; }
    }
    public class CreateCooperateScoreDto
    {
        public int CompanyId { get; set; }
        public double Score { get; set; }
    }

    public class GetCooperateScoreForEditOutput
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public double Score { get; set; }
    }

    public class GetCooperateScoreForEditInput {
        public int Id { get; set; }
    }
    public class EditCooperateScoreInput
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public double Score { get; set; }
    }
}
