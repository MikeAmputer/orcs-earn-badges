using Octokit;

namespace Action.Badges;

public class Newcomer : Badge
{
	public override string UniqueName => "newcomer";

	protected override string Image => "newcomer";

	protected override string Alt => "Newcomer";

	protected override string Description => "Create a character issue";

	public override bool IsAchieved(Issue issue, CharacterStatistics _) => issue.Comments > 0;
}
