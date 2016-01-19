﻿using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Ninject;
using WPDevToolkit.UI;
using WPDevToolkit.ViewModel;

namespace WPDevToolkit.Views
{
    public sealed partial class AboutPage : BasePage
    {
        private readonly AboutViewModel _aboutVm;

        public AboutPage()
        {
            this.InitializeComponent();

            var kernel = new StandardKernel();
            kernel.Bind<AboutViewModel>().To<AboutViewModel>();

            // set data context
            _aboutVm = kernel.Get<AboutViewModel>();
            DataContext = _aboutVm;

            Loaded += AboutPage_OnLoaded;
        }

        private async void AboutPage_OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            await _aboutVm.LoadAsync();
        }

        private void ReleaseNotes_OnClick(Hyperlink sender, HyperlinkClickEventArgs args)
        {
            Frame.Navigate(typeof(ReleaseNotesPage));
        }

        private async void SupportListViewItem_OnTapped(object sender, TappedRoutedEventArgs e)
        {
            var lvi = sender as ListViewItem;
            if (lvi == null) return;

            switch ((string)lvi.Tag)
            {
                case "donation":
                    Frame.Navigate(typeof(DonationPage));
                    break;
                case "rating":
                    await _aboutVm.HandleRatingAsync();
                    break;
                case "feedback":
                    await _aboutVm.HandleFeedbackAsync();
                    break;
                case "sharing":
                    _aboutVm.HandleSharing();
                    break;
                case "bugreport":
                    await _aboutVm.HandleBugReportAsync();
                    break;
                default:
                    return;
                    break;
            }
        }
    }
}
