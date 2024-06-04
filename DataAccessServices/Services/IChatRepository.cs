using DomainModel.DTO.ChatRoom;
using DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.DTO.Chat;

namespace DataAccessServices.Services
{
    public interface IChatRepository
    {
        Task<ViewChat> GetById(int id);
        Task<int?> Create(CreateChat model);    
    }
}
