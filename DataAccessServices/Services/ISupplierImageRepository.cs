using DataAccessServices.Services.Base;
using DomainModel.DTO.SupplierImage;
using DomainModel.Models;

namespace DataAccessServices.Services
{
    public interface ISupplierImageRepository : IBaseRepositorySearchable<SupplierImage,int, SupplierImage, SupplierImageComplexResult>
    {
        
    }
}
