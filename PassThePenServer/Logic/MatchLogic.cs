using DataAccess;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class MatchLogic
    {
        public int AddMatchWinner(string username)
        {
            int statusCode = 500;

            using (var database = new passthepenEntities())
            {
                var newWinner = database.Game.Add(new Game()
                {
                    winner = username
                });
                database.SaveChanges();

                if(newWinner != null)
                {
                    statusCode = 200;
                }
            }
            return statusCode;
        }
    }
}
