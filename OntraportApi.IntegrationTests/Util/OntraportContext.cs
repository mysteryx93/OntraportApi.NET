using System;
using HanumanInstitute.Validators;
using Microsoft.Extensions.Logging;
using Xunit.Abstractions;

namespace HanumanInstitute.OntraportApi.IntegrationTests;

/// <summary>
/// Initializes necessary classes to test Ontraport API classes.
/// </summary>
/// <typeparam name="T">The type of Ontraport API class to test.</typeparam>
public class OntraportContext<T> : IDisposable
    where T : class
{
    private readonly ITestOutputHelper _output;

    public OntraportContext(ITestOutputHelper output = null)
    {
        if (output != null)
        {
            _output = output;
            AppDomain.CurrentDomain.UnhandledException += (s, e) => Dispose(true);
        }
    }

    public ILogger<OntraportHttpClient> Log => _log ??= new MockLogger<OntraportHttpClient>();
    private ILogger<OntraportHttpClient> _log;

    public OntraportHttpClient HttpClient => _httpClient ??= ConfigHelper.GetHttpClient(Log);
    private OntraportHttpClient _httpClient;

    public OntraportObjects OntraObjects => _ontraObjects ??= new OntraportObjects(HttpClient);
    private OntraportObjects _ontraObjects;

    public T Ontra => _ontra ??= SetupOntra();
    private T _ontra;

    private T SetupOntra()
    {
        if (typeof(T).IsAssignableFromGeneric(typeof(OntraportBaseCustomObject<,>)))
        {
            return (T)Activator.CreateInstance(typeof(T), HttpClient, OntraObjects)!;
        }
        else
        {
            return (T)Activator.CreateInstance(typeof(T), HttpClient)!;
        }
    }

    private bool _disposedValue;
    protected virtual void Dispose(bool disposing)
    {
        if (!_disposedValue)
        {
            if (disposing)
            {
                _output?.WriteLine(Log.ToString());
            }
            _disposedValue = true;
        }
    }

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}