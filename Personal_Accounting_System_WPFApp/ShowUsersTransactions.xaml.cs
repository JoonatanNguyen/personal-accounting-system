﻿using System;
using System.Windows.Controls;
using Personal_Accounting_System_WPFApp.Dtos;
using Personal_Accounting_System_WPFApp.Services;

namespace Personal_Accounting_System_WPFApp
{
    /// <summary>
    /// Interaction logic for ShowUsersTransactions.xaml
    /// </summary>
    public partial class ShowUsersTransactions : Page
    {
        public ShowUsersTransactions()
        {
            InitializeComponent();

            var userRoleService = new UserRoleService();
            var usersList = userRoleService.GetAllUsers();

            UsersListBox.ItemsSource = usersList;
        }

        private void UsersListBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = (UserRoleDto)UsersListBox.SelectedItems[0];
            UsersName.Content = selectedItem.UserId;
            
        }

        private void ModifyUser_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var selectedItem = (UserRoleDto)UsersListBox.SelectedItems[0];
            var userId = selectedItem.UserId;

            ModifyUserPage editUserPage = new ModifyUserPage(userId);
            NavigationService.Navigate(editUserPage);
            
        }

        private void ShowUsersTransactionPage_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var selectedItem = (UserRoleDto)UsersListBox.SelectedItems[0];
            var userId = selectedItem.UserId;

            ShowUsersTransactionsPage showUsersTransactionsPage = new ShowUsersTransactionsPage(userId);
            NavigationService.Navigate(showUsersTransactionsPage);
        }


        private void AddUser_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            AddUserPage addUserPage = new AddUserPage();
            NavigationService.Navigate(addUserPage);
        }
    }
}
