using Candidate_BussinessObjects;
using Candidate_Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CandidateManagement_DOQUOCHUY
{
    /// <summary>
    /// Interaction logic for CandidateProfileWindow.xaml
    /// </summary>
    public partial class CandidateProfileWindow : Window
    {
        private readonly ICandidateProfileService profileService;
        private readonly IJobPostingService jobService;
        private readonly int? roleID;
        public CandidateProfileWindow()
        {
            InitializeComponent();
            this.profileService = new CandidateProfileService();
           this.jobService = new JobPostingService();   
        }
        public CandidateProfileWindow(int? roleID)
        {
            InitializeComponent();
          this.profileService = new CandidateProfileService();
            this.jobService = new JobPostingService();
            this.roleID = roleID;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            switch (roleID)
            {
                case 1: 
                    break;
                    case 2:
                    //staff
                    this.btnAdd.IsEnabled = false;
                      break;
                    case 3:
                    break;
                    default:
                    this.Close();
                    break;
            }
            this.loadDataInt();
        }
        private void loadDataInt()
        {

            this.dtgCandidateProfile.ItemsSource = profileService.GetCandidatesProfiles()
                .Select(a => new
                {
                    a.CandidateId,
                    a.Fullname,
                    a.Posting.JobPostingTitle,
                    a.Birthday,
                    a.ProfileShortDescription,
                    a.ProfileUrl,
                });
            this.cmbPostID.ItemsSource = jobService.GetJobPostings();
            this.cmbPostID.DisplayMemberPath = "JobPostingTitle";
            this.cmbPostID.SelectedValuePath = "PostingId";
        }


        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
           
            // Create new candidate and set all value from form
            CandidateProfile candidateProfile = new CandidateProfile();
            candidateProfile.CandidateId = txtCandidateID.Text;
            candidateProfile.Fullname = txtFullname.Text;
            candidateProfile.Birthday = dpBirthday.SelectedDate;
            candidateProfile.ProfileShortDescription = txtDescription.Text;
            candidateProfile.ProfileUrl = txtImage.Text;
            candidateProfile.PostingId = cmbPostID.SelectedValue.ToString();
            // Save candidate to DB
            if (profileService.AddCandidateProfile(candidateProfile))
            {
                System.Windows.MessageBox.Show("Add Successful");
                this.loadDataInt();
            }
            else
            {
                System.Windows.MessageBox.Show("Something is wrong");
            }
     }
        


        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void dtgCandidateProfile_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // ?
            DataGrid? dataGrid = sender as DataGrid;
            DataGridRow? row = (DataGridRow)dataGrid.ItemContainerGenerator.ContainerFromIndex(dataGrid.SelectedIndex);
            if (row != null)
            {
                DataGridCell? RowColumn = dataGrid.Columns[0].GetCellContent(row).Parent as DataGridCell;
                String? id = ((TextBlock)RowColumn.Content).Text;
                if (id != null)
                {
                    // Keep user input in form
                    CandidateProfile candidateProfile = profileService.GetCandidateProfiles(id);
                    txtCandidateID.Text = candidateProfile.CandidateId;
                    txtFullname.Text = candidateProfile.Fullname;
                    dpBirthday.SelectedDate = candidateProfile.Birthday;
                    txtDescription.Text = candidateProfile.ProfileShortDescription;
                    txtImage.Text = candidateProfile.ProfileUrl;
                    cmbPostID.SelectedValue = candidateProfile.PostingId;
                }
            }
        }
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            CandidateProfile candidateProfile = new CandidateProfile();
            candidateProfile.CandidateId = txtCandidateID.Text;
            
            profileService.DeleteCandidateProfile(candidateProfile.CandidateId);
            // Reload the Data grid
            this.dtgCandidateProfile.ItemsSource = profileService.GetCandidatesProfiles();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            // Create new candidate and set all value from form
            CandidateProfile candidateProfile = new CandidateProfile();
            candidateProfile.CandidateId = txtCandidateID.Text;
            candidateProfile.Fullname = txtFullname.Text;
            candidateProfile.Birthday = dpBirthday.SelectedDate;
            candidateProfile.ProfileShortDescription = txtDescription.Text;
            candidateProfile.ProfileUrl = txtImage.Text;
            candidateProfile.PostingId = cmbPostID.SelectedValue.ToString();
            // Update candidate to DB
            profileService.UpdateCandidateProfile(candidateProfile);
            // Reload the Data grid
            this.dtgCandidateProfile.ItemsSource = profileService.GetCandidatesProfiles();
        }

        private void btnDelete_Click_1(object sender, RoutedEventArgs e)
        {
            CandidateProfile candidateProfile = new CandidateProfile();
            candidateProfile.CandidateId = txtCandidateID.Text;

            profileService.DeleteCandidateProfile(candidateProfile.CandidateId);
            // Reload the Data grid
            this.dtgCandidateProfile.ItemsSource = profileService.GetCandidatesProfiles();
        }
    }
}


    

