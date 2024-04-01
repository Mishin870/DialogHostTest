using MaterialDesignThemes.Wpf;

namespace DialogHostTest.Utils;

public static class ViewUtils {
    private const string ROOT_DIALOG = "RootDialog";

    private static void AutoClose(string host = ROOT_DIALOG) {
        if (DialogHost.IsDialogOpen(host)) {
            try {
                DialogHost.Close(host);
            } catch (Exception) {
                // ignored
            }
        }
    }

    public static async Task DoWithPreloader(Func<Task> task, string host = ROOT_DIALOG) {
        var dialog = new PreloaderDialog();
        var handler = (DialogOpenedEventHandler)(async (_, args) => {
            await task();

            if (!args.Session.IsEnded) {
                args.Session.Close(false);
            }
        });

        AutoClose(host);
        await DialogHost.Show(dialog, host, handler);
    }
}