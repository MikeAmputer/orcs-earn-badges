namespace Action.Badges;

public class UndeadSlayerSilver : Badge
{
	protected override string Image => "undead-slayer-silver";

	protected override string Alt => "Undead Slayer Silver";

	protected override string Description => "Slay 50 undead";

	public override bool IsAchieved(CharacterData data) => data.GetKills(Enemy.Undead) >= 50;
	public override bool IsUpgraded(CharacterData data) => data.GetKills(Enemy.Undead) >= 250;
}
