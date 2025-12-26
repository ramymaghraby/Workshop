using LMS.BLL.Model;
using LMS.BLL.Repository;
using LMS.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace LMS.BLL.Service
{
    public class MemberService : IMemberService
    {
        GenericRepository<Member> _memberRepository;
        public MemberService()
        {
            _memberRepository = new GenericRepository<Member>();
        }
        public async Task<bool> RegisterMemberAsync(MemberDTO memberDTO)
        {
            
            var result = await _memberRepository.CreateAsync(new Member
            {
                Name = memberDTO.Name,
                Email = memberDTO.Email,
                Phone = memberDTO.Phone,
            });
            
            return true;
        }
        public async Task<bool> DeactivateMemberAsync(MemberDTO memberDTO)
        {
            var member = await _memberRepository.GetByAsync(m => m.Id == memberDTO.Id);
            member.IsActive = false;
            await _memberRepository.UpdateAsync(member);
            return true;
        }
        public async Task<bool> UnregisterMemberAsync(MemberDTO memberDTO)
        {
            var member = await _memberRepository.GetByAsync(m => m.Id == memberDTO.Id);
            member.IsActive = false;
            await _memberRepository.UpdateAsync(member);
            return true;
        }

    }

    public interface IMemberService
    {
        public Task<bool> RegisterMemberAsync(MemberDTO memberDTO);
        public Task<bool> DeactivateMemberAsync(MemberDTO memberDTO);
        public Task<bool> UnregisterMemberAsync(MemberDTO memberDTO);

    }
}
