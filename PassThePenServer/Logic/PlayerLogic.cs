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

        public int AutenticateEmail(string email)
        {
            int emailResult = 500;
            using (var dataBase = new DataAccess.passthepenEntities())
            {
                var playerEmail = (from Player in dataBase.Player where
                                   Player.email.Equals(email) select Player).Count();
                if(playerEmail > 0)
                {
                    emailResult = 200;
                }
            }
            return emailResult;
        }

    }
}
