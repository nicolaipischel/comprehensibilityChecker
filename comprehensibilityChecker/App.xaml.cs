using System.Configuration;
using System.Windows;
using comprehensibilityChecker.Adapters;
using comprehensibilityChecker.Integrations;
using comprehensibilityChecker.UI;
using comprehensibilityChecker.WPF;

namespace comprehensibilityChecker
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private Integration _integration;

        private void OnStartup(object sender, StartupEventArgs e)
        {   
            var window = CreateWindow();
            var viewModel = SetupViewModel();

            var stopWordListPath = GetStopwordListPath();

            _integration = CreateIntegration(viewModel, stopWordListPath);

            var view = CreateView();
            ApplyViewModelToView(viewModel, view);
            ApplyViewToWindow(view, window);

            window.Show();
        }

        private string GetStopwordListPath()
        {
            return ConfigurationManager.AppSettings["StopWordListPath"];
        }

        private MainViewModel SetupViewModel()
        {
            var vm = new MainViewModel();
            vm.SelectManuscriptCommand = new ActionCommand<object>((parameter) => _integration.Run());
            return vm;

        }

        private Integration CreateIntegration(MainViewModel viewModel, string stopWordListPath)
        {
            var manuscriptProvider = new ManuscriptProvider();
            var stopWordProvider = new StopwordProvider(stopWordListPath);
            var userInterface = new UserInterface(viewModel);

            return new Integration(userInterface, manuscriptProvider, stopWordProvider);
        }

        private MainView CreateView()
        {
            return new MainView();
        }

        private MainWindow CreateWindow()
        {
            var window = new MainWindow {Title = "ComprehensibilityChecker"};
            return window;
        }

        private void ApplyViewModelToView(MainViewModel vm, MainView view)
        {
            view.DataContext = vm;
        }

        private void ApplyViewToWindow(MainView view, MainWindow window)
        {
            window.Content = view;
        }
    }
}
