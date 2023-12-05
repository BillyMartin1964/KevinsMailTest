using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Microsoft.Identity.Client;

using Newtonsoft.Json;

using prpts.Models;

using static System.Windows.Forms.AxHost;

namespace prpts.Services
{
    public class EmailService //: IEmailService
    {
        string clientId = "0"; // "fa00187c-9223-4994-a5b2-7e55259f8846";
        string clientSecret = "0"; // "5vg8Q~fYJa2_l6SiedvUdvM7l.P1aLWE6b9Akb98";
        string tenantId = "0"; // "be84b8eb-a186-425e-b558-67785f8a8273";
        readonly CspParameters _cspp = new CspParameters();
        RSACryptoServiceProvider _rsa;
        const string SrcFolder = @"C:\Users\kperez\Documents\Projects\DRAW_EmailingC\DRAW_EmailingC\bin\Debug\";
        const string PubKeyFile = @"C:\Users\kperez\Documents\Projects\DRAW_EmailingC\DRAW_EmailingC\bin\Debug\encrypt\rsaPublicKey.txt";



        public static async Task ReceiveEmailAsync()
        {
            throw new NotImplementedException();
        }

        public static async Task SendEmailAsync(string tenantId, string clientId, string clientSecret, Email email)
        {
            // Set up the Microsoft Graph API endpoint and version
            string graphApiEndpoint = "https://graph.microsoft.com/v1.0";

            using (AesManaged myAes = new AesManaged())
            {
                // Encrypt the string to an array of bytes.
                byte[] clientSecret_encrypted = FileService.EncryptStringToBytes_Aes(clientSecret, myAes.Key, myAes.IV);
                string clientSecret_roundtrip = FileService.DecryptStringFromBytes_Aes(clientSecret_encrypted, myAes.Key, myAes.IV);
                //Display the original data and the decrypted data.
                Console.WriteLine("Original:   {0}", clientSecret);
                Console.WriteLine("Round Trip: {0}", clientSecret_roundtrip);

                byte[] clientId_encrypted = FileService.EncryptStringToBytes_Aes(clientId, myAes.Key, myAes.IV);
                string clientId_roundtrip = FileService.DecryptStringFromBytes_Aes(clientId_encrypted, myAes.Key, myAes.IV);
                //Display the original data and the decrypted data.
                Console.WriteLine("Original:   {0}", clientId);
                Console.WriteLine("Round Trip: {0}", clientId_roundtrip);

                byte[] tenantId_encrypted = FileService.EncryptStringToBytes_Aes(tenantId, myAes.Key, myAes.IV);
                string tenantId_roundtrip = FileService.DecryptStringFromBytes_Aes(tenantId_encrypted, myAes.Key, myAes.IV);
                //Display the original data and the decrypted data.
                Console.WriteLine("Original:   {0}", tenantId);
                Console.WriteLine("Round Trip: {0}", tenantId_roundtrip);

                // Write the string array to a new file
                string docPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            }

            // Set up the user's email address and message content
            //string userEmail = email.Sender.EmailAddress;
            //string messageSubject = email.Subject;
            //string messageBody = email.Body.Content;
            //List<EmailUser> CCEmail = email.CC;

            // Set up the authentication context and acquire a token
            var authBuilder = ConfidentialClientApplicationBuilder.Create(clientId)
                .WithAuthority($"https://login.microsoftonline.com/{tenantId}/v2.0")
                .WithClientSecret(clientSecret)
                .Build();

            var authResult = await authBuilder.AcquireTokenForClient(new[] { "https://graph.microsoft.com/.default" })
                .ExecuteAsync();

            // Set up the HTTP client and add the access token to the authorization header
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authResult.AccessToken);

            // Set up the email message
            // userEmail = "kperez@recyclingit.com";
            /*
                        // Create the email content
                        var message = await createEmail("Sent from the MailSendMailWithAttachment test.");

                        var attachment = new FileAttachment();
                        attachment.OdataType = "#microsoft.graph.fileAttachment";
                        attachment.Name = "MyFileAttachment.txt";
                        attachment.ContentBytes = System.IO.File.ReadAllBytes(@"Z:\IT\RGD\Reports\RAS_FL_CompTots_All_20231119_20231125.pdf");

                        message.Attachments = new MessageAttachmentsCollectionPage();
                        message.Attachments.Add(attachment);

                        //await graphClient.Me.SendMail(message, true).Request().PostAsync();
                        var response = await httpClient.PostAsync($"{graphApiEndpoint}/users/{userEmail}/sendMail", new StringContent(jsonMessageO, System.Text.Encoding.UTF8, "application/json"));

                        // Create the message with attachment.
                        byte[] contentBytes = System.IO.File.ReadAllBytes(@"Z:\IT\RGD\Reports\RAS_FL_CompTots_All_20231119_20231125.pdf");
                        string contentType = "image/png";
            //            MessageAttachmentsCollectionPage attachments = new MessageAttachmentsCollectionPage();

                        attachments.Add(new FileAttachment
                        {
                            OdataType = "#microsoft.graph.fileAttachment",
                            ContentBytes = contentBytes,
                            ContentType = contentType,
                            ContentId = "RAS_FL_CompTots_All_20231119_20231125",
                            Name = "RAS_FL_CompTots_All_20231119_20231125.pdf"
                        });
            */
            byte[] contentBytes = System.IO.File.ReadAllBytes(@"Z:\IT\RGD\Reports\RAS_FL_CompTots_All_20231119_20231125.pdf");
            byte[] contentBytes2 = System.IO.File.ReadAllBytes(@"C:\Users\kperez\Pictures\20230321_215519.jpg");
            var mailMarkup = @"<h1>A mail with an embedded image <img src='cid:Pic' alt='Pic' /></h1>";
            var emailList = new List<string>();

