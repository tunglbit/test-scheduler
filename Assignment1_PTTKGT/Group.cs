using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1_PTTKGT
{
    class Group
    {
        private string groupId = null;

        public string GroupId
        {
            get { return groupId; }
            set { groupId = value; }
        }
        private string team = null;

        public string Team
        {
            get { return team; }
            set { team = value; }
        }

        public Group(string group, string team)
        {
            this.groupId = group;
            this.team = team;
        }
    }
}
