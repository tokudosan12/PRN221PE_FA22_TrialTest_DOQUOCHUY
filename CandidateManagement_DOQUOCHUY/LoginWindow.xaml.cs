using Candidate_BussinessObjects;
using Candidate_Services;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CandidateManagement_DOQUOCHUY
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private IHRAccountService iAccountService;
        public LoginWindow()
        {
            InitializeComponent();
            iAccountService = new HRAccountService();
        }

       

        private void btnlLogin_Click(object sender, RoutedEventArgs e)
        {
            Hraccount hraccount = iAccountService.GetHraccountByEmail(txtEmail.Text.Trim());
            
            if (hraccount != null && txtPassword.Password.Equals(hraccount.Password) )
            {
                int? roleID = hraccount.MemberRole;
                switch (roleID)
                {
                    case 1:
                        this.Hide();
                        CandidateProfileWindow candForm = new CandidateProfileWindow(roleID);
                        candForm.Show();
                        break;
                        case 2:
                        this.Hide();
                        CandidateProfileWindow staffCandidate = new CandidateProfileWindow();
                        staffCandidate.Show();
                        break;
                        case 3:
                        break;
                    default:
                        break;
                }
                
               // MessageBox.Show("Hello Huydo");
            }
            else
            {
                MessageBox.Show("Bye Bye"!);
            }
            
            

        }

        private void btnCancle_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}