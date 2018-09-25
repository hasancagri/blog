using MyBlogApp.Entities.Concrete;
using System.ServiceModel;

namespace MyBlogApp.Interfaces
{
    [ServiceContract]
    public interface IEtiketService
    {
        [OperationContract]
        void Add(Etiket etiket);

        [OperationContract]
        void Delete(Etiket etiket);
    }
}
