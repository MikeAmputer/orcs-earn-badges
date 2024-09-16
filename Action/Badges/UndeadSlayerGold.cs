namespace Action.Badges;

public class UndeadSlayerGold : Badge
{
	protected override string Image => "undead-slayer-gold";

	protected override string Alt => "Undead Slayer Gold";

	protected override string Description => "Slay 250 undead";

	public override bool IsAchieved(CharacterData data) => data.GetKills(Enemy.Undead) >= 250;
	public override bool IsUpgraded(CharacterData data) => false;
}
