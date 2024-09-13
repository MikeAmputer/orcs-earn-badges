namespace Action.Badges;

public class BanditSlayerGold : Badge
{
	protected override string Image => "bandit-slayer-gold";

	protected override string Alt => "Bandit Slayer Gold";

	protected override string Description => "Slay 250 bandits";

	public override bool IsAchieved(CharacterData data) => data.GetKills(Enemy.Bandit) >= 250;
	public override bool IsUpgraded(CharacterData data) => false;
}
