namespace Action.Badges;

public class CyclesGold : Badge
{
	protected override string Image => "cycles-gold";

	protected override string Alt => "Cycles Gold";

	protected override string Description => "Play for 365 days total";

	public override bool IsAchieved(CharacterData data) => data.Statistics.CyclesPlayed >= 365;
	public override bool IsUpgraded(CharacterData data) => false;
}
