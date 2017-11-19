using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace iTento.ViewModels
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void Notify([CallerMemberName] string propertyName = null)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                Debug.WriteLine("propertyName: " + propertyName);
            }
        }

        protected void WritePrefs(string prefsName, int score)
        {
            Application.Current.Properties[prefsName] = score;
        }

        protected int ReadPrefs(string prefsName)
        {
            int score = 0;
            if (Application.Current.Properties.ContainsKey(prefsName))
                score = Int32.Parse(Application.Current.Properties[prefsName].ToString());
            return score;
        }
    }
}
