namespace Action.Badges;

public class CyclesBronze : Badge
{
	protected override string Image => "cycles-bronze";

	protected override string Alt => "Cycles Bronze";

	protected override string Description => "Play for 10 days total";

	public override bool IsAchieved(CharacterData data) => data.Statistics.CyclesPlayed >= 10;
	public override bool IsUpgraded(CharacterData data) => data.Statistics.CyclesPlayed >= 100;
}
