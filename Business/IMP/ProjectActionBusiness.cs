using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessServices.Services;
using DataAccessServices.Services;
using DomainModel.Assist;
using DomainModel.DTO.ProjectAction;
using DomainModel.Models;

namespace Business.IMP
{
    public class ProjectActionBusiness:IProjectActionBusiness
    {
        private readonly IProjectActionRepository _projectActionRepository;

        public ProjectActionBusiness(IProjectActionRepository projectActionRepository)
        {
            _projectActionRepository = projectActionRepository;
        }
        private ProjectAction ToModel(ProjectActionAddEditModel addEditModel)
        {
            ProjectAction product = new ProjectAction
            {
                PersianTitle = addEditModel.PersianTitle,
                ProjectActionId = addEditModel.ProjectActionId,
                ProjectActionName = addEditModel.ProjectActionName,
            };
            return product;

        }
        private ProjectActionAddEditModel ToAddEditModel(ProjectAction model)
        {
            var product = new ProjectActionAddEditModel
            {
                PersianTitle = model.PersianTitle,
                ProjectActionId = model.ProjectActionId,
                ProjectActionName = model.ProjectActionName,
            };
            return product;
        }
        public OperationResult Delete(int id)
        {
            return _projectActionRepository.Delete(id);
        }

        public OperationResult Update(ProjectActionAddEditModel current)
        {
            return _projectActionRepository.Update(ToModel(current));
        }

        public OperationResult AddNew(ProjectActionAddEditModel current)
        {
            return _projectActionRepository.Add(ToModel(current));
        }

        public ProjectActionAddEditModel Get(int id)
        {
            return ToAddEditModel(_projectActionRepository.Get(id));
        }

        public List<ProjectAction> GetAll()
        {
            return _projectActionRepository.GetAll();
        }
    }
}
