using Avalonia.Controls;
using demoMatModel1.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace demoMatModel1
{
    public partial class MainWindow : Window
    {
        public List<Employee> emp = Helper.context.Employees.Include(x => x.IdDolzhnostNavigation).Include(x => x.IdPodrazdNavigation).ToList();
        public MainWindow()
        {
            InitializeComponent();
            grid.DataContext = emp;
            list.ItemsSource = emp;
        }
    }
}