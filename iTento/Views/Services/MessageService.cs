using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTento.Views.Services
{
    public class MessageService : ViewModels.Services.IMessageService
    {
        public async Task ShowAsync(string title, string message)
        {
            await Xamarin.Forms.Application.Current.MainPage.DisplayAlert(title, message, "OK");

        }

        public async Task<Boolean> ShowAsync(string title, string message, string btnLeft, string btnRight)
        {
            var answer = await Xamarin.Forms.Application.Current.MainPage.DisplayAlert(
                title, message, btnRight, btnLeft);

            return (answer);
        }
    }
}
