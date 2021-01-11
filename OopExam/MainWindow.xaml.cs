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

            //adds each account to the accounts list
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
            //selected account object that refers to what is being selected in listbox
            //the item in the listbox is casted to an account object
            Account selectedAccount = (Account)lbxAccounts.SelectedItem;

            //checks if the selected item is savings account and displays the details in the necessary fields
            if (selectedAccount is SavingsAccount)
            {
                SavingsAccount account = (SavingsAccount)selectedAccount;
                tbkFirstName.Text = account.FirstName;
                tbkLastName.Text = account.LastName;
                tbkBalance.Text = account.Balance.ToString();
                tbkInterestDate.Text = account.InterestDate;
                tbxTransactionAmt.Text = account.CalculateInterest().ToString();
               
            }
            //checks if the selected item is a current acccount and displays the details in the necessary fields
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
            //clears any objects currently in the collection and sets the listbox to null
            filteredAccounts.Clear();
            lbxAccounts.ItemsSource = null;

            //if both current account and savings account checkboxes are ticked add in all accounts
            if (cbxCurrAccounts.IsChecked == true && cbxSavAccounts.IsChecked == true)
            {
                foreach (Account account in accounts)
                {
                    filteredAccounts.Add(account);
                }
                //display accounts in listbox
                lbxAccounts.ItemsSource = filteredAccounts;
            }
            else
            {
                //if current account is checked and not savings account display current accounts
                if (cbxCurrAccounts.IsChecked == true && cbxSavAccounts.IsChecked == false)
                {
                    foreach (Account account in accounts)
                    {
                        if (account is CurrentAccount)
                        {
                            filteredAccounts.Add(account);
                        }

                    }
                    //display accounts in listbox
                    lbxAccounts.ItemsSource = filteredAccounts;
                }
                //if savings account is checked and not current account display savings accounts
                else if (cbxSavAccounts.IsChecked == true && cbxCurrAccounts.IsChecked == false)
                {
                    foreach (Account account in accounts)
                    {
                        if (account is SavingsAccount)
                        {
                            filteredAccounts.Add(account);
                        }

                    }
                    //display accounts in listbox
                    lbxAccounts.ItemsSource = filteredAccounts;

                }
                //if both boxes are not ticked no accounts are displayed
                else if (cbxSavAccounts.IsChecked == false && cbxCurrAccounts.IsChecked == false)
                {
                    //clears the filteredAccounts collection and outputs empty collection
                    filteredAccounts.Clear();
                    lbxAccounts.ItemsSource = filteredAccounts;
                }

            }
        }
    }
}
