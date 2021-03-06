﻿using ReactiveUI;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

namespace CodeHub.Core.Factories
{
    public interface IActionMenuFactory
    {
        IActionMenu Create(string title = null);

        IPickerMenu CreatePicker();

        Task ShareUrl(Uri uri);

        void SendToPasteBoard(string str);
    }

    public interface IActionMenu
    {
        void AddButton(string title, IReactiveCommand clickAction);

        Task Show(object sender);
    }

    public interface IPickerMenu
    {
        ICollection<string> Options { get; }

        int SelectedOption { get; set; }

        Task<int> Show(object sender);
    }

    public static class ActionMenuFactoryExtensions
    {
        public static Task ShareUrl(this IActionMenuFactory @this, string uri)
        {
            return @this.ShareUrl(new Uri(uri));
        }
    }
}

