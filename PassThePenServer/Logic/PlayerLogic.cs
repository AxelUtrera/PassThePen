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

        public  int AutenticatePlayerDB(Domain.Player player)
        {
            int userResult = 500;
            string passwordHash = Encription.ToSHA2Hash(player.password);
            using (var dataBase = new passthepenEntities())
            {
                dataBase.Database.Log = Console.WriteLine;
                var user = (from Player in dataBase.Player
                            where Player.username.Equals(player.username)
                            && Player.password.Equals(passwordHash)
                            select Player).Count();
                if (user > 0)
                {
                    userResult = 200;
                }
            }
            return userResult;
        }

        public static int AddPlayerToDB(Domain.Player player)
        {
            //Tarea: Validar que no exista el usuario a agregar en la base de datos.
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
                    password = Encription.ToSHA2Hash(player.password),
                    profileImage = player.profileImage
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
            using (var dataBase = new passthepenEntities())
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


        public Domain.Player ObtainPlayerData(string username)
        {
            Domain.Player playerSend = null;
            using (var dataBaseContext = new passthepenEntities())
            {
                Player playerObtained = dataBaseContext.Player.Find(username);
                playerSend = new Domain.Player()
                {
                    username = playerObtained.username,
                    name = playerObtained.name,
                    lastname = playerObtained.lastname,
                    email = playerObtained.email,
                    profileImage = playerObtained.profileImage
                };
            }
            return playerSend;
        }


        public int UpdateDataPlayer(String username, Domain.Player player)
        {
            int stateCode = 500;
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
                    stateCode = 200;
                }
            }
            return stateCode;
        }

        public int UpdatePassword(string username, string password)
        {
            int stateCode = 500;
            string encriptedPassword = Encription.ToSHA2Hash(password);
            using (var dataBaseContext = new passthepenEntities())
            {
                var updatedPassword = dataBaseContext.Player.First(u => u.username == username);
                updatedPassword.password = encriptedPassword;
                int returnValue = dataBaseContext.SaveChanges();
                if (returnValue > 0)
                {
                    stateCode = 200;
                }
            }
            return stateCode;
        }


        public int UpdatePasswordEmail(string email, string password)
        {
            int result = 500;
            string encriptedPassword = Encription.ToSHA2Hash(password);
            using (var dataBaseContext = new passthepenEntities())
            {
                var updatePasswordEmail = dataBaseContext.Player.First(e => e.email == email);
                updatePasswordEmail.password = encriptedPassword;
                int returnValue = dataBaseContext.SaveChanges();
                if (returnValue > 0)
                {
                    result = 200;
                }
            }
            return result;
        }

        public List<Domain.Friends> RecoverFriends(string username)
        {
            List<Domain.Friends> friendsList = new List<Domain.Friends>();
            using (var dataBaseContext = new passthepenEntities())
            {
                try
                {
                   var friends = (from Friends in dataBaseContext.Friends
                                   where
                                   Friends.usernamePlayer == username
                                   select Friends).ToList();
                    for(int index = 0; index < friends.Count(); index++)
                    {
                        Domain.Friends newFriend = new Domain.Friends();
                        newFriend.idPlayerFriends = friends[index].idFriend;
                        newFriend.username = friends[index].usernamePlayer;
                        newFriend.friendUsername = friends[index].friendUsername;
                        friendsList.Add(newFriend);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                }
            }
            return friendsList;
        }


        public int DeleteFriend(Domain.Friends friend)
        {
            int operationResult = 500;

            using (var context = new passthepenEntities())
            {
                var friendToDeleted = context.Friends.Where(u => u.usernamePlayer.Equals(friend.username) && u.friendUsername.Equals(friend.friendUsername)).First();
                var deletedToFriend = context.Friends.Where(u => u.usernamePlayer.Equals(friend.friendUsername) && u.friendUsername.Equals(friend.username)).First();

                if(friendToDeleted != null && deletedToFriend != null)
                {
                    context.Friends.Remove(friendToDeleted);
                    context.Friends.Remove(deletedToFriend);
                    context.SaveChanges();
                    operationResult = 200;
                }
            }

            return operationResult;
        }

      
    }
}
