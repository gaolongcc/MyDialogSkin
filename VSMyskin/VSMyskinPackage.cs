using System;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.InteropServices;
using System.ComponentModel.Design;
using Microsoft.Win32;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.VisualStudio.OLE.Interop;
using Microsoft.VisualStudio.Shell;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
// 注意VSMyskin为项目名称
using Company.VSMyskin;

namespace Company.VSMyskin
{
    [PackageRegistration(UseManagedResourcesOnly = true)]
    [InstalledProductRegistration("#110", "#112", "1.0", IconResourceID = 400)]
    [Guid(GuidList.guidVSMyskinPkgString)]
    [ProvideAutoLoad(UIContextGuids.NoSolution)]
    [ProvideAutoLoad(UIContextGuids.SolutionExists)]  
    public sealed class VSMyskinPackage : Package
    {
        public VSMyskinPackage()
        {
            Debug.WriteLine(string.Format(CultureInfo.CurrentCulture, "Entering constructor for: {0}", this.ToString()));
        }
        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            var rWindow = (Window)sender;
            var rImageSource = BitmapFrame.Create(new Uri(@"E:\C++_Projects\VSMyskin\VSMyskin\Skin.jpg"/*图片路径*/), BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
            rImageSource.Freeze();

            var rImageControl = new Image()
            {
                Source = rImageSource,
                Stretch = Stretch.UniformToFill,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
            };

            Grid.SetRowSpan(rImageControl, 4);
            var rRootGrid = (Grid)rWindow.Template.FindName("RootGrid", rWindow);
            rRootGrid.Children.Insert(0, rImageControl);
        }

        #region Package Members
        protected override void Initialize()
        {
            Debug.WriteLine(string.Format(CultureInfo.CurrentCulture, "Entering Initialize() of: {0}", this.ToString()));
            base.Initialize();
            Application.Current.MainWindow.Loaded += MainWindow_Loaded;
        }
        #endregion
    }
}
