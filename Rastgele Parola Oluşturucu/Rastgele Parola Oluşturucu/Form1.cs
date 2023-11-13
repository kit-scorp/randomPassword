using System;
using System.Linq;
using System.Net.Mail;
using System.Windows.Forms;
namespace Rastgele_Parola_Oluşturucu
{
    public partial class Form1 : Form
    {
       

        public Form1()
        {
            InitializeComponent();
        }




        private void button2_Click(object sender, EventArgs e)
        {
            string email = richTextBox1.Text.Trim();
            string username = richTextBox2.Text.Trim();
            string password = richTextBox3.Text.Trim();

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                label5.Text = "Lütfen tüm bilgileri doldurun.";
            }
            else
            {
                if (IsValidEmail(email))
                {
                    label5.Text = "Geçerli bir e-posta adresi.";
                    if (IsValidUsername(username))
                    {
                        label5.Text = "Geçerli bir e-posta adresi.\ngeçerli username";
                        
                    }
                    else
                    {
                        label5.Text = "Geçerli bir e-posta adresi.\ngeçersiz username";
                    }
                }
                else
                {
                    label5.Text = "Geçerli bir e-posta adresi değil.";
                    if (IsValidUsername(username))
                    {
                        label5.Text = "Geçerli bir e-posta adresi değil.\ngeçerli username";

                    }
                    else
                    {
                        label5.Text = "Geçerli bir e-posta adresi değil.\ngeçersiz username";
                    }
                }
            }
        }

            private bool IsValidEmail(string email)
            {
                try
                {
                    MailAddress mailAddress = new MailAddress(email);
                    return true;
                }
                catch (FormatException)
                {
                    return false;
                }
            }

            private void GenerateAndDisplayRandomPassword()
            {
                string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                Random random = new Random();
                char[] passwordArray = new char[8];

                for (int i = 0; i < 8; i++)
                {
                    passwordArray[i] = characters[random.Next(characters.Length)];
                }

                string result = new string(passwordArray);
                richTextBox3.Text = result;
            }

            private void button3_Click(object sender, EventArgs e)
            {
                GenerateAndDisplayRandomPassword();
            }


        private bool IsValidUsername(string username)
        {
            // en az 4 karakter içermesi gereken bir kullanıcı adı kontrolü
            if (username.Length >= 4)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
