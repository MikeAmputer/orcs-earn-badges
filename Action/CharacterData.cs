using Octokit;

namespace Action;

public class CharacterData
{
	public required Issue Issue { get; init; }
	public required CharacterStatistics Statistics { get; init; }
}