            var mail = new Email(
                 new EmailUser("pohara@recyclingit.com", "pohara@recyclingit.com"), //To
                 new EmailUser("pohara@recyclingit.com", "pohara@recyclingit.com"), //From
            "Mail with an embedded image", //Subject
                new EmailBody(mailMarkup, "HTML"),
                new List<EmailUser> {
                        new EmailUser ( "Kevin Perez", "kperez@recyclingit.com"),
                        new EmailUser("P Ohara", "pohara@recyclingit.com")
                },
                new List<EmailAttachment>
                    {
                        new EmailAttachment
                        {
                            odatatype = "#microsoft.graph.fileAttachment",
                            contentBytes = contentBytes,
                            contentType = "application/pdf",
                            contentId = "File",
                            name = "RAS_FL_CompTots_All_20231119_20231125.pdf"
                        },
                         new EmailAttachment
                        {
                            odatatype = "#microsoft.graph.fileAttachment",
                            contentBytes = contentBytes2,
                            contentType = "image/jpg",
                            contentId = "Pic",
                            name = "thumbs-up.png"
                        },
                    });

            var saveToSentItems = true;


            // Convert the email message to a JSON string and send the email via Microsoft Graph
            var jsonMessageO = JsonConvert.SerializeObject(emailMessage);
            var jsonMessage2 = JsonConvert.SerializeObject(mail);
            /*
            var list = JsonConvert.DeserializeObject(jsonMessageO);
            userEmail = "{\"message\":{\"subject\":\""
                + StrSubject
                + "\",\"body\":{\"contentType\":\"Text\",\"content\":\""
                + strBody;

            userEmail += "\"},\"toRecipients\":[";

            userEmail += "{\"emailAddress\":{\"address\":\"kperez@recyclingit.com\"}}";
            userEmail += ",{\"emailAddress\":{\"address\":\"pohara@recyclingit.com\"}}";

            string[] ToEmails = strTO.Split(';');
            int emailaddresscount = 0;
            foreach (var word in ToEmails)
            {
                if (emailaddresscount > 0)
                    userEmail += ",";

                userEmail += "{\"emailAddress\":{\"address\":\"" + word.Trim() + "\"}}";
                //+ ",{\"emailAddress\":{\"address\":\"pohara@recyclingit.com\"}}";
                emailaddresscount += 1;
            }

            string[] CCEmails = strCC.Split(';');
            foreach (var word in CCEmails)
            {
                if (emailaddresscount > 0)
                    userEmail += ",";
                userEmail += "{\"emailAddress\":{\"address\":\"" + word.Trim() + "\"}}";
                //+ ",{\"emailAddress\":{\"address\":\"pohara@recyclingit.com\"}}";
                emailaddresscount += 1;
            }


            userEmail += "]}}";
        */
            /*           
                       var itemToAdd = new JObject();
                       itemToAdd["id"] = 1234;
                       itemToAdd["name"] = "carl2";
                       array.Add(itemToAdd);
           */

            //var jsonMessage = JsonConvert.SerializeObject(emailMessage);
            //userEmail = jsonMessage;

            //var response = await httpClient.PostAsync($"{graphApiEndpoint}/users/{userEmail}/sendMail", new StringContent(jsonMessage2, System.Text.Encoding.UTF8, "application/json"));

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Email sent successfully.");
            }
            else
            {
                Console.WriteLine("Failed to send email. Status code: " + response.StatusCode);
                Console.WriteLine("Failed to send email. Status code: " + response.RequestMessage);

                //https://login.microsoftonline.com/common/oauth2/nativeclient //using this one
                //https://login.live.com/oauth20_desktop.srf
                //msalfa00187c-9223-4994-a5b2-7e55259f8846://auth
            }
        }


    }
}
