using DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class PlayerLogic
    {

        public  int AutenticatePlayerDB(Player player)
        {
            int userResult = 500;
            string passwordHash = Encription.ToSHA2Hash(player.password);
            using (var dataBase = new passthepenEntities())
            {
                dataBase.Database.Log = Console.WriteLine;
                var user = (from Player in dataBase.Player
                            where Player.email.Equals(player.email)
                            && Player.password.Equals(passwordHash)
                            select Player).Count();

                
                if (user > 0)
                {
                    userResult = 200;
                }
            }

            return userResult;
        }

        public static int AddPlayerToDB(Player player)
        {
            int statusCode = 500;
            using (var dataBase = new passthepenEntities())
            {
                dataBase.Database.Log = Console.WriteLine;
                var newPlayer = dataBase.Player.Add(new Player()
                {
                    email = player.email,
                    username = player.username,
                    name = player.name,
                    lastname = player.lastname,
                    password = Encription.ToSHA2Hash(player.password)
                });
                dataBase.SaveChanges();

                if (newPlayer != null)
                {
                    statusCode = 200;
                }
            }
            return statusCode;
        }
    }
}
