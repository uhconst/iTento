using System;
using System.Threading.Tasks;

namespace iTento.ViewModels.Services
{
    public interface IMessageService
    {
        Task ShowAsync(string title, string message);

        Task<Boolean> ShowAsync(string title, string message, string btnLeft, string btnRight);
    }
}
