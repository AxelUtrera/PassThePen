using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Class1
    {
        public Boolean insertDataTest()
        {
            bool result = false;
            using (var context = new DataAccess.passthepenEntities())
            {
             
                var insert = context.Player.Add(new Player() { username = "j1000", lastname = "morales", name = "axel", email = "1234", password = "admin"});
                context.SaveChanges();

                if (insert != null)
                {
                    result = true;
                }
            };

            return result;
           
        }
    }
}
