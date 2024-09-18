namespace Action.Badges;

public class PvpKillsGold : Badge
{
	protected override string Image => "pvp-kills-gold";

	protected override string Alt => "PvP Kills Gold";

	protected override string Description => "Get 100 PvP kills";

	public override bool IsAchieved(CharacterData data) => data.GetKills(Enemy.Player) >= 100;
	public override bool IsUpgraded(CharacterData data) => false;
}
