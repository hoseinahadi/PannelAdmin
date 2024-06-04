using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessServices.Services;
using DataAccessServices.Services;
using DomainModel.Assist;
using DomainModel.DTO.Gender;
using DomainModel.DTO.GuestUser;
using DomainModel.Models;

namespace Business.IMP
{
    public class GuestUserBusiness:IGuestUserBusiness
    {
        private readonly IGuestUserRepository repo;

        public GuestUserBusiness(IGuestUserRepository repo)
        {
            this.repo = repo;
        }
        private GuestUser ToModel(GuestUserAddEditModel addOrEdit)
        {
            return new GuestUser
            {
                WebBrowserId = addOrEdit.WebBrowserId,
                AcceptLanguage = addOrEdit.AcceptLanguage,
                AdobeFlash = addOrEdit.AdobeFlash,
                ConnectionId = addOrEdit.ConnectionId,
                GuestUserId = addOrEdit.GuestUserId,
                JavaScript = addOrEdit.JavaScript,
                ScreenResolutionX = addOrEdit.ScreenResolutionX,
                ScreenResolutionY = addOrEdit.ScreenResolutionY,

                
            };
        }
        private GuestUserAddEditModel ToAddEditModel(GuestUser model)
        {
            return new GuestUserAddEditModel
            {
                WebBrowserId = model.WebBrowserId,
                AcceptLanguage = model.AcceptLanguage,
                AdobeFlash = model.AdobeFlash,
                ConnectionId = model.ConnectionId,
                GuestUserId = model.GuestUserId,
                JavaScript = model.JavaScript,
                ScreenResolutionX = model.ScreenResolutionX,
                ScreenResolutionY = model.ScreenResolutionY,


            };
        }
        public OperationResult Add(GuestUserAddEditModel model)
        {
            return repo.Add(ToModel(model));
        }

        public OperationResult Update(GuestUserAddEditModel model)
        {
            return repo.Update(ToModel(model));
        }

        public OperationResult Delete(int id)
        {
            return repo.Delete(id);
        }

        public GuestUserAddEditModel Get(int id)
        {
            return ToAddEditModel(repo.Get(id));
        }

        public List<GuestUser> GetAll()
        {
            return repo.GetAll();
        }

        public GuestUserComplexResults Search(GuestUserSearchModel sm, out int recordCount)
        {
            return repo.Search(sm, out recordCount);
        }
    }
}
