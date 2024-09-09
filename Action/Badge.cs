using Action.Badges;

namespace Action;

public abstract class Badge
{
	public static IReadOnlyCollection<Badge> All =>
	[
		new Newcomer(),
		new ReactionsBronze(), new ReactionsSilver(), new ReactionsGold(),
		new CyclesBronze(), new CyclesSilver(), new CyclesGold(),
	];

	private const string ImageRoute = "https://github.com/MikeAmputer/orcs-earn-badges/blob/master/img";

	protected abstract string Image { get; }
	protected abstract string Alt { get; }
	protected abstract string Description { get; }

	public abstract bool IsAchieved(CharacterData data);
	public abstract bool IsUpgraded(CharacterData data);

	public string GetHtml(int width, string url)
	{
		var img = $"<img src=\"{ImageRoute}/{Image}.png\" alt=\"{Alt}\" title=\"{Description}\" width=\"{width}\">";

		return $"<a href=\"{url}\">{img}</a>";
	}
}
