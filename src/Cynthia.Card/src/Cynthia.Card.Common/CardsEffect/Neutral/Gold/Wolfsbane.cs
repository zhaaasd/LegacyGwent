using System.Linq;
using System.Threading.Tasks;
using Alsein.Extensions;

namespace Cynthia.Card
{
    [CardEffectId("12037")]//附子草
    public class Wolfsbane : CardEffect
    {//在墓场停留3个回合后，在回合结束时，对最强的敌军单位造成6点伤害，使最弱的友军单位获得6点增益。
        public Wolfsbane(IGwentServerGame game, GameCard card) : base(game, card) { }
        public override async Task OnTurnOver(int playerIndex)
        {
            if (playerIndex == Card.PlayerIndex && Card.Status.CardRow.IsInCemetery() && Card.Status.Countdown > 0)
            {
                await Card.Effect.SetCountdown(offset: -1);
                if (Card.Effect.Countdown <= 0)
                {//触发效果
                    var cards = Game.GetAllCard(PlayerIndex).Where(x => x.Status.CardRow.IsOnPlace());
                    var mycard = cards.Where(x => x.PlayerIndex == PlayerIndex).WhereAllHighest();
                    var enemycard = cards.Where(x => x.PlayerIndex != PlayerIndex).WhereAllLowest();
                    if (enemycard.Count() > 0)
                        await enemycard.Mess().First().Effect.Damage(6, Card, BulletType.RedLight);
                    if (mycard.Count() > 0)
                        await mycard.Mess().First().Effect.Boost(6, Card);
                }
            }
        }
    }
}