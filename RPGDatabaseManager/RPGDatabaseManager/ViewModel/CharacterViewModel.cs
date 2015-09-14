using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using RPGDatabaseManager.Annotations;
using RPGDatabaseManager.Commands;
using RPGDatabaseManager.Models;

namespace RPGDatabaseManager.ViewModel
{
    class CharacterViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Character> Characters { get; set; } = new ObservableCollection<Character>();

        private Character selectedCharacter;

        public Character SelectedCharacter
        {
            get { return selectedCharacter; }
            set
            {
                selectedCharacter = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddCharacterCommand { get; }

        public CharacterViewModel()
        {
            AddCharacterCommand = new Command(x => AddCharacter());
            //Characters.Add(new Character("Sample"));
            //Characters.Add(new Character("Sample 2"));

        }

        private void AddCharacter()
        {
            Characters.Add(new Character("Sample"));
        }


        #region NotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
#endregion
    }
}
