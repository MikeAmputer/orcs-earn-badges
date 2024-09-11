using Octokit;

namespace Action;

public class CharacterData
{
	public required Issue Issue { get; init; }
	public required CharacterDto CharacterDto { get; init; }

	public CharacterStatistics Statistics => CharacterDto.Statistics;

	public bool IsOrc => Issue.Labels.Any(l => l.Name == "orc");
	public int WargearRank => CharacterDto.ArmorRank + CharacterDto.WeaponRank;

	public int GetKills(Enemy enemyType)
	{
		return Statistics.Kills.GetValueOrDefault(enemyType, 0);
	}
}
