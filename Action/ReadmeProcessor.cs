using System.Text.RegularExpressions;

namespace Action;

public class ReadmeProcessor
{
	private const string Marker = "<!-- orcs-earn-badges -->";
	private const string LineMarker = $"^{Marker}$";

	private const string CharacterImageRoute =
		"https://github.com/MikeAmputer/orcs-earn-badges/blob/master/img/character";

	private static readonly Regex MarkerRegex = new(LineMarker, RegexOptions.Compiled | RegexOptions.Multiline);

	private readonly string _content;
	private readonly IReadOnlyCollection<Badge> _badges;

	public ReadmeProcessor(string content, IReadOnlyCollection<Badge> badges)
	{
		_content = content;
		_badges = badges;
	}

	public string GetContent(CharacterData characterData, int iconSize)
	{
		var characterIssueUrl = characterData.Issue.HtmlUrl;
		var isOrc = characterData.IsOrc;
		var level = characterData.Statistics.Level;

		var matches = MarkerRegex.Matches(_content);

		if (matches.Count != 2)
		{
			throw new InvalidOperationException("The readme file is not marked properly");
		}

		var before = _content[..matches[0].Index].TrimEnd();
		var after = _content[(matches[1].Index + matches[1].Length)..].TrimStart();

		var badgeContent = string.Join("\n      ", _badges.Select(b => b.GetHtml(iconSize)));

		var args = new object[]
		{
			/*0*/ characterIssueUrl,
			/*1*/ $"{CharacterImageRoute}/{(isOrc ? "orc" : "human")}-{level}.png",
			/*2*/ level,
			/*3*/ isOrc ? "Orc" : "Human",
			/*4*/ badgeContent,
		};

		var table = string.Format(BadgeTableHtml, args);

		return $"{before}\n\n{Marker}\n{table}\n{Marker}\n\n{after}";
	}

	private const string BadgeTableHtml = @"<table>
  <tr>
    <td width=""90"">
      <p align=""center"">
        <a href=""{0}""><img src=""{1}"" alt=""Level {2}, {3}"" title=""Level {2}, {3}"" width=""64""></a>
      </p>
    </td>
    <td>
      {4}
    </td>
  </tr>
</table>";
}
