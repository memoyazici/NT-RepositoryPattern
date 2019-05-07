using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Northwind.DTO;
using Northwind.Entity;
using Northwind.Repository;

namespace Northwind.WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ProductService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ProductService.svc or ProductService.svc.cs at the Solution Explorer and start debugging.
    public class ProductService : ServiceBase<ProductRepository,Product,ProductDTO>
    {
        /* ProductService isimli bir servis oluşturulacak , arka planda IroductService
         * isimli bir interface oluştur. ProductSEvice servisimiz IProductService isimli
         * interface den türetirsek... Hiyerarşiyi bu şekilde bırakırsak, ISErvice ve ServiceBase içindeki
         * metotlar kullanılamayacak. Oysa ki biz IService ve ServiceBAse içindeki metotların
         * (Listing, Deleting, Updting) tüm Service lerde tekrar tekrar yazılmaması için 
         * oluşturmuştuk. (Product, Category, Supplier)
          */
       
    }
}
