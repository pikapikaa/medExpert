using medExpert.Models;
using medExpert.Views.Audits.Popups;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace medExpert.ViewModels.Audits
{
    public class CarouselImageViewModel : INotifyPropertyChanged
    {
        public INavigation Navigation { get; set; }

        public ViolationImage PreviousImage { get; set; }
        public ViolationImage CurrentImage { get; set; }
        public ViolationImage CurrentItem { get; set; }

        private ObservableCollection<ViolationImage> images;
        public ObservableCollection<ViolationImage> Images
        {
            get { return images; }
            set
            {
                images = value;
                OnPropertyChanged(nameof(Images));
            }
        }

        public CarouselImageViewModel()
        {
            MessagingCenter.Subscribe<MenuImagePopupViewModel>(this,
             MessageKeys.DeletePhoto, sender =>
             {
                 if (sender is MenuImagePopupViewModel menuImagePopupViewModel)
                 {
                     var res = new ObservableCollection<ViolationImage>(Images
                                                .Where(i => (i is ViolationImage && i
                                                .ImageUrl != CurrentImage.ImageUrl)));
                     Images = res; 
                     OnPropertyChanged(nameof(Images));
                     MessagingCenter.Send(this, MessageKeys.RefreshImageList);
                 }
             });
        }

        public ICommand CloseCarouselImageViewCommand => new Command<object>(async (object obj) =>
        {
            await Navigation.PopModalAsync();
        });

        public ICommand OpenMenuPopupCommand => new Command<object>(async (object obj) =>
        {
            await PopupNavigation.Instance.PushAsync(new MenuImagePopupView(), false); 
        });

        public ICommand ItemChangedCommand => new Command<ViolationImage>((ViolationImage item) =>
        {
            PreviousImage = CurrentImage;
            CurrentImage = item;
            OnPropertyChanged("PreviousImage");
            OnPropertyChanged("CurrentImage");
        });

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }

    internal class DataFactoryImage
    {
        public List<ViolationImage> GetImages()
        {
            return new List<ViolationImage>()
            {
                new ViolationImage()
                {
                    Name = "Baboon",
                    Location = "Africa & Asia",
                    Details = "Baboons are African and Arabian Old World monkeys belonging to the genus Papio, part of the subfamily Cercopithecinae.",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/f/fc/Papio_anubis_%28Serengeti%2C_2009%29.jpg/200px-Papio_anubis_%28Serengeti%2C_2009%29.jpg"
                },
                new ViolationImage(){  
                    Name = "Capuchin Monkey",
                    Location = "Central & South America",
                    Details = "The capuchin monkeys are New World monkeys of the subfamily Cebinae. Prior to 2011, the subfamily contained only a single genus, Cebus.",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/4/40/Capuchin_Costa_Rica.jpg/200px-Capuchin_Costa_Rica.jpg"
            },
            };
        }
    }
}