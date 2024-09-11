namespace Action.Badges;

public class CraftSilver : Badge
{
	protected override string Image => "craft-silver";

	protected override string Alt => "Craft Silver";

	protected override string Description => "Reach a combined wargear rank of 4";

	public override bool IsAchieved(CharacterData data) => data.WargearRank >= 4;
	public override bool IsUpgraded(CharacterData data) => data.WargearRank >= 10;
}
