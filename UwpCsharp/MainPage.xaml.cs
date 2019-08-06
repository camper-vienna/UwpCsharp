using Sentry;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
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

namespace UwpCsharp
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

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void ThrowUnhandledExceptionClick(object sender, RoutedEventArgs e) => TheOffender();

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ThrowUnhandledExceptionClick(this, e);
            }
            catch (Exception ex)
            {   
                SentrySdk.WithScope(s =>
                {
                    s.AddBreadcrumb(
                        nameof(Button_Click),
                        category: "click",
                        type: "handled",
                        dataPair: (nameof(e.OriginalSource), e.OriginalSource.ToString()));

                    SentrySdk.CaptureException(ex);
                });
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void TheOffender() => throw new Exception("No one will catch me!");

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            unsafe
            {

                var nativeObject = new WindowsRuntimeComponent1.Class1();

                //int* foo = (int*)23424;
                //int bar = *foo + 42;
                //Console.WriteLine(bar);
            }
        }
    }
}
