using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessServices.Services;
using DataAccessServices.Services;
using DomainModel.Assist;
using DomainModel.DTO.GuestUser;
using DomainModel.DTO.Image;
using DomainModel.DTO.Page;
using DomainModel.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace Business.IMP
{
    public class ImageBusiness : IImageBusiness
    {
        private readonly IImageRepository repo;
        private IHostingEnvironment Environment;

        public ImageBusiness(IImageRepository repo, IHostingEnvironment environment)
        {
            this.repo = repo;
            Environment = environment;
        }
        private Image ToModel(ImageAddOrEditModel addOrEdit)
        {
            return new Image
            {
                UserId = addOrEdit.UserId,
                ProductId = addOrEdit.ProductId,
                EmployeeId = addOrEdit.EmployeeId,
                ImageCode = addOrEdit.ImageCode,
                ImageId = addOrEdit.ImageId,
                ImageName = addOrEdit.ImageName,
                ImageUrl = addOrEdit.ImageUrl,




            };
        }
        private ImageAddOrEditModel ToAddEditModel(Image model)
        {
            return new ImageAddOrEditModel
            {
                UserId = model.UserId,
                ProductId = model.ProductId,
                EmployeeId = model.EmployeeId,
                ImageCode = model.ImageCode,
                ImageId = model.ImageId,
                ImageName = model.ImageName,
                ImageUrl = model.ImageUrl,


            };
        }
        public OperationResult Add(ImageAddOrEditModel model)
        {
            
            return repo.Add(ToModel(model));
            


        }

        public OperationResult Update(ImageAddOrEditModel model)
        {
            return repo.Update(ToModel(model));
        }

        public OperationResult Delete(int id)
        {
            return repo.Delete(id);
        }

        public ImageAddOrEditModel Get(int id)
        {
            return ToAddEditModel(repo.Get(id));
        }

        public List<Image> GetAll()
        {
            return repo.GetAll();
        }

        public ImageComplexResults Search(ImageSearchModel sm, out int recordCount)
        {
            return repo.Search(sm, out recordCount);
        }
    }
}
