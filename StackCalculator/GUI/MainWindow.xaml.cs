using Microsoft.Win32;
using StackCalculatror.Core;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private NameManager _nameManager;
        private FunctionLoader _functionLoader;
        private ExpressionParser _expressionParser;

        private void Button_Add_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                FileName = "Library",
                DefaultExt = ".dll",
                Filter = "Library file (.dll)|*.dll"
            };

            bool? result = dialog.ShowDialog();

            if (result == true)
            {
                var filename = dialog.FileName;
                try
                {
                    var file = new FileInfo(filename);
                    _functionLoader.LoadFunctionsFromAssemblyPath(filename);
                    lbLibraries.Items.Add(file.Name);
                    UpdateFuntionList();
                }
                catch
                {

                }
            }
        }

        private void UpdateFuntionList()
        {
            lbFuntions.Items.Clear();
            foreach (var name in _nameManager.GetAllNames())
            {
                lbFuntions.Items.Add(name);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _nameManager = new NameManager();
            _functionLoader = new FunctionLoader(_nameManager);
            _expressionParser = new ExpressionParser(_nameManager);

            _functionLoader.LoadFunctionsFromAssembly(typeof(NameManager).Assembly);
            lbLibraries.Items.Add("StackArithmetic.dll");
            UpdateFuntionList();
        }

        private void Button_Open_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                FileName = "Text file",
                DefaultExt = ".txt",
                Filter = "Text file (.txt)|*.txt|All files|*.*"
            };

            bool? result = dialog.ShowDialog();

            if (result == true)
            {
                var filename = dialog.FileName;
                tbInputExpression.Text = String.Join(" ", File.ReadAllLines(filename));
            }
        }

        private void Button_Run_Click(object sender, RoutedEventArgs e)
        {
            tbOutputExpression.Text = "";
            try
            {
                var expression = _expressionParser.Parse(tbInputExpression.Text);
                var stack = new Stack<object>();
                expression(stack);
                var result = stack.Select(outputElement => outputElement.ToString()).Reverse();
                tbOutputExpression.Text = string.Join(" ", result);
            }
            catch (Exception)
            {
                tbOutputExpression.Text = "Incorrect expression";
            }
        }
    }
}
