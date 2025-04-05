namespace RestaurantPosMAUI.Controls;

public partial class CurrentDatetimeControl : ContentView, IDisposable
{
	private readonly PeriodicTimer _timer;
	public CurrentDatetimeControl()
	{
		InitializeComponent();

		dayTimeLable.Text = DateTime.Now.ToString("dddd, hh:mm:ss tt");
		dateLable.Text = DateTime.Now.ToString("MMM dd, yyyy");

		_timer = new PeriodicTimer(TimeSpan.FromSeconds(1));
		UpdateTimer();

    }

    public void Dispose()=> _timer?.Dispose();

    private async void UpdateTimer()
	{
		if (_timer != null)
		{
			while(await _timer.WaitForNextTickAsync())
			{
                dayTimeLable.Text = DateTime.Now.ToString("dddd, hh:mm:ss tt");
                dateLable.Text = DateTime.Now.ToString("MMM dd, yyyy");
            }
		}
	}
}