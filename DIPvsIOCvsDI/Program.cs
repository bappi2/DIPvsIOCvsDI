
// dotnet add package Microsoft.Extensions.DependencyInjection 
using Microsoft.Extensions.DependencyInjection;


var services = new ServiceCollection();
services.AddTransient<IGithubClient, GithubClient>();
services.AddTransient<GitHubService>();

var serviceProvider = services.BuildServiceProvider();
var gitHubService = serviceProvider.GetRequiredService<GitHubService>();
var stars = gitHubService.GetStars("dotnet");

// var stars = new GitHubService().GetStars("dotnet");

System.Console.WriteLine($"Stars: {stars}");


class GitHubService (IGithubClient githubClient)
{
    private IGithubClient _githubClient = githubClient;
    public int GetStars(string repoName)
    {
        // Call GitHub API
        //return new GithubClient().GetRepo(repoName).Stars;
        return _githubClient.GetRepo(repoName).Stars;
    }
}

internal interface IGithubClient
{
    (string repoName, int Stars) GetRepo(string repoName);
}

internal class GithubClient : IGithubClient
{
    public (string repoName, int Stars) GetRepo(string repoName)
    {
        // Call GitHub API
        return (repoName, repoName.Length);
    }
}
