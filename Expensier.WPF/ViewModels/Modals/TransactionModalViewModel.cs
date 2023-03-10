using Expensier.Domain.Services.Transactions;
using Expensier.WPF.Commands;
using Expensier.WPF.State.Accounts;
using Expensier.WPF.State.Navigators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Expensier.WPF.ViewModels.Modals
{
    public class TransactionModalViewModel : ViewModelBase
    {
        private string _transactionName;
        public string TransactionName
        {
            get
            {
                return _transactionName;
            }
            set
            {
                _transactionName = value;
                OnPropertyChanged(nameof(TransactionName));
                OnPropertyChanged(nameof(CanAdd));
            }
        }

        private double _amount;
        public double Amount
        {
            get
            {
                return _amount;
            }
            set
            {
                _amount = value;
                OnPropertyChanged(nameof(Amount));
                OnPropertyChanged(nameof(CanAdd));
            }
        }

        private TransactionType _category;
        public TransactionType Category
        {
            get
            {
                return _category;
            }
            set
            {
                _category = value;
                OnPropertyChanged(nameof(Category));
            }
        }

        private DateTime _processDate = DateTime.Now;
        public DateTime ProcessDate
        {
            get
            {
                return _processDate;
            }
            set
            {
                _processDate = value;
                OnPropertyChanged(nameof(ProcessDate));
            }
        }

        public bool CanAdd => !string.IsNullOrEmpty(TransactionName) && Amount > 0.0;

        public IEnumerable<TransactionType> TransactionType => Enum.GetValues(typeof(TransactionType)).Cast<TransactionType>();

        public ICommand AddNewTransaction { get; }


        public TransactionModalViewModel(ITransactionService transactionService, AccountStore accountStore, IRenavigator renavigator)
        {
            AddNewTransaction = new AddTransactionCommand(this, transactionService, accountStore, renavigator);
        }
    }
}
