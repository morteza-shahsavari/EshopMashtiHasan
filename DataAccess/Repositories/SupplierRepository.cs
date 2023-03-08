using Shopping.DataAcceServiesContract.Repositories;

using Framework.BaseModel;
using Shopping.DomainModel.DTO.Supplier;
using Shopping.DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.DataAccess.Repositories
{
    public class SupplierRepository : ISupplierRepository
    {
        private  Supplier ToSupplierModel(SupplierAddUpdateModel model)
        {
            Supplier S = new Supplier { 
                Grade= model.Grade,
                SupplierID= model.SupplierID,
                SupplierName= model.SupplierName,
                Tel= model.Tel
            };
            return S;
        }

        private readonly EshopMashtiHasanContext db;
        public SupplierRepository(EshopMashtiHasanContext db)
        {
            this.db = db;
        }
        public OperationResult Add(SupplierAddUpdateModel model)
        {
            OperationResult op = new OperationResult("Add", "Suplier");
            try
            {
              var S=this.ToSupplierModel(model);
                db.Suppliers.Add(S);
                db.SaveChanges();
                op.ToSuccess(S.SupplierID, "Add Successfuly");
            }
            catch (Exception ex)
            {

                op.ToFail("Add Faild" + ex);
            }
            return op;
        }

        public Supplier Get(int id)
        {
           return db.Suppliers.FirstOrDefault(x => x.SupplierID == id);
        }

        public List<Supplier> GetAll()
        {
            return db.Suppliers.ToList();
        }

        public bool HasProduct(int SuplierID)
        {
            return db.Suppliers.Any(x => x.SupplierID == SuplierID);
        }

        public OperationResult Remove(int id)
        {
            OperationResult op = new OperationResult("Delete", "Suplier", id);
            try
            {
                var sup = db.Suppliers.FirstOrDefault(x => x.SupplierID == id);
                db.Suppliers.Remove(sup);
                db.SaveChanges();
                op.ToSuccess("Delete Successfuly");
            }
            catch (Exception ex)
            {

                op.ToFail("Delete Faild" + ex);
            }
            return op;
        }

        public List<SupplierListItem> Search(SupplierSearchModel sm, out int RecordCount)
        {
            var q = from item in db.Suppliers select new SupplierListItem
            {
                SupplierID= item.SupplierID,
                SupplierName= item.SupplierName,
                Grade= item.Grade,
                Tel= item.Tel,
                ProductCount=item.Products.Count
            };
            if (!string.IsNullOrEmpty(sm.Tel))
            {
                q = q.Where(x => x.Tel.StartsWith(sm.Tel));
            }
            if (!string.IsNullOrEmpty(sm.SupplierName))
            {
                q = q.Where(x => x.SupplierName.StartsWith(sm.SupplierName));
            }
            if (sm.PageSize == 0)
            {
                sm.PageSize = 20;
            }
            RecordCount = q.Count();
            q =q.OrderBy(x => x.SupplierID).Skip(sm.PageIndex*sm.PageSize).Take(sm.PageSize);
            return q.ToList();

        }

        public OperationResult Update(SupplierAddUpdateModel model)
        {
            OperationResult op = new OperationResult("Update", "Suplier", model.SupplierID);
            try
            {
                var sup = db.Suppliers.FirstOrDefault(x => x.SupplierID == model.SupplierID);
                sup.SupplierName=model.SupplierName;
                sup.Tel=model.Tel;
                sup.Grade=model.Grade;
                
                db.SaveChanges();
                op.ToSuccess("Update Successfuly");
            }
            catch (Exception ex)
            {

                op.ToFail("Update Faild" + ex);
            }
            return op;
        }

        public bool ExitsSupplierName(string SupplierName)
        {
            return db.Suppliers.Any(x => x.SupplierName == SupplierName);
        }

        public bool ExitsSupplierName(string SupplierName, int supplierID)
        {
            return db.Suppliers.Any(x => x.SupplierName == SupplierName && x.SupplierID!=supplierID);
        }


    }
}
