namespace DatabaseBusinessLogic.Models
{
    public class BattleLogModel
    {
        public int PlayerHitPoints { get; set; }
        
        public string Logs { get; set; }

        public BattleLogModel(int playerHitPoints, string logs)
        {
            PlayerHitPoints = playerHitPoints;
            Logs = logs;
        }
    }
}