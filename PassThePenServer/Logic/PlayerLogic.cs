using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class PlayerLogic
    {

        public int AutenticatePlayerDB(string username, string password)
        {
            int userResult = 500;
            string passwordHash = Encription.ToSHA2Hash(password);
            using (var dataBase = new DataAccess.passthepenEntities())
            {
                dataBase.Database.Log = Console.WriteLine;
                var user = (from Player in dataBase.Player
                            where Player.username.Equals(username)
                            && Player.password.Equals(passwordHash)
                            select Player).Count();

                if (user > 0)
                {
                    userResult = 200;
                }
            }

            return userResult;
        }

    }
}
