using Octokit;

namespace Action.Badges;

public class ReactionsGold : Badge
{
	public override string UniqueName => "reactions-gold";

	protected override string Image => "reactions-gold";

	protected override string Alt => "Reactions Gold";

	protected override string Description => "Earn 100 heart emojis on your character issue";

	public override bool IsAchieved(Issue issue, CharacterStatistics _) => issue.Reactions.Heart >= 100;
}
