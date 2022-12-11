using DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Core;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class PlayerLogic
    {
        private readonly Log log = new Log();

        public int AutenticatePlayer(Domain.Player player)
        {
            int userResult = 500;
            string passwordHash = Encription.ToSHA2Hash(player.password);
            try
            {
                using (var dataBase = new passthepenEntities())
                {
                    var user = (from Player in dataBase.Player
                                where Player.username.Equals(player.username)
                                && Player.password.Equals(passwordHash)
                                select Player).Count();
                    if (user > 0)
                    {
                        userResult = 200;
                    }
                }
            }
            catch(ArgumentNullException ex)
            {
                log.Add(ex.ToString());
            }
            catch (EntityException ex)
            {
                log.Add(ex.ToString());
            }
            return userResult;
        }


        public int AddPlayer(Domain.Player player)
        {
            //Tarea: Validar que no exista el usuario a agregar en la base de datos.
            int statusCode = 500;
            try
            {
                using (var dataBase = new passthepenEntities())
                {
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
            }
            catch (DbUpdateException ex)
            {
                log.Add(ex.ToString());
            }
            catch (EntityException ex)
            {
                log.Add(ex.ToString());
            }
            return statusCode;
        }


        public int AutenticateEmail(string email)
        {
            int emailResult = 500;
            try
            {
                using (var dataBase = new passthepenEntities())
                {
                    var playerEmail = (from Player in dataBase.Player
                                       where
                                       Player.email.Equals(email)
                                       select Player).Count();
                    if (playerEmail > 0)
                    {
                        emailResult = 200;
                    }
                }
            }
            catch (ArgumentNullException ex)
            {
                log.Add(ex.ToString());
            }
            catch (EntityException ex)
            {
                log.Add(ex.ToString());
            }
            return emailResult;
        }


        public int FindPlayer(string username)
        {
            int operationResult = 500;
            try
            {
                using (var context = new passthepenEntities())
                {
                    var userFound = context.Player.Find(username);

                    if (userFound != null)
                    {
                        operationResult = 200;
                    }
                }
            }
            catch (InvalidOperationException ex)
            {
                log.Add(ex.ToString());
            }
            catch (EntityException ex)
            {
                log.Add(ex.ToString());
            }
            return operationResult;
        }


        public Domain.Player ObtainPlayerData(string username)
        {
            Domain.Player playerSend = null;
            try
            {
                using (var dataBaseContext = new passthepenEntities())
                {
                    Player playerObtained = dataBaseContext.Player.Find(username);
                    if (playerObtained != null)
                    {
                        playerSend = new Domain.Player()
                        {
                            username = playerObtained.username,
                            name = playerObtained.name,
                            lastname = playerObtained.lastname,
                            email = playerObtained.email,
                            profileImage = playerObtained.profileImage
                        };
                    }
                }
            }
            catch(InvalidOperationException ex)
            {
                log.Add(ex.ToString());
            }
            catch (EntityException ex)
            {
                log.Add(ex.ToString());
            }
            return playerSend;
        }


        public int UpdateDataPlayer(String username, Domain.Player player)
        {
            int stateCode = 500;
            try
            {
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
            }
            catch (ArgumentNullException ex)
            {
                log.Add(ex.ToString());
            }
            catch (DbUpdateException ex)
            {
                log.Add(ex.ToString());
            }
            catch (EntityException ex)
            {
                log.Add(ex.ToString());
            }
            return stateCode;
        }


        public int UpdatePassword(string username, string password)
        {
            int stateCode = 500;
            try
            {
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
            }
            catch (ArgumentNullException ex)
            {
                log.Add(ex.ToString());
            }
            catch (DbUpdateException ex)
            {
                log.Add(ex.ToString());
            }
            catch (EntityException ex)
            {
                log.Add(ex.ToString());
            }
            return stateCode;
        }


        public int UpdatePasswordEmail(string email, string password)
        {
            int result = 500;
            try
            {
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
            }
            catch (ArgumentNullException ex)
            {
                log.Add(ex.ToString());
            }
            catch (DbUpdateException ex)
            {
                log.Add(ex.ToString());
            }
            catch (EntityException ex)
            {
                log.Add(ex.ToString());
            }
            return result;
        }

        public int AddGuestFriend(string username)
        {
            int operationResult = 500;
            try
            {
                using (var dataBaseContext = new passthepenEntities())
                {

                    var resultUserToGuest = dataBaseContext.Friends.Add(new Friends()
                    {
                        usernamePlayer = "Guest",
                        friendUsername = username
                    });

                    var resultGuestToUser = dataBaseContext.Friends.Add(new Friends()
                    {
                        usernamePlayer = username,
                        friendUsername = "Guest"
                    });

                    operationResult = dataBaseContext.SaveChanges();

                    if (resultUserToGuest != null && resultGuestToUser != null)
                    {
                        operationResult = 200;
                    }


                }
            }
            catch (DbUpdateException ex)
            {
                log.Add(ex.ToString());
            }
            catch (EntityException ex)
            {
                log.Add(ex.ToString());
            }
            return operationResult;
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
                    for (int index = 0; index < friends.Count; index++)
                    {
                        Domain.Friends newFriend = new Domain.Friends();
                        newFriend.idPlayerFriends = friends[index].idFriend;
                        newFriend.username = friends[index].usernamePlayer;
                        newFriend.friendUsername = friends[index].friendUsername;
                        friendsList.Add(newFriend);
                    }
                }
                catch (ArgumentNullException ex)
                {
                    log.Add(ex.ToString());
                }
                catch (EntityException ex)
                {
                    log.Add(ex.ToString());
                }
            }
            return friendsList;
        }


        public int DeleteFriend(Domain.Friends friend)
        {
            int operationResult = 500;

            try
            {
                using (var context = new passthepenEntities())
                {
                    var friendToDeleted = context.Friends.Where(u => u.usernamePlayer.Equals(friend.username) && u.friendUsername.Equals(friend.friendUsername)).First();
                    var deletedToFriend = context.Friends.Where(u => u.usernamePlayer.Equals(friend.friendUsername) && u.friendUsername.Equals(friend.username)).First();

                    if (friendToDeleted != null && deletedToFriend != null)
                    {
                        context.Friends.Remove(friendToDeleted);
                        context.Friends.Remove(deletedToFriend);
                        context.SaveChanges();
                        operationResult = 200;
                    }
                }
            }
            catch (ArgumentNullException ex)
            {
                log.Add(ex.ToString());
            }
            catch (DbUpdateException ex)
            {
                log.Add(ex.ToString());
            }
            catch (EntityException ex)
            {
                log.Add(ex.ToString());
            }
            return operationResult;
        }


    }
}
