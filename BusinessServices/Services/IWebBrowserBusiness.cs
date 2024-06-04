using DomainModel.Assist;
using DomainModel.DTO.WbBrowser;
using DomainModel.Models;

namespace BusinessServices.Services
{
    public interface IWebBrowserBusiness
    {
        OperationResult Add(WebBrowserAddEditModel model);
        OperationResult Update(WebBrowserAddEditModel model);
        OperationResult Delete(int id);
        WebBrowserAddEditModel Get(int id);
        List<WebBrowser> GetAll();
    }
}
