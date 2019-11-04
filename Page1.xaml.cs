using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace testmobil
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
        public string text = null;
        public Page1()
        {
            InitializeComponent();
            text = null;
        }

        public Page1(string s)
        {
            InitializeComponent();
            TextHolder.Text = s;
            text = s;
        }



        private void Button_Clicked(object sender, EventArgs e)
        {
            text = TextHolder.Text;
            Navigation.PopAsync();
        }
    }

    
}