using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Windows.Browser;
using System.Collections.ObjectModel;
using SharedClasses;
using System.IO;
using System.Text;
using System.Runtime.Serialization.Json;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Gauges;

namespace Client
{
      [ScriptableType]
    public partial class ClientPage : Page
    {
          private ObservableCollection<ThermoTemps> thermoCollection;
          public ObservableCollection<ThermoTemps> ThermoCollection
          {
              get
              {
                  return thermoCollection;
              }
              set
              {
                  thermoCollection = value;
              }
          }

          public ClientPage()
        {
            InitializeComponent();
            ThermoCollection = new ObservableCollection<ThermoTemps>();
             this.gridThermo.ItemsSource = ThermoCollection;
            HtmlPage.RegisterScriptableObject("myObject", this);
        }

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            
            HtmlPage.Window.Invoke("sendMessage", this.textBox1.Text);
        }

          [ScriptableMember]
        public void UpdateText(string result)
        {              
            try
            {
                string jsonString = result.Substring(result.IndexOf('{'));
                ThermoTemps myDeserializedObj = new ThermoTemps();

                DataContractJsonSerializer dataContractJsonSerializer = new DataContractJsonSerializer(typeof(ThermoTemps));
                MemoryStream memoryStream = new MemoryStream(Encoding.Unicode.GetBytes(jsonString));
                myDeserializedObj = (ThermoTemps)dataContractJsonSerializer.ReadObject(memoryStream);
                ThermoCollection.Add(myDeserializedObj);

                this.radialBarCoolVent.Value = myDeserializedObj.CoolingVent; // set the needle
                this.radialBarFan.Value = myDeserializedObj.Fan; // set the needle
                this.radialBarFreezer.Value = myDeserializedObj.Freezer; // set the needle
                this.radialBarFridge.Value = myDeserializedObj.Fridge; // set the needle
                this.radialBarIceMaker.Value = myDeserializedObj.IceMaker; // set the needle
            }
            catch (Exception ex) { }

            mytextblock.Text += result + Environment.NewLine;
        }
    }
}
