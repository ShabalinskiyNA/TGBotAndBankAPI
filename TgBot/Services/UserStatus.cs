using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using TgBot.Services;

namespace TgBot.Services
{
    static class UserStatus
    {
        private static Dictionary<long, HandlerSteps> _userStatuses = new Dictionary<long, HandlerSteps>();
        private static Dictionary<long, string> userMes = new Dictionary<long, string>();
        
        public static void AddUser(long userId)
        {
            while( _userStatuses.ContainsKey(userId) )
            {
                _userStatuses.Remove(userId);
            }
            while(userMes.ContainsKey(userId) )
            {
                userMes.Remove(userId);
            }


            HandlerSteps nowStep = ResponseWriters.WriteCurrency;
            _userStatuses.Add(userId, nowStep);
        }
        public static void RemoveUser(long userId)
        {
            while (_userStatuses.ContainsKey(userId))
            {
                _userStatuses.Remove(userId);
            }
        }

        public static HandlerSteps GetUserState(long userId)
        {
            return _userStatuses[userId];
        }

        public static void AddMessageText(long userId, string message)
        {
            while (userMes.ContainsKey(userId))
            {
                userMes.Remove(userId);
            }
            userMes.Add(userId, message);
        }
        public static string GetUserMessage(long userId)
        {
            return userMes[userId];
        }
        public static void NextStatusStep(long userId, HandlerSteps newStep)
        {
            _userStatuses[userId] = newStep;
        }
        public static void RemoveMes(long userId)
        {
            while (userMes.ContainsKey(userId))
            {
                userMes.Remove(userId);
            }
        }
    }
}
