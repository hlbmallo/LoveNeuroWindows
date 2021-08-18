using System;

namespace LoveNeuroWinUI3.Contracts.Services
{
    public interface IPageService
    {
        Type GetPageType(string key);
    }
}
