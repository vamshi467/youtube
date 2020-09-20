using System;
using System.Collections.ObjectModel;
using NewControlsDemo.Models;
using NewControlsDemo.Services;
using Prism.Navigation;

namespace NewControlsDemo.ViewModels
{
    public class CarouselPageViewModel : BaseViewModel
    {
        public CarouselPageViewModel(INavigationService navigationService, FacadeService facadeService)
            : base(navigationService, facadeService)
        {
            loadStaticData();
        }

        private ObservableCollection<CardsModel> _cards;
        public ObservableCollection<CardsModel> Cards
        {
            get { return _cards; }
            set
            {
                if (_cards != value)
                {
                    SetProperty(ref _cards, value);
                }
            }
        }

        private void loadStaticData()
        {
            var cards = new ObservableCollection<CardsModel>();
            cards.Add(new CardsModel { Title = "Amazon", Type = "Platinum Card", ImageUrl = "https://www.federalbank.co.in/image/journal/article?img_id=21371350&t=1560144599475", Amount = 5920.80, CardHolderName = "Tom Lathem" });
            cards.Add(new CardsModel { Title = "SBI Card", Type = "Silver", ImageUrl = "https://pngimg.com/uploads/credit_card/credit_card_PNG71.png", Amount = 6000, CardHolderName = "Ross Tylor" });
            cards.Add(new CardsModel { Title = "Visa", Type = "Primium", ImageUrl = "https://www.federalbank.co.in/image/journal/article?img_id=21371350&t=1560144599475", Amount = 2500, CardHolderName = "Json Roy" });
            Cards = new ObservableCollection<CardsModel>(cards);
        }
    }
}
