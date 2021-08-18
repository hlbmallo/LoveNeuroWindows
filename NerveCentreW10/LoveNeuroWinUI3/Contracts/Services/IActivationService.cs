using System.Threading.Tasks;

namespace LoveNeuroWinUI3.Contracts.Services
{
    public interface IActivationService
    {
        Task ActivateAsync(object activationArgs);
    }
}
