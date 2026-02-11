namespace PFMS.Middleware.Application.DTO;
public record RegisterUserRequest
(
    //string? UserType,
    string? UserTypeId,
    string? Email,
    string? PdCode,
    DateOnly? FromDate,
    DateOnly? ToDate,
    string? CreatedBy
 );
    


