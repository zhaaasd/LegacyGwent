using System.Linq;
using System.Threading.Tasks;
using Alsein.Extensions;

namespace Cynthia.Card
{
	[CardEffectId("44011")]//攻城后援
	public class SiegeSupport : CardEffect
	{//使后续打出的友军单位获得1点增益，“机械”单位额外获得1点护甲。 操控。
		public SiegeSupport(IGwentServerGame game, GameCard card) : base(game, card){}
		public override async Task<int> CardPlayEffect(bool isSpying)
		{
			return 0;
		}
	}
}