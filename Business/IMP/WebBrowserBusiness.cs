using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessServices.Services;
using DataAccessServices.Services;
using DomainModel.Assist;
using DomainModel.DTO.User;
using DomainModel.DTO.WbBrowser;
using DomainModel.Models;

namespace Business.IMP
{
    public class WebBrowserBusiness:IWebBrowserBusiness
    {
        private readonly IWebBrowserRepository repo;

        public WebBrowserBusiness(IWebBrowserRepository repo)
        {
            this.repo = repo;
        }
        private WebBrowser ToModel(WebBrowserAddEditModel addOrEdit)
        {
            return new WebBrowser
            {
                WebBrowserId = addOrEdit.WebBrowserId,
                WebBrowserName = addOrEdit.WebBrowserName,

            };
        }
        private WebBrowserAddEditModel ToAddEditModel(WebBrowser model)
        {
            return new WebBrowserAddEditModel
            {
                WebBrowserId = model.WebBrowserId,
                WebBrowserName = model.WebBrowserName,
                
            };
        }
        public OperationResult Add(WebBrowserAddEditModel model)
        {
            return repo.Add(ToModel(model));
        }

        public OperationResult Update(WebBrowserAddEditModel model)
        {
            return repo.Update(ToModel(model));
        }

        public OperationResult Delete(int id)
        {
            return repo.Delete(id);
        }

        public WebBrowserAddEditModel Get(int id)
        {
            return ToAddEditModel(repo.Get(id));
        }

        public List<WebBrowser> GetAll()
        {
            return repo.GetAll();
        }
    }
}
