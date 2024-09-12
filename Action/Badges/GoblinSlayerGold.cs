namespace Action.Badges;

public class GoblinSlayerGold : Badge
{
	protected override string Image => "goblin-slayer-gold";

	protected override string Alt => "Goblin Slayer Gold";

	protected override string Description => "Slay 250 goblins";

	public override bool IsAchieved(CharacterData data) => data.GetKills(Enemy.Goblin) >= 250;
	public override bool IsUpgraded(CharacterData data) => false;
}
