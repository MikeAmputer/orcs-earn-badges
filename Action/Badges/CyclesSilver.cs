namespace Action.Badges;

public class CyclesSilver : Badge
{
	protected override string Image => "cycles-silver";

	protected override string Alt => "Cycles Silver";

	protected override string Description => "Play for 100 days total";

	public override bool IsAchieved(CharacterData data) => data.Statistics.CyclesPlayed >= 100;
	public override bool IsUpgraded(CharacterData data) => data.Statistics.CyclesPlayed >= 365;
}
