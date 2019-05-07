using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.DTO
{
    public class ProductDTO
    {
        [Column(Order = 0)]
        public int ProductID { get; set; }
        [Column(Order = 1)]
        public string ProductName { get; set; }
        [Column(Order = 2)]
        public Nullable<int> SupplierID { get; set; }
        [Column(Order = 3)]
        public Nullable<int> CategoryID { get; set; }
        [Column(Order = 4)]
        public string QuantityPerUnit { get; set; }
        [Column(Order = 5)]
        public Nullable<decimal> UnitPrice { get; set; }
        [Column(Order = 6)]
        public Nullable<short> UnitsInStock { get; set; }
        [Column(Order = 7)]
        public Nullable<short> UnitsOnOrder { get; set; }
        [Column(Order = 8)]
        public Nullable<short> ReorderLevel { get; set; }
        [Column(Order = 9)]
        public bool Discontinued { get; set; }
    }
}
