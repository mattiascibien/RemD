using System;
using System.Collections.Generic;
using Caliburn.Micro;
using RemD.Interfaces;
using RemD.ViewModels;
using Xceed.Wpf.AvalonDock.Layout;
using Xceed.Wpf.AvalonDock;

namespace RemD.Bootstrapper
{

    public class AppBootstrapper : BootstrapperBase
    {
        SimpleContainer container;

        public AppBootstrapper()
        {
            Initialize();
        }

        protected override void Configure()
        {
            MessageBinder.SpecialValues.Add("$documentcontext", context =>
            {
                LayoutDocument doc = null;
                if (context.EventArgs is DocumentClosingEventArgs)
                {
                    var args = context.EventArgs as DocumentClosingEventArgs;
                    doc = args.Document;
                }
                else if (context.EventArgs is DocumentClosedEventArgs)
                {
                    var args = context.EventArgs as DocumentClosedEventArgs;
                    doc = args.Document;
                }
                return doc.Content;
            });


            container = new SimpleContainer();

            container.Singleton<IWindowManager, WindowManager>();
            container.Singleton<IEventAggregator, EventAggregator>();
            container.Singleton<ShellViewModel>();
        }

        protected override object GetInstance(Type service, string key)
        {
            var instance = container.GetInstance(service, key);
            if (instance != null)
                return instance;

            throw new InvalidOperationException("Could not locate any instances.");
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return container.GetAllInstances(service);
        }

        protected override void BuildUp(object instance)
        {
            container.BuildUp(instance);
        }

        protected override void OnStartup(object sender, System.Windows.StartupEventArgs e)
        {
            DisplayRootViewFor<ShellViewModel>();
        }
    }
}