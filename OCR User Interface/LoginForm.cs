using System;
using System.IO;
using System.Windows.Forms;

namespace OCR_User_Interface
{
    public partial class LoginForm : Form
    {
        public String correctPWHash;
        public int tryCounter = 5;

        public LoginForm()
        {
            InitializeComponent();
            passwordBox.UseSystemPasswordChar = true;

            // Get password from the text file
            correctPWHash = File.ReadAllText(@"C:\Users\turbo\source\repos\OCR User Interface\OCR User Interface\HashedPassword.txt");
        }

        private void enterButton_Click(object sender, EventArgs e)
        {
            if (passwordBox.Text != String.Empty)
            {
                if (tryCounter > 0)
                {
                    bool correct = CheckPassword(passwordBox.Text);
                    if (correct == true)
                    {
                        MainMenu menu = new MainMenu();
                        menu.Show();

                        this.Hide();
                    }
                    else
                    {
                        messageLabel.Text = "Incorrect Password";
                    }
                    tryCounter--;
                }
                else
                {
                    messageLabel.Text = "Incorrect password entered too many times.";
                }
            }
        }

        public bool CheckPassword(string input)
        {
            byte[] data = System.Text.Encoding.ASCII.GetBytes(input); // Convert string to array of bytes
            data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data); // Convert data to a hash
            String hash = System.Text.Encoding.ASCII.GetString(data); // Convert hash to a string

            if (hash == correctPWHash)
            {
                return true;
            }

            else
            {
                return false;
            }
        }   

        public void CheckForInput()
        {
            // Checks for wether or not the user has inputted a password
            if (passwordBox.Text == "")
            {
                messageLabel.Text = "Enter a password";
            }

            else
            {
                messageLabel.Text = "";
            }
        }

        private void passwordBox_TextChanged(object sender, EventArgs e)
        {
            CheckForInput();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked == true)
            {
                passwordBox.UseSystemPasswordChar = false;
            }
            if (checkBox1.Checked == false)
            {
                passwordBox.UseSystemPasswordChar = true;
            }
        }
    }
}
