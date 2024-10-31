namespace MauiWebViewIssue;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
		loadWebView.Source = "https://github.com/letscodewithkalyan/JetPackCompose";
    }
}


