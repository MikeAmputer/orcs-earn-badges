namespace Action.Badges;

public class UndeadSlayerBronze : Badge
{
	protected override string Image => "undead-slayer-bronze";

	protected override string Alt => "Undead Slayer Bronze";

	protected override string Description => "Slay 10 undead";

	public override bool IsAchieved(CharacterData data) => data.GetKills(Enemy.Undead) >= 10;
	public override bool IsUpgraded(CharacterData data) => data.GetKills(Enemy.Undead) >= 50;
}
