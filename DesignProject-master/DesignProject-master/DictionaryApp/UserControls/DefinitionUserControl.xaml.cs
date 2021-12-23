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

namespace DictionaryApp.UserControls
{
    /// <summary>
    /// Interaction logic for DefinitionUserControl.xaml
    /// </summary>
    public partial class DefinitionUserControl : UserControl
    {
        Grid _grid;
        public DefinitionUserControl(Grid grid,Models.DictionaryModel dictionary)
        {
            InitializeComponent();
            _grid = grid;
            word.Text = dictionary.WordUpper;
            def.Text = dictionary.Definition;
        }

        private void exitBtn_MouseDown(object sender, MouseButtonEventArgs e)
        {
            _grid.Children.Remove(this);
            
        }
    }
}
