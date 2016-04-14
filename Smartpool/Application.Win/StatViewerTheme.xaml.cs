using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

// ReSharper disable once CheckNamespace
namespace Smartpool.Application.Win
{
    public class StatViewer : Button
    {
        public Brush BorderColor
        {
            get { return (Brush)GetValue(BorderColorProperty); }
            set { SetValue(BorderColorProperty, value); }
        }

        public static readonly DependencyProperty BorderColorProperty =
            DependencyProperty.RegisterAttached(
                "BorderColor",
                typeof(Brush),
                typeof(StatViewer),
                new FrameworkPropertyMetadata(new SolidColorBrush(Colors.Red)));

        public string Parameter
        {
            get { return (string)GetValue(ParameterProperty); }
            set { SetValue(ParameterProperty, value); }
        }

        public static readonly DependencyProperty ParameterProperty =
            DependencyProperty.RegisterAttached(
                "Parameter",
                typeof(string),
                typeof(StatViewer),
                new FrameworkPropertyMetadata("XX"));

        public string ParameterTarget
        {
            get { return (string)GetValue(ParameterTargetProperty); }
            set { SetValue(ParameterTargetProperty, value); }
        }

        public static readonly DependencyProperty ParameterTargetProperty =
            DependencyProperty.RegisterAttached(
                "ParameterTarget",
                typeof(string),
                typeof(StatViewer),
                new FrameworkPropertyMetadata("Target yy"));
    }
}