using DataAccess;
using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comunication
{
    public class PlayerMgt : IPlayerMgt
    {
        public int AddPlayer(Player player)
        {
            return 1;
        }

        public int AutenticatePlayer(string username, string password)
        {
            return 1;
        }

        public int AutenticateEmail(string email)
        {
            PlayerLogic playerLogic = new PlayerLogic();
            return playerLogic.AutenticateEmail(email); 
        }
    }
}
