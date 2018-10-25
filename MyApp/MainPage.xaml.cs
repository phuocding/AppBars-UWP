using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace MyApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        async void SaveFile()
        {
            FileSavePicker fileSavePicker = new FileSavePicker();
            foreach (string key in FileTypeList.Keys)
            {
                fileSavePicker.FileTypeChoices.Add(key, FileTypeList[key]);
            }
            StorageFile file = await fileSavePicker.PickSaveFileAsync();
            if (file != null)
            {
                var sf = await file.GetParentAsync();
                var x = sf.Provider;
                CachedFileManager.DeferUpdates(file);
                await FileIO.WriteTextAsync(file, Text);
                FileUpdateStatus status = await CachedFileManager.CompleteUpdatesAsync(file);
                FileName = file.Name;
            }
        }
    }
}
