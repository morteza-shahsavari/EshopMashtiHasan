using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.BussinessServiceContract.BussinessModel.Supplier
{
    public class SupplierAddEditViewModel
    {
        public int SupplierID { get; set; }
        [Required(ErrorMessage ="نام تولید کننده رو وارد نمایید")]
        [StringLength(100,MinimumLength =3,ErrorMessage ="نام تولید کننده بین 3تا110 باشد")]
        public string SupplierName { get; set; }
        [Required(ErrorMessage = "رتبه تولید کننده رو وارد نمایید")]
        public double Grade { get; set; }
        [Required(ErrorMessage = "تلفن تولید کننده رو وارد نمایید")]
        public string Tel { get; set; }

    }
}
