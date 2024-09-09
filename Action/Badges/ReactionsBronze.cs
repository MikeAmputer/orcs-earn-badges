namespace Action.Badges;

public class ReactionsBronze : Badge
{
	protected override string Image => "reactions-bronze";

	protected override string Alt => "Reactions Bronze";

	protected override string Description => "Earn 5 heart emojis on your character issue";

	public override bool IsAchieved(CharacterData data) => data.Issue.Reactions.Heart >= 5;
	public override bool IsUpgraded(CharacterData data) => data.Issue.Reactions.Heart >= 25;
}
