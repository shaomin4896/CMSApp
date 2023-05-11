using Microsoft.Extensions.DependencyInjection;

public class AddHeadersDelegatingHandler : DelegatingHandler
{
    private readonly ILocalStorageService _localStorageService;

    public AddHeadersDelegatingHandler() : base(new HttpClientHandler())
    {
        _localStorageService = ServiceLocator.Current.GetInstance<ILocalStorageService>();
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        if (request.RequestUri.AbsolutePath.Contains("login")) return await base.SendAsync(request, cancellationToken);

        request.Headers.Add("Authorization", $"Bearer {(await _localStorageService.GetItem<string>("jwtToken"))}");

        return await base.SendAsync(request, cancellationToken);
    }
}