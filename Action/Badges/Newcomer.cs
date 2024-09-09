namespace Action.Badges;

public class Newcomer : Badge
{
	protected override string Image => "newcomer";

	protected override string Alt => "Newcomer";

	protected override string Description => "Create a character issue";

	public override bool IsAchieved(CharacterData data) => data.Issue.Comments > 0;
	public override bool IsUpgraded(CharacterData data) => false;
}
