using System;
using System.Collections.Generic;
using System.Text;

namespace PoointWebApi.Model
{
    public class ChatsTeams
    {
        public string ChatName { get; set; }
    }

    public class ChatsTeamsById
    {
        public int Id { get; set; }
    }

    public class ChatsTeamsData
    {
        public int Id { get; set; }
        public string ChatName { get; set; }
    }
}
