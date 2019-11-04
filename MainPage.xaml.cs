using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace testmobil
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            var page1 = new Page1();
            
            page1.Disappearing += (a, b) => {
                if (page1.text != null)
                {
                    Label label = new Label();
                    label.Text = page1.text.Split('\n')[0];
                    label.BackgroundColor = Color.LightCoral;
                    label.FontSize = 30;

                    var tapG = new TapGestureRecognizer();
                    tapG.Tapped += (tapsender, taps) =>
                    {

                        //label.Text = "gavno";
                        var editor = new Page1(page1.text);
                        editor.Disappearing += (c, d) => {
                            page1.text = editor.text;

                            label.Text = editor.text.Split('\n')[0];
                        };
                        Navigation.PushAsync(editor);
                    };
                    label.GestureRecognizers.Add(tapG);
                    stacklayout1.Children.Add(label);
                }
            };
            Navigation.PushAsync(page1);
        }
    }
}
