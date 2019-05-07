using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;

namespace Northwind.WCF
{
    [ServiceContract]
    public interface IService<DTO> where DTO : class
    {
        /*Servis katmanı client'tan talebi alıp repository katmanına iletir
         IService interface i ve içerisinde tanımlı metotlar client ile iletişime geçeceği
         için contract içine dahil edilmesi gerekir  */

        /* Bu katmanın olmasının sebebi client'ların direk olarak Entity ve Facade lara
         * ulaşmaması içindir. Servis katmanına Client tarafından gelen nesneler DTO
         * nesneleridir. Entitty nesneleri gelmez.  */

        /*DTO katmanı Entity lerin aynısı olacaktır, sadece DTO içinde serilize edilebilir
         * nesneler barındırır.
         * Client ile servis arasında gidip/gelen nesnelerin serilize edilebilir olması
         * gerekir
         */

        [OperationContract]
        List<DTO> Listing();

        [OperationContract]
        bool Adding(DTO dto);

        [OperationContract]
        bool Updating(DTO dto);

        [OperationContract]
        bool Deleting(DTO dto);
    }
}