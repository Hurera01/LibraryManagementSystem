using LibraryManagementSystem.DTO;

namespace LibraryManagementSystem.Service.Interfaces
{
    public interface ILoanService
    {
        Task Add(LoanDto loan);
        Task<LoanDto> GetById(int loan_id);
        Task Update(int id, LoanDto loan);
        Task Delete(int loan_id);
    }
}
