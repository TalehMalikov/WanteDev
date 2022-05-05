using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WanteDev.Core.DataAccess.Abstraction;
using WanteDev.Infrasturcture;
using WanteDev.Models;

namespace WanteDev.ViewModels
{
    public abstract class BaseControlViewModel<T> : BaseViewModel where T : BaseModel, new()
    {
        public IUnitOfWork DB { get; }
        public DataProvider DataProvider { get; }
        public BaseControlViewModel(IUnitOfWork db)
        {
            DB = db;
            DataProvider = new DataProvider(db);
        }

        #region 
        
        /* public virtual void Initialize()
        {
            Values = new ObservableCollection<T>(AllValues);
            CurrentSituation = (byte)Situations.NORMAL;
            CurrentValue = new T();
        }
*/
        private T currentValue = new T();
        public T CurrentValue
        {
            get
            {
                return currentValue;
            }
            set
            {
                currentValue = value;
                OnPropertyChanged(nameof(CurrentValue));
            }
        }
        
        /*
        private T selectedValue = new T();
        public virtual T SelectedValue
        {
            get
            {
                return selectedValue;
            }
            set
            {
                selectedValue = value;
                CurrentValue = (T)SelectedValue?.Clone();
                CurrentSituation = SelectedValue != null ? (byte)Situations.SELECTED : (byte)Situations.NORMAL;


                OnPropertyChanged(nameof(SelectedValue));
            }
        }

        public List<T> AllValues { get; set; }

        private ObservableCollection<T> values;
        public ObservableCollection<T> Values
        {
            get
            {
                return values;
            }
            set
            {
                values = value;
                OnPropertyChanged(nameof(Values));
            }
        }

        public virtual ICommand Reject => new RejectCommand<T>(this);


        public ExportExcelCommand<T> ExportExcel => new ExportExcelCommand<T>(this);

        public abstract void OnSearch();
        public abstract string Header { get; }

        private string searchText;
        public string SearchText
        {
            get
            {
                return searchText;
            }
            set
            {
                searchText = value;
                OnSearch();
            }
        }

        private byte currentSituation = (byte)Situations.NORMAL;
        public byte CurrentSituation
        {
            get => currentSituation;
            set
            {
                currentSituation = value;
                OnPropertyChanged(nameof(CurrentSituation));
            }
        }
*/
        #region error dialog
        /*
        private string _message;
        public string Message
        {
            get => _message;
            set
            {
                _message = value;
                OnPropertyChanged(nameof(Message));
                OnPropertyChanged(nameof(TextColor));
            }
        }

        public Brush TextColor => Message == Constants.OperationSuccessMessage ? Brushes.Green : Brushes.Red;
        public ErrorDialog ErrorDialog { get; set; }
*/
        #endregion
        /*
        protected bool IsCompatibleWithFilter<T>(T value)
        {
            if (value == null)
            {
                return true;
            }
            else if (value != null && Convert.ToString(value).ToLower().Contains(SearchText.ToLower()))
                return true;

            return false;
        }
         */
        #endregion
    }
}
