using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataAccessServices.Services;
using DomainModel.DTO.Chat;
using DomainModel.DTO.ChatRoom;
using DomainModel.DTO.User;
using DomainModel.Models;
using DomainModel.Models.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DataAccess.Repositories
{
    public class ChatRoomRepository: IChatRoomRepository
    {
        private readonly ILogger logger;
        private readonly ShikaShopContext db;
        private readonly IMapper mapper;

        public ChatRoomRepository(ILogger logger, ShikaShopContext db, IMapper mapper)
        {
            this.logger = logger;
            this.db = db;
            this.mapper = mapper;
        }
        public async Task<List<ViewChatRoom>> GetAllByRole(User user)
        {
            List<ViewChatRoom> model = new List<ViewChatRoom>();
            try
            {
                var entity = await db.ChatRoom.Where(x => !x.IsDelete).Include(x => x.sendingUser)
                    .Include(x => x.recaivingUser).Include(x => x.chats).ToListAsync();
                if ( user.RoleId==3)
                {
                    entity = entity.Where(x => x.SendUserId == user.UserId).ToList();
                }

                foreach (var item in entity)
                {
                    ViewChatRoom chatroom = new ViewChatRoom();
                    chatroom = mapper.Map<ViewChatRoom>(item);
                    chatroom.SendingUser = mapper.Map<UserInfo>(item.sendingUser);
                    if (chatroom.SendingUser!=null)
                    {
                        if (user.RoleId == 1)
                        {
                            chatroom.SendingUser.RoleId = 1;
                            chatroom.SendingUser.RoleName = " مدیر ";
                        }
                        else if (user.RoleId == 2)
                        {
                            chatroom.SendingUser.RoleId = 2;
                            chatroom.SendingUser.RoleName = " کارمند ";
                        }
                        else if (user.RoleId == 3)
                        {
                            chatroom.SendingUser.RoleId = 3;
                            chatroom.SendingUser.RoleName = " مشتری ";
                        }

                    }
                    chatroom.ReceivingUser= mapper.Map<UserInfo>(item.recaivingUser);
                    if (chatroom.ReceivingUser != null)
                    {
                        if (user.RoleId == 1)
                        {
                            chatroom.ReceivingUser.RoleId = 1;
                            chatroom.ReceivingUser.RoleName = " مدیر ";
                        }
                        else if (user.RoleId == 2)
                        {
                            chatroom.ReceivingUser.RoleId = 2;
                            chatroom.ReceivingUser.RoleName = " کارمند ";
                        }
                        else if (user.RoleId == 3)
                        {   
                            chatroom.ReceivingUser.RoleId = 3;
                            chatroom.ReceivingUser.RoleName = " مشتری ";
                        }

                    }

                    List<ViewChat> listChats = new List<ViewChat>();
                    foreach (var itemchat in item.chats.Where(x=>!x.IsDelete).OrderByDescending(x=>x.ChatId))
                    {
                        ViewChat chat = new ViewChat();
                        chat = mapper.Map<ViewChat>(itemchat);
                        chat.CreationDatestring = itemchat.CreationDate.ToString();
                        chat.User = mapper.Map<UserInfo>(itemchat.User);
                        if (chat.User != null)
                        {
                            if (user.RoleId == 1)
                            {
                                chat.User.RoleId = 1;
                                chat.User.RoleName = " مدیر ";
                            }
                            else if (user.RoleId == 2)
                            {
                                chat.User.RoleId = 2;
                                chat.User.RoleName = " کارمند ";
                            }
                            else if (user.RoleId == 3)
                            {
                                chat.User.RoleId = 3;
                                chat.User.RoleName = " مشتری ";
                            }

                        }
                        listChats.Add(chat);
                    }
                    chatroom.OldChat=listChats;
                    model.Add(chatroom);
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex," ارور در ریپوزیتوری ");
            }
            return model;
        }

        public async Task<ViewChatRoom> GetById(int id)
        {
            ViewChatRoom model = new ViewChatRoom();
            try
            {
                var entity = await db.ChatRoom.Where(x => !x.IsDelete && x.ChatRoomId==id)
                    .Include(x => x.sendingUser)
                    .Include(x => x.recaivingUser).Include(x => x.chats).SingleOrDefaultAsync();
                
                model = mapper.Map<ViewChatRoom>(entity);
                model.SendingUser = mapper.Map<UserInfo>(entity.sendingUser);
                if (model.SendingUser != null)
                {
                    if (id == 1)
                    {
                        model.SendingUser.RoleId = 1;
                        model.SendingUser.RoleName = " مدیر ";
                    }
                    else if (id == 2)
                    {
                        model.SendingUser.RoleId = 2;
                        model.SendingUser.RoleName = " کارمند ";
                    }
                    else if (id == 3)
                    {
                        model.SendingUser.RoleId = 3;
                        model.SendingUser.RoleName = " مشتری ";
                    }

                }
                model.ReceivingUser = mapper.Map<UserInfo>(entity.recaivingUser);
                if (model.ReceivingUser != null)
                {
                    if (id == 1)
                    {
                        model.ReceivingUser.RoleId = 1;
                        model.ReceivingUser.RoleName = " مدیر ";
                    }
                    else if (id == 2)
                    {
                        model.ReceivingUser.RoleId = 2;
                        model.ReceivingUser.RoleName = " کارمند ";
                    }
                    else if (id == 3)
                    {
                        model.ReceivingUser.RoleId = 3;
                        model.ReceivingUser.RoleName = " مشتری ";
                    }

                }

                List<ViewChat> listChats = new List<ViewChat>();
                foreach (var item in entity.chats.Where(x => !x.IsDelete).OrderByDescending(x => x.ChatId))
                {
                    ViewChat chat = new ViewChat();
                    chat = mapper.Map<ViewChat>(item);
                    chat.CreationDatestring = item.CreationDate.ToString();
                    chat.User = mapper.Map<UserInfo>(item.User);
                    if (chat.User != null)
                    {
                        if (item.User.RoleId == 1)
                        {
                            chat.User.RoleId = 1;
                            chat.User.RoleName = " مدیر ";
                        }
                        else if (item.User.RoleId == 2)
                        {
                            chat.User.RoleId = 2;
                            chat.User.RoleName = " کارمند ";
                        }
                        else if (item.User.RoleId == 3)
                        {
                            chat.User.RoleId = 3;
                            chat.User.RoleName = " مشتری ";
                        }

                    }
                    listChats.Add(chat);
                }
                model.OldChat = listChats;
                

            }
            catch (Exception ex)
            {
                logger.LogError(ex, " ارور در ریپوزیتوری ");
            }

            return model;
        }

        public async Task<ViewChatRoom> GetBySendingUserIdReceivingUserId(int sendingUserId, int receivingUserId)
        {
            ViewChatRoom model = new ViewChatRoom();
            try
            {
                var entity = await db.ChatRoom.Where(x => !x.IsDelete &&
                                                          x.SendUserId == sendingUserId &&
                                                          x.recaivingUserId== receivingUserId)
                    .Include(x => x.sendingUser)
                    .Include(x => x.recaivingUser).Include(x => x.chats).SingleOrDefaultAsync();

                model = mapper.Map<ViewChatRoom>(entity);
                model.SendingUser = mapper.Map<UserInfo>(entity.sendingUser);
                if (model.SendingUser != null)
                {
                    if (sendingUserId == 1)
                    {
                        model.SendingUser.RoleId = 1;
                        model.SendingUser.RoleName = " مدیر ";
                    }
                    else if (sendingUserId == 2)
                    {
                        model.SendingUser.RoleId = 2;
                        model.SendingUser.RoleName = " کارمند ";
                    }
                    else if (sendingUserId == 3)
                    {
                        model.SendingUser.RoleId = 3;
                        model.SendingUser.RoleName = " مشتری ";
                    }

                }
                model.ReceivingUser = mapper.Map<UserInfo>(entity.recaivingUser);
                if (model.ReceivingUser != null)
                {
                    if (receivingUserId == 1)
                    {
                        model.ReceivingUser.RoleId = 1;
                        model.ReceivingUser.RoleName = " مدیر ";
                    }
                    else if (receivingUserId == 2)
                    {
                        model.ReceivingUser.RoleId = 2;
                        model.ReceivingUser.RoleName = " کارمند ";
                    }
                    else if (sendingUserId == 3)
                    {
                        model.ReceivingUser.RoleId = 3;
                        model.ReceivingUser.RoleName = " مشتری ";
                    }

                }

                List<ViewChat> listChats = new List<ViewChat>();
                foreach (var item in entity.chats.Where(x => !x.IsDelete).OrderByDescending(x => x.ChatId))
                {
                    ViewChat chat = new ViewChat();
                    chat = mapper.Map<ViewChat>(item);
                    chat.CreationDatestring = item.CreationDate.ToString();
                    chat.User = mapper.Map<UserInfo>(item.User);
                    if (chat.User != null)
                    {
                        if (item.User.RoleId == 1)
                        {
                            chat.User.RoleId = 1;
                            chat.User.RoleName = " مدیر ";
                        }
                        else if (item.User.RoleId == 2)
                        {
                            chat.User.RoleId = 2;
                            chat.User.RoleName = " کارمند ";
                        }
                        else if (item.User.RoleId == 3)
                        {
                            chat.User.RoleId = 3;
                            chat.User.RoleName = " مشتری ";
                        }

                    }
                    listChats.Add(chat);
                }
                model.OldChat = listChats;


            }
            catch (Exception ex)
            {
                logger.LogError(ex, " ارور در ریپوزیتوری ");
            }

            return model;
        }

        public async Task<int> GetAllCountByRole(User user)
        {
            int counter = new int();
            try
            {
                if (user.RoleId!=1)
                {
                    counter = await db.ChatRoom
                        .Where(x => !x.IsDelete && x.SendUserId == user.UserId)
                        .CountAsync();
                }
                else
                {
                    counter = await db.ChatRoom
                        .Where(x => !x.IsDelete )
                        .CountAsync();
                }
                
            }
            catch (Exception ex)
            {
                logger.LogError(ex,"");
            }

            return counter;
        }

        public async Task<bool> existById(int id)
        {
            try
            {
                return await db.ChatRoom.AnyAsync(x => !x.IsDelete && x.ChatRoomId == id);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, " خطا در ریپوزیتوری ");
                return false;
            }
        }

        public async Task<bool> existByIdUserId(int id, int userId)
        {
            try
            {
                return await db.ChatRoom.AnyAsync(x => !x.IsDelete && x.ChatRoomId == id && x.SendUserId== userId);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, " خطا در ریپوزیتوری ");
                return false;
            }
        }

        public async Task<bool> existByIdSendingUserIdreceivingUserId(int sendingUserId, int receivingUserId)
        {
            try
            {
                return await db.ChatRoom.AnyAsync(x => !x.IsDelete && x.recaivingUserId == receivingUserId && x.SendUserId == sendingUserId);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, " خطا در ریپوزیتوری ");
                return false;
            }
        }

        public async Task<int?> Create(CreateChatRoom model)
        {
            ChatRoom entity = new ChatRoom();
            try
            {
                entity.SendUserId = model.SendingUserId;
                entity.recaivingUserId = model.ReceivingUserId;
                await db.AddAsync(entity);
                await db.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                logger.LogError(ex, " خطا در ریپوزیتوری ");
                return null;
            }

            return entity.ChatRoomId;
        }
    }
}
