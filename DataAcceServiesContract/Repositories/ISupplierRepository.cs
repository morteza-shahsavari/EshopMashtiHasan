using Framework.Base;
using Shopping.DomainModel.DTO.Supplier;
using Shopping.DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.DataAcceServiesContract.Repositories
{
    public interface ISupplierRepository:IBaseRepositorysearchable<Supplier,int,SupplierSearchModel,SupplierListItem,SupplierAddUpdateModel,SupplierAddUpdateModel>
    {
        bool HasProduct(int SuplierID);
        bool ExitsSupplierName(string SupplierName);
        bool ExitsSupplierName(string SupplierName,int supplierID);

    }
}
