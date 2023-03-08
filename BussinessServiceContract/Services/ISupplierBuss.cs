using Shopping.BussinessServiceContract.BussinessModel.Supplier;
using Framework.BaseModel;
using Shopping.DomainModel.DTO.Supplier;
using Shopping.DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.BussinessServiceContract.Services
{
    public interface ISupplierBuss
    {
        OperationResult RegisterSupplier(SupplierAddEditViewModel sup);
        OperationResult UpdateSupplier(SupplierAddEditViewModel sup);
        OperationResult RemoveSupplier(int SupplierID);
        List<Supplier>GetAll();
        SupplierAddEditViewModel GetSuppiler(int SupplierID);
        List<SupplierListItem> Search(SupplierSearchModel Search, out int ReCordCount);

    }
}
