using MyBlogApp.Interfaces;

namespace MyBlogApp.MvcWebUI.Controllers
{
    public class EtiketController
        : BaseController
    {
        private readonly IEtiketService _etiketService;
        public EtiketController(IEtiketService etiketService)
        {
            _etiketService = etiketService;
        }
    }
}