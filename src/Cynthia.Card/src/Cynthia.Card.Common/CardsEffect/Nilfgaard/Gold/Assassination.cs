using System.Linq;
using System.Threading.Tasks;
using Alsein.Extensions;

namespace Cynthia.Card
{
    [CardEffectId("32015")]//暗算
    public class Assassination : CardEffect
    {//对1个敌军单位造成8点伤害，再对1个敌军单位造成8点伤害。
        public Assassination(IGwentServerGame game, GameCard card) : base(game, card) { }
        public override async Task<int> CardUseEffect()
        {
            for (var i = 0; i < 2; i++)
            {
                var result = await Game.GetSelectPlaceCards(Card, selectMode: SelectModeType.EnemyRow);
                if (result.Count <= 0) continue;
                await result.Single().Effect.Damage(8, Card);
            }
            return 0;
        }
    }
}