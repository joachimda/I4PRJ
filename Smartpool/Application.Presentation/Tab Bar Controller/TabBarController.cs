//========================================================================
// FILENAME :   TabBarController.cs
// DESCR.   :   Implementation of controller that handles switching
//              between different view controllers
//------------------------------------------------------------------------ 
// REV. AUTHOR  CHANGE DESCRIPTION
// 1.0  LP      Initial version
//========================================================================

using System;
using System.Collections.Generic;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace Smartpool.Application.Presentation
{
    public class TabBarController : ITabBarController
    {
        // Properties

        private readonly List<ITabbedViewController> _viewControllers;
        private IViewController _topViewController;
        private int _topViewControllerIndex;

        public int TopViewControllerIndex
        {
            get { return _topViewControllerIndex; }
            set
            {
                // Unload the view of the current top view controller, and load the new one
                if (value >= _viewControllers.Count) throw new ArgumentException();
                _topViewController?.UnloadView();
                _topViewControllerIndex = value;
                _topViewController = _viewControllers[_topViewControllerIndex];
                _topViewController?.LoadView();
            }
        }

        // Life Cycle

        public TabBarController(List<ITabbedViewController> viewControllers)
        {
            _viewControllers = viewControllers;
            TopViewControllerIndex = 0;

            // Make the connection between view controllers and tab bar controller
            foreach (var viewController in _viewControllers)
            {
                viewController.TabBarController = this;
            }
        }
    }
}