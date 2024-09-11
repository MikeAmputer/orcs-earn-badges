namespace Action.Badges;

public class SpiderSlayerBronze : Badge
{
	protected override string Image => "spider-slayer-bronze";

	protected override string Alt => "Spider Slayer Bronze";

	protected override string Description => "Slay 10 spiders";

	public override bool IsAchieved(CharacterData data) => data.GetKills(Enemy.Spider) >= 10;
	public override bool IsUpgraded(CharacterData data) => data.GetKills(Enemy.Spider) >= 50;
}
