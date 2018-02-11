using System;

namespace OrnekApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }



    public class OrderService
    {
        private IOrderSaver orderSaver;

        public OrderService(IOrderSaver orderSaver)
        {
            this.orderSaver = orderSaver;
        }

        public void AcceptOrder(Order order)
        {
            //Domain logic such as validation

            orderSaver.SaveOrder(order);


            //service locator
            //OrderSaverFactory.GetOrderSaver().SaveOrder(order);
        }
    }


    public class Order
    {

    }


    public class OrderDatabase: IOrderSaver
    {
        public void SaveOrder(Order order)
        {
            throw new ApplicationException("I need a database to work");
        }
    }

    public class IOrderSaver
    {
        public void SaveOrder(Order order) { }
    }


    //public class ServiceLocator
    //{
    //    public static IOrderSaver OrderSaver { get; set; }

    //    public static IOrderSaver GetOrderSaver()
    //    {
    //        if (OrderSaver == null)
    //            OrderSaver = new OrderDatabase();

    //        return OrderSaver;
    //    }
    //}





}
