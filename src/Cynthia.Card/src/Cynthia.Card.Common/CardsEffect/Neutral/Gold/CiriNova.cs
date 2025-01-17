using System;
using System.Linq;
using System.Threading.Tasks;
using Alsein.Extensions;

namespace Cynthia.Card
{
    [CardEffectId("12032")]//希里：新星
    public class CiriNova : CardEffect
    {//若每张铜色牌在己方初始牌组中刚好有2张，则基础战力变为22点。
        public CiriNova(IGwentServerGame game, GameCard card) : base(game, card) { }
        public override async Task<int> CardPlayEffect(bool isSpying)
        {
            if (Game.PlayerBaseDeck[PlayerIndex].Deck
                .Where(x => x.Group == Group.Copper)
                .GroupBy(x => x.CardId).Any(x => x.Count() != 2))
                return 0;
            var offset = 22 - Card.Status.Strength;
            if (offset > 0)
                await Card.Effect.Strengthen(offset, Card);
            else if (offset < 0)
                await Card.Effect.Weaken(Math.Abs(offset), Card);
            return 0;
        }
    }
}