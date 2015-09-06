using RPGDatabaseManager.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.Windows.Controls;

namespace RPGDatabaseManager.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        //observable list of setting so the ui will know
        //when changes happen to the setting list like 
        //adding or removing a new setting
        private ObservableCollection<Setting> settings;
        public ObservableCollection<Setting> Settings
        {
            get { return settings; }
        }

        //create a new list of setting and add it to settings
        public MainWindowViewModel()
        {
            settings = new ObservableCollection<Setting>()
            {
                new Setting(new CharacterView(), "Character"),
                new Setting(new DialogueView(), "Dialogue"),
                new Setting(new ItemsView(), "Items"),
            };         
        }

        //update the view when selected tab changes
        private int selectedTab;
        public int SelectedTab
        {
            get { return selectedTab; }
            set
            {
                selectedTab = value;
                OnPropertyChanged("SelectedTab");
                UpdateView();

            }
        }

        //load the page of the particular tab
        private void UpdateView()
        {
            settings[SelectedTab].LoadPage();
        }

        //invoked when subscribing property changes value
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this,new PropertyChangedEventArgs(name));
            }
        }







    }
}
