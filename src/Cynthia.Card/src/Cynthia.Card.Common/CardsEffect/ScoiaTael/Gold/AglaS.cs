using System.Linq;
using System.Threading.Tasks;
using Alsein.Extensions;

namespace Cynthia.Card
{
	[CardEffectId("52004")]//艾格莱丝
	public class AglaS : CardEffect
	{//从对方墓场复活1张铜色/银色“特殊”牌，随后将其放逐。
		public AglaS(IGwentServerGame game, GameCard card) : base(game, card){}
		public override async Task<int> CardPlayEffect(bool isSpying)
		{
			return 0;
		}
	}
}