using System;
using System.Reflection;

namespace Рефлексия
{
    class Program
    {
        static void Main(string[] args)
        {

            MyTestClass mtc = new MyTestClass(12.0, 3.5);
            Reflect.MethodReflectInfo<MyTestClass>(mtc);

            Console.ReadLine();
        }
    }
    class MyTestClass
    {
        public double gg;
        public double gg1;
        public MyTestClass(double gg, double gg1)
        {
            this.gg = gg;
            this.gg1 = gg1;
        }
        public double Sum() { return gg + gg1;}

        public void Method() =>Console.WriteLine($"d = {0} f = {1}, {gg}, {gg} Тут сума ваших чисел");
        public void SumInt(int a, int b)
        {
            gg=(double)a;
            gg1=(double)b;
        }
        public void Set(double a, double b)
        {
            gg = a;
            gg1 = b;
        }
        public override string ToString()
        {
            return "MyTestClass";
        }

    }
    class Reflect
    {
        // Данный метод выводит информацию о содержащихся в классе методах
        public static void MethodReflectInfo<T>(T obj) where T : class
        {
            Type t = typeof(T);
            // Получаем коллекцию методов
            MethodInfo[] MArr = t.GetMethods();
            Console.WriteLine("\t\t*** Список методов класса {0} ***\n", obj.ToString());     
            foreach (MethodInfo m in MArr) 
            {
                Console.Write(" --> " + m.ReturnType.Name + " \t" + m.Name + "( ");
                // Вывести параметры методов
                ParameterInfo[] p = m.GetParameters();
                for (int i = 0; i < p.Length; i++)
                {
                  
                    Console.Write(p[i].ParameterType.Name + " " + p[i].Name);
                  //  Console.WriteLine("--------------------------------------");
                  //  Console.Write($"{p[i].ParameterType.Name} {p[i].Name}");
                    if (i + 1 < p.Length) Console.Write(", ");
                }
                Console.WriteLine(")");
            }
          //  Console.Write(")\n");
           // Console.Write(")");
        }
    }
}
