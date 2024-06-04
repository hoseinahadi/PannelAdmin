using DataAccessServices.Services.Base;
using DomainModel.DTO.Image;
using DomainModel.Models;

namespace DataAccessServices.Services
{
    public interface IImageRepository:IBaseRepositorySearchable<Image,int,ImageSearchModel,ImageComplexResults>
    {
    }
}
