using System.Windows;
using System.Windows.Controls;

// ReSharper disable once CheckNamespace
namespace Smartpool.Application.Win
{
    public class SpTabControl : Button
    {
        // button objects
        private Button _showStatViewbutton;
        private Button _showHistoryViewbutton;

        // events exposed to container
        public static readonly RoutedEvent OnShowStatButtonClickedEvent =
            EventManager.RegisterRoutedEvent("OnShowStatButtonClicked", RoutingStrategy.Direct, typeof(RoutedEventHandler), typeof(SpTabControl));
        public static readonly RoutedEvent OnShowHistoryButtonClickedEvent =
            EventManager.RegisterRoutedEvent("OnShowHistoryButtonClicked", RoutingStrategy.Direct, typeof(RoutedEventHandler), typeof(SpTabControl));

        static SpTabControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SpTabControl), new FrameworkPropertyMetadata(typeof(SpTabControl)));
        }

        // get the button objects as the template is applied and add click event handlers
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            _showStatViewbutton = GetTemplateChild("PART_StatViewButton") as Button;
            _showHistoryViewbutton = GetTemplateChild("PART_HistoryViewButton") as Button;

            if (_showStatViewbutton != null) _showStatViewbutton.Click += ShowStatButtonClicked;

            if (_showHistoryViewbutton != null) _showHistoryViewbutton.Click += ShowHistoryButtonClicked;

        }

        // expose and raise 'OnShowStatButtonClicked' event
        public event RoutedEventHandler OnShowStatButtonClicked
        {
            add { AddHandler(OnShowStatButtonClickedEvent, value); }
            remove { RemoveHandler(OnShowStatButtonClickedEvent, value); }
        }

        private void ShowStatButtonClicked(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(OnShowStatButtonClickedEvent));
        }

        // expose and raise 'OnShowHistoryButtonClicked' event
        public event RoutedEventHandler OnShowHistoryButtonClicked
        {
            add { AddHandler(OnShowHistoryButtonClickedEvent, value); }
            remove { RemoveHandler(OnShowHistoryButtonClickedEvent, value); }
        }

        private void ShowHistoryButtonClicked(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(OnShowHistoryButtonClickedEvent));
        }
    }
}