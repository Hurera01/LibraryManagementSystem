using LibraryManagementSystem.Data;
using LibraryManagementSystem.DTO;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Repository.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Repository.Implemention
{
    public class MemberRepository : IMemberRepository
    {
        protected readonly ApplicationDbContext _context;
        public MemberRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Add(MemberDto member)
        {
            string storedProcedure = "EXEC CreateMember @p_first_name,@p_last_name,@p_email ,@p_phone_number,@p_membership_date,@StatusCode OUTPUT, @Message OUTPUT";

            var firstNameParam = new SqlParameter("@p_first_name", member.first_name);
            var lastNameParam = new SqlParameter("@p_last_name", member.last_name);
            var emailParam = new SqlParameter("@p_email", member.email);
            var phoneParam = new SqlParameter("@p_phone_number", member.phone_number);
            var membershipDateParam = new SqlParameter("@p_membership_date", member.membership_date);

            var statusCodeParam = new SqlParameter("@StatusCode", System.Data.SqlDbType.Int) { Direction = System.Data.ParameterDirection.Output };
            var messageParam = new SqlParameter("@Message", System.Data.SqlDbType.NVarChar, 255) { Direction = System.Data.ParameterDirection.Output };

            await _context.Database.ExecuteSqlRawAsync(storedProcedure, firstNameParam, lastNameParam, emailParam, phoneParam, membershipDateParam, statusCodeParam, messageParam);

            Members obj_Member = new Members { first_name = member.first_name, last_name = member.last_name, email = member.email, phone_number = member.phone_number, membership_date = member.membership_date };
            _context.Members.Add(obj_Member);
            var statusCode = statusCodeParam.Value;
            var message = messageParam.Value;

            if ((int)statusCode != 0)
            {
                throw new Exception($"Error Creating Loan: {message}");
            }
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }


        public Task Update(int id, MemberDto member)
        {
            throw new NotImplementedException();
        }

        public Task<MemberDto> GetById(int member_id)
        {
            throw new NotImplementedException();
        }
    }
}
