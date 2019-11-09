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
                    Frame frame = new Frame
                    {
                        BorderColor = Color.Black
                    };

                    frame.BackgroundColor = Color.LightCoral;

                    Label label = new Label();
                    label.Text = page1.text.Split('\n')[0];
                    label.BackgroundColor = Color.LightCoral;
                    label.FontSize = 30;
                    frame.Content = label;

                    var tapG = new TapGestureRecognizer();
                    tapG.Tapped += (tapsender, taps) =>
                    {
                        var editor = new Page1(page1.text);
                        editor.Disappearing += (c, d) => {
                            page1.text = editor.text;
                            label.Text = editor.text.Split('\n')[0];
                        };
                        Navigation.PushAsync(editor);
                    };
                    
                    label.GestureRecognizers.Add(tapG);

                    var swipe = new SwipeGestureRecognizer();

                    if (stacklayout1.Height > stacklayout2.Height)
                    {
                        
                        swipe.Direction = SwipeDirection.Right;
                        swipe.Swiped += (swipesender, swipes) =>
                        {
                            stacklayout1.Children.Remove(frame);
                        };
                        stacklayout2.Children.Add(frame);
                    }
                    else
                    {
                        
                        swipe.Direction = SwipeDirection.Right;
                        swipe.Swiped += (swipesender, swipes) =>
                        {
                            stacklayout2.Children.Remove(frame);
                        };
                        stacklayout1.Children.Add(frame);
                    }
                    frame.GestureRecognizers.Add(swipe);

                }
            };
            Navigation.PushAsync(page1);
        }
    }
}
