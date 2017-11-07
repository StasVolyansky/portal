using App.Shared;
using App.System.DTO;
using Portal.Domain.System;

namespace App.System
{
    public class SystemManager
    {
        private readonly IRepository<User> repository;
        private readonly SystemService systemService;

        public SystemManager(IRepository<User> command, SystemService systemService)
        {
            this.repository = command;
            this.systemService = systemService;
        }

        public void CreateUser(UserInsertionDto dto)
        {
            var user = systemService.CreateUser(dto.Email, dto.Password);

            repository.Create(user);
        }

        public void AssignUserToRole(RoleAssignmentDto dto)
        {
            var user = repository.GetById(dto.UserId);

        }
    }
}