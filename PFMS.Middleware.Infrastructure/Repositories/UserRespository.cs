using Dapper;
using Npgsql;
using PFMS.Middleware.Application.DTO;
using PFMS.Middleware.Application.RepositoryContracts;
using PFMS.Middleware.Domain.Entities;
using PFMS.Middleware.Infrastructure.DBContext;
using System.Data;

namespace PFMS.Middleware.Infrastructure.Repositories
{
    public class UserRespository : IUsersRepository
    {
        private readonly DapperDbContext _dbContext;

        public UserRespository(DapperDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<RegisteredUser?> AddUser(UserRegisteration registerRequest)
        {          
            var parameters = new DynamicParameters();
            //parameters.Add("p_user_type", registerRequest.UserType);
            parameters.Add("p_user_type_id", registerRequest.UserTypeId);
            parameters.Add("p_email", registerRequest.Email);
            parameters.Add("p_pd_code", registerRequest.PdCode);              
            parameters.Add("p_from_date", ToTimestamp(registerRequest.FromDate));
            parameters.Add("p_to_date", ToTimestamp(registerRequest.ToDate));
            parameters.Add("p_created_by", registerRequest.CreatedBy);
            parameters.Add("p_rows_inserted", dbType: DbType.Int32, direction: ParameterDirection.InputOutput, value: 0);

            var sql = "CALL pfms_usp_Register_user(@p_user_type_id,@p_email, @p_pd_code, @p_from_date, @p_to_date,@p_created_by,@p_rows_inserted)";
            int rowCountAffected = await _dbContext.DbConnection.ExecuteAsync(sql,parameters);
            int actualRows = parameters.Get<int>("p_rows_inserted");         

            if (actualRows > 0)
            {
                RegisteredUser user = new RegisteredUser();
                user.Message = "User Inserted SuccssFully";
                user.Success = true;
                return user;
            }
            else
            {
                RegisteredUser user = new RegisteredUser();
                user.Message = "SomeThing Went Wrong!!";
                user.Success = false;
                return user;
            }
        }    
        public async Task<PfmsUser?> GetUserInfoBYUserID(int? id)
        {
            //SQL query to select a record
            string query = "SELECT * FROM public.\"PfmsUsers\" WHERE \"Id\"=@id";
            var parameters = new { Id = id };
            PfmsUser? user = await _dbContext.DbConnection.QueryFirstOrDefaultAsync<PfmsUser>(query, parameters);
            return user;
        }

        // Helper method to ensure the correct DateTimeKind for PostgreSQL
        public DateTime? ToTimestamp(DateOnly? date)
        {
            if (!date.HasValue) return null;
            // Get current time
            DateTime now = DateTime.Now;
            // Create a DateTime with Kind = Unspecified (required for 'timestamp without time zone')
            return new DateTime(date.Value.Year, date.Value.Month, date.Value.Day, now.Hour, now.Minute, now.Second, DateTimeKind.Unspecified);
        }
    }
}
