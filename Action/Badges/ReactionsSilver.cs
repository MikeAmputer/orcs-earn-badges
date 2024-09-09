namespace Action.Badges;

public class ReactionsSilver : Badge
{
	protected override string Image => "reactions-silver";

	protected override string Alt => "Reactions Silver";

	protected override string Description => "Earn 25 heart emojis on your character issue";

	public override bool IsAchieved(CharacterData data) => data.Issue.Reactions.Heart >= 25;
	public override bool IsUpgraded(CharacterData data) => data.Issue.Reactions.Heart >= 100;
}
