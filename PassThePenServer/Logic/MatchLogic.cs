using DataAccess;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class MatchLogic
    {
        private readonly Log _log = new Log();


        public int AddMatchWinner(string username)
        {
            int statusCode = 500;

            using (var database = new passthepenEntities())
            {
                try
                {
                    var newWinner = database.Game.Add(new Game()
                    {
                        winner = username
                    });
                    database.SaveChanges();

                    if (newWinner != null)
                    {
                        statusCode = 200;
                    }
                }
                catch (DbUpdateException ex)
                {
                    _log.Add(ex.ToString());
                }
                catch (EntityException ex)
                {
                    _log.Add(ex.ToString());
                }
            }
            return statusCode;
        }
    }
}
