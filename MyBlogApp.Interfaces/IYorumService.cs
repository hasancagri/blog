using MyBlogApp.Entities.Concrete;
using System.Collections.Generic;
using System.ServiceModel;

namespace MyBlogApp.Interfaces
{
    [ServiceContract]
    public interface IYorumService
    {
        [OperationContract]
        void Add(Yorum yorum);

        [OperationContract]
        Yorum Get(int id, bool isInclude);

        [OperationContract]
        void Update(Yorum yorum);

        [OperationContract]
        List<Yorum> GetAll(bool isInclude);

        [OperationContract]
        void Delete(int id);

        [OperationContract]
        void Delete(Yorum yorum);

        [OperationContract]
        List<Yorum> SonYorumlar();

        [OperationContract]
        int YorumSayisi();
    }
}
