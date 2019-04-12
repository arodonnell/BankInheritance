using System;
using System.Collections.Generic;
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
using System.Collections.ObjectModel;

namespace Bank
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<BankAccount> accounts = new ObservableCollection<BankAccount>();
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            BankAccount b1 = new BankAccount("Keith McManus", "901214", "12344321", 1000m);
            BankAccount b2 = new BankAccount("Kara McManus", "901214", "12349876", 2000m);
            BankAccount b3 = new BankAccount("Kiera McManus", "901214", "12346543", 3000m);
            BankAccount b4 = new BankAccount("Ken McManus", "901214", "12346345", 4000m);


            SavingsAccount s1 = new SavingsAccount("Tom Jones", "901214", "43214321", 1000m, 0.08m);
            SavingsAccount s2 = new SavingsAccount("Aled Jones", "901214", "43214321", 1000m, 0.08m);
            SavingsAccount s3 = new SavingsAccount("Alice Jones", "901214", "43214321", 1000m, 0.08m);
            SavingsAccount s4 = new SavingsAccount("Alana Jones", "901214", "43214321", 1000m, 0.08m);

            accounts.Add(b1);
            accounts.Add(b2);
            accounts.Add(b3);
            accounts.Add(b4);

            accounts.Add(s1);
            accounts.Add(s2);
            accounts.Add(s3);
            accounts.Add(s4);

            lbxDisplay.ItemsSource = accounts;
        }
        //Display list box details of item selected

        private void lbxDisplay_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //BankAccount selectedAccount = accounts[lbxDisplay.SelectedIndex];

            BankAccount selectedAccount = lbxDisplay.SelectedItem as BankAccount;

            tblkDetail.Text = selectedAccount.GetDetail();
        }

        //withdraw
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            BankAccount selectedAccount = accounts[lbxDisplay.SelectedIndex];

            decimal amtToWithdraw = Convert.ToDecimal(tbxAmount.Text);

            selectedAccount.Balance -= amtToWithdraw;

            tblkDetail.Text = selectedAccount.GetDetail();
        }

        //deposit
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            BankAccount selectedAccount = accounts[lbxDisplay.SelectedIndex];

            decimal amtToDeposit = Convert.ToDecimal(tbxAmount.Text);

            selectedAccount.Balance += amtToDeposit;

            tblkDetail.Text = selectedAccount.GetDetail();
        }

        //add interest
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("Not yet implemented");

            //BankAccount selectedAccount = accounts[lbxDisplay.SelectedIndex];

            BankAccount selectedAccount = lbxDisplay.SelectedItem as BankAccount;

            selectedAccount.GetType();

            if (selectedAccount is SavingsAccount)
            {
                //SavingsAccount savAccount = (SavingsAccount)selectedAccount;
                SavingsAccount savAccount = selectedAccount as SavingsAccount;
                savAccount.Balance = savAccount.Balance + (savAccount.Balance * savAccount.Rate);
                tblkDetail.Text = selectedAccount.GetDetail();


            }
            else if (selectedAccount is BankAccount)
            {
                MessageBox.Show("Is a bank account, can't add interest");
            }
        }

        private void tbxAmount_GotFocus(object sender, RoutedEventArgs e)
        {
            tbxAmount.Text = "";
        }
    }
}
