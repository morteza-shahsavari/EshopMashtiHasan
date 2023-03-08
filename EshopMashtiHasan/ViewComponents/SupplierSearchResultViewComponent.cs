
using Microsoft.AspNetCore.Mvc;
using Shopping.BussinessServiceContract.Services;
using Shopping.DomainModel.DTO.Supplier;

namespace EshopMashtiHasan.ViewComponents
{
    [ViewComponent(Name = "SupplierSearchResult")]
    public class SupplierSearchResultViewComponent:ViewComponent
    {
        private readonly ISupplierBuss buss;
        public SupplierSearchResultViewComponent(ISupplierBuss buss)
        {
            this.buss = buss;
        }
        public IViewComponentResult Invoke(SupplierSearchModel sm)
        {
            if (sm==null)
            {
                sm = new SupplierSearchModel {PageSize=20 };
            }
            if (sm.PageSize==0)
            {
                sm.PageSize = 20;
            }
            int rc = 0;
               var lst = buss.Search(sm,out rc);
            return View(lst);
        }
    }
}
