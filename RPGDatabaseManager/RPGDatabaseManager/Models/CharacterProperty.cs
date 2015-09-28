using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using RPGDatabaseManager.Annotations;

namespace RPGDatabaseManager.Models
{
    public class CharacterProperty<T> : INotifyPropertyChanged, ICharacterProperty
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

        public Type Type
        {
            get
            {
                return typeof(T);
            }
        }

        private T propertyValue;

        public T PropertyValue
        {
            get { return propertyValue; }
            set
            {
                propertyValue = value;
                OnPropertyChanged();
            }
        }

        public static implicit operator T(CharacterProperty<T> value)
        {
            return value.PropertyValue;
        }

        public static implicit operator CharacterProperty<T>(T value)
        {
            return new CharacterProperty<T> { PropertyValue = value };
        }


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}