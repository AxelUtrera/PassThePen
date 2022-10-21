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
        public int AddPlayer(DataAccess.Player player)
        {
            return PlayerLogic.AddPlayerToDB(player);
        }

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
    }
}
