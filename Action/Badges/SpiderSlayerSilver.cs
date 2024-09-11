namespace Action.Badges;

public class SpiderSlayerSilver : Badge
{
	protected override string Image => "spider-slayer-silver";

	protected override string Alt => "Spider Slayer Silver";

	protected override string Description => "Slay 50 spiders";

	public override bool IsAchieved(CharacterData data) => data.GetKills(Enemy.Spider) >= 50;
	public override bool IsUpgraded(CharacterData data) => data.GetKills(Enemy.Spider) >= 250;
}
