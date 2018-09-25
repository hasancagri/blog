using MyBlogApp.Entities.Concrete;
using MyBlogApp.Entities.Web.SelectList;
using System.Collections.Generic;
using System.ServiceModel;

namespace MyBlogApp.Interfaces
{
    [ServiceContract]
    public interface IUyeService
    {
        [OperationContract]
        Uye Get(int id, bool isInclude);

        [OperationContract]
        List<Uye> GetAll(bool isInclude);

        [OperationContract]
        void Delete(Uye uye);

        [OperationContract]
        void Delete(int id);

        [OperationContract]
        void Add(Uye uye);

        [OperationContract]
        void Update(Uye uye);

        [OperationContract]
        List<UyeSelectList> GetUyeSelectList();

        [OperationContract]
        int UyeSayisi();
    }
}
