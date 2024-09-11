namespace Action.Badges;

public class CraftGold : Badge
{
	protected override string Image => "craft-gold";

	protected override string Alt => "Craft Gold";

	protected override string Description => "Reach a combined wargear rank of 10";

	public override bool IsAchieved(CharacterData data) => data.WargearRank >= 10;
	public override bool IsUpgraded(CharacterData data) => false;
}
