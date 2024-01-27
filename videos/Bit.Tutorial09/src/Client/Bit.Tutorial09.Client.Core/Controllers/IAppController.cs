namespace Bit.Tutorial09.Client.Core.Controllers;

public interface IAppController
{
    void AddQueryString(string key, object? value) { }
    void AddQueryStrings(Dictionary<string, object?> queryString) { }
}
