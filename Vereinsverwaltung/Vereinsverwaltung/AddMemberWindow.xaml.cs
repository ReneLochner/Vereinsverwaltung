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
    /// Interaction logic for AddMemberWindow.xaml
    /// </summary>
    public partial class AddMemberWindow : Window
    {
        Member newMember;
        public AddMemberWindow()
        {
            InitializeComponent();
            Loaded += new RoutedEventHandler(AddMemberWindow_Loaded);
        }

        void AddMemberWindow_Loaded(object sender, RoutedEventArgs e)
        {
            btnSave.Click += new RoutedEventHandler(btnSave_Click);
            btnCancel.Click += new RoutedEventHandler(btnCancel_Click);
            Random random = new Random();
            newMember = new Member();
            newMember.Id = random.Next(100, 1000000); // Create "Unique" Id
            newMember.FirstName = "Vorname eingeben ...";
            newMember.LastName = "Nachname eingeben ...";
            newMember.Birthdate = "Geburtsdatum eingeben ...";

            grdMemberFields.DataContext = newMember;
        }

        void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Repository.GetInstance().AddMember(newMember);
            Close();
        }

        void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
