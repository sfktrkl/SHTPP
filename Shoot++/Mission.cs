namespace Shoot
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