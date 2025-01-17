using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alsein.Extensions;

namespace Cynthia.Card
{
	[CardEffectId("14019")]//倾盆大雨
	public class TorrentialRain : CardEffect
	{//在对方单排降下灾厄。回合开始时，对所在排最多2个随机单位造成1点伤害。
		public TorrentialRain(IGwentServerGame game, GameCard card) : base(game, card){}
		public override async Task<int> CardUseEffect()
		{
			var result = await Game.GetSelectRow(Card.PlayerIndex,Card,new List<RowPosition>(){RowPosition.EnemyRow1,RowPosition.EnemyRow2,RowPosition.EnemyRow3});
			await Game.ApplyWeather(Card.PlayerIndex,result,RowStatus.TorrentialRain);
			return 0;
		}
	}
}