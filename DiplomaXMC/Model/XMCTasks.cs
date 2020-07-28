using System;
using System.Collections.Generic;
using System.Text;

namespace DiplomaXMC.Model
{
    public class XMCTasks
    {
        public long XMCTask_Id { get; set; }
        public string Task_Name { get; set; }
        public string Task_Description { get; set; }
        public long Creator_Id { get; set; }
        public long Referencer_Id { get; set; }
        public long XMCPune_Id { get; set; }
        public long XMCProjekt_Id { get; set; }
        public long XMCTipologjia_Id { get; set; }
    }
}
