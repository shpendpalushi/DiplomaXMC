using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiplomaXMC.Model
{
    public class XMCUsers
    {
        public long Id { set; get; }
        public string Full_Name { set; get; }
        public string Email { set; get; }
        public string Username { set; get; }
        public string Description { set; get; }
        public string Password { set; get; }
        public long PozicionId { set; get; }


    }
}
