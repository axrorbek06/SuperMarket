using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            DBServis db = new DBServis();

            /// 1 
            //db.Create("water", 3000 , 1);

            /// 2
            db.ReadAll();

            ///3
            //db.ReadById(3);

            /// 4
            //db.Update(1 , "Coca-Cola" , 8000 , 1);
            //db.ReadAll();

            /// 5
            //db.Delete(4);
            //db.ReadAll();

            /// 6
            //db.ReadPriceBYNum(5000);

            /// 7
            //db.ReadByName("pepsi");

            /// 8
            //db.CreateCategory("beverage");
            //db.CreateCategory("sweet");
            //db.CreateCategory("fruit");

            /// 9 
            //db.UpdateCategory(1 , 1);
            //db.UpdateCategory(2 , 2);
            //db.UpdateCategory(3 , 1);
            //db.UpdateCategory(7 , 1);
            //db.UpdateCategory(5 , 1);
            //db.UpdateCategory(6 , 3);
            //db.UpdateCategory(8 , 3);
            //db.ReadAll();

            /// 10
            //db.ReadByCategory(3);









        }
    }
}
