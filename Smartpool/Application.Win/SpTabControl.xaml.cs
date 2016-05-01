//========================================================================
// DESCR.   :   Logic to create button events and expose it to the container.
//              Allows button click events to be caught by the container 
//              SpTabControl even though the buttons are within it.
//------------------------------------------------------------------------ 
// REV. AUTHOR  CHANGE DESCRIPTION
// 1.0  EN      Initial version with event for Stats
// 1.01 EN      Added event for History
// 1.02 EN      Added events for AddPool and EditPool
//========================================================================

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
        private Button _showAddPoolViewbutton;
        private Button _showEditPoolViewbutton;

        // events exposed to container
        public static readonly RoutedEvent OnShowStatButtonClickedEvent =
            EventManager.RegisterRoutedEvent("OnShowStatButtonClicked", RoutingStrategy.Direct, typeof(RoutedEventHandler), typeof(SpTabControl));
        public static readonly RoutedEvent OnShowHistoryButtonClickedEvent =
            EventManager.RegisterRoutedEvent("OnShowHistoryButtonClicked", RoutingStrategy.Direct, typeof(RoutedEventHandler), typeof(SpTabControl));
        public static readonly RoutedEvent OnShowAddPoolButtonClickedEvent =
            EventManager.RegisterRoutedEvent("OnShowAddPoolButtonClicked", RoutingStrategy.Direct, typeof(RoutedEventHandler), typeof(SpTabControl));
        public static readonly RoutedEvent OnShowEditPoolButtonClickedEvent =
            EventManager.RegisterRoutedEvent("OnShowEditPoolButtonClicked", RoutingStrategy.Direct, typeof(RoutedEventHandler), typeof(SpTabControl));

        static SpTabControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SpTabControl), new FrameworkPropertyMetadata(typeof(SpTabControl)));
        }

        // Get the button objects as the template is applied and add click event handlers
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            _showStatViewbutton = GetTemplateChild("PART_StatViewButton") as Button;
            _showHistoryViewbutton = GetTemplateChild("PART_HistoryViewButton") as Button;
            _showAddPoolViewbutton = GetTemplateChild("PART_AddPoolViewButton") as Button;
            _showEditPoolViewbutton = GetTemplateChild("PART_EditPoolViewButton") as Button;

            if (_showStatViewbutton != null) _showStatViewbutton.Click += ShowStatButtonClicked;
            if (_showHistoryViewbutton != null) _showHistoryViewbutton.Click += ShowHistoryButtonClicked;
            if (_showAddPoolViewbutton != null) _showAddPoolViewbutton.Click += ShowAddPoolButtonClicked;
            if (_showEditPoolViewbutton != null) _showEditPoolViewbutton.Click += ShowEditPoolButtonClicked;

        }

        // Expose and raise 'OnShowStatButtonClicked' event
        public event RoutedEventHandler OnShowStatButtonClicked
        {
            add { AddHandler(OnShowStatButtonClickedEvent, value); }
            remove { RemoveHandler(OnShowStatButtonClickedEvent, value); }
        }

        private void ShowStatButtonClicked(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(OnShowStatButtonClickedEvent));
        }

        // Expose and raise 'OnShowHistoryButtonClicked' event
        public event RoutedEventHandler OnShowHistoryButtonClicked
        {
            add { AddHandler(OnShowHistoryButtonClickedEvent, value); }
            remove { RemoveHandler(OnShowHistoryButtonClickedEvent, value); }
        }

        private void ShowHistoryButtonClicked(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(OnShowHistoryButtonClickedEvent));
        }

        // expose and raise 'OnShowAddPoolButtonClicked' event
        public event RoutedEventHandler OnShowAddPoolButtonClicked
        {
            add { AddHandler(OnShowAddPoolButtonClickedEvent, value); }
            remove { RemoveHandler(OnShowAddPoolButtonClickedEvent, value); }
        }

        private void ShowAddPoolButtonClicked(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(OnShowAddPoolButtonClickedEvent));
        }

        // expose and raise 'OnShowHistoryButtonClicked' event
        public event RoutedEventHandler OnShowEditPoolButtonClicked
        {
            add { AddHandler(OnShowEditPoolButtonClickedEvent, value); }
            remove { RemoveHandler(OnShowEditPoolButtonClickedEvent, value); }
        }

        private void ShowEditPoolButtonClicked(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(OnShowEditPoolButtonClickedEvent));
        }
    }
}