using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataAccessServices.Services;
using DomainModel.DTO.Chat;
using DomainModel.Models.Context;
using Microsoft.Extensions.Logging;

namespace DataAccess.Repositories
{
    internal class ChatRepository: IChatRepository
    {
        private readonly ILogger logger;
        private readonly ShikaShopContext db;
        private readonly IMapper mapper;

        public ChatRepository(ILogger logger, ShikaShopContext db, IMapper mapper)
        {
            this.logger = logger;
            this.db = db;
            this.mapper = mapper;
        }
        public Task<ViewChat> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int?> Create(CreateChat model)
        {
            throw new NotImplementedException();
        }
    }
}
