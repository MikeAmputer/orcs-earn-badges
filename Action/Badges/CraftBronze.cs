namespace Action.Badges;

public class CraftBronze : Badge
{
	protected override string Image => "craft-bronze";

	protected override string Alt => "Craft Bronze";

	protected override string Description => "Craft your first wargear";

	public override bool IsAchieved(CharacterData data) => data.WargearRank > 0;
	public override bool IsUpgraded(CharacterData data) => data.WargearRank >= 4;
}
