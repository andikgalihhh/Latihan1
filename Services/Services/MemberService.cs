using DataAccess.Models;
using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class MemberService
    {
        public readonly static MemberService Instance = new MemberService();
        private readonly UserRepository userRepository = UserRepository.Instance;

        static MemberService() { }

        public void AddNewMember(string username, string password)
        {
            var newMember = new Member()
            {
                Username = username,
                Password = password
            };

            userRepository.Save(newMember);
        }

        public void UpdateMember(string username, string newpassword)
        {
            var userToUpdate = userRepository.GetByUsername(username);
            if (userToUpdate != null)
            {
                userToUpdate.Password = newpassword;
                userRepository.Update(userToUpdate);
            }
            else
            {
                throw new Exception("Member not found");
            }
        }
            public void DisableMember(string username)
        {
            var userToDisable = userRepository.GetByUsername(username);

            if (userToDisable is null || userToDisable is not Member)
                return;

            var user = (Member)userToDisable;
            user.IsDisabled = true;
            userRepository.Save(user);
        }
    }
}
