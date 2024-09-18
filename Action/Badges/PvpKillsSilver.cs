namespace Action.Badges;

public class PvpKillsSilver : Badge
{
	protected override string Image => "pvp-kills-silver";

	protected override string Alt => "PvP Kills Silver";

	protected override string Description => "Get 25 PvP kills";

	public override bool IsAchieved(CharacterData data) => data.GetKills(Enemy.Player) >= 25;
	public override bool IsUpgraded(CharacterData data) => data.GetKills(Enemy.Player) >= 100;
}
