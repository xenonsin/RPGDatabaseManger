using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using RPGDatabaseManager.Annotations;

namespace RPGDatabaseManager.Models
{
    class Character : INotifyPropertyChanged
    {
        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }

        private int id;
        public int ID
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged();
            }
        }

        private string description;

        public string Description
        {
            get { return description; }
            set
            {
                description = value;
                OnPropertyChanged();
            }
        }
        //Dictionary could be better
        public List<CharacterAttribute> Attributes { get; private set; } = new List<CharacterAttribute>();
        public ObservableDictionary<string,ICharacterProperty> Properties { get; private set; } = new ObservableDictionary<string,ICharacterProperty> ();
        public List<CharacterStats> Stats { get; private set; } = new List<CharacterStats>();
        public List<CharacterPortraits> Portraits { get; private set; } = new List<CharacterPortraits>();

        public Character(string name)
        {
            Name = name;
            Description = "Sample Text";
            ID = -1;
        }
        public Character(string name, int id)
        {
            Name = name;
            Description = "Sample Text";
            ID = id;
        }

        public void Reset()
        {
            Name = "Sample";
            Description = "Sample Text";

            //TODO: Need to change implementation to support dynamic adding of fields.
            //Attributes = new List<CharacterAttribute>();
            //Properties = new List<CharacterProperty>();
            //Stats = new List<CharacterStats>();
            //Portraits = new List<CharacterPortraits>();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
