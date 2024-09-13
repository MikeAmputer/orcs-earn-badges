namespace Action.Badges;

public class BanditSlayerSilver : Badge
{
	protected override string Image => "bandit-slayer-silver";

	protected override string Alt => "Bandit Slayer Silver";

	protected override string Description => "Slay 50 bandits";

	public override bool IsAchieved(CharacterData data) => data.GetKills(Enemy.Bandit) >= 50;
	public override bool IsUpgraded(CharacterData data) => data.GetKills(Enemy.Bandit) >= 250;
}
