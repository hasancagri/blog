using MyBlogApp.Entities.Web.SelectList;
using System.Collections.Generic;
using System.ServiceModel;

namespace MyBlogApp.Interfaces
{
    [ServiceContract]
    public interface IYetkiService
    {
        [OperationContract]
        List<YetkiSelectList> GetYetkiSelectList();
    }
}
