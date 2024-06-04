using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.DTO.ChatRoom;
using DomainModel.Models;

namespace DataAccessServices.Services
{
    public interface IChatRoomRepository
    {
        Task<List<ViewChatRoom>> GetAllByRole(User user);
        Task<ViewChatRoom> GetById(int id);
        Task<ViewChatRoom> GetBySendingUserIdReceivingUserId(int sendingUserId, int receivingUserId);
        Task<int> GetAllCountByRole(User user);
        Task<bool> existById(int id);
        Task<bool> existByIdUserId(int id, int userId);
        Task<bool> existByIdSendingUserIdreceivingUserId(int sendingUserId, int receivingUserId);
        Task<int?> Create(CreateChatRoom model);



    }
}
