using MyBlogApp.Entities.Concrete;
using MyBlogApp.Entities.Web.SelectList;
using System.Collections.Generic;
using System.ServiceModel;

namespace MyBlogApp.Interfaces
{
    [ServiceContract]
    public interface IKategoriService
    {
        [OperationContract]
        List<Kategori> GetAllKategori(bool isInclude);

        [OperationContract]
        Kategori Get(int id, bool isInclude);

        [OperationContract]
        void Update(Kategori kategori);

        [OperationContract]
        void Delete(Kategori kategori);

        [OperationContract]
        void Add(Kategori kategori);

        [OperationContract]
        int KategoriSayisi();

        [OperationContract]
        List<KategoriSelectList> GetKategoriSelectList();
    }
}
