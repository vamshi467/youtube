using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Mail;
using Xamarin.Forms;

namespace NewControlsDemo.Views
{
    public partial class MailTemplatePage : ContentPage
    {
        public MailTemplatePage()
        {
            InitializeComponent();
        }

        void btnSend_Clicked(object sender, System.EventArgs e)
        {
            try
            {

                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("xamdev.here@gmail.com");
                mail.To.Add("divyesh.bhatt@differenzsystem.com"); // txtTo.Text
                mail.Subject = $"User Recommended Adventure {txtSubject.Text}";
                mail.Body = txtBody.Text;

                SmtpServer.Port = 587;
                SmtpServer.Host = "smtp.gmail.com";
                SmtpServer.EnableSsl = true;
                SmtpServer.UseDefaultCredentials = false;
                SmtpServer.Credentials = new System.Net.NetworkCredential("xamdev.here@gmail.com", "welcome2020");

                SmtpServer.Send(mail);
                Debug.WriteLine("mail sent successfully");
            }
            catch (Exception ex)
            {
                DisplayAlert("Faild", ex.Message, "OK");
            }
        }
    }
}
