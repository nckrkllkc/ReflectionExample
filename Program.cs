using System;
using System.Reflection;

namespace ReflectionExample
{
    class Program
    {
        static void Main(string[] args)
        {
            //DortIslem dortIslem = new DortIslem(1,2);
            //Console.WriteLine(dortIslem.Topla(2,3));
            //Console.WriteLine(dortIslem.Topla2());

            var type = typeof(DortIslem);

            //gelen tipe göre new işlemi
            Activator.CreateInstance(type);

            //CreateInstance object döndürdüğü için cast işlemi yapılır
            DortIslem dortIslem = (DortIslem)Activator.CreateInstance(type);
            Console.WriteLine(dortIslem.Topla(4, 5));

            //parametreli constructor ile instance alma işlemi
            DortIslem dortIslem2 = (DortIslem)Activator.CreateInstance(type,6,7);
            Console.WriteLine(dortIslem2.Topla2());

            var instance = Activator.CreateInstance(type,7,6);

            //Invoke(calisagiInstance,parametreler)
            instance.GetType().GetMethod("Topla2").Invoke(instance,null); //Gelen tipe göre içinde Topla2 metodu arayıp invoke ile çalıştırır
            //yukarıdakinin daha anlaşılır hali :)
            MethodInfo methodInfo = instance.GetType().GetMethod("Topla2");
            //yukarıda instance üzerinden ulaşarak sadece metot bilgisine ulaşırız.
            //hangi instance'ın Topla2 sini çalıştırayım? sorusunun cevabı için instance ı parametre olarak yolluyoruz.
            methodInfo.Invoke(instance, null);

            var methods = type.GetMethods();
            foreach (var method in methods)
            {
                Console.WriteLine(method.Name);
                foreach (var parametre in method.GetParameters())
                {
                    Console.WriteLine("Parametre: " + parametre);
                }

                foreach (var attribute in method.GetCustomAttributes())
                {
                    Console.WriteLine("Attribute: " + attribute);
                }

                Console.WriteLine("-------------------");
            }

            
        }
    }

    class DortIslem
    {
        int _sayi1;
        int _sayi2;
        public DortIslem()
        {

        }
        public DortIslem(int sayi1, int sayi2)
        {
            _sayi1 = sayi1;
            _sayi2 = sayi2;
        }
        public int Topla(int sayi1, int sayi2)
        {
            return sayi1 + sayi2;
        }

        public int Carp(int sayi1, int sayi2)
        {
            return sayi1 * sayi2;
        }

        public int Topla2()
        {
            return _sayi1 + _sayi2;
        }

        public int Carp2()
        {
            return _sayi1 * _sayi2;
        }
    }
}
