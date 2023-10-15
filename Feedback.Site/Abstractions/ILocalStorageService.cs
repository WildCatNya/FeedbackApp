﻿namespace Feedback.Site.Abstractions;

public interface ILocalStorageService
{
    Task<T?> GetItem<T>(string key);
    Task SetItem<T>(string key, T value);
    Task RemoveItem(string key);
}