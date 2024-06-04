using DataAccessServices.Services.Base;
using DomainModel.DTO.Supplier;
using DomainModel.Models;

namespace DataAccessServices.Services
{
    public interface ISupplierRepository:IBaseRepositorySearchable<Supplier,int,SupplierSearchModel,SupplierComplexResults>
    {
        bool HasSupplier(string name);
    }
}
