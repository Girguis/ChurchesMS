﻿namespace ChurchMS.Application.Contracts.Logging;

public interface IAppLogger
{
    void LogInformation(string message);
    void LogWarning(string message);
    void LogError(string message, Exception ex);
}