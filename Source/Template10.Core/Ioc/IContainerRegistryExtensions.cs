﻿using Prism.Ioc;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Threading.Tasks;
using Template10.Navigation;
using Windows.Foundation;
using Windows.UI.Core;
using Windows.UI.Xaml.Navigation;

namespace Template10.Ioc
{
    public static partial class IContainerRegistryExtensions
    {
        public static void Register(IContainerRegistry container, string key, Type view, Type viewModel)
        {
            if (viewModel != null)
            {
                container.Register(viewModel);
                ViewModelLocationProvider.Register(view.ToString(), viewModel);
            }
            PageRegistry.Register(key, (view, viewModel));
        }

        public static void RegisterView<TView, TViewModel>(this IContainerRegistry registry)
            => Register(registry, typeof(TView).Name, typeof(TView), typeof(TViewModel));
        public static void RegisterView<TView, TViewModel>(this IContainerRegistry registry, string key)
            => Register(registry, key, typeof(TView), typeof(TViewModel));
        public static void RegisterView<TView>(this IContainerRegistry registry)
            => Register(registry, typeof(TView).Name, typeof(TView), null);
        public static void RegisterView<TView>(this IContainerRegistry registry, string key)
            => Register(registry, key, typeof(TView), null);

        public static void RegisterForNavigation<TView, TViewModel>(this IContainerRegistry registry)
            => Register(registry, typeof(TView).Name, typeof(TView), typeof(TViewModel));
        public static void RegisterForNavigation<TView, TViewModel>(this IContainerRegistry registry, string key)
            => Register(registry, key, typeof(TView), typeof(TViewModel));
        public static void RegisterForNavigation<TView>(this IContainerRegistry registry)
            => Register(registry, typeof(TView).Name, typeof(TView), null);
        public static void RegisterForNavigation<TView>(this IContainerRegistry registry, string key)
            => Register(registry, key, typeof(TView), null);

        public static void RegisterViewModel() { }

    }
}
