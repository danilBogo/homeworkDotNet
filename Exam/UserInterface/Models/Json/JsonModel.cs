using UserInterface.Models.Index;

namespace UserInterface.Models.Json
{
    public class JsonModel
    {
        public IndexFormViewModel PlayerModel { get; set; }
        
        public MonsterModel MonsterModel { get; set; }

        public JsonModel(IndexFormViewModel playerModel, MonsterModel monsterModel)
        {
            PlayerModel = playerModel;
            MonsterModel = monsterModel;
        }
    }
}