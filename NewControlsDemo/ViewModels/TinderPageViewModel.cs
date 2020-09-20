using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using MLToolkit.Forms.SwipeCardView.Core;
using NewControlsDemo.Models;
using NewControlsDemo.Services;
using Prism.Commands;
using Prism.Navigation;

namespace NewControlsDemo.ViewModels
{
    public class TinderPageViewModel : BaseViewModel
    {
        private ObservableCollection<Profile> _profiles = new ObservableCollection<Profile>();

        private uint _threshold;

        public TinderPageViewModel(INavigationService navigationService, FacadeService facadeService)
            : base(navigationService, facadeService)
        {
            InitializeProfiles();
        }

        public ObservableCollection<Profile> Profiles
        {
            get => _profiles;
            set { SetProperty(ref _profiles, value); }
        }

        public uint Threshold
        {
            get => _threshold;
            set { SetProperty(ref _threshold, value); }
        }

        public DelegateCommand<SwipedCardEventArgs> SwipedCommand { get { return new DelegateCommand<SwipedCardEventArgs>(async (obj) => await OnSwipedCommand(obj)); } }
        private async Task OnSwipedCommand(SwipedCardEventArgs eventArgs)
        {
        }

        public DelegateCommand<DraggingCardEventArgs> DraggingCommand { get { return new DelegateCommand<DraggingCardEventArgs>((obj) => OnDraggingCommand(obj)); } }
        private void OnDraggingCommand(DraggingCardEventArgs eventArgs)
        {
            switch (eventArgs.Position)
            {
                case DraggingCardPosition.Start:
                    return;

                case DraggingCardPosition.UnderThreshold:
                    break;

                case DraggingCardPosition.OverThreshold:
                    break;

                case DraggingCardPosition.FinishedUnderThreshold:
                    return;

                case DraggingCardPosition.FinishedOverThreshold:
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void InitializeProfiles()
        {
            Profiles.Add(new Profile { ProfileId = 1, Name = "Laura", Age = 24, Gender = Gender.Female, Photo = "p705193.jpg" });
            Profiles.Add(new Profile { ProfileId = 2, Name = "Sophia", Age = 21, Gender = Gender.Female, Photo = "p597956.jpg" });
            Profiles.Add(new Profile { ProfileId = 3, Name = "Anne", Age = 19, Gender = Gender.Female, Photo = "p497489.jpg" });
            Profiles.Add(new Profile { ProfileId = 4, Name = "Yvonne ", Age = 27, Gender = Gender.Female, Photo = "p467499.jpg" });
            Profiles.Add(new Profile { ProfileId = 5, Name = "Abby", Age = 25, Gender = Gender.Female, Photo = "p589739.jpg" });
            Profiles.Add(new Profile { ProfileId = 6, Name = "Andressa", Age = 28, Gender = Gender.Female, Photo = "p453095.jpg" });
            Profiles.Add(new Profile { ProfileId = 7, Name = "June", Age = 29, Gender = Gender.Female, Photo = "p503001.jpg" });
            Profiles.Add(new Profile { ProfileId = 8, Name = "Kim", Age = 22, Gender = Gender.Female, Photo = "p627958.jpg" });
            Profiles.Add(new Profile { ProfileId = 9, Name = "Denesha", Age = 26, Gender = Gender.Female, Photo = "p474893.jpg" });
            Profiles.Add(new Profile { ProfileId = 10, Name = "Sasha", Age = 23, Gender = Gender.Female, Photo = "p458914.jpg" });

            Profiles.Add(new Profile { ProfileId = 11, Name = "Austin", Age = 28, Gender = Gender.Male, Photo = "p378674.jpg" });
            Profiles.Add(new Profile { ProfileId = 11, Name = "James", Age = 32, Gender = Gender.Male, Photo = "p398931.jpg" });
            Profiles.Add(new Profile { ProfileId = 11, Name = "Chris", Age = 27, Gender = Gender.Male, Photo = "p401107.jpg" });
            Profiles.Add(new Profile { ProfileId = 11, Name = "Alexander", Age = 30, Gender = Gender.Male, Photo = "p731150.jpg" });
            Profiles.Add(new Profile { ProfileId = 11, Name = "Steve", Age = 31, Gender = Gender.Male, Photo = "p327144.jpg" });
        }
    }
}



