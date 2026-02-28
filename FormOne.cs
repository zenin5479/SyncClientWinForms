using System.Net;
using System.Windows.Forms;

namespace SyncClientWinForms
{
   public partial class FormOne : Form
   {
      private const string BaseUrl = "http://127.0.0.1:8080/api/items";
      private static readonly WebClient Client = new WebClient();

      public FormOne()
      {
         InitializeComponent();
      }

      private void ButtonStart_Click(object sender, System.EventArgs e)
      {

      }




      private void ButtonClear_Click(object sender, System.EventArgs e)
      {
         TextBoxReader.Clear();
         RichTextBoxReader.Clear();
         ListBoxReader.Items.Clear();
      }
   }
}