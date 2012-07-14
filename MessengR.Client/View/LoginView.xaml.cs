﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MessengR.Client.View
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView
    {
        public LoginView()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            AuthenticationResult authResult = LoginHelper.Login(ConfigurationManager.AppSettings["HostURL"], txtUsername.Text, txtPassword.Password);
            if(authResult.StatusCode == HttpStatusCode.OK)
            {
                var mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
            else
            {
                if(!String.IsNullOrEmpty(authResult.Message))
                {
                    txtError.Text = authResult.Message;
                    txtError.Visibility = Visibility.Visible;
                }
            }
        }
    }
}
