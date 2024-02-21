using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TaskInTray
{
    public class ViewModel: INotifyPropertyChanged
    {
        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged([CallerMemberName] string propertyName = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        #endregion

        #region Member

        protected string _textTaskName = string.Empty;

        protected DateTime _selectedTaskDate = DateTime.Now;

        #endregion

        #region Property

        public DelegateCommand CommandAddTask { get; } = null;

        public ObservableCollection<TaskData> TaskDataList { get; set; } = new ObservableCollection<TaskData>();

        public string TextTaskName { get { return _textTaskName; } set { _textTaskName = value; RaisePropertyChanged("TextTaskName"); } }

        public DateTime SelectedTaskDate { get { return _selectedTaskDate; } set { _selectedTaskDate = value; RaisePropertyChanged("SelectedTaskDate"); } }

        #endregion

        public ViewModel()
        {
            CommandAddTask = new DelegateCommand(AddTask);

            TaskDataList.Add(new TaskData() { Name = "Hoge" });
            TaskDataList.Add(new TaskData() { Name = "Fuga" });
            TaskDataList.Add(new TaskData() { Name = "Hage" });
        }

        protected void AddTask(object sender)
        {
            TaskDataList.Add(new TaskData() { Name = TextTaskName, DeadlineDate = SelectedTaskDate });
        }
    }
}
