using medExpert.Models;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace medExpert.ViewModels.Audits
{
    public class MediaSelectionPopupViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<string> listSelectedImages;
        public ObservableCollection<string> ListSelectedImages
        {
            get { return listSelectedImages; }
            set
            {
                listSelectedImages = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Показать камеру
        /// </summary>
        public ICommand ShowCamera => new Command<object>(async (object obj) =>
        {
            await PopupNavigation.Instance.PopAsync(false);
            await CrossMedia.Current.Initialize();
            ListSelectedImages = new ObservableCollection<string>();

            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                return;
            }
            var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                PhotoSize = PhotoSize.Small,
                DefaultCamera = CameraDevice.Rear,
                SaveToAlbum = true,
                Directory = "MedExpert"
            });

            if (file == null)
            {
                return;
            }
            else
            {
                ListSelectedImages.Add(file.Path);
                MessagingCenter.Send(this, MessageKeys.PickPhoto);
            }
        });

        /// <summary>
        /// Показать галерею
        /// </summary>
        public ICommand ShowGallery => new Command<object>(async (object obj) =>
        {
            ListSelectedImages = new ObservableCollection<string>();
            await PopupNavigation.Instance.PopAsync(false);
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsTakePhotoSupported)
            {
                return;
            }
            var selectedPhotos = await CrossMedia.Current.PickPhotosAsync();
            
            if (selectedPhotos?.Count >= 1)
            {
                foreach(var temp in selectedPhotos)
                {
                    ListSelectedImages.Add(temp.Path);
                }

                MessagingCenter.Send(this, MessageKeys.PickPhoto);
            }
            
        });

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
