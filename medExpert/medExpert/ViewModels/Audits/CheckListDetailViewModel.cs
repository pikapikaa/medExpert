﻿using medExpert.Models;
using medExpert.Views.Audits;
using medExpert.Views.Audits.Popups;
using Plugin.Media.Abstractions;
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
using Xamarin.Forms.PancakeView;

namespace medExpert.ViewModels.Audits
{
    public class CheckListDetailViewModel : INotifyPropertyChanged
    {
        public INavigation Navigation { get; set; }

        private int imagesScreenOverCount;
        private int imagesCount;

        private ObservableCollection<ViolationImage> _violationImageFiltered;
        private ObservableCollection<ViolationImage> _violationImageUnfiltered;

        private ObservableCollection<ViolationImage> images;
        private ViolationImage image1;
        private ViolationImage image2;
        private ViolationImage image3;
        public ViolationImage Image1
        {
            get { return image1; }
            set
            {
                image1 = value;
                OnPropertyChanged();
            }
        }

        public ViolationImage Image2
        {
            get { return image2; }
            set
            {
                image2 = value;
                OnPropertyChanged();
            }
        }

        public ViolationImage Image3
        {
            get { return image3; }
            set
            {
                image3 = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<ViolationImage> Images
        {
            get { return images; }
            set
            {
                images = value;
                OnPropertyChanged(nameof(Images));
            }
        }

        /// <summary>
        /// Количество изображений
        /// </summary>
        public int ImagesCount
        {
            get { return imagesCount; }
            set
            {
                imagesCount = value;
                OnPropertyChanged(nameof(ImagesCount));
                SetImagesScreenOverCount();
            }
        }

        /// <summary>
        /// Количество изображений не вместившихся в экран
        /// </summary>
        public int ImagesScreenOverCount
        {
            get { return imagesScreenOverCount; }
            set
            {
                imagesScreenOverCount = value;
                OnPropertyChanged(nameof(ImagesScreenOverCount));
            }
        }

        private void SetImagesScreenOverCount()
        {
            ImagesScreenOverCount = imagesCount > 3 ?
              imagesCount - 3 : 0;
        }

        private string allowButtonBackground = "White";
        private string preventButtonBackground = "White";
        private string unworkableButtonBackground = "White";
        private string allowButtonTextColor = "#0F74E5";
        private string preventButtonTextColor = "#0F74E5";
        private string unworkableButtonTextColor = "#0F74E5";

        /// <summary>
        /// Цвет кнопки "Соответствует"
        /// </summary>
        public string AllowButtonBackground
        {
            get { return allowButtonBackground; }
            set
            {
                allowButtonBackground = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Цвет кнопки "Не соответствует"
        /// </summary>
        public string PreventButtonBackground
        {
            get { return preventButtonBackground; }
            set
            {
                preventButtonBackground = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Цвет кнопки "Не применимо"
        /// </summary>
        public string UnworkableButtonBackground
        {
            get { return unworkableButtonBackground; }
            set
            {
                unworkableButtonBackground = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Цвет текста кнопки "Соответствует"
        /// </summary>
        public string AllowButtonTextColor
        {
            get { return allowButtonTextColor; }
            set
            {
                allowButtonTextColor = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Цвет текста кнопки "Не соответствует"
        /// </summary>
        public string PreventButtonTextColor
        {
            get { return preventButtonTextColor; }
            set
            {
                preventButtonTextColor = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Цвет текста кнопки "Не применимо"
        /// </summary>
        public string UnworkableButtonTextColor
        {
            get { return unworkableButtonTextColor; }
            set
            {
                unworkableButtonTextColor = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Violation> violations;
      
        public ObservableCollection<Violation> Violations
        {
            get { return violations; }
            set
            {
                violations = value;
                OnPropertyChanged(nameof(Violations));
            }
        }

        public CheckListDetailViewModel()
        {
            var _listOfItems = new DataViolationFactory().GetViolations();
            Violations = new ObservableCollection<Violation>(_listOfItems);

            var _listOfImages = new DataFactoryImage().GetImages();
            Images = new ObservableCollection<ViolationImage>(_listOfImages);
            ImagesCount = Images.Count;

            if (Images.Count >= 3)
            {
                Image1 = Images[0];
                Image2 = Images[1];
                Image3 = Images[2];
            }
            else if (Images.Count == 2)
            {
                Image1 = Images[0];
                Image2 = Images[1];
            }
            else if (Images.Count == 1)
            {
                Image1 = Images[0];
            }

            MessagingCenter.Subscribe<MediaSelectionPopupViewModel>(this,
              MessageKeys.PickPhoto, sender =>
              {
                  if (sender is MediaSelectionPopupViewModel mediaSelectionPopupViewModel)
                  {
                      foreach(var temp in mediaSelectionPopupViewModel.ListSelectedImages)
                      {
                          Images.Add(new ViolationImage() { ImageUrl = temp});
                          ImagesCount = Images.Count;
                          if (Images.Count >= 3)
                          {
                              Image1 = Images[0];
                              Image2 = Images[1];
                              Image3 = Images[2];
                          }
                          else if (Images.Count == 2)
                          {
                              Image1 = Images[0];
                              Image2 = Images[1];
                          }
                          else if (Images.Count == 1)
                          {
                              Image1 = Images[0];
                          }
                      }
                  }
              });

            MessagingCenter.Subscribe<CarouselImageViewModel>(this,
             MessageKeys.RefreshImageList, sender =>
             {
                 if (sender is CarouselImageViewModel carouselImageViewModel)
                 {
                    
                     Images = carouselImageViewModel.Images;
                 }
             });
        }

        public DashPattern BorderDashPattern { get; set; } = new DashPattern(10, 5, 2, 5);

        /// <summary>
        /// 
        /// </summary>
        public ICommand ShowMenuViolation => new Command<object>(async (object obj) =>
        {
            await PopupNavigation.Instance.PushAsync(new MenuPopupView(), false);
        });

        /// <summary>
        /// Команда выбора нарушения 
        /// </summary>
        public ICommand CheckViolationCommand => new Command<object>((object obj) =>
        {
            var item = (obj as Image).BindingContext as Violation;
            if (item is Violation structuralUnit)
            {
                var res = Violations.FirstOrDefault(i => i.Id == structuralUnit.Id);
                if (res != null)
                {
                    res.IsChecked = !res.IsChecked;
                }
                OnPropertyChanged(nameof(Violations));
            }
        });

        /// <summary>
        /// Нажатие кнопки "Соответствует"
        /// </summary>
        public ICommand AllowButtonCommand => new Command<object>((object obj) =>
        {
            AllowButtonBackground = "#3CBB78";
            PreventButtonBackground = "White";
            UnworkableButtonBackground = "White";

            AllowButtonTextColor = "White";
            PreventButtonTextColor = "#0F74E5";
            UnworkableButtonTextColor = "#0F74E5";
        });

        /// <summary>
        /// Нажатие кнопки "Не соответствует"
        /// </summary>
        public ICommand PreventButtonCommand => new Command<object>((object obj) =>
        {
            AllowButtonBackground = "White";
            PreventButtonBackground = "#F82463";
            UnworkableButtonBackground = "White";

            AllowButtonTextColor = "#0F74E5";
            PreventButtonTextColor = "White";
            UnworkableButtonTextColor = "#0F74E5";
        });

        /// <summary>
        /// Нажатие кнопки "Не прменимо"
        /// </summary>
        public ICommand UnworkableButtonCommand => new Command<object>((object obj) =>
        {
            AllowButtonBackground = "White";
            PreventButtonBackground = "White";
            UnworkableButtonBackground = "#989BA8";

            AllowButtonTextColor = "#0F74E5";
            PreventButtonTextColor = "#0F74E5";
            UnworkableButtonTextColor = "White";
        });

        /// <summary>
        /// Команда раскрытия аккордеона
        /// </summary>
        public ICommand InverseAccordion => new Command<object>((object obj) =>
        {
            var item = (obj as SwipeView).BindingContext as Violation;
            item.IsExpand = !item.IsExpand;
        });

        /// <summary>
        /// 
        /// </summary>
        public ICommand ShowMediaButton => new Command<object>(async (object obj) =>
        {
            await PopupNavigation.Instance.PushAsync(new MediaSelectionPopupView(), false);
        });

        /// <summary>
        /// 
        /// </summary>
        public ICommand OpenPhotoCommand => new Command<object>(async (object obj) =>
        {
            await Navigation.PushModalAsync(new NavigationPage(new CarouselImageView()
            {
                BindingContext = new CarouselImageViewModel()
                {
                    Images = this.Images,
                    Navigation = this.Navigation
                }
            }), true) ;
        });

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }

    internal class DataViolationFactory
    {
        public List<Recommendation> GetRecommendations()
        {
            return new List<Recommendation>()
            {
                new Recommendation
                {
                    Id = 1,
                    Text = "Не отпускаются"
                },
                new Recommendation
                {
                    Id = 2,
                    Text = "Не отпускаются наркотические и психотропные препараты по рецептам2"
                }
            };
        }
            public List<Violation> GetViolations()
            {
                return new List<Violation>()
                {
                    new Violation()
                    {
                        Id = 1,
                        Text = "Не отпускают",
                        Recommendations = new ObservableCollection<Recommendation>(GetRecommendations())
                    },
                     new Violation()
                    {
                        Id = 2,
                        Text = "Не отпускаются2",
                        Recommendations = new ObservableCollection<Recommendation>(GetRecommendations())
                    },
                      new Violation()
                    {
                        Id = 3,
                        Text = "Не отпускаются наркотические и психотропные препараты по рецептам3"
                    }
                };
            }
    }


}