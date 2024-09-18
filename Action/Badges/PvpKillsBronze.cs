namespace Action.Badges;

public class PvpKillsBronze : Badge
{
	protected override string Image => "pvp-kills-bronze";

	protected override string Alt => "PvP Kills Bronze";

	protected override string Description => "Get 5 PvP kills";

	public override bool IsAchieved(CharacterData data) => data.GetKills(Enemy.Player) >= 5;
	public override bool IsUpgraded(CharacterData data) => data.GetKills(Enemy.Player) >= 25;
}
