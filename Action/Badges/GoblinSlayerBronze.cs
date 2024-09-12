namespace Action.Badges;

public class GoblinSlayerBronze : Badge
{
	protected override string Image => "goblin-slayer-bronze";

	protected override string Alt => "Goblin Slayer Bronze";

	protected override string Description => "Slay 10 goblins";

	public override bool IsAchieved(CharacterData data) => data.GetKills(Enemy.Goblin) >= 10;
	public override bool IsUpgraded(CharacterData data) => data.GetKills(Enemy.Goblin) >= 50;
}
