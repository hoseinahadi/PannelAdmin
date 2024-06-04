using DomainModel.Assist;
using DomainModel.DTO.Currency;
using DomainModel.Models;

namespace BusinessServices.Services
{
    public interface ICurrencyBusiness
    {
        OperationResult Add(CurrencyAddOrEditModel model);
        OperationResult Update(CurrencyAddOrEditModel model);
        OperationResult Delete(int id);
        CurrencyAddOrEditModel Get(int id);
        List<Currency> GetAll();
        CurrencyComplexResults Search(CurrencySearchModel sm, out int recordCount);
    }
}
