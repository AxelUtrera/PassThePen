using Domain;
using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.ServiceModel;
using System.ServiceModel.Configuration;
using System.Text;                                
using System.Threading.Tasks;

namespace Comunication
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public partial class ImplementationServices : IPlayerManagement
    {
        PlayerLogic playerLogic = new PlayerLogic();

        public int AddPlayer(Player player)
        {
            return playerLogic.AddPlayer(player);
        }

        public int UpdateDataPlayer(string username, Player player)
        {
            return playerLogic.UpdateDataPlayer(username, player);
        }

        public Player GetDataPlayer(string username)
        {
            return playerLogic.ObtainPlayerData(username);
        }

        public int UpdatePlayerPassword(string username, string password)
        {
            return playerLogic.UpdatePassword(username, password);
        }

        public int UpdatePassword(string email, string password)
        {
            return playerLogic.UpdatePasswordEmail(email, password);
        }

        public Friends[] GetFriends(String username)
        {
            List<Friends> friends = playerLogic.RecoverFriends(username);
            return friends.ToArray();
        }

        public int DeleteFriend(Friends friendToDelete)
        {
            return playerLogic.DeleteFriend(friendToDelete);
        }

        public int FindPlayer(string username)
        {
            return playerLogic.FindPlayer(username);
        }

        public int AddGuestFriend(string usernamePlayer)
        {
            return playerLogic.AddGuestFriend(usernamePlayer);
        }
    }

    public partial class ImplementationServices : IAutentication
    {
        Log log = new Log();
        public int AutenticatePlayer(Player player)
        {
            PlayerLogic newPlayerLogic = new PlayerLogic();
            return newPlayerLogic.AutenticatePlayer(player);
        }

        public int AutenticateEmail(string email)
        {
            PlayerLogic playerNewLogic = new PlayerLogic();
            return playerNewLogic.AutenticateEmail(email);
        }

        public int CodeEmail(string to, String affair, int validationCode)
        {
            SendEmail sendEmail = new SendEmail();
            return sendEmail.SendNewEmail(to, affair, validationCode);
        }

        public int FindPlayerIsConected(string usernamePlayer)
        {
            int isConected = 200;
            const int userNotConected = 404;
            try
            {
                if (_usersConnected.FirstOrDefault(user => user.username.Equals(usernamePlayer)) == null)
                {
                    isConected = userNotConected;
                }
            }
            catch (ArgumentNullException ex)
            {
                log.Add(ex.ToString());
            }
            return isConected;
        }

    }

    public partial class ImplementationServices : IFriendRequests
    {
        FriendRequestsLogic friendRequestLogic = new FriendRequestsLogic();

        public int AcceptFriendRequest(FriendRequest friendRequest)
        {
            return friendRequestLogic.AcceptFriendRequest(friendRequest);
        }

        public int DeclineFriendRequests(FriendRequest friendRequest)
        {
            return friendRequestLogic.DeleteFriendRequest(friendRequest);
        }

        public List<FriendRequest> GetFriendRequestsList(string username)
        {
            return friendRequestLogic.GetFriendRequestsOfPlayer(username);
        }

        public int SendFriendRequests(FriendRequest friendRequest)
        {
            return friendRequestLogic.SendFriendRequests(friendRequest);
        }
    }


    public partial class ImplementationServices : IPlayerConnection
    {
        private List<ConnectedUser> _usersConnected = new List<ConnectedUser>();
        private List<ConnectedUser> _playersInGroup = new List<ConnectedUser>();

        public void Connect(string username)
        {
            ConnectedUser user = new ConnectedUser()
            {
                username = username,
                operationContext = OperationContext.Current,
                score = 0
            };

            _usersConnected.Add(user);
        }


        public void Disconnect(string username)
        {
            try
            {
                var user = _usersConnected.FirstOrDefault(i => i.username == username);
                if (user != null)
                {
                    _usersConnected.Remove(user);
                }
            }
            catch (ArgumentNullException ex)
            {
                log.Add(ex.ToString());
            }            
        }


        public List<string> GetNameOnlinePlayers()
        {
            List<string> onlinePlayers = new List<string>();
            foreach (ConnectedUser player in _usersConnected)
            {
                onlinePlayers.Add(player.username);
            }

            return onlinePlayers;
        }


        public void SendOnlinePlayers(string username)
        {
            try
            {
                Friends[] friends = GetFriends(username);
                _usersConnected.Find(us => us.username.Equals(username)).operationContext.GetCallbackChannel<IPlayersServicesCallBack>().RechargeFriends(friends);
            }
            catch (ArgumentNullException ex)
            {
                log.Add(ex.ToString());
            }
        }


        public void SendMathInvitation(string invitingPlayer, string invitedPlayer)
        {        
            const int invitationAcepted = 200;
            const int userNotFound = 404;
            
            try
            {
                ConnectedUser userConnected = _usersConnected.FirstOrDefault(user => user.username.Equals(invitedPlayer));
                ConnectedUser matchHost = _usersConnected.FirstOrDefault(user => user.username.Equals(invitingPlayer));

                if (userConnected.operationContext.GetCallbackChannel<IPlayersServicesCallBack>().NotifyMatchInvitation(invitingPlayer) == invitationAcepted)
                {
                    
                    if (FindPlayerInGroup(invitingPlayer) == userNotFound)
                    {
                        matchHost.hostState = true;
                        _playersInGroup.Add(matchHost);
                    }

                    _playersInGroup.Add(userConnected);
                    foreach (ConnectedUser playerInGroup in _playersInGroup)
                    {
                        playerInGroup.operationContext.GetCallbackChannel<IPlayersServicesCallBack>().GetDataPlayersInGoup();
                        playerInGroup.operationContext.GetCallbackChannel<IPlayersServicesCallBack>().VisualizeButtonLeaveGroup();
                    }
                }
            }
            catch (ArgumentNullException ex)
            {
                log.Add(ex.ToString());
            }
        }


        public void LeaveGroup(string usernamePlayer)
        {
            try
            {
                ConnectedUser player = _playersInGroup.FirstOrDefault(i => i.username == usernamePlayer);

                if (player != null)
                {
                    if (player.hostState)
                    {
                        LeaveHost(player);                       
                    }

                    _playersInGroup.Remove(player);
                    foreach (ConnectedUser playerInGroup in _playersInGroup)
                    {
                        playerInGroup.operationContext.GetCallbackChannel<IPlayersServicesCallBack>().GetDataPlayersInGoup();
                    }
                }

                if (_playersInGroup.Count == 1)
                {
                    _playersInGroup.Clear();
                }
            }
            catch (ArgumentNullException ex)
            {
                log.Add(ex.ToString());
            }
        }


        private void LeaveHost(ConnectedUser host)
        {
            _playersInGroup.Remove(host);

            foreach (ConnectedUser usersInGroup in _playersInGroup)
            {
                usersInGroup.operationContext.GetCallbackChannel<IPlayersServicesCallBack>().OpenExitHostMessage();
            }

            _playersInGroup.Clear();
        }


        public int FindPlayerInGroup(string usernameToFind)
        {
            int statusUser = 200;
            const int userNotFound = 404; 

            try
            {
                if (_playersInGroup.FirstOrDefault(user => user.username.Equals(usernameToFind)) == null)
                {
                    statusUser = userNotFound;
                }
            }
            catch (ArgumentNullException ex)
            {
                log.Add(ex.ToString());
            }
            return statusUser;
        }


        public int GroupIsNotFull()
        {
            int statusCode = 500;

            if (_playersInGroup.Count < 6)
            {
                statusCode = 200;
            }

            return statusCode;
        }


        public List<Player> GetListPlayersInGroup()
        {
            PlayerLogic playerLogicGroup  = new PlayerLogic();
            List<Player> groupPlayers = new List<Player>();

            foreach (ConnectedUser playerInGroup in _playersInGroup)
            {
                Player dataPlayer = playerLogicGroup.ObtainPlayerData(playerInGroup.username);

                if (dataPlayer != null)
                {
                    groupPlayers.Add(dataPlayer);
                }
            }

            return groupPlayers;
        }


        public void StartMatch(string username)
        {
            ConnectedUser user = _playersInGroup.FirstOrDefault(u => u.username.Equals(username));

            if (user.hostState)
            {
                foreach (ConnectedUser connectedUser in _playersInGroup)
                {
                    connectedUser.operationContext.GetCallbackChannel<IPlayersServicesCallBack>().OpenMatchWindow();
                }
            }
            else
            {
                user.operationContext.GetCallbackChannel<IPlayersServicesCallBack>().NotifyOnlyHostStart();
            }
        }
    }



    public partial class ImplementationServices : IMatchManagement
    {
        private int _turnNumber = 0;
        private Dictionary<string, byte[]> _playersDraws = new Dictionary<string, byte[]>();


        public void SelectTurnTime()
        {
            try
            {
                int[] seconds = { 15, 20, 25, 30 };
                Random random = new Random();
                int time = seconds[random.Next(seconds.Length)];

                foreach (ConnectedUser user in _playersInGroup)
                {
                    user.matchContext.GetCallbackChannel<IMatchCallback>().DistributeTurnTime(time);
                }
            }
            catch (ArgumentOutOfRangeException ex)
            {
                log.Add(ex.ToString());
            }
        }


        public void SendCard(string card)
        {
            foreach (ConnectedUser user in _playersInGroup)
            {
                user.matchContext.GetCallbackChannel<IMatchCallback>().DistributeCard(card);
            }
        }


        public void SetMatchOperationContext(string username)
        {
            foreach (var user in _playersInGroup.Where(user => user.username.Equals(username)))
            {
                user.matchContext = OperationContext.Current;
            }
        }


        public void StartTurnSignal(string username)
        {
            _turnNumber++;
            if (_turnNumber == 11)
            {
                ObtainMatchWinner();
            }
            else
            {
                foreach (ConnectedUser matchUser in _playersInGroup)
                {
                    matchUser.matchContext.GetCallbackChannel<IMatchCallback>().ReturnStartTurnSignal(_turnNumber);
                }
            }
        }


        public void SendDraws(string username, byte[] draw)
        {
            try
            {
                _playersDraws.Add(username, draw);

                if (_playersDraws.Count == _playersInGroup.Count)
                {
                    foreach (ConnectedUser player in _playersInGroup)
                    {
                        player.matchContext.GetCallbackChannel<IMatchCallback>().DistributeDraws(_playersDraws);
                    }
                    _playersDraws.Clear();
                }
            }
            catch (ArgumentNullException ex)
            {
                log.Add(ex.ToString());
            }
        }


        public Dictionary<string, int> GetPlayersScore()
        {
            Dictionary<string, int> playersScore = new Dictionary<string, int>();
            try
            {
                foreach (ConnectedUser user in _playersInGroup)
                {
                    playersScore.Add(user.username, user.score);
                }
            }
            catch (ArgumentNullException ex)
            {
                log.Add(ex.ToString());
            }
            return playersScore;
        }


        public void ObtainMatchWinner()
        {
            try
            {
                const int operationValid = 200;
                int maxScore = _playersInGroup.Max(s => s.score);
                ConnectedUser winner = _playersInGroup.FirstOrDefault(w => w.score == maxScore);

                MatchLogic matchLogic = new MatchLogic();
                int result = matchLogic.AddMatchWinner(winner.username);
                _playersDraws.Clear();
                _turnNumber = 0;

                if (result == operationValid)
                {
                    foreach (ConnectedUser player in _playersInGroup)
                    {
                        _usersConnected.First(u => u.username == player.username).score = 0;
                        player.hostState = false;
                        player.matchContext.GetCallbackChannel<IMatchCallback>().NotifyWinner(winner.username);
                    }
                    _playersInGroup.Clear();
                }
            }
            catch (ArgumentNullException ex)
            {
                log.Add(ex.ToString());
            }
        }


        public bool GetHostState(string username)
        {
            ConnectedUser user = _playersInGroup.FirstOrDefault(w => w.username == username);
            return user.hostState;
        }


        public void RemoveMatchPlayer(string username)
        {
            try
            {
                ConnectedUser removedPlayer = _playersInGroup.FirstOrDefault(u => u.username == username);
                removedPlayer.matchContext.GetCallbackChannel<IMatchCallback>().CloseMatchWindow();
                _usersConnected.First(u => u.username == removedPlayer.username).score = 0;

                _playersInGroup.Remove(removedPlayer);
                _playersDraws.Remove(removedPlayer.username);

                foreach (ConnectedUser user in _playersInGroup)
                {
                    user.matchContext.GetCallbackChannel<IMatchCallback>().UpdateMatchPlayers();
                }
            }
            catch (ArgumentNullException ex)
            {
                log.Add(ex.ToString());
            }
        }

        public void LeaveMatch(string username)
        {
            try
            {
                ConnectedUser leavePlayer = _playersInGroup.FirstOrDefault(u => u.username == username);

                if (leavePlayer.hostState)
                {
                    KickAllPlayers();
                }
                else if(_playersInGroup.Count == 2)
                {
                    KickAllPlayers();
                }
                else
                {
                    leavePlayer.matchContext.GetCallbackChannel<IMatchCallback>().CloseMatchWindow();
                    _usersConnected.First(u => u.username == leavePlayer.username).score = 0;
                    _playersInGroup.Remove(leavePlayer);

                    foreach (ConnectedUser user in _playersInGroup)
                    {
                        user.matchContext.GetCallbackChannel<IMatchCallback>().UpdateMatchPlayers();
                    }
                }
            }
            catch (ArgumentNullException ex)
            {
                log.Add(ex.ToString());
            }
        }

        private void KickAllPlayers()
        {
            foreach (ConnectedUser user in _playersInGroup)
            {
                user.hostState = false;
                _usersConnected.First(u => u.username == user.username).score = 0;
                user.matchContext.GetCallbackChannel<IMatchCallback>().CloseMatchWindow();
            }

            _playersInGroup.Clear();
            _playersDraws.Clear();
            _turnNumber = 0;
        }
    }


    public partial class ImplementationServices : IChatServices
    {
        public void SendMessage(string senderUsername, string message)
        {
            ChatLogic chatLogic = new ChatLogic();
            string completeMessage = chatLogic.BuildMessage(senderUsername, message);

            foreach (ConnectedUser user in _playersInGroup)
            {
                user.chatContext.GetCallbackChannel<IChatServiceCallback>().MessageSend(completeMessage);
            }

        }

        public void SetChatOperationContext(string username)
        {
            foreach (var user in _playersInGroup.Where(user => user.username.Equals(username)))
            {
                user.chatContext = OperationContext.Current;
            }
        }
    }


    public partial class ImplementationServices : IDrawReviewService
    {
        public void AddPlayerScore(Dictionary<string, int> playerScore)
        {
            foreach(ConnectedUser player in _playersInGroup)
            {
                player.score += playerScore.FirstOrDefault(x => x.Key == player.username).Value;
            }
        }


        public void SetDrawReviewContext(string username)
        {
            foreach (var player in _playersInGroup.Where(player => player.username.Equals(username)))
            {
                player.drawContext = OperationContext.Current;
            }
        }
    }

}
