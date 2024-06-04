using System.Collections.Generic;
using BusinessServices.Services;
using DataAccessServices.Services;
using DomainModel.Assist;
using DomainModel.DTO.GuestUserMessage;
using DomainModel.Models;

namespace Business.IMP
{
    public class GuestUserMessageBusiness:IGuestUserMessageBusiness
    {
        private readonly IGuestUserMessageRepository _guestUserMessageRepository;

        public GuestUserMessageBusiness(IGuestUserMessageRepository guestUserMessageRepository)
        {
            _guestUserMessageRepository = guestUserMessageRepository;
        }
        public OperationResult Add(GuestUserMessage model)
        {
            return _guestUserMessageRepository.Add(model);
        }

        public OperationResult Update(GuestUserMessage model)
        {
            return _guestUserMessageRepository.Update(model);
        }

        public OperationResult Delete(int id)
        {
            return _guestUserMessageRepository.Delete(id);
        }

        public GuestUserMessage Get(int id)
        {
            return _guestUserMessageRepository.Get(id);
        }

        public List<GuestUserMessage> GetAll()
        {
            return _guestUserMessageRepository.GetAll();
        }

        public GuestUserMessageComplexResult Search(GuestUserMessage sm, out int recordCount)
        {
            return _guestUserMessageRepository.Search(sm, out recordCount);
        }
    }
}
