using System.Windows;
using DialogHostTest.Utils;

namespace DialogHostTest;

public partial class MainWindow : Window {
    public MainWindow() {
        InitializeComponent();
    }

    private async void Short_OnClick(object sender, RoutedEventArgs e) {
        await DoTask(TimeSpan.FromMilliseconds(100));
    }

    private async void Medium_OnClick(object sender, RoutedEventArgs e) {
        await DoTask(TimeSpan.FromSeconds(1));
    }

    private async void Long_OnClick(object sender, RoutedEventArgs e) {
        await DoTask(TimeSpan.FromSeconds(5));
    }

    private async Task DoTask(TimeSpan timeSpan) {
        await ViewUtils.DoWithPreloader(async () => {
            await Task.Delay(timeSpan);
        });
    }
}