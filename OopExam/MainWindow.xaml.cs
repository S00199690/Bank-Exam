using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OopExam
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Account> accounts = new List<Account>();
        ObservableCollection<Account> filteredAccounts = new ObservableCollection<Account>();
        public MainWindow()
        {
            //upon running the program 2 account objects are created
            InitializeComponent();
            //checkboxes are checked upon running
            cbxCurrAccounts.IsChecked = true;
            cbxSavAccounts.IsChecked = true;
            CurrentAccount ca1 = new CurrentAccount("Peter", "Reilly", 10000.0, "11/01/2021", 100189);
            CurrentAccount ca2 = new CurrentAccount("Mary", "Smith", 25000.30, "01/10/2020", 100190);

            SavingsAccount sa1 = new SavingsAccount("David", "Reavey", 5000.0, "14/05/2020", 100200);
            SavingsAccount sa2 = new SavingsAccount("Lisa", "Maguire", 7500.0, "11/01/2021", 100201);

            //adds each employee to the employees list
            accounts.Add(ca1);
            accounts.Add(ca2);
            accounts.Add(sa1);
            accounts.Add(sa2);

            //refresh display
            lbxAccounts.ItemsSource = null;
            lbxAccounts.ItemsSource = accounts;
        }

        private void lbxAccounts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //selected employee object that refers to what is being selected in listbox
            //the item in the listbox is casted to an employee object
            Account selectedAccount = (Account)lbxAccounts.SelectedItem;

            //checks if the selected item is a part time employee and displays the details in the necessary fields
            if (selectedAccount is SavingsAccount)
            {
                SavingsAccount account = (SavingsAccount)selectedAccount;
                tbkFirstName.Text = account.FirstName;
                tbkLastName.Text = account.LastName;
                tbkBalance.Text = account.Balance.ToString();
                tbkInterestDate.Text = account.InterestDate;
                tbxTransactionAmt.Text = account.CalculateInterest().ToString();
               
            }
            //checks if the selected item is a full time employee and displays the details in the necessary fields
            else if (selectedAccount is CurrentAccount)
            {
                CurrentAccount account = (CurrentAccount)selectedAccount;
                tbkFirstName.Text = account.FirstName;
                tbkLastName.Text = account.LastName;
                tbkBalance.Text = account.Balance.ToString();
                tbkInterestDate.Text = account.InterestDate;
                tbxTransactionAmt.Text = account.CalculateInterest().ToString();
            }
        }

        private void cbxCurrAccounts_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
