using DomainModel.Assist;
using DomainModel.DTO.Tax;
using DomainModel.Models;

namespace BusinessServices.Services
{
    public interface ITaxBusiness
    {
        OperationResult Add(TaxAddEditModel model);
        OperationResult Update(TaxAddEditModel model);
        OperationResult Delete(int id);
        TaxAddEditModel Get(int id);
        List<Tax> GetAll();
        TaxComplexResults Search(TaxSearchModel sm, out int recordCount);
    }
}
