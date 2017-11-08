using App.Shared;
using App.System.DTO;
using Portal.Domain.System;
using System;
using System.Linq;

namespace App.System
{
    public class SystemManager
    {
        private readonly IRepository<User> userRepository;
        private readonly SystemService systemService;

        public SystemManager(IRepository<User> userRepository, SystemService systemService)
        {
            this.userRepository = userRepository;
            this.systemService = systemService;
        }

        public void CreateUser(UserInsertionDto dto)
        {
            var user = systemService.CreateUser(dto.Email, dto.Password);

            userRepository.Create(user);
        }

        public void AssignUserToRole(RoleAssignmentDto dto)
        {
            var user = userRepository.GetById(dto.UserId);

            user.AddRoleEnrolment(dto.RoleId);

            userRepository.Update(user);
        }

        public bool CheckCredentials(string login, string password) =>
            userRepository.Find(u => string.Equals(u.Email, login, StringComparison.CurrentCultureIgnoreCase)
                && u.PasswordHash == systemService.HashPassword(password)).Count() > 0;
    }
}