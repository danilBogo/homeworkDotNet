namespace DatabaseBusinessLogic.Models
{
    public class JsonModel
    {
        public PlayerModel PlayerModel { get; set; }
        
        public MonsterModel MonsterModel { get; set; }

        public JsonModel(PlayerModel playerModel, MonsterModel monsterModel)
        {
            PlayerModel = playerModel;
            MonsterModel = monsterModel;
        }
    }
}