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
                ChangeDeleteButtonText();
            }
        }

        private string deleteButtonText;
        public string DeleteButtonText
        {
            get { return deleteButtonText;}
            set
            {
                deleteButtonText = value;
                OnPropertyChanged();
            }
           
        }

        public ICommand AddCharacterCommand { get; }
        public ICommand DeleteCharacterCommand { get; }

        public CharacterViewModel()
        {
            //Bind Commands
            AddCharacterCommand = new Command(x => AddCharacter());
            DeleteCharacterCommand = new Command(x => DeleteCharacter());

            //Characters.Add(new Character("Sample"));
            //Characters.Add(new Character("Sample 2"));

        }

        private void AddCharacter()
        {
            Characters.Add(new Character("Sample", Characters.Count));
            SelectedCharacter = Characters[Characters.Count - 1];
        }

        private void DeleteCharacter()
        {
            //If Selected character is in the middle of the list, clear contents.
            //If Selected character is at the end of the list, delete instead.
            var index = SelectedCharacter.ID;

            if (index == Characters.Count - 1)
            {
                Characters.RemoveAt(index);

                if (Characters.Count > 0)
                {
                    SelectedCharacter = Characters[index - 1];
                }
            }
            else
            {
                SelectedCharacter.Reset();
                OnPropertyChanged();
            }

            
        }

        private void ChangeDeleteButtonText()
        {
            DeleteButtonText = SelectedCharacter != null && SelectedCharacter.ID == Characters.Count - 1 ? "Delete" : "Clear";

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
