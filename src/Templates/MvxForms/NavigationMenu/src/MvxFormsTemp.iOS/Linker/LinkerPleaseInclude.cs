using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows.Input;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Commands;
using MvvmCross.Core;
using MvvmCross.IoC;
using MvvmCross.Navigation;
using MvvmCross.Platforms.Ios.Views;
using MvvmCross.ViewModels;
using MvvmCross.Views;
using UIKit;

namespace MvxFormsTemp.iOS.Linker
{
    // This class is never actually executed, but when Xamarin linking is enabled it does ensure types and properties
    // are preserved in the deployed app
    [Preserve(AllMembers = true)]
    public class LinkerPleaseInclude
    {
        public void Include(UIButton uiButton)
        {
            uiButton.TouchUpInside += (s, e) =>
                                      uiButton.SetTitle(uiButton.Title(UIControlState.Normal), UIControlState.Normal);
        }

        public void Include(UIBarButtonItem barButton)
        {
            barButton.Clicked += (s, e) =>
                                 barButton.Title = $"{ barButton.Title }";
        }

        public void Include(UITextField textField)
        {
            textField.Text = $"{ textField.Text }";
            textField.EditingChanged += (sender, args) => { textField.Text = ""; };
            textField.EditingDidEnd += (sender, args) => { textField.Text = ""; };
        }

        public void Include(UITextView textView)
        {
            textView.Text = $"{ textView.Text }";
            textView.TextStorage.DidProcessEditing += (sender, e) => textView.Text = "";
            textView.Changed += (sender, args) => { textView.Text = ""; };
        }

        public void Include(UILabel label)
        {
            label.Text = $"{ label.Text }";
            label.AttributedText = new NSAttributedString($"{ label.AttributedText.ToString() }");
        }

        public void Include(UIImageView imageView)
        {
            imageView.Image = new UIImage(imageView.Image.CGImage);
        }

        public void Include(UIControl control)
        {
            control.ValueChanged += (sender, args) => { control.ClipsToBounds = true; };
        }

        public void Include(UIDatePicker date)
        {
            date.Date = date.Date.AddSeconds(1);
        }

        public void Include(UISlider slider)
        {
            slider.Value = slider.Value + 1;
        }

        public void Include(UIProgressView progress)
        {
            progress.Progress = progress.Progress + 1;
        }

        public void Include(UISwitch sw)
        {
            sw.On = !sw.On;
        }

        public void Include(MvxViewController vc)
        {
            vc.Title = $"{vc.Title}";
        }

        public void Include(UIStepper s)
        {
            s.Value = s.Value + 1;
        }

        public void Include(UIPageControl s)
        {
            s.Pages = s.Pages + 1;
        }

        public void Include(UISearchBar searchBar)
        {
            searchBar.Text = $"{ searchBar.Text }";
            searchBar.TextChanged += (sender, e) => searchBar.Text = "";
            searchBar.CancelButtonClicked += (s, e) => searchBar.Text = $"{ searchBar.Text }";
        }

        public void Include(INotifyCollectionChanged changed)
        {
            changed.CollectionChanged += (s, e) => { _ = $"{e.Action}{e.NewItems}{e.NewStartingIndex}{e.OldItems}{e.OldStartingIndex}"; };
        }

        public void Include(INotifyPropertyChanged changed)
        {
            changed.PropertyChanged += (sender, e) => { _ = e.PropertyName; };
        }

        public void Include(ICommand command)
        {
            command.CanExecuteChanged += (s, e) => { if (command.CanExecute(null)) command.Execute(null); };
        }

        public void Include(MvxPropertyInjector injector)
        {
            _ = new MvxPropertyInjector();
        }

        public void Include(MvxTaskBasedBindingContext c)
        {
            c.Dispose();
            var c2 = new MvxTaskBasedBindingContext();
            c2.Dispose();
        }

        public void Include(MvxViewModelViewTypeFinder viewModelViewTypeFinder)
        {
            _ = new MvxViewModelViewTypeFinder(null, null);
            _ = new MvxAppStart<MvxNullViewModel>(null, null);
        }

        public void Include(MvxNavigationService service, IMvxViewModelLoader loader, IMvxViewDispatcher viewDispatcher)
        {
            _ = new MvxNavigationService(null, viewDispatcher, MvvmCross.Mvx.IoCProvider);
        }

        public void Include(ConsoleColor color)
        {
            Console.Write("");
            Console.WriteLine("");
            _ = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.ForegroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.DarkGray;
        }

        public void Include(MvxSettings settings)
        {
            _ = new MvxSettings();
        }

        public void Include(MvxStringToTypeParser parser)
        {
            _ = new MvxStringToTypeParser();
        }

        public void Include(MvxViewModelLoader loader)
        {
            _ = new MvxViewModelLoader(null);
        }

        public void Include(MvxViewModelViewLookupBuilder builder)
        {
            _ = new MvxViewModelViewLookupBuilder();
        }

        public void Include(MvxCommandCollectionBuilder builder)
        {
            _ = new MvxCommandCollectionBuilder();
        }

        public void Include(MvxStringDictionaryNavigationSerializer serializer)
        {
            _ = new MvxStringDictionaryNavigationSerializer();
        }

        public void Include(MvxChildViewModelCache cache)
        {
            _ = new MvxChildViewModelCache();
        }
    }
}
