using DomainModel.Assist;

namespace DataAccessServices.Services.Base
{
    public interface IBaseRepository<TModel,TKey>
    {
        OperationResult Add (TModel model);
        OperationResult Delete (TKey id);
        OperationResult Update(TModel model);
        TModel Get (TKey id);
        List<TModel> GetAll();

    }
}
