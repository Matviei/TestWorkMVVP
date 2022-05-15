using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TestWorkMVVP.Commands;
using TestWorkMVVP.CreateArrayAndFindValue;
using TestWorkMVVP.Models;
using TestWorkMVVP.ViewModels.Base;

namespace TestWorkMVVP.ViewModels
{
    class MainWindowViewModel : ViewModel
    {
        private string _SearhValue;

        public string SearhValue
        {
            get => _SearhValue;
            set => Set(ref _SearhValue, value);
        }

        private string _LogMessage = "Выберите файл";

        public string LogMessage
        {
            get => _LogMessage;
            set => Set(ref _LogMessage, value);
        }

        public ICommand SortBtCommand { get; }

        private bool CanSortBtCommandExecuted(object p) => true;

        private void OnSortBtCommandExecuted(object p)
        {
            ArrayBD.IntArray = null;
            CreateArray.ArrayCreate();
            if (ArrayBD.IntArray == null)
            {
                LogMessage += "\nОшибка";
                return;
            }

            LogMessage += "\nУспешно добавлено и отсортировано";
        }

        public ICommand SearhButtoncommand { get; }

        private bool CanSearhButtoncommandExecuted(object p)
        {
            return ArrayBD.IntArray != null;
        }

        private void OnSearhButtoncommandExecuted(object p)
        {
            int testConvertInt;
            if (!int.TryParse(SearhValue, out testConvertInt))
            {
                LogMessage += "\nВведите число типа Int32";
                return;

            }
            int count = FindValue.FindCountValue(Convert.ToInt32(SearhValue));
           if (count > 0)
           {
               LogMessage += "\nИскомое значение " + SearhValue + " в количестве " + count;
               return;
           }

           LogMessage += "\nЧисло "+SearhValue+" не найдено";

        }

            public MainWindowViewModel()
        {
            SortBtCommand = new LambdaCommand(OnSortBtCommandExecuted, CanSortBtCommandExecuted);
            SearhButtoncommand = new LambdaCommand(OnSearhButtoncommandExecuted, CanSearhButtoncommandExecuted);
        }

    }
}
