using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmFoundation.Wpf;
using System.Windows.Input;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Xml.Serialization;
using System.IO;
using System.Windows.Media;
using System.Windows.Data;
using Microsoft.Win32;

namespace AgentAssignment
{
    // 
    public class Agents : ObservableCollection<Agent>, INotifyPropertyChanged
    {
        const string AppTitle = "Agent Assignments 4 - Lab 3";
        string filename = "";
        string filePath = "";
        string filter;
        bool dirty = false;

        public Agents()
        {
            if ((bool)(DesignerProperties.IsInDesignModeProperty.GetMetadata(typeof(DependencyObject)).DefaultValue))
            {
                // In Design mode
                Add(new Agent("001", "Nina", "Assassination", "UpperVolta"));
                Add(new Agent("007", "James Bond", "Martinis", "North Korea"));
                Title = "Untitled - " + AppTitle;
            }
            Title = "Untitled - " + AppTitle;
        }

        #region Commands

        ICommand _addCommand;
        public ICommand AddCommand
        {
            get { return _addCommand ?? (_addCommand = new RelayCommand(AddAgent)); }
        }

        private void AddAgent()
        {
            // Show Modal Dialog
            var dlg = new AgentWindow();
            dlg.Title = "Add New Agent";
            Agent newAgent = new Agent();
            dlg.DataContext = newAgent;
            if (dlg.ShowDialog() == true)
            {
                Add(newAgent);
                CurrentSpecialityIndex = 0;
                CurrentAgent = newAgent;
                dirty = true;
            }
        }

        ICommand _editCommand;
        public ICommand EditCommand
        {
            get { return _editCommand ?? (_editCommand = new RelayCommand(EditAgent, DeleteAgent_CanExecute)); }
        }

        private void EditAgent()
        {
            // Show Modal Dialog
            var dlg = new AgentWindow();
            dlg.Title = "Edit Agent";
            // Need a temp agent in case of cancel
            Agent tempAgent = new Agent();
            tempAgent.ID = CurrentAgent.ID;
            tempAgent.CodeName = currentAgent.CodeName;
            tempAgent.Speciality = currentAgent.Speciality;
            tempAgent.Assignment = currentAgent.Assignment;
            dlg.DataContext = tempAgent;
            if (dlg.ShowDialog() == true)
            {
                CurrentAgent.ID = tempAgent.ID;
                currentAgent.CodeName = tempAgent.CodeName;
                currentAgent.Speciality = tempAgent.Speciality;
                currentAgent.Assignment = tempAgent.Assignment;
                dirty = true;
            }
        }

        ICommand _deleteCommand;
        public ICommand DeleteCommand
        {
            get { return _deleteCommand ?? (_deleteCommand = new RelayCommand(DeleteAgent, DeleteAgent_CanExecute)); }
        }

