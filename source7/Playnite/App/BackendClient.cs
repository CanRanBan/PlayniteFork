using System.IO;
using System.Net.Http;

namespace Playnite;

public class BackendClient : IDisposable
{
    public class ResponseBase
    {
        public string? Error { get; set; }
    }

    public class ErrorResponse : ResponseBase
    {
        public ErrorResponse()
        {
        }

        public ErrorResponse(string error)
        {
            Error = error;
        }

        public ErrorResponse(Exception error)
        {
            Error = error.Message;
        }
    }

    public class DataResponse<T> : ResponseBase
    {
        public T? Data { get; set; }

        public DataResponse()
        {
        }

        public DataResponse(T? data)
        {
            Data = data;
        }
    }

    public class User
    {
        public string? Id { get; set; }
        public string? WinVersion { get; set; }
        public string? PlayniteVersion { get; set; }
        public DateTime LastLaunch { get; set; }
        public bool Is64Bit { get; set; }
    }

    public class RecommendedAddons
    {
        public Dictionary<string, string>? Libraries { get; set; }
        public Dictionary<string, string>? Generic { get; set; }
    }

    private readonly HttpClient httpClient;

    public BackendClient(string endpoint)
    {
        httpClient = new HttpClient()
        {
            Timeout = new TimeSpan(0, 0, 20),
            BaseAddress = new Uri(endpoint.EndWithUriSeparator())
        };

        httpClient.DefaultRequestHeaders.Add("Playnite-Version", PlayniteApplication.CurrentVersion.ToString());
    }

    public void Dispose()
    {
        httpClient.Dispose();
    }

    public async Task DownloadFile(string subUrl, string downloadPath)
    {
        var response = await httpClient.GetAsync(subUrl);
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(response.StatusCode.ToString());
        }

        await using var fs = new FileStream(downloadPath, FileMode.Create);
        await response.Content.CopyToAsync(fs);
    }

    private async Task<T?> PostRequest<T>(string url, object? payload)
    {
        HttpContent? content = null;
        if (payload != null)
        {
            content = new StringContent(Serialization.ToJson(payload), Encoding.UTF8, "application/json");
        }

        var response = await httpClient.PostAsync(url, content);
        var strResponse = await response.Content.ReadAsStringAsync();
        CheckResponse(response, strResponse);
        var data = Serialization.FromJson<DataResponse<T>>(strResponse);
        if (data == null)
        {
            return default;
        }

        return data.Data;
    }

    private async Task PostRequest(string url, HttpContent? content)
    {
        var response = await httpClient.PostAsync(url, content);
        CheckResponse(response, await response.Content.ReadAsStringAsync());
    }

    private async Task<T?> GetRequest<T>(string url)
    {
        var response = await httpClient.GetAsync(url);
        var content = await response.Content.ReadAsStringAsync();
        CheckResponse(response, content);
        var data = Serialization.FromJson<DataResponse<T>>(content);
        if (data == null)
        {
            return default;
        }

        return data.Data;
    }

    private static void CheckResponse(HttpResponseMessage message, string content)
    {
        ResponseBase? response = null;
        if (!content.IsNullOrWhiteSpace())
        {
            Serialization.TryFromJson(content, out response, out var _);
        }

        if (!message.IsSuccessStatusCode)
        {
            throw new Exception($"Server returned failure {message.StatusCode}: {response?.Error}");
        }

        if (response?.Error.IsNullOrEmpty() == false)
        {
            throw new Exception(response.Error);
        }
    }

    public async Task<List<string>?> GetPatrons()
    {
        return await GetRequest<List<string>>("patreon/patrons");
    }

    public async Task PostUserUsage(string instId)
    {
        var user = new User
        {
            Id = instId,
            WinVersion = Environment.OSVersion.VersionString,
            PlayniteVersion = PlayniteApplication.CurrentVersion.ToString(),
            Is64Bit = Environment.Is64BitOperatingSystem
        };

        await PostRequest(
            "playnite/users",
            new StringContent(Serialization.ToJson(user), Encoding.UTF8, "application/json"));
    }

    public async Task<Guid> UploadDiagPackage(string diagPath)
    {
        using var fs = new FileStream(diagPath, FileMode.Open);
        using var content = new StreamContent(fs);
        return await PostRequest<Guid>("playnite/diag", content);
    }

    public async Task<string[]?> GetAddonBlacklist()
    {
        return await GetRequest<string[]>("addons/blacklist");
    }

    public async Task<RecommendedAddons> GetDefaultExtensions()
    {
        var stringData = await GetRequest<string>("addons/defaultextensions");
        if (stringData.IsNullOrEmpty())
        {
            return new();
        }
        else
        {
            return Serialization.FromJson<RecommendedAddons>(stringData) ?? new();
        }
    }
}