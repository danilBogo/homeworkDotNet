namespace DatabaseBusinessLogic.Models
{
    public class JsonRequestModel
    {
        public PlayerModel PlayerModel { get; set; }
        
        public MonsterModel MonsterModel { get; set; }

        public JsonRequestModel(PlayerModel playerModel, MonsterModel monsterModel)
        {
            PlayerModel = playerModel;
            MonsterModel = monsterModel;
        }
    }
}