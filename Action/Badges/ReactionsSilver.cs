using Octokit;

namespace Action.Badges;

public class ReactionsSilver : Badge
{
	public override string UniqueName => "reactions-silver";

	protected override string Image => "reactions-silver";

	protected override string Alt => "Reactions Silver";

	protected override string Description => "Earn 25 heart emojis on your character issue";

	public override bool IsAchieved(Issue issue, CharacterStatistics _) => issue.Reactions.Heart >= 25;
}
