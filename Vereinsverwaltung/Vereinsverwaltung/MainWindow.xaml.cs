using MemberManager;
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

namespace Vereinsverwaltung
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Member> members;
        public MainWindow()
        {
            InitializeComponent();
            Loaded += new RoutedEventHandler(MainWindow_Loaded);
        }

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Repository rep = Repository.GetInstance();
            members = rep.GetAllMember();
            lvnames.ItemsSource = members;

            btnNew.Click += new RoutedEventHandler(btnNew_Click);
            btnDelete.Click += new RoutedEventHandler(btnDelete_Click);
            btnEdit.Click += new RoutedEventHandler(btnEdit_Click);
        }

        void btnNew_Click(object sender, RoutedEventArgs e)
        {
            AddMemberWindow addMemberWindow = new AddMemberWindow();
            addMemberWindow.ShowDialog();
            members = Repository.GetInstance().GetAllMember();
            lvnames.ItemsSource = members;
        }

        void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if(lvnames.SelectedItem == null)
            {
                return;
            }
            Member selectedMember = (Member)lvnames.SelectedItem;
            Repository.GetInstance().RemoveMember(selectedMember);
            members = Repository.GetInstance().GetAllMember();
            lvnames.ItemsSource = members;
        }

        void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (lvnames.SelectedItem == null)
            {
                return;
            }
            Member selectedMember = (Member)lvnames.SelectedItem;
            EditMemberWindow editMemberWindow = new EditMemberWindow(selectedMember);
            editMemberWindow.ShowDialog();
            members = Repository.GetInstance().GetAllMember();
            lvnames.ItemsSource = members;
        }
    }
}
