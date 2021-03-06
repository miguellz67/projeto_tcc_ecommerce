﻿using System.Collections.Generic;

namespace ECOM.API.Identity.Hubs.Interfaces
{
    public interface IConnectionMapping<T>
    {
        int Count { get; }

        void Add(T key, string connectionId);

        IEnumerable<string> GetConnections(T key);

        void Remove(T key, string connectionId);
    }
}
