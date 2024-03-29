﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PoointWebApi.Model
{
    public class Chats
    {
        public int Id { get; set; }
        public int UserId1 { get; set; }
        public int UserId2 { get; set; }
        public string Username1 { get; set; }
        public string Username2 { get; set; }
    }

    public class ChatsById
    {
        public int Id { get; set; }
    }

    public class ChatsIds
    {
        public int UserId1 { get; set; }
        public int UserId2 { get; set; }
    }
}
