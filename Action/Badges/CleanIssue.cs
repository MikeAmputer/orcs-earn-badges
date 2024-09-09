namespace Action.Badges;

public class CleanIssue : Badge
{
	protected override string Image => "clean-issue";

	protected override string Alt => "Clean Issue";

	protected override string Description => "Keep your character issue clean";

	public override bool IsAchieved(CharacterData data) => data.Issue.Comments <= 3;
	public override bool IsUpgraded(CharacterData data) => false;
}
