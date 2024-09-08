using System.Text.RegularExpressions;
using Octokit;

namespace Action;

public class ReadmeProcessor
{
	private const string Marker = @"<!-- orcs-earn-badges -->";
	private const string LineMarker = $"^{Marker}$";

	private static readonly Regex MarkerRegex = new(LineMarker, RegexOptions.Compiled | RegexOptions.Multiline);

	private readonly string _content;
	private readonly IReadOnlyCollection<Badge> _badges;
	private readonly int _iconSize;
	private readonly string _characterIssueUrl;
	private readonly string _characterName;
	private readonly bool _isOrc;

	public ReadmeProcessor(
		string content,
		IReadOnlyCollection<Badge> badges,
		Options options,
		Issue characterIssue) : this(
		content,
		badges,
		options.IconSize,
		characterIssue.HtmlUrl,
		characterIssue.Title,
		characterIssue.Labels.Any(l => l.Name == "orc"))
	{
	}

	private ReadmeProcessor(
		string content,
		IReadOnlyCollection<Badge> badges,
		int iconSize,
		string characterIssueUrl,
		string characterName,
		bool isOrc)
	{
		_content = content;
		_badges = badges;
		_iconSize = iconSize;
		_characterIssueUrl = characterIssueUrl;
		_characterName = characterName;
		_isOrc = isOrc;
	}

	public string GetContent()
	{
		var matches = MarkerRegex.Matches(_content);

		if (matches.Count != 2)
		{
			throw new InvalidOperationException("The readme file is not marked properly");
		}

		var before = _content[..matches[0].Index].TrimEnd();
		var after = _content[(matches[1].Index + matches[1].Length)..].TrimStart();

		var badgeContent = string.Join("\n", _badges.Select(b => b.GetHtml(_iconSize, _characterIssueUrl)));

		return $"{before}\n\n{Marker}\n{badgeContent}\n{Marker}\n\n{after}";
	}
}
