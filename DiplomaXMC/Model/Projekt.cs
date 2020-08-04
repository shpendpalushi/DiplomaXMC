using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiplomaXMCWS.ViewModel
{
    public class Projekt
    {
        public long XMCProjekt_Id { get; set; }
        public string Projekt_Name { get; set; }
        public int Projekt_Hours_Precalculated { get; set; }
        public string Projekt_Description { get; set; }
    }
}