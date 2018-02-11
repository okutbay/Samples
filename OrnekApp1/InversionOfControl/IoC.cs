using System;
using System.Collections.Generic;
using System.Text;

namespace OrnekApp1.InversionOfControl
{
    public class IoC
    {
        public IoC()
        {
            //Injection via Constructor
            MyClass someInstanceOfMyClass1 = new MyClass(new MyOtherDependencyClass());
            someInstanceOfMyClass1.DoSomething();

            //Injection via Property
            MyClass someInstanceOfMyClass2 = new MyClass();
            someInstanceOfMyClass2.MyDependency = new MyOtherDependencyClass();
            someInstanceOfMyClass2.DoSomething();

            //Injection via Method
            MyClass someInstanceOfMyClass3 = new MyClass();
            someInstanceOfMyClass3.InjectViaMethod(new MyOtherDependencyClass());
            someInstanceOfMyClass3.DoSomething();

            //Injection via Service Locator
            MyClass someInstanceOfMyClass4 = new MyClass(1);
            someInstanceOfMyClass4.DoSomething();
        }

        public interface IMyDependencyClass
        {
            string GetData();
        }

        public class MyDependencyClass : IMyDependencyClass
        {
            public string GetData()
            {
                return "Got data";
            }
        }

        public class MyOtherDependencyClass : IMyDependencyClass
        {
            public string GetData()
            {
                return "Got another data";
            }
        }

        public class MySomeOtherDependencyClass : IMyDependencyClass
        {
            public string GetData()
            {
                return "Got some another data";
            }
        }

        public class MyClass
        {
            private IMyDependencyClass _dependency;

            public MyClass()
            {
                //Default constructer is needed for 
                //Injection via Property and
                //Injection via Method
            }

            #region Injection via Constructor
            //Injection via Constructor
            public MyClass(IMyDependencyClass dependency)
            {
                this._dependency = dependency;
            }
            #endregion

            #region Injection via Property
            //Injection via Property
            public IMyDependencyClass MyDependency
            {
                set
                {
                    _dependency = value;
                }
            }
            #endregion

            #region Injection via Method
            //Injection via Method
            public void InjectViaMethod(IMyDependencyClass dependency)
            {
                this._dependency = dependency;
            }
            #endregion

            #region Injection via Service Locator
            //Injection via Service Locator
            MyServiceLocator sl = new MyServiceLocator();
            public MyClass(int index)
            {
                this._dependency = sl.LocateDependency(index);
            }

            class MyServiceLocator
            {
                public IMyDependencyClass LocateDependency(int index)
                {
                    if (index == 1)
                        return new MyOtherDependencyClass();
                    else if (index == 2)
                        return new MySomeOtherDependencyClass();
                    else
                        return new MyDependencyClass();
                }
            }
            #endregion

            public string DoSomething()
            {
                //we are calling injected class' method 
                return this._dependency.GetData();
            }
        }
    }
}
