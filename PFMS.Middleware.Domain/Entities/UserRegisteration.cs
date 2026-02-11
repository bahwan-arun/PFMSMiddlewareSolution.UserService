
namespace PFMS.Middleware.Domain.Entities
{
    public class UserRegisteration
    {
        
        //public string? UserType { get; set; }
        public string? UserTypeId { get; set; }
        public string? Email { get; set; }
        public string? PdCode { get; set; }
        public DateOnly? FromDate { get; set; }
        public DateOnly? ToDate { get; set;}
        public string? CreatedBy { get; set; }

    }
}
