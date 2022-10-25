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

        public Player ObtainPlayerData(string username)
        {
            Player playerObtained = null;
            using (var dataBaseContext = new passthepenEntities())
            {
                //playerObtained = (((Player)(from Player in dataBaseContext.Player
                //                        where Player.username.Equals(username)
                //                      select Player)));

                playerObtained = dataBaseContext.Player.Find(username);
            }
            return playerObtained;
        }

        public Boolean UpdateDataPlayer(String username, Player player)
        {
            Boolean isUpdated = false;
            using (var dataBaseContext = new passthepenEntities())
            {
                var updatedPlayer = dataBaseContext.Player.First(u => u.username == username);
                updatedPlayer.name = player.name;
                updatedPlayer.lastname = player.lastname;
                updatedPlayer.email = player.email;
                updatedPlayer.profileImage = player.profileImage;
                int returnValue = dataBaseContext.SaveChanges();
                if (returnValue > 0)
                {
                    isUpdated = true;
                }
            }
            return isUpdated;
        }

        public Boolean UpdatePassword(string username, string password)
        {
            Boolean isChanged = false;
            string encriptedPassword = Encription.ToSHA2Hash(password);
            using (var dataBaseContext = new passthepenEntities())
            {
                var updatedPassword = dataBaseContext.Player.First(u => u.username == username);
                updatedPassword.password = encriptedPassword;
                int returnValue = dataBaseContext.SaveChanges();
                if (returnValue > 0)
                {
                    isChanged = true;
                }
            }
            return isChanged;
        }

    }
}
