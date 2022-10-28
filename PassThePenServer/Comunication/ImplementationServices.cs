using DataAccess;
using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comunication
{
    public partial class ImplementationServices : IPlayerManagement
    {
        public int AddPlayer(DataAccess.Player player)
        {
            return PlayerLogic.AddPlayerToDB(player);
        }

        public int UpdateDataPlayer(string username, Player player)
        {
            PlayerLogic playerLogic = new PlayerLogic();
            return playerLogic.UpdateDataPlayer(username, player);
        }

        public Player GetDataPlayer(string username)
        {
            PlayerLogic playerLogic = new PlayerLogic();
            return playerLogic.ObtainPlayerData(username);
        }

        public int UpdatePlayerPassword(string username, string password)
        {
            PlayerLogic playerLogic = new PlayerLogic();
            return playerLogic.UpdatePassword(username, password);
        }

        public int UpdatePassword(string SendEmail, string password)
        {
            PlayerLogic playerLogic = new PlayerLogic();
            return playerLogic.UpdatePasswordEmail(SendEmail, password);
        }
    }

    public partial class ImplementationServices : IAutentication
    {
        public int AutenticatePlayer(DataAccess.Player player)
        {
            PlayerLogic playerLogic = new PlayerLogic();
            return playerLogic.AutenticatePlayerDB(player);
        }

        public int AutenticateEmail(string email)
        {
            PlayerLogic playerLogic = new PlayerLogic();
            return playerLogic.AutenticateEmail(email);
        }

        public int CodeEmail(string to, String affair, int validationCode)
        {
            SendEmail sendEmail = new SendEmail();
            return sendEmail.SendNewEmail(to, affair, validationCode);
        }
    }
}
