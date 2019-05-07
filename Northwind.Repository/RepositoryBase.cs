using Northwind.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Repository
{
    public class RepositoryBase<TT> : IRepository<TT>  where TT : class 
    {

        /*Repository Base Classında Context e ihtiyacımız var. Bu yüzden 
        Northwind.Repository projemize Northwind.Entity Projesini referans olarak eklememiz
        gerekir.
        */
        /*Singleton Pattern mimarisi, uygulamanın tek context yada tek connection üzerinden
         * işlem yapmasının sağlandığı design pattern dır.
         * Sık sık bağlantı açılıp/kapatılan uygulamalarda bu işlemler bu işlemler SQL
         * Server a gereksiz yük bindirir. Bunun yerine hazırda context nesnesi var mı diye
         * bakılır, eğer yoksa yeniden oluşturulur. Tek instance kullanıma zorlar.
         */
        private NorthwindEntities context;

        public NorthwindEntities Context {
            get
            {
                if (context == null)
                {
                    context = new NorthwindEntities();
                }
                return context;
            }
            set
            {
                context = value;
            }
        }

        public bool Adding(TT entity)
        {
            //Set<TT>() : Context in TT tipini algılamasını sağlar
            Context.Set<TT>().Add(entity);
            try
            {
                return Context.SaveChanges() > 0;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Deleting(TT entity)
        {
            Context.Set<TT>().Remove(entity);
            return true;
        }

        public List<TT> Listing()
        {
            //Product entitysi gelirse product, Category ise category list döndürecek
            return Context.Set<TT>().ToList();
        }

        public bool Updating(TT entity)
        {
            try
            {
                Context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
