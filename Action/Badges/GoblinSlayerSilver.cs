namespace Action.Badges;

public class GoblinSlayerSilver : Badge
{
	protected override string Image => "goblin-slayer-silver";

	protected override string Alt => "Goblin Slayer Silver";

	protected override string Description => "Slay 50 goblins";

	public override bool IsAchieved(CharacterData data) => data.GetKills(Enemy.Goblin) >= 50;
	public override bool IsUpgraded(CharacterData data) => data.GetKills(Enemy.Goblin) >= 250;
}
