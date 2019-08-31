namespace Shoot
{
    public class Mission
    {
        public MissionDatabase.Data data;
        private string missionName;

        public Mission(string mission)
        {
            this.missionName = mission;
            this.data = MissionDatabase.GetMission(missionName);
        }

        public void RefreshMission()
        {
            this.data = MissionDatabase.GetMission(missionName);
        }
    }
}