using LibraryManagementSystem.DTO;
using LibraryManagementSystem.Repository.Interfaces;
using LibraryManagementSystem.Service.Interfaces;

namespace LibraryManagementSystem.Service.Implementation
{
    public class MemberService : IMemberService
    {
        private readonly IMemberRepository _memberRepository;
        public MemberService(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }
        public async Task Add(MemberDto member)
        {
            await _memberRepository.Add(member);
        }

        public Task Delete(int member_id)
        {
            throw new NotImplementedException();
        }

        public Task<MemberDto> GetById(int member_id)
        {
            throw new NotImplementedException();
        }

        public Task Update(int id, MemberDto member)
        {
            throw new NotImplementedException();
        }
    }
}
