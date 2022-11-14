namespace WebApi.RequestModel
{
    public class StudentUpdateRequest
    {
        public int Id { get; set; }

        public string? Studentname { get; set; }

        public int? Mobilenumber { get; set; }

        public string? Companyname { get; set; }
    }
}
