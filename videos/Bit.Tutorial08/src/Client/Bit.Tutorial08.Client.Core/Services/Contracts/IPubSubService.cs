﻿namespace Bit.Tutorial08.Client.Core.Services.Contracts;

/// <summary>
/// Contract for Publish/Subscribe pattern.
/// </summary>
public interface IPubSubService
{
    void Publish(string message, object? payload);
    Action Subscribe(string message, Func<object?, Task> handler);
}
