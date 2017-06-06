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

namespace AI_PROJECT
{
    /// <summary>
    /// Interaction logic for country.xaml
    /// </summary>
    public partial class country : TextBlock
    {
        int index;
        int color;
        Path map;
      
        public country()
        {
            InitializeComponent();          
        }
       
        public int country_color { get { return this.color; }

            set { this.color = value; }
        }
        public Path path_of_map { get { return this.map; } set { this.map = value; } }
        public int country_index
        {
            get { return this.index; }

            set { this.index = value; }
        }
        
       

    }
}
