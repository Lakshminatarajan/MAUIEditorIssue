namespace MAUIEditorIssue
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }
    }

    public class CustomStyleEditor : Editor

    {

#if WINDOWS
 
        protected override void OnHandlerChanged()

        {

            // Hide editor border and underline.

            var platformView = this.Handler?.PlatformView as Microsoft.UI.Xaml.Controls.TextBox;

            if (platformView != null)

            {

                this.ApplyTextBoxStyle(platformView);

            }
 
 
            base.OnHandlerChanged();

        }
 
        private void ApplyTextBoxStyle(Microsoft.UI.Xaml.Controls.TextBox? textbox)

        {

            var textBoxStyle = new Microsoft.UI.Xaml.Style(typeof(Microsoft.UI.Xaml.Controls.TextBox));

            textBoxStyle.Setters.Add(new Microsoft.UI.Xaml.Setter() { Property = Microsoft.UI.Xaml.Controls.Control.BorderBrushProperty, Value = new Microsoft.UI.Xaml.Media.SolidColorBrush(Windows.UI.Color.FromArgb(0, 0, 0, 0)) });

            textBoxStyle.Setters.Add(new Microsoft.UI.Xaml.Setter() { Property = Microsoft.UI.Xaml.Controls.Control.BorderThicknessProperty, Value = new Thickness(0) });
 
            textbox!.Resources.Add(typeof(Microsoft.UI.Xaml.Controls.TextBox), textBoxStyle);

        }

#endif

    }


}
