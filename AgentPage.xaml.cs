﻿using System;
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

namespace Berdin_Glazki
{
    /// <summary>
    /// Логика взаимодействия для AgentPage.xaml
    /// </summary>
    public partial class AgentPage : Page
    {

        public AgentPage()
        {
            InitializeComponent();
            var currentAgent = Berdin_GlazkiEntities.GetContext().Agent.ToList();
            AgentListView.ItemsSource = currentAgent;

            ComboSort.SelectedIndex = 0;
            ComboFilter.SelectedIndex = 0;

            UpdateAgents();
        }

        private void UpdateAgents()
        {
            var currentAgent = Berdin_GlazkiEntities.GetContext().Agent.ToList();
            currentAgent = currentAgent.Where(p => (p.Title.ToLower().Contains(TBoxSearch.Text.ToLower()) || p.Phone.Replace("+", "").Replace(" ", "").Replace("(", "").Replace(")", "").Replace("-", "").Contains(TBoxSearch.Text) || p.Email.ToLower().Contains(TBoxSearch.Text.ToLower()))).ToList();
            
            
            if (ComboSort.SelectedIndex == 1)
            {
                currentAgent = currentAgent.OrderBy(p => p.Title).ToList();
            }
            if (ComboSort.SelectedIndex == 2)
            {
                currentAgent = currentAgent.OrderByDescending(p => p.Title).ToList();
            }
            if (ComboSort.SelectedIndex == 3)
            {
                currentAgent = currentAgent.OrderBy(p => p.Priority).ToList();
            }
            if (ComboSort.SelectedIndex == 4)
            {
                currentAgent = currentAgent.OrderByDescending(p => p.Priority).ToList();
            }
            
            
            if (ComboFilter.SelectedIndex == 0)
            {
                currentAgent = currentAgent.ToList();
            }
            if (ComboFilter.SelectedIndex == 1)
            {
                currentAgent = currentAgent.Where(p => p.AgentTypeID == 1).ToList();
            }

            if (ComboFilter.SelectedIndex == 2)
            {
                currentAgent = currentAgent.Where(p => p.AgentTypeID == 2).ToList();
            }

            if (ComboFilter.SelectedIndex == 3)
            {
                currentAgent = currentAgent.Where(p => p.AgentTypeID == 3).ToList();
            }
            if (ComboFilter.SelectedIndex == 4)
            {
                currentAgent = currentAgent.Where(p => p.AgentTypeID == 4).ToList();
            }
            if (ComboFilter.SelectedIndex == 5)
            {
                currentAgent = currentAgent.Where(p => p.AgentTypeID == 5).ToList();
            }
            if (ComboFilter.SelectedIndex == 6)
            {
                currentAgent = currentAgent.Where(p => p.AgentTypeID == 6).ToList();
            }
            AgentListView.ItemsSource = currentAgent;


        }

        private void TBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateAgents();
        }

        private void ComboFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateAgents();
        }

        private void ComboSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateAgents();
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            UpdateAgents();
        }
    }
}
