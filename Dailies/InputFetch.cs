using System.Net;

namespace Dailies;

public class InputFetch(string sessionToken)
{
    private const string ADVENT_URL = "https://adventofcode.com";

    private HttpClientHandler GetHandler()
    {
        HttpClientHandler handler = new HttpClientHandler();
        // Add the cookie to the handler
        handler.CookieContainer = new CookieContainer();
        handler.CookieContainer.Add(new Uri(ADVENT_URL), new Cookie("session", sessionToken));
        return handler;
    }

    private HttpClient GetClient()
    {
        HttpClient client = new HttpClient(GetHandler());
        client.BaseAddress = new Uri(ADVENT_URL);
        return client;
    }

    public async Task<string> GetRawInput(
        string srcUrl)
    {
        HttpClient client = GetClient();
        HttpResponseMessage msg = await client.GetAsync(srcUrl);

        string rawContent = await msg.Content.ReadAsStringAsync();

        return rawContent;
    }

    public async Task<IList<string>> GetMultiLine(string srcUrl)
    {
        string rawInput = await GetRawInput(srcUrl);
        return new List<string>(rawInput.Split('\n', StringSplitOptions.RemoveEmptyEntries));
    }

    //Day1: https://adventofcode.com/2024/day/1/input
    public async Task<IList<string>> GetDay1Input(
        string srcUrl = "/2024/day/1/input"
    )
    {
        return await GetMultiLine(srcUrl);
    }

    //Day2: https://adventofcode.com/2024/day/2/input
    public async Task<IList<string>> GetDay2Input(
        string srcUrl = "/2024/day/2/input")
    {
        return await GetMultiLine(srcUrl);
    }

    public async Task<string> GetDay3Input(
        string srcUrl = "/2024/day/3/input")
    {
        return await GetRawInput(srcUrl);
    }

    public async Task<string> GetDay4Input(
        string srcUrl = "/2024/day/4/input")
    {
        return await GetRawInput(srcUrl);
    }

    public async Task<string> GetDay5Input(
        string srcUrl = "/2024/day/5/input")
    {
        return await GetRawInput(srcUrl);
    }

    public async Task<string> GetDay6Input(
        string srcUrl = "/2024/day/6/input")
    {
        return await GetRawInput(srcUrl);
    }

    public async Task<string> GetDay7Input(
        string srcUrl = "/2024/day/7/input")
    {
        return await GetRawInput(srcUrl);
    }

    public async Task<string> GetDay8Input(
        string srcUrl = "/2024/day/8/input")
    {
        return await GetRawInput(srcUrl);
    }

    public async Task<string> GetDay9Input(
        string srcUrl = "/2024/day/9/input")
    {
        return await GetRawInput(srcUrl);
    }

    public async Task<string> GetDay10Input(
        string srcUrl = "/2024/day/10/input")
    {
        return await GetRawInput(srcUrl);
    }

    public async Task<string> GetDay11Input(
        string srcUrl = "/2024/day/11/input")
    {
        return await GetRawInput(srcUrl);
    }
}