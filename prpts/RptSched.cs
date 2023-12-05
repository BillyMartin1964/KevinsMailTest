using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Net.Mail;
using System.IO.Pipes;
using static prpts.RptSched;
using Microsoft.Identity.Client;
using prpts.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;
using System.Net.Mime;
using System.Reflection.Metadata;
using static System.Windows.Forms.AxHost;
using System.Collections;
using prpts.Services;
//using Microsoft.Graph;

namespace prpts
{
    public partial class RptSched : System.Windows.Forms.Form
    {
        // Set up the client application ID and secret
        //read these from encrypted file instead and decrypt only.
        string clientId = "0"; // "fa00187c-9223-4994-a5b2-7e55259f8846";
        string clientSecret = "0"; // "5vg8Q~fYJa2_l6SiedvUdvM7l.P1aLWE6b9Akb98";
        string tenantId = "0"; // "be84b8eb-a186-425e-b558-67785f8a8273";

        //public string strTO = "";
        //public string strCC = "";
        //public string strBody = "";
        //public string strSubject = "";

        // Declare CspParameters and RsaCryptoServiceProvider
        //// objects with global scope of your Form class.
        readonly CspParameters _cspp = new CspParameters();
        //RSACryptoServiceProvider _rsa;

        // Path variables for source, encryption, and
        // decryption folders. Must end with a backslash.
        //const string EncrFolder = @"C:\Users\kperez\Documents\Projects\DRAW_EmailingC\DRAW_EmailingC\bin\Debug\Encrypt\";
        //const string DecrFolder = @"C:\Users\kperez\Documents\Projects\DRAW_EmailingC\DRAW_EmailingC\bin\Debug\Decrypt\";
        //const string SrcFolder = @"C:\Users\kperez\Documents\Projects\DRAW_EmailingC\DRAW_EmailingC\bin\Debug\";

        // Public key file
        //const string PubKeyFile = @"C:\Users\kperez\Documents\Projects\DRAW_EmailingC\DRAW_EmailingC\bin\Debug\encrypt\rsaPublicKey.txt";

        // Key container name for
        // private/public key value pair.
        //const string KeyName = "Key01";

        Email testEmail { get; set; }


        public RptSched()
        {
            InitializeComponent();

            testEmail = new Email(
                new EmailUser("billy@sitesculptors.com", "Billy"),
                new EmailUser("kperez@recyclingit.com", "Kevin"),
                "Test Email",
                new EmailBody("<p>This is the body of the test email</p>", "html"),
                new List<EmailUser>{ new EmailUser("kperez@recyclingit.com", "Kevin")}
                );

            LoadEmail(testEmail);
        }

        private void LoadEmail(Email testEmail)
        {
            tbFrom.Text = testEmail.Sender.EmailAddress;
            tbTo.Text = testEmail.Recipient.EmailAddress;
            tbCC.Text  = testEmail.CC.FirstOrDefault<EmailUser>().EmailAddress;
            tbSubject.Text  = testEmail.Subject;
            tbBody.Text  = testEmail.Body.Content;

        }

        public async Task SendEmail(Email email)
        {
            var secrets = FileService.GetSecrets();
            await EmailService.SendEmailAsync(tenantId, clientId, clientSecret, email);
        }

        private async void button2_Click(object sender, EventArgs e)
        {
             var secrets = FileService.GetSecrets();

            await SendEmail(new Email(new EmailUser(tbTo.Text), new EmailUser(tbFrom.Text),tbSubject.Text, new EmailBody(tbBody.Text), new List<EmailUser> { new EmailUser(tbCC.Text) }));
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            if (FileService._rsa is null)
            {
                MessageBox.Show("Key not set.");
            }
            else
            {
                // Display a dialog box to select the encrypted file.
                decryptOpenFileDialog.InitialDirectory = FileService.EncrFolder;
                if (decryptOpenFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string fName = decryptOpenFileDialog.FileName;
                    if (fName != null)
                    {
                        FileService.DecryptFile(new FileInfo(fName));
                    }
                }
            }

        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            if (FileService._rsa is null)
            {
                MessageBox.Show("Key not set.");
            }
            else
            {
                // Display a dialog box to select a file to encrypt.
                encryptOpenFileDialog.InitialDirectory = FileService.SrcFolder;
                if (encryptOpenFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string fName = encryptOpenFileDialog.FileName;
                    if (fName != null)
                    {
                        // Pass the file name without the path.
                        FileService.EncryptFile(new FileInfo(fName));
                    }
                }
            }

        }

        private void btnExportPK_Click(object sender, EventArgs e)
        {
            // Save the public key created by the RSA
            // to a file. Caution, persisting the
            // key to a file is a security risk.
            Directory.CreateDirectory(FileService.EncrFolder);
            using (var sw = new StreamWriter(FileService.PubKeyFile, false))
            {
                sw.Write(FileService._rsa.ToXmlString(false));
            }
        }

        private void btnImportPK_Click(object sender, EventArgs e)
        {
            using (var sr = new StreamReader(FileService.PubKeyFile))
            {
                _cspp.KeyContainerName = FileService.KeyName;
                FileService._rsa = new RSACryptoServiceProvider(_cspp);

                string keytxt = sr.ReadToEnd();
                FileService._rsa.FromXmlString(keytxt);
                FileService._rsa.PersistKeyInCsp = true;

                label1.Text = FileService._rsa.PublicOnly
                ? $"Key: {_cspp.KeyContainerName} - Public Only"
                    : $"Key: {_cspp.KeyContainerName} - Full Key Pair";
            }

        }

        private void btnGetPK_Click(object sender, EventArgs e)
        {
            _cspp.KeyContainerName = FileService.KeyName;
            FileService._rsa = new RSACryptoServiceProvider(_cspp)
            {
                PersistKeyInCsp = true
            };

            label1.Text = FileService._rsa.PublicOnly
                ? $"Key: {_cspp.KeyContainerName} - Public Only"
                : $"Key: {_cspp.KeyContainerName} - Full Key Pair";

        }

        private void RptSched_Load(object sender, EventArgs e)
        {

        }

        private void tbSubject_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbCC_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbTO_TextChanged(object sender, EventArgs e)
        {

        }
    }

}
