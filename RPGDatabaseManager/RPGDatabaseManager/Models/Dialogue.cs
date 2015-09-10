

using System.ComponentModel;
using System.Runtime.CompilerServices;
using RPGDatabaseManager.Annotations;

namespace RPGDatabaseManager.Models
{
    public class Dialogue : INotifyPropertyChanged
    {
        private string name;
        private int startNodeid;

        public Dialogue(string name, int startNodeid)
        {
            Name = name;
            StartNodeID = startNodeid;
        }

        public string Name 
        { 
            get { return name; } 
            set 
            { 
                name = value; 
                OnPropertyChanged("Name"); 
            } 
        }

        public int StartNodeID
        {
            get { return startNodeid; }
            set
            {
                startNodeid = value;
                OnPropertyChanged("StartNodeID");
            }
        }
        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

    }
}