using System.Text.Json;
using System.Text.RegularExpressions;
using Octokit;

namespace Action;

public static class OctokitExtensions
{
	private const string DtoRegexPattern = @"```json\r?\n(.+)\r?\n```";

	private static readonly Regex DtoRegex = new(DtoRegexPattern, RegexOptions.Compiled);

	public static async Task<Issue?> GetCharacterIssue(this IGitHubClient gitHubClient, long gameRepoId, string creator)
	{
		ArgumentNullException.ThrowIfNull(gitHubClient);

		var issueRequest = new RepositoryIssueRequest
		{
			Filter = IssueFilter.All,
			Labels = { "character" },
			State = ItemStateFilter.Open,
			SortProperty = IssueSort.Updated,
			SortDirection = SortDirection.Descending,
			Creator = creator,
		};

		var issueRequestOptions = new ApiOptions
		{
			PageCount = 1,
			PageSize = 1,
		};

		var characterIssues = await gitHubClient.Issue
			.GetAllForRepository(gameRepoId, issueRequest, issueRequestOptions);

		return characterIssues?.ToList().FirstOrDefault();
	}

	public static async Task<IssueComment?> GetCharacterStateComment(
		this IGitHubClient gitHubClient,
		Repository gameRepo,
		int issueNumber)
	{
		ArgumentNullException.ThrowIfNull(gitHubClient);

		var commentsRequestOptions = new ApiOptions
		{
			PageSize = 100,
		};

		var comments = await gitHubClient.Issue.Comment
			.GetAllForIssue(gameRepo.Id, issueNumber, commentsRequestOptions);

		return comments
			.Where(c => c.User.Id == gameRepo.Owner.Id)
			.Where(comment => comment.Body.StartsWith("### Stats"))
			.MinBy(comment => comment.CreatedAt);
	}

	public static CharacterDto GetCharacterDto(this IssueComment? comment)
	{
		if (comment == null || string.IsNullOrWhiteSpace(comment.Body))
		{
			return new();
		}

		var jsonString = DtoRegex.Match(comment.Body).TryGetGroupValue(1);

		if (string.IsNullOrWhiteSpace(jsonString))
		{
			return new();
		}

		return JsonSerializer.Deserialize<CharacterDto>(jsonString)
			?? throw new InvalidOperationException($"Unable to deserialize character DTO: {comment.HtmlUrl}.");
	}
}
