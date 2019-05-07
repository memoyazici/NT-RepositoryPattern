using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Extensions
{
    /*Extension metotlar ve bu metotların bulunduğu classlar static olmalıdır.. */
    public static class Extension
    {
        /* C# 'ta bulunan Object classının içine yeni bir metot ekleyeceğiz */
        /*this Object source : Object tipinin içerisine bu metot(Changer) eklenecektir.
         Bu yazım tarzı ile, halihazırda bulunan bir sınıfın içerisine, dışarıdan bir metot
         eklemiş olacağız. Bundan sonra projenin içerisine, herhangi bir sınıf eklendiğinde
         bu metot, o sınıfın içinde otomatik olarak varmış gibi olacak. (Inheritance)
         
             * Kısacası bu gösteim extension metot gösterimidir*/
        /*Changer<T>(this Object source) : source elemanı hangi instance üzerinden . 
         ile metota ulaşıyorsak o instance ı temsil eder. Biz changer metodu ile source
         elemanını T Tipine dönüştüreceğiz. Ve geriye T tipinde eleman döndüreceğiz*/

         /*Product nesnesinin içindeki Property leri productDTO içerisine koyacağız, Yada
          ProductDTO içerisindeki propertyleri, Product nesnesinin içine koyacağız*/

        public static T Changer<T>(this Object source)
        {
            //T Tiinde instance oluştur ve oluşan instance ı yine T tipinde bir değişkene ata.
            T target = Activator.CreateInstance<T>();
            Type targetType = target.GetType();
            Type sourceType = source.GetType();

            PropertyInfo[] sourceProperties = sourceType.GetProperties();
            PropertyInfo[] targetProperties = targetType.GetProperties();

            foreach (PropertyInfo pInf in sourceProperties)
            {
                object value = pInf.GetValue(source);
                PropertyInfo targetpInf = targetProperties.FirstOrDefault(x => x.Name == pInf.Name);
                if (targetpInf != null)
                {
                    targetpInf.SetValue(target, value);

                }
            }
            
            return target;
        }
    }
}
