using MemberManager;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Vereinsverwaltung
{
    /// <summary>
    /// Interaction logic for EditMemberWindow.xaml
    /// </summary>
    public partial class EditMemberWindow : Window
    {
        Member selectedMember;
        public EditMemberWindow(Member selectedMember)
        {
            InitializeComponent();
            Loaded += new RoutedEventHandler(EditMemberWindow_Loaded);
            this.selectedMember = new Member();
            this.selectedMember.Id = selectedMember.Id;
            this.selectedMember.FirstName = selectedMember.FirstName;
            this.selectedMember.LastName = selectedMember.LastName;
            this.selectedMember.Birthdate = selectedMember.Birthdate;
        }

        void EditMemberWindow_Loaded(object sender, RoutedEventArgs e)
        {
            btnSave.Click += new RoutedEventHandler(btnSave_Click);
            btnCancel.Click += new RoutedEventHandler(btnCancel_Click);

            grdMemberFields.DataContext = selectedMember;
        }

        void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Repository.GetInstance().EditMember(selectedMember);
            Close();
        }

        void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
