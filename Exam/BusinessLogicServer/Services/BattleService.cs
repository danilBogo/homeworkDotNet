using System;
using System.Text;
using DatabaseBusinessLogic.Interfaces;
using DatabaseBusinessLogic.Models;

namespace DatabaseBusinessLogic.Services
{
    public class BattleService
    {
        private Random _rnd;
        
        public BattleService()
        {
            _rnd = new Random();
        }

        public BattleLogModel GetBattleLogs(PlayerModel playerModel, MonsterModel monsterModel)
        {
            var strBuilder = new StringBuilder();
            strBuilder.Append($"Выпал монстр: {monsterModel.Name}\n\n");
            var isThatMovePlayers = true;
            while (playerModel.HitPoints > 0 && monsterModel.HitPoints > 0)
            {
                if (isThatMovePlayers)
                {
                    for (var i = 0; i < playerModel.NumberAttacksPerRound; i++)
                    {
                        if (!IsHitPositive(playerModel.HitPoints) || !IsHitPositive(monsterModel.HitPoints)) continue;
                        var moveLogs = MakeMove(playerModel, monsterModel);
                        strBuilder.Append($"{GetStringBegin(true, monsterModel.Name)}{moveLogs}\n\n");
                    }
                }
                else
                {
                    for (var i = 0; i < monsterModel.NumberAttacksPerRound; i++)
                    {
                        if (!IsHitPositive(playerModel.HitPoints) || !IsHitPositive(monsterModel.HitPoints)) continue;
                        var moveLogs = MakeMove(monsterModel, playerModel);
                        strBuilder.Append($"{GetStringBegin(false, monsterModel.Name)}{moveLogs}\n\n");
                    }
                }
                isThatMovePlayers = !isThatMovePlayers;
            }

            strBuilder.Append(GetResult(playerModel.HitPoints, monsterModel.HitPoints));
            
            var battleLogs = new BattleLogModel(playerModel.HitPoints, strBuilder.ToString());
            return battleLogs;
        }

        private bool IsHitPositive(int hit) => hit > 0;

        private string GetStringBegin(bool isThatMovePlayers, string monsterName)
        {
            return isThatMovePlayers ? "Ваш ход:\n" : $"Ход монстра \"{monsterName}\":\n";
        }

        private string GetResult(int playerHp, int monsterHp)
        {
            if (playerHp == 0)
                return "Вы умерли";
            if (monsterHp == 0)
                return "Монстр побеждён";
            throw new Exception("Invalid result");
        }

        private string MakeMove(ICreature firstCreature, ICreature secondCreature)
        {
            var attacker = default(ICreature);
            var defender = default(ICreature);
            
            if (firstCreature is PlayerModel && secondCreature is MonsterModel)
            {
                attacker = (PlayerModel) firstCreature;
                defender = (MonsterModel) secondCreature;
            }

            if (firstCreature is MonsterModel && secondCreature is PlayerModel)
            {
                attacker = (MonsterModel) firstCreature;
                defender = (PlayerModel) secondCreature;
            }

            if (attacker is null || defender is null)
                throw new Exception("Invalid player or monster model");
            
            var diceResult = DropMainDice();
            switch (diceResult)
            {
                case 1:
                {
                    return $"Критический промах выпало {diceResult}";
                }
                case 20:
                {
                    var diceDamage = DropDamageDice(attacker.Damage);
                    var attackerDamage = (diceDamage + attacker.DamageModifier) * 2;
                    defender.HitPoints -= attackerDamage;
                    if (defender.HitPoints < 0)
                        defender.HitPoints = 0;
                    return $"Критическое попадание выпало {diceDamage}\n" +
                           $"Модификатор урона нападающего {attacker.DamageModifier}\n" +
                           $"Нанесённый урон {attackerDamage}\n" +
                           $"Хитпоинты защищающегося {defender.HitPoints}";
                }
                default:
                {
                    if (diceResult is < 1 or > 20)
                        throw new Exception("Invalid dice result");
                    var armorPenetration = diceResult + attacker.DamageModifier;
                    if (armorPenetration <= defender.ArmorClass)
                        return $"Выпало {diceResult}\n" +
                               $"Модификатор урона нападающего {attacker.DamageModifier}\n" +
                               $"Броня защищающегося {defender.ArmorClass}, броня не пробита ";
                    var attackerDamage = DropDamageDice(attacker.Damage) + attacker.DamageModifier;
                    defender.HitPoints -= attackerDamage;
                    if (defender.HitPoints < 0)
                        defender.HitPoints = 0;
                    return $"Выпало {diceResult}\n" +
                           $"Модификатор урона нападающего {attacker.DamageModifier}\n" +
                           $"Броня защищающегося {defender.ArmorClass}, броня пробита\n" +
                           $"Нанесённый урон {attackerDamage}\n" +
                           $"Хитпоинты защищающегося {defender.HitPoints}";
                }
            }
        }

        private int DropMainDice() => _rnd.Next(1, 21);

        private int DropDamageDice(string damage)
        {
            var parts = damage.Split('k');
            if (!int.TryParse(parts[0], out var countDrops) || !int.TryParse(parts[1], out var upperValue))
                throw new Exception("Invalid damage");
            var result = 0;
            for (var i = 0; i < countDrops; i++)
                result += _rnd.Next(1, upperValue + 1);
            return result;
        }
    }
}