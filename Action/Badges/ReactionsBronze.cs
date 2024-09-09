using Octokit;

namespace Action.Badges;

public class ReactionsBronze : Badge
{
	public override string UniqueName => "reactions-bronze";

	protected override string Image => "reactions-bronze";

	protected override string Alt => "Reactions Bronze";

	protected override string Description => "Earn 5 heart emojis on your character issue";

	public override bool IsAchieved(Issue issue, CharacterStatistics _) => issue.Reactions.Heart >= 5;
}
