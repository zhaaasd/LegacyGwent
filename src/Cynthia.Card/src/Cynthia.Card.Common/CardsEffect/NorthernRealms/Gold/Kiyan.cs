using System.Linq;
using System.Threading.Tasks;
using Alsein.Extensions;

namespace Cynthia.Card
{
	[CardEffectId("42010")]//凯亚恩
	public class Kiyan : CardEffect
	{//择一：创造1张铜色/银色“炼金”牌；或从牌组打出1张铜色/银色“道具”牌。
		public Kiyan(IGwentServerGame game, GameCard card) : base(game, card){}
		public override async Task<int> CardPlayEffect(bool isSpying)
		{
			return 0;
		}
	}
}