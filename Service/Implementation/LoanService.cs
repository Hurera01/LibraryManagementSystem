using LibraryManagementSystem.DTO;
using LibraryManagementSystem.Repository.Interfaces;
using LibraryManagementSystem.Service.Interfaces;

namespace LibraryManagementSystem.Service.Implementation
{
    public class LoanService : ILoanService
    {
        private readonly ILoanRepository _loanRepository;

        public LoanService(ILoanRepository loanRepository)
        {
            _loanRepository = loanRepository;
        }

        public async Task Add(LoanDto loan)
        {
            await _loanRepository.Add(loan);
        }

        public Task Delete(int loan_id)
        {
            throw new NotImplementedException();
        }

        public Task<LoanDto> GetById(int loan_id)
        {
            throw new NotImplementedException();
        }

        public Task Update(int id, LoanDto loan)
        {
            throw new NotImplementedException();
        }
    }
}
