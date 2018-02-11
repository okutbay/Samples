using System;
using static OrnekApp1.InversionOfControl.IoC;

namespace OrnekApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            string returnValue = string.Empty;

            //Injection via Constructor
            MyClass someInstanceOfMyClass1 = new MyClass(new MyDependencyClass());
            returnValue = someInstanceOfMyClass1.DoSomething();
            Console.WriteLine(returnValue);

            //Injection via Property
            MyClass someInstanceOfMyClass2 = new MyClass();
            someInstanceOfMyClass2.MyDependency = new MyOtherDependencyClass();
            returnValue = someInstanceOfMyClass2.DoSomething();
            Console.WriteLine(returnValue);

            //Injection via Method
            MyClass someInstanceOfMyClass3 = new MyClass();
            someInstanceOfMyClass3.InjectViaMethod(new MySomeOtherDependencyClass());
            returnValue = someInstanceOfMyClass3.DoSomething();
            Console.WriteLine(returnValue);

            //Injection via Service Locator
            MyClass someInstanceOfMyClass4 = new MyClass(5);
            returnValue = someInstanceOfMyClass4.DoSomething();
            Console.WriteLine(returnValue);

            Console.ReadLine();
        }
    }
}
