using Northwind.DTO;
using Northwind.Entity;
using Northwind.Extensions;
using Northwind.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Northwind.WCF
{
    public class ServiceBase<Rep, Entity, DTO> : IService<DTO> 
        where DTO : class 
        where Rep : RepositoryBase<Entity> 
        where Entity : class
    {   /* Rep : RepositoryBase<Entity>  hareket tipi Repositorybase türünde olduğundan
        ServiceBAse sınıfını kullandığımız yerlerde Rep harket tipi için Product+,Supplier+
        ve CategoryRepository yazılabilir*/
        /*ServiceBase sınıfı RepositoryBase sınıfına talepleri gönderen ve
        RepositoryBase sınıfından response ları alan bir sınıftır. SErviceBase sınıfının
        hangi RepositoryBase(ProductRepo,CategoryRepo vs) sınıfı ile iletişimde 
        olduğunu bilmek gerekir. Ayrıca servicebase sınıfı client'a DTO nesnesi yollamalı
        ve client'tan gelen DTO nesnesini RepositoryBase sınıfına gönderirken
        Enttye dönüştürmesi gerekir*/

        /*ServiceBase in hem Repository tipi hem Entity tipi hem de DTO tipi argümanlarına
          * ihtiyacı var
            */
        private Rep repository;

        public Rep Repository
        {
            get {
                /*Generic tip için instance oluşturak istediğimizde new Rep() şeklinde
                 initialization yapılmaz. Generic için instance oluşturacak sınıfın adı
                 Activator ve Metot'un adı CreateInstance adlı generic metottur.*/
                //CreateInstance<Rep> dışarıdan alınan tiptir ve instance dışardan alınan bu tip ile üretilecektir.

                //repository =  repository == null ? Activator.CreateInstance<Rep>() : repository;
                repository = repository ?? Activator.CreateInstance<Rep>();
                return repository;
            }
            set {
                repository = value;
            }
        }


        public bool Adding(DTO dto)
        {
            return Repository.Adding(dto.Changer<Entity>());
        }

        public bool Deleting(DTO dto)
        {
            return Repository.Deleting(dto.Changer<Entity>());
            
        }

        public List<DTO> Listing()
        {
            /*ServiceBAse inden RepositoryBAse e talep gönderilecek*/

            //return Repository.Listing();
            /*Service katmanımız Repositoryden Entity alır. Öncelikle alınan entity lerin
             DTO nesnesine dönüştürülmesi gerekir
             DTO-to-Entity ve Entity-to-DTO çevrimine ihtiyacımız vardır.   */

            /*d.Changer<Product>(); d. nın anlamı Changer<> metoduna hangi kaynak üstünden 
             ulaştığımızı gösterir. Yani changer a ProductDTO üstünden ulaşıyorsunuz
             Başka bir deyişle PRoductDTO nesnesini Product nesnesine dönüştürüyorsunuz*/
            /*<Product>() : Changer metodunun dışarıdan istediği argüman tipini gösterir. 
             Changer hangi tipe dönüştürecekse, o tip argüman tip olarak belirtilir.
             */

            //Deneme DTO->Entity Entity->DTO
            //ProductDTO d = new ProductDTO();
            //Product prod = d.Changer<Product>();
            /////////////////////////////////////////////////////////////////////
            //Product p = new Product();
            //ProductDTO pdt = p.Changer<ProductDTO>();

            //Product p = new Product();
            //p.ProductName = "MyAvokado";
            //p.UnitPrice = 19;
            //p.UnitsInStock = 50;
            //ProductDTO dt = p.Changer<ProductDTO>();

            //throw new NotImplementedException();
            return Repository.Listing().Select(x=> x.Changer<DTO>()).ToList();

        }

        public bool Updating(DTO dto)
        {
            return Repository.Updating(dto.Changer<Entity>());
            //throw new NotImplementedException();
        }
    }
}