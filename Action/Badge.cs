using Action.Badges;
using Octokit;

namespace Action;

public abstract class Badge
{
	public static IReadOnlyCollection<Badge> All =>
	[
		new Newcomer(),
	];

	private const string ImageRoute = "https://github.com/MikeAmputer/orcs-earn-badges/blob/master/img";

	public abstract string UniqueName { get; }
	protected abstract string Image { get; }
	protected abstract string Alt { get; }
	protected abstract string Description { get; }

	public abstract bool IsAchieved(Issue issue, CharacterStatistics statistics);

	public string GetHtml(int width, string url)
	{
		var img = $"<img src=\"{ImageRoute}/{Image}.png\" alt=\"{Alt}\" title=\"{Description}\" width=\"{width}\">";
		return $"<a href=\"{url}\">{img}</a>";
	}
}
