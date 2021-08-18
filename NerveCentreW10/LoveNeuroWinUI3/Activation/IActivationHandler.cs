using System.Threading.Tasks;

namespace LoveNeuroWinUI3.Activation
{
    public interface IActivationHandler
    {
        bool CanHandle(object args);

        Task HandleAsync(object args);
    }
}
