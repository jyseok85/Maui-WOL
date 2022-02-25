namespace WOL;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}


    private async void Button_Clicked1(object sender, EventArgs e)
    {
		await WOL.WakeOnLan("10-E7-C6-39-8D-7E");		
    }
	private async void Button_Clicked2(object sender, EventArgs e)
	{
		await WOL.WakeOnLan("10-E7-C6-39-8D-7E");
	}
	private async void Button_Clicked3(object sender, EventArgs e)
	{
		await WOL.WakeOnLan("10-E7-C6-39-8D-7E");
	}
}