        private void DeleteAgent()
        {
            MessageBoxResult res = MessageBox.Show("Are you sure you want to delete agent " + CurrentAgent.CodeName +
                "?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
            if (res == MessageBoxResult.Yes)
            {
                Remove(CurrentAgent);
                NotifyPropertyChanged("Count");
                dirty = true;
            }
        }

        private bool DeleteAgent_CanExecute()
        {
            if (Count > 0 && CurrentIndex >= 0)
                return true;
            else
                return false;
        }

        ICommand _nextCommand;
        public ICommand NextCommand
        {
            get
            {
                return _nextCommand ?? (_nextCommand = new RelayCommand(
                    () => ++CurrentIndex,
                    () => CurrentIndex < (Count - 1)));
            }
        }

        ICommand _PreviusCommand;
        public ICommand PreviusCommand
        {
            get { return _PreviusCommand ?? (_PreviusCommand = new RelayCommand(PreviusCommandExecute, PreviusCommandCanExecute)); }
        }

        private void PreviusCommandExecute()
        {
            if (CurrentIndex > 0)
                --CurrentIndex;
        }

        private bool PreviusCommandCanExecute()
        {
            if (CurrentIndex > 0)
                return true;
            else
                return false;
        }

        ICommand _SaveAsCommand;
        public ICommand SaveAsCommand
        {
            get { return _SaveAsCommand ?? (_SaveAsCommand = new RelayCommand(SaveAsCommand_Execute)); }
        }

        private void SaveAsCommand_Execute()
        {
            var dialog = new SaveFileDialog();

            dialog.Filter = "Agent assignment documents|*.agn|All Files|*.*";
            dialog.DefaultExt = "agn";
            if (filePath == "")
                dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            else
                dialog.InitialDirectory = Path.GetDirectoryName(filePath);

            if (dialog.ShowDialog(App.Current.MainWindow) == true)
            {
                filePath = dialog.FileName;
                filename = Path.GetFileName(filePath);
                SaveFile();
                Title = filename + " - " + AppTitle;
            }
        }

        ICommand _SaveCommand;
        public ICommand SaveCommand
        {
            get { return _SaveCommand ?? (_SaveCommand = new RelayCommand(SaveFileCommand_Execute, SaveFileCommand_CanExecute)); }
        }

        private void SaveFileCommand_Execute()
        {
            SaveFile();
        }

        private void SaveFile()
        {
            List<Agent> tempAgents;

            try
            {
                // Copy the agents to a List. 
                tempAgents = this.ToList<Agent>();
                Repository.SaveFile(filePath, tempAgents);
                dirty = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Unable to save file", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool SaveFileCommand_CanExecute()
        {
            return (filename != "") && (Count > 0);
        }

        ICommand _NewFileCommand;
        public ICommand NewFileCommand
        {
            get { return _NewFileCommand ?? (_NewFileCommand = new RelayCommand(NewFileCommand_Execute)); }
        }

        private void NewFileCommand_Execute()
        {
            if (dirty)
            {
                MessageBoxResult res = MessageBox.Show("You have unsaved data. Are you sure you want to initiate a new file without saving data first?",
                    "Warning", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
                if (res == MessageBoxResult.No)
                {
                    return;
                }
            }

            Clear();
            filename = "";
            Title = "Untitled - " + AppTitle;
            dirty = false;
        }


        ICommand _OpenFileCommand;
        public ICommand OpenFileCommand
        {
            get { return _OpenFileCommand ?? (_OpenFileCommand = new RelayCommand<string>(OpenFileCommand_Execute)); }
        }

        private void OpenFileCommand_Execute(string argFilename)
        {
            List<Agent> tempAgents;
            var dialog = new OpenFileDialog();

            if (dirty)
            {
                MessageBoxResult res = MessageBox.Show("You have unsaved data. Are you sure you want to open a new file without saving data first?",
                    "Warning", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
                if (res == MessageBoxResult.No)
                {
                    return;
                }
            }

            dialog.Filter = "Agent assignment documents|*.agn|All Files|*.*";
            dialog.DefaultExt = "agn";
            if (filePath == "")
                dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            else
                dialog.InitialDirectory = Path.GetDirectoryName(filePath);

            if (dialog.ShowDialog(App.Current.MainWindow) == true)
            {
                filePath = dialog.FileName;
                filename = Path.GetFileName(filePath);
                try
                {
                    Repository.ReadFile(filePath, out tempAgents);

                    // We have to insert the agents in the existing collection. 
                    Clear();
                    foreach (var agent in tempAgents)
                        Add(agent);
                    Title = filename + " - " + AppTitle;
                    dirty = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Unable to open file", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        ICommand _CloseAppCommand;
        public ICommand CloseAppCommand
        {
            get { return _CloseAppCommand ?? (_CloseAppCommand = new RelayCommand(CloseCommand_Execute)); }
        }

        private void CloseCommand_Execute()
        {
            bool regret = false;

            if (dirty)
            {
                MessageBoxResult res = MessageBox.Show("You have unsaved data. Are you sure you want to close the application without saving data first?",
                    "Warning", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
                if (res == MessageBoxResult.No)
                {
                    regret = true;
                }
            }
            if (!regret)
                Application.Current.MainWindow.Close();
        }

        ICommand _ColorCommand;
        public ICommand ColorCommand
        {
            get { return _ColorCommand ?? (_ColorCommand = new RelayCommand<String>(ColorCommand_Execute)); }
        }

        private void ColorCommand_Execute(String colorStr)
        {
            SolidColorBrush newBrush = SystemColors.WindowBrush; // Default color

            try
            {
                if (colorStr != null)
                {
                    if (colorStr != "Default")
                        newBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString(colorStr));
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Unknown color name, default color is used", "Program error!");
            }

            Application.Current.MainWindow.Resources["BackgroundBrush"] = newBrush;
        }
        #endregion // Commands

        #region Properties

        int currentIndex = -1;

        public int CurrentIndex
        {
            get { return currentIndex; }
            set
            {
                if (currentIndex != value)
                {
                    currentIndex = value;
                    NotifyPropertyChanged();
                }
            }
        }

        Agent currentAgent = null;

        public Agent CurrentAgent
        {
            get { return currentAgent; }
            set
            {
                if (currentAgent != value)
                {
                    currentAgent = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public IReadOnlyCollection<string> FilterSpecialities
        {
            get
            {
                ObservableCollection<string> result = new ObservableCollection<string>();
                result.Add("All");
                foreach (var s in new Specialities())
                    result.Add(s);
                return result;
            }
        }

        int currentSpecialityIndex = 0;

        public int CurrentSpecialityIndex
        {
            get { return currentSpecialityIndex; }
            set
            {
                if (currentSpecialityIndex != value)
                {
                    ICollectionView cv = CollectionViewSource.GetDefaultView(this);
                    currentSpecialityIndex = value;
                    if (currentSpecialityIndex == 0)
                        cv.Filter = null; // Index 0 is no filter (show all)
                    else
                    {
                        filter = FilterSpecialities.ElementAt(currentSpecialityIndex);
                        cv.Filter = CollectionViewSource_Filter;
                    }
                    NotifyPropertyChanged();
                }
            }
        }

        private bool CollectionViewSource_Filter(object ag)
        {
            Agent agent = ag as Agent;
            return (agent.Speciality == filter);
        }

        private string _title;
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                if (_title != value)
                {
                    _title = value;
                    NotifyPropertyChanged();
                }
            }
        }

        #endregion

        #region INotifyPropertyChanged implementation

        public new event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}
