using RestaurantPosMAUI.Data;

namespace RestaurantPosMAUI
{
    public partial class App : Application
    {
        private readonly DatabaseService _databaseService;

        public App(DatabaseService databaseService)
        {
       
            InitializeComponent();

            MainPage = new AppShell();
            _databaseService = databaseService;

            //Task.Run(async () => await _databaseService.InitializeDatabaseAsync()).GetAwaiter().GetResult();
        }

        protected override async void OnStart()
        {
            base.OnStart();
            await _databaseService.InitializeDatabaseAsync();
        }
    }
}
