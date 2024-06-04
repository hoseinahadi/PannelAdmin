using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessServices.Services;
using DataAccessServices.Services;
using DomainModel.Assist;
using DomainModel.DTO.OrderReturn;
using DomainModel.DTO.Page;
using DomainModel.Models;

namespace Business.IMP
{
    public class PageBusiness:IPageBusiness
    {
        private readonly IPageRepository repo;

        public PageBusiness(IPageRepository repo)
        {
            this.repo = repo;
        }
        private Page ToModel(PageAddEditModel addOrEdit)
        {
            return new Page
            {
                PageId = addOrEdit.PageId,
                PageName = addOrEdit.PageName,

            };
        }
        private PageAddEditModel ToAddEditModel(Page model)
        {
            return new PageAddEditModel
            {
                PageId = model.PageId,
                PageName = model.PageName,

            };
        }
        public OperationResult Add(PageAddEditModel model)
        {
            return repo.Add(ToModel(model));
        }

        public OperationResult Update(PageAddEditModel model)
        {
            return repo.Update(ToModel(model));
        }

        public OperationResult Delete(int id)
        {
            return repo.Delete(id);
        }

        public PageAddEditModel Get(int id)
        {
            return ToAddEditModel(repo.Get(id));
        }

        public List<Page> GetAll()
        {
            return repo.GetAll();
        }
    }
}
