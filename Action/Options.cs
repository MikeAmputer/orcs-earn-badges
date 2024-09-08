using CommandLine;
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

namespace Action;

public class Options
{
	[Option("token", Required = true)]
	public string GitHubToken { get; set; } = string.Empty;

	[Option("repo", Required = true)]
	public string Repository { get; set; }

	[Option("owner", Required = true)]
	public string RepositoryOwner { get; set; }

	[Option("branch", Required = true)]
	public string Branch { get; set; }

	[Option("readme", Required = false, Default = "README.md")]
	public string ReadmePath { get; set; }

	[Option("size", Required = false, Default = 64)]
	public int IconSize { get; set; }

	public string RepositoryName => Repository.Split('/').Last();
}
