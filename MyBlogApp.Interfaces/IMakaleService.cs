using MyBlogApp.Entities.Concrete;
using MyBlogApp.Entities.Web.SelectList;
using System.Collections.Generic;
using System.ServiceModel;

namespace MyBlogApp.Interfaces
{
    [ServiceContract]
    public interface IMakaleService
    {
        [OperationContract]
        List<Makale> GetAll(bool isInclude);

        [OperationContract]
        void Update(Makale makale);

        [OperationContract]
        Makale GetMakale(int id, bool isInclude = false);

        [OperationContract]
        void OkunmaArttir(int id, int quantity = 1);

        [OperationContract]
        List<MakaleSelectList> GetMakaleSelectList();

        [OperationContract]
        List<Makale> PopulerMakaleler();

        [OperationContract]
        List<Makale> KategorininMakalesi(int kategoriId);

        [OperationContract]
        List<Makale> BlogAra(string Ara = null);

        [OperationContract]
        int MakaleSayisi();

        [OperationContract]
        void Delete(Makale makale);
    }
}
