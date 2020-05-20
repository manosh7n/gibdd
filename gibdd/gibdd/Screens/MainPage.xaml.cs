using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace gibdd
{
    public partial class MainPage : TabbedPage
    {
        public ProfileData profile { get; set; }
        public MainPage(ProfileData item)
        {
            profile = item;
            InitializeComponent();
        }
        
    }
}