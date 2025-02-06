using LibraryManagementSystem.DTO;

namespace LibraryManagementSystem.Service.Interfaces
{
    public interface IMemberService
    {
        Task Add(MemberDto member);
        Task<MemberDto> GetById(int member_id);
        Task Update(int id, MemberDto member);
        Task Delete(int member_id);
    }
}
