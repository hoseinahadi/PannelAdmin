using DataAccessServices.Services.Base;
using DomainModel.DTO.ContactUs;
using DomainModel.Models;

namespace DataAccessServices.Services
{
    public interface IContactUsRepository:IBaseRepositorySearchable<ContactUs,int,ContactUsSearchModel,ContactUsComplexResults>
    {
        
    }
}
