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
                this.Notify("id_truqueiroA");
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
                this.Notify("id_truqueiroB");
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

        public HomeViewModel()
        {
            this.TruqueiroA_Plus_Command = new Command(this.TruqueiroA_Plus);
            this.TruqueiroB_Plus_Command = new Command(this.TruqueiroB_Plus);

            this.TruqueiroA_Minus_Command = new Command(this.TruqueiroA_Minus);
            this.Reset_Command = new Command(this.Reset);
            this.TruqueiroB_Minus_Command = new Command(this.TruqueiroB_Minus);

            this.TruqueiroA = "0";
            this.TruqueiroB = "0";
        }

        private void TruqueiroA_Plus()
        {

        }

        private void TruqueiroB_Plus()
        {
            int z = Int32.Parse(this.TruqueiroB);

            z++;

            this.TruqueiroB = z.ToString();
        }

        private void TruqueiroA_Minus()
        {
            
        }

        public void Reset()
        {
            //int x = Int32.Parse(this.TruqueiroA);

            //x++;

            this.TruqueiroA = "BB";
        }

        private void TruqueiroB_Minus()
        {

        }
    }
}
