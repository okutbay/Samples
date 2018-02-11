using System;
using System.Collections.Generic;
using System.Text;

namespace OrnekApp1.InversionOfControl
{
    public class Classic
    {
        public class MyDependencyClass
        {
            public void GetData()
            {
                throw new Exception("Got data");
            }
        }

        public class MyClass
        {
            private MyDependencyClass _dependency;

            public MyClass()
            {
                //MyClass dependent on the MyDependencyClass and responsible for creating a new instance
                this._dependency = new MyDependencyClass();
            }

            public void DoSomething()
            {
                this._dependency.GetData();
            }

        }
    }
}
