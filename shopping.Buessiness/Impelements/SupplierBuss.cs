using Shopping.BussinessServiceContract.BussinessModel.Supplier;
using Shopping.BussinessServiceContract.Services;
using Shopping.DataAcceServiesContract.Repositories;
using Framework.BaseModel;
using Shopping.DomainModel.DTO.Supplier;
using Shopping.DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shopping.Buessiness.Impelements
{
    public class SupplierBuss : ISupplierBuss
    {


        SupplierAddUpdateModel ToDataAccessModel(SupplierAddEditViewModel sup)
        {
            SupplierAddUpdateModel r= new SupplierAddUpdateModel
            {
                Grade=sup.Grade,
                SupplierName=sup.SupplierName,
                Tel=sup.Tel,
                SupplierID=sup.SupplierID
            };
            return r;
        }
        private readonly ISupplierRepository repo;
        public SupplierBuss(ISupplierRepository repo)
        {
            this.repo = repo;
        }
        public List<Supplier> GetAll()
        {
           return repo.GetAll();
        }

        public SupplierAddEditViewModel GetSuppiler(int SupplierID)
        {
            var s = repo.Get(SupplierID);
            var Supvm = new SupplierAddEditViewModel {
            SupplierID=s.SupplierID,
            Tel=s.Tel,
            Grade=s.Grade,
            SupplierName=s.SupplierName
            };
            return Supvm;
        }

        public OperationResult RegisterSupplier(SupplierAddEditViewModel sup)
        {
            if (repo.ExitsSupplierName(sup.SupplierName))
            {
                OperationResult op = new OperationResult("Register", "Supplier").ToFail("SupplierName Areadly Exits");
            }
            var s = ToDataAccessModel(sup);
            return repo.Add(s);

        }

        public OperationResult RemoveSupplier(int SupplierID)
        {
            if (repo.HasProduct(SupplierID))
            {
                OperationResult op = new OperationResult("Delete", "Supplier").ToFail("Supplier has Product Exits");
            }
            return repo.Remove(SupplierID);
        }

        public List<SupplierListItem> Search(SupplierSearchModel Search, out int ReCordCount)
        {
            return repo.Search(Search, out ReCordCount).ToList();
        }

        public OperationResult UpdateSupplier(SupplierAddEditViewModel sup)
        {
            if (repo.ExitsSupplierName(sup.SupplierName,sup.SupplierID))
            {
                OperationResult op = new OperationResult("Update", "Supplier").ToFail("SupplierName Areadly Exits");
            }
            var s = ToDataAccessModel(sup);
            return repo.Update(s);
        }
    }
}
