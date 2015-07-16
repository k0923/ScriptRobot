using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WinForm = System.Windows.Forms;

namespace RemoteScriptAgent
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_Open_Click(object sender, RoutedEventArgs e)
        {
            WinForm.OpenFileDialog ofd = new WinForm.OpenFileDialog();
            if(ofd.ShowDialog()== WinForm.DialogResult.OK)
            {
                tb_Script.Text = ofd.FileName;
            }
        }

        public void LoadAssembly()
        {
            AppDomain.CurrentDomain.AssemblyResolve+=CurrentDomain_AssemblyResolve;
            var domain = AppDomain.CreateDomain("SecondDomain");
            Type type = typeof(Proxy);
            var proxy = (Proxy)domain.CreateInstanceAndUnwrap(
                type.Assembly.FullName,
                type.FullName);
            proxy.LoadAssembly(@"C:\Users\TestLib.dll");
            
            AppDomain.Unload(domain);
        }

        Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            return Assembly.LoadFrom(@"C:\Users\TestLib.dll");
        }

        private void btn_Run_Click(object sender, RoutedEventArgs e)
        {
            //AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
            var asmName = AssemblyName.GetAssemblyName(@"C:\Users\yanzhou\Documents\GitHub\SAPGuiAutomationLib\SAPAutomation\bin\Debug\SAPAutomation.dll");

            //AppDomainSetup domainSetup = new AppDomainSetup();
            //domainSetup.ApplicationBase = AppDomain.CurrentDomain.BaseDirectory;
            //domainSetup.PrivateBinPath = "Framework";

           
            //domain.Load(asmName);

            

            
            
            //domain.ExecuteAssembly(@"C:\Users\yanzhou\Desktop\New folder\TestScript.exe");
            
            
          
        }

        

       

        
    }
}
