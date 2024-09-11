namespace Action.Badges;

public class SpiderSlayerGold : Badge
{
	protected override string Image => "spider-slayer-gold";

	protected override string Alt => "Spider Slayer Gold";

	protected override string Description => "Slay 250 spiders";

	public override bool IsAchieved(CharacterData data) => data.GetKills(Enemy.Spider) >= 250;
	public override bool IsUpgraded(CharacterData data) => false;
}
