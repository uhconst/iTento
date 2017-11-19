using System;
using System.Threading.Tasks;

namespace iTento.ViewModels.Services
{
    public interface IMessageService
    {
        Task ShowAsync(string title, string message);
    }
}
