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
        private readonly string _truqueiroA;
        private readonly string _truqueiroB;

        public HomeViewModel()
        {
            this._messageService = DependencyService.Get<Services.IMessageService>();

            this._truqueiroA = "TruqueiroA";
            this._truqueiroB = "TruqueiroB"; 

            this.TruqueiroA_Plus_Command = new Command(this.TruqueiroA_Plus);

            this.TruqueiroB_Plus_Command = new Command(this.TruqueiroB_Plus);

            this.TruqueiroA_Minus_Command = new Command(this.TruqueiroA_Minus);
            this.Reset_Command = new Command(this.Reset);
            this.TruqueiroB_Minus_Command = new Command(this.TruqueiroB_Minus);

            this.TruqueiroA = ReadPrefs(_truqueiroA).ToString();
            this.TruqueiroB = ReadPrefs(_truqueiroB).ToString();
        }

        private void TruqueiroA_Plus()
        {
            this.TruqueiroA = AddOnePoint(_truqueiroA);
        }

        private void TruqueiroB_Plus()
        {
            this.TruqueiroB = AddOnePoint(_truqueiroB);
        }

        private void TruqueiroA_Minus()
        {
            this.TruqueiroA = RemoveOnePoint(_truqueiroA);
        }

        private async void Reset()
        {
            bool reset = await this._messageService.ShowAsync("Zerar?", "Tem certeza que deseja zerar o placar?", "Não", "Sim");

            if (reset) {
                int pointsA = 0;
                int pointsB = 0;

                WritePrefs(_truqueiroA, pointsA);
                WritePrefs(_truqueiroB, pointsB);

                this.TruqueiroA = pointsA.ToString();
                this.TruqueiroB = pointsA.ToString();
            }
        }

        private void TruqueiroB_Minus()
        {
            this.TruqueiroB = RemoveOnePoint(_truqueiroB);
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
