namespace Action.Badges;

public class BanditSlayerBronze : Badge
{
	protected override string Image => "bandit-slayer-bronze";

	protected override string Alt => "Bandit Slayer Bronze";

	protected override string Description => "Slay 10 bandits";

	public override bool IsAchieved(CharacterData data) => data.GetKills(Enemy.Bandit) >= 10;
	public override bool IsUpgraded(CharacterData data) => data.GetKills(Enemy.Bandit) >= 50;
}
