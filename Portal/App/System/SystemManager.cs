using App.Shared;
using App.System.DTO;
using Portal.Domain.System;
using Portal.Domain.System.Entities;

namespace App.System
{
    public class SystemManager
    {
        private readonly IWriteRepository<User> command;
        private readonly SystemService systemService;

        public SystemManager(IWriteRepository<User> command, SystemService systemService)
        {
            this.command = command;
            this.systemService = systemService;
        }

        public void CreateUser(UserInsertionDto dto)
        {
            var user = systemService.CreateUser(dto.Email, dto.Password);

            command.Create(user);
        }
    }
}