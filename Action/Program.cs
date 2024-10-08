﻿using Action;
using CommandLine;
using Octokit;
using Octokit.Internal;

const string product = "orcs-earn-badges";
const string version = "1";

const string gameRepoName = "orcs-have-issues";
const string gameRepoOwner = "MikeAmputer";

var productInfo = new ProductHeaderValue(product, version);
var options = Parser.Default.ParseArguments<Options>(args).Value;
var credentialStore = new InMemoryCredentialStore(new Credentials(options.GitHubToken));

var ghClient = new GitHubClient(productInfo, credentialStore);

var badgeRepo = await ghClient.Repository.Get(options.RepositoryOwner, options.RepositoryName);

var gameRepo = await ghClient.Repository.Get(gameRepoOwner, gameRepoName);
var characterIssue = await ghClient.GetCharacterIssue(gameRepo.Id, options.RepositoryOwner);

if (characterIssue == null)
{
	Console.WriteLine("No character created");

	return;
}

Console.WriteLine($"Issue number #{characterIssue.Number}");

var characterStateComment = await ghClient.GetCharacterStateComment(gameRepo, characterIssue.Number);
var characterDto = characterStateComment?.GetCharacterDto();

if (characterDto == null)
{
	Console.WriteLine("Unable to load character data");

	return;
}

var characterData = new CharacterData
{
	Issue = characterIssue,
	CharacterDto = characterDto,
};

var achievementRepresentations = Badge.All
	.Where(b => b.IsAchieved(characterData))
	.Where(b => !b.IsUpgraded(characterData))
	.ToList();

var repositoryContents = await ghClient.Repository.Content.GetAllContents(badgeRepo.Id, options.ReadmePath);
var readme = repositoryContents.Single();

var content = new ReadmeProcessor(readme.Content, achievementRepresentations)
	.GetContent(characterData, options.IconSize);

var updateRequest = new UpdateFileRequest("Update orcs-have-issues badges", content, readme.Sha, options.Branch);

await ghClient.Repository.Content.UpdateFile(badgeRepo.Id, readme.Name, updateRequest);
