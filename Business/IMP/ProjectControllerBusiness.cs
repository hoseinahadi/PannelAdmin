using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessServices.Services;
using DataAccessServices.Services;
using DomainModel.Assist;
using DomainModel.DTO.ProjectController;
using DomainModel.Models;

namespace Business.IMP
{
    public class ProjectControllerBusiness:IProjectControllerBusiness
    {
        private readonly IProjectControllerRepository _projectControllerRepository;

        public ProjectControllerBusiness(IProjectControllerRepository projectControllerRepository)
        {
            _projectControllerRepository = projectControllerRepository;
        }
        private ProjectController ToModel(ProjectControllerAddEditModel x)
        {
            ProjectController result = new ProjectController
            {
                PersianTitle = x.PersianTitle,
                ProjectControllerId = x.ProjectControllerId,
                ProjectControllerName = x.ProjectControllerName
            };
            return result;
        }
        private ProjectControllerAddEditModel ToAddEditModel(ProjectController x)
        {
            ProjectControllerAddEditModel result = new ProjectControllerAddEditModel
            {
                PersianTitle = x.PersianTitle,
                ProjectControllerId = x.ProjectControllerId,
                ProjectControllerName = x.ProjectControllerName
            };
            return result;
        }
        public OperationResult Delete(int id)
        {
            return _projectControllerRepository.Delete(id);
        }

        public OperationResult Update(ProjectControllerAddEditModel current)
        {
            return _projectControllerRepository.Update(ToModel(current));
        }

        public OperationResult AddNew(ProjectControllerAddEditModel current)
        {
            return _projectControllerRepository.Add(ToModel(current));
        }

        public ProjectControllerAddEditModel Get(int id)
        {
            return ToAddEditModel(_projectControllerRepository.Get(id));
        }

        public List<ProjectController> GetAll()
        {
            return _projectControllerRepository.GetAll();
        }
    }
}
