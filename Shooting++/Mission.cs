using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shooting__
{
    public class Mission
    {
        public Mission(string mission)
        {
            this.missionData = MissionDatabase.GetMission(mission);
        }

        private MissionDatabase.Data missionData;

        public MissionDatabase.Data GetMission()
        {
            return missionData;
        }
    }
}
