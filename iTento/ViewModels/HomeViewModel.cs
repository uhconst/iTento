using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace iTento.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        string truqueiroA;
        public string TruqueiroA
        {
            get
            {
                return truqueiroA;
            }
            set
            {
                truqueiroA = value;
                Notify(nameof(TruqueiroA));
            }
        }

        string truqueiroB;
        public string TruqueiroB
        {
            get
            {
                return truqueiroB;
            }
            set
            {
                truqueiroB = value;
                Notify(nameof(TruqueiroB));
            }
        }

        public ICommand TruqueiroA_Plus_Command
        {
            get;
            set;
        }

        public ICommand TruqueiroB_Plus_Command
        {
            get;
            set;
        }

        public ICommand TruqueiroA_Minus_Command
        {
            get;
            set;
        }

        public ICommand Reset_Command
        {
            get;
            set;
        }

        public ICommand TruqueiroB_Minus_Command
        {
            get;
            set;
        }

        private readonly Services.IMessageService _messageService;

        public HomeViewModel()
        {
            this._messageService = DependencyService.Get<Services.IMessageService>();

            this.TruqueiroA_Plus_Command = new Command(this.TruqueiroA_Plus);
            this.TruqueiroB_Plus_Command = new Command(this.TruqueiroB_Plus);

            this.TruqueiroA_Minus_Command = new Command(this.TruqueiroA_Minus);
            this.Reset_Command = new Command(this.Reset);
            this.TruqueiroB_Minus_Command = new Command(this.TruqueiroB_Minus);

            this.TruqueiroA = ReadPrefs("TruqueiroA").ToString();
            this.TruqueiroB = ReadPrefs("TruqueiroB").ToString();
        }

        private void TruqueiroA_Plus()
        {
            this.TruqueiroA = AddOnePoint("TruqueiroA");
        }

        private void TruqueiroB_Plus()
        {
            this.TruqueiroB = AddOnePoint("TruqueiroB");
        }

        private void TruqueiroA_Minus()
        {
            this.TruqueiroA = RemoveOnePoint("TruqueiroA");
        }

        private void Reset()
        {
            
        }

        private void TruqueiroB_Minus()
        {
            this.TruqueiroB = RemoveOnePoint("TruqueiroB");
        }

        private string AddOnePoint(string name)
        {
            int points = ReadPrefs(name);

            if (points < 22)
            {
                points++;
                WritePrefs(name, points);
            }
            else
                ShowAlert();
            
            return points.ToString();
        }

        private string RemoveOnePoint(string name)
        {
            int points = ReadPrefs(name);

            if (points > 0) 
            {
                points--;
                WritePrefs(name, points);
            }
            return points.ToString();
        }

        private async void ShowAlert()
        {
            await this._messageService.ShowAsync("Cuidado com a bebida, truqueiro!", "Máximo de pontos que consegue chegar é 22!");
        }
    }
}
