﻿namespace Ecommerce.Shared.Contracts
{
    public interface ICustomLogger
    {
        void Info (string message);
        void Warn(string message);
        void Debug(string message);
        void Error(string message);
        void Fatal(string message);
    }
}
