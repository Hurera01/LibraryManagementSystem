using LibraryManagementSystem.Data;
using LibraryManagementSystem.DTO;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Repository.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Repository.Implemention
{
    public class LoanRepository : ILoanRepository
    {
        protected readonly ApplicationDbContext _context;

        public LoanRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Add(LoanDto loan)
        {
            string storedProcedure = $"EXEC CreateLoan @p_book_id, @p_member_id , @p_loan_date ,@p_due_date ,@p_return_date,@StatusCode ,@Message";

            var bookIdParam = new SqlParameter("@p_book_id", loan.book_id);
            var memberIdParam = new SqlParameter("@p_member_id", loan.member_id);
            var loanDateParam = new SqlParameter("@p_loan_date", loan.loan_date);
            var dueDateParam = new SqlParameter("@p_due_date", loan.due_date);
            var returnDateParam = new SqlParameter("@p_return_date", loan.return_date);

            var statusCodeParam = new SqlParameter("@StatusCode", System.Data.SqlDbType.Int) { Direction = System.Data.ParameterDirection.Output };
            var messageParam = new SqlParameter("@Message", System.Data.SqlDbType.NVarChar, 255) { Direction = System.Data.ParameterDirection.Output };

            await _context.Database.ExecuteSqlRawAsync(storedProcedure, bookIdParam, memberIdParam, loanDateParam, dueDateParam, returnDateParam, statusCodeParam, messageParam);
            Loans obj_loan = new Loans { book_id = loan.book_id, member_id = loan.member_id, loan_date = loan.loan_date, due_date = loan.due_date, return_date = loan.return_date };
            _context.Loans.Add(obj_loan);
            var statusCode = statusCodeParam.Value;
            var message = messageParam.Value;

            if ((int)statusCode != 0)
            {
                throw new Exception($"Error creating Loan: {message}");
            }
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }


        public Task Update(int id, LoanDto book)
        {
            throw new NotImplementedException();
        }

        public Task<LoanDto> GetById(int loan_id)
        {
            throw new NotImplementedException();
        }
    }
}
