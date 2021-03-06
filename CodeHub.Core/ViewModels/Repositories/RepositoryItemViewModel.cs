﻿using ReactiveUI;
using System;
using CodeHub.Core.Utilities;
using System.Diagnostics;

namespace CodeHub.Core.ViewModels.Repositories
{
    [DebuggerDisplay("{Owner}/{Name}")]
    public class RepositoryItemViewModel : ReactiveObject, ICanGoToViewModel
    {
        public string Name { get; private set; }

        public string Owner { get; private set; }

        public GitHubAvatar Avatar { get; private set; }

        public string Description { get; private set; }

        public int Stars { get; private set; }

        public int Forks { get; private set; }

        public bool ShowOwner { get; private set; }

        public IReactiveCommand<object> GoToCommand { get; private set; }

        internal RepositoryItemViewModel(string name, string owner, string imageUrl,
                                         string description, int stars, int forks,
                                         bool showOwner, Action<RepositoryItemViewModel> gotoCommand)
        {
            Name = name;
            Owner = owner;
            Avatar = new GitHubAvatar(imageUrl);
            Description = description;
            Stars = stars;
            Forks = forks;
            ShowOwner = showOwner;
            GoToCommand = ReactiveCommand.Create().WithSubscription(x => gotoCommand(this));
        }

        internal RepositoryItemViewModel(Octokit.Repository repository, bool showOwner, Action<RepositoryItemViewModel> gotoCommand)
            : this(repository.Name, repository.Owner.Login, repository.Owner.AvatarUrl, 
                repository.Description, repository.StargazersCount, repository.ForksCount, showOwner, gotoCommand)
        {
        }
    }
}

