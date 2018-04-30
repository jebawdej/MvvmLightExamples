using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UwpTwoViews.Views;

namespace UwpTwoViews.ViewModels
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary> 
    public class ViewModelLocator
    {
        /// <summary>
        /// Keys for the two pages
        /// </summary>
        public const string FirstPageKey = "FirstPage";
        public const string SecondPageKey = "SecondPage";
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            var nav = new NavigationService();
            nav.Configure(FirstPageKey, typeof(FirstPage));
            nav.Configure(SecondPageKey, typeof(SecondPage));

            if (ViewModelBase.IsInDesignModeStatic)
            {
                // Create design time view services and models
            }
            else
            {
                // Create run time view services and models
            }


            //Register your services used here
            SimpleIoc.Default.Register<INavigationService>(() => nav);
            SimpleIoc.Default.Register<FirstPageViewModel>();
            SimpleIoc.Default.Register<SecondPageViewModel>();
        }


        // <summary>
        // Gets the FirstPage view model.
        // </summary>
        // <value>
        // The FirstPage view model.
        // </value>
        public FirstPageViewModel FirstPageInstance
        {
            get
            {
                return ServiceLocator.Current.GetInstance<FirstPageViewModel>();
            }
        }

        // <summary>
        // Gets the SecondPage view model.
        // </summary>
        // <value>
        // The SecondPage view model.
        // </value>
        public SecondPageViewModel SecondPageInstance
        {
            get
            {
                return ServiceLocator.Current.GetInstance<SecondPageViewModel>();
            }
        }

        // <summary>
        // The cleanup.
        // </summary>
        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}
