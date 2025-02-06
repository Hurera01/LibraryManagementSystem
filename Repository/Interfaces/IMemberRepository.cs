using LibraryManagementSystem.DTO;

namespace LibraryManagementSystem.Repository.Interfaces
{
    public interface IMemberRepository
    {
        Task Add(MemberDto member);
        Task<MemberDto> GetById(int member_id);
        Task Update(int id, MemberDto member);
        Task Delete(int member_id);
    }
}
