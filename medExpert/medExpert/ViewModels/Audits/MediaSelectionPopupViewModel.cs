using Plugin.Media;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace medExpert.ViewModels.Audits
{
    public class MediaSelectionPopupViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// 
        /// </summary>
        public ICommand ShowCamera => new Command<object>(async (object obj) =>
        {
            await PopupNavigation.Instance.PopAsync(false);
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                return;
            }
            var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                Directory = "Sample",
                Name = "test.jpg"
            });

            if (file == null)
                return;
            else _ = file;
        });

        /// <summary>
        /// 
        /// </summary>
        public ICommand ShowGallery => new Command<object>(async (object obj) =>
        {
            await PopupNavigation.Instance.PopAsync(false);
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                return;
            }
            await CrossMedia.Current.PickPhotoAsync();


        });

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
