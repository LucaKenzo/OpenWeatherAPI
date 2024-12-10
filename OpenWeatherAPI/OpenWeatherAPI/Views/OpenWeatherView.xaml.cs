using OpenWeatherAPI.ViewModels;

namespace OpenWeatherAPI.Views;

public partial class OpenWeatherView : ContentPage
{
    public partial class OpenWeatherView : ContentPage
    {
        private readonly OpenWeatherViewModel _viewModel;

        public OpenWeatherView()
        {
            InitializeComponent();
            _viewModel = BindingContext as OpenWeatherViewModel;

            // Carregar os dados iniciais
            Task.Run(async () => await InitializeWeatherData());
        }

        private void InitializeComponent()
        {
            throw new NotImplementedException();
        }

        private async Task InitializeWeatherData()
        {
            // Substitua "São Paulo" e coordenadas pelos valores desejados
            await _viewModel.LoadWeatherAsync("São Paulo");
            await _viewModel.LoadForecastAsync(-23.5505, -46.6333);
        }
    }
}