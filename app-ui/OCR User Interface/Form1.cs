using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace OCR_User_Interface
{
    public partial class MainMenu : Form
    {

        Bitmap bitmap = new Bitmap(28, 28); // Bitmap for drawing
        bool IsDrawing = false; // Boolean checking if drawing or not
        private OpenFileDialog ofd; // Checking for files in file explorer

        Model model = new Model(@"C:\Users\turbo\Neural Network Stuff\OCR (NEA)\savefile2.txt"); // Model used for predictions 

        public int stackCounter = 0; // Counter locating top of stack
        public static Bitmap[] editStack = new Bitmap[100]; // Stack storing edit history

        // INITIALIZE:
        public MainMenu()
        {
            InitializeComponent();
        }
        private void MainMenu_Load(object sender, EventArgs e)
        {
            ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.tif;...";
            ofd.Title = "Please select an image file to analyse";

            DrawBoard.Size = new Size(280, 280);
            editStack[0] = new Bitmap(28, 28);

            predictionBox.ReadOnly = true;
            confidenceBox.ReadOnly = true;
        }

        // ENDING
        private void MainMenu_FormClosing(object sender, FormClosingEventArgs e)
        { 
            Application.Exit();
        }

        // MOUSE INPUT:
        private void DrawBoard_MouseDown(object sender, MouseEventArgs e)
        {
            if (IsDrawing == true)
            {
                IsDrawing = false;
            }
            else
            {
                IsDrawing = true;
            }
        }

        private void DrawBoard_MouseMove(object sender, MouseEventArgs e)
        {
            if (IsDrawing == true)
            {
                Graphics graphics = Graphics.FromImage(bitmap);
                DrawBoard.SizeMode = PictureBoxSizeMode.StretchImage;

                // Drawboard size is 280 x 280, so divide by 10

                int xPos = (int)(e.X / 10) ;
                int yPos = (int)(e.Y / 10) ;

                // Bind domain of inputs from 0-27 (No out of bounds errors)
                if (xPos > 0 && yPos > 0 && xPos < 28 && yPos < 28)
                {
                    // Setting 4 pixels for a thick brush
                    bitmap.SetPixel(xPos, yPos, Color.Black);
                    bitmap.SetPixel(xPos - 1, yPos, Color.Black);
                    bitmap.SetPixel(xPos, yPos - 1, Color.Black);
                    bitmap.SetPixel(xPos - 1, yPos - 1, Color.Black);

                    DrawBoard.Image = bitmap; // Displaying image
                }
                MakePrediction(bitmap, false); // Getting a prediction
            }
        }

        private void DrawBoard_MouseUp(object sender, MouseEventArgs e)
        {
            if (IsDrawing == true)
            {
                IsDrawing = false;
            }
            
            // Edit is finished, so bitmap is saved to stack
            SaveToStack();
        }

        // FILE INPUT:
        private void FileSearchButton_Click(object sender, EventArgs e)
        {
            // Get input from a file
            ofd.ShowDialog();

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                DrawBoard.SizeMode = PictureBoxSizeMode.StretchImage;

                Bitmap bmp1 = (Bitmap)Image.FromFile(ofd.FileName);
                bmp1 = new Bitmap(bmp1, new Size(28, 28)); // Resize to fit drawboard
                DrawBoard.Image = bmp1;
                bitmap = bmp1;
            }
            // Predict from drawboard image
            MakePrediction((Bitmap)DrawBoard.Image, true);
        }

        // DRAWING:
        public void SaveToStack()
        {
            stackCounter++; // Increase the current stack position counter
            editStack[stackCounter] = CopyBitmap(bitmap); // Copy the current bitmap
        }

        public void ClearSaveStack(int index)
        {
            // Nullify all values except for index 0 of editStack
            for (int i = index; i < editStack.Length; i++)
            {
                editStack[i] = null;
            }
            // Clearing the current bitmap
            if (index == 1)
            {
                bitmap = new Bitmap(28, 28);
            }
        }

        public Bitmap CopyBitmap(Bitmap bmp)
        {
            // Copy the values of a bitmap without being dependent on it's changing values
            Bitmap newBitmap = new Bitmap(28, 28);

            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    newBitmap.SetPixel(i, j, bmp.GetPixel(i, j));
                }
            }

            return newBitmap;
        }

        private void clearDrawBox_Click(object sender, EventArgs e)
        {
            // Clear the contents of the drawbox, reset the editStack and set stackCounter to 0

            // Reset the editing bitmap and redisplay
            bitmap = new Bitmap(28, 28);
            DrawBoard.Image = bitmap;

            // Make a prediction of the new bitmap (to ensure no confusion)
            MakePrediction(bitmap, false);
            
            // Reset editStack
            stackCounter = 0;
            ClearSaveStack(1);
        }

        private void undoBtn_Click(object sender, EventArgs e)
        {
            // Go back to the previous edit
            if (stackCounter > 0)
            {
                ClearSaveStack(stackCounter); // Clear all places ahead of stackCounter
                stackCounter--; // Go to the previous stack value
                DrawBoard.Image = editStack[stackCounter]; // Display the previous stack value
                bitmap = editStack[stackCounter]; // Assign current bitmap to bitmap
            }

            if (stackCounter == 0)
            {
                ClearSaveStack(1); // If gone back to the start, clear any remaining bitmaps to reduce errors
            }
        }

        // PREDICTIONS:
        public void MakePrediction(Bitmap img, bool isFromFile)
        {
            double[] pixelValues = new double[img.Width * img.Height];
            int counter = 0;

            // Loop through the bitmap and get the alpha channel value of each pixel
            for (int i = 0; i < img.Width; i++)
            {
                for (int j = 0; j < img.Height; j++)
                {
                    Color pixel = img.GetPixel(i, j);

                    if (isFromFile == true)
                    {
                        pixelValues[counter] = (255 - pixel.R) / 255; // Pixel values are white at 255
                    }
                    else
                    {
                        pixelValues[counter] = pixel.A / 255;
                    }

                    counter++;
                }
            }

            double[] predictions = model.ForwardPass(pixelValues); // Get the predictions for each possible character
            int index = 0; // This is the index of the predicted value

            // Get the index of the most likely value
            for (int i = 0; i < predictions.Length; i++)
            {
                if (predictions[i] == predictions.Max())
                {
                    index = i;
                }
            }

            // Display the predictions
            predictionBox.Text = Convert.ToString(Category(index));
            confidenceBox.Text = Convert.ToString(predictions.Max() * 100);
        }

        private char Category(int index)
        {
            // Represent the category for each label (manually set from 0-46)
            switch (index)
            {
                case (0):
                    return '0';
                    break;
                case (1):
                    return '1';
                    break;
                case (2):
                    return '2';
                    break;
                case (3):
                    return '3';
                    break;
                case (4):
                    return '4';
                    break;
                case (5):
                    return '5';
                    break;
                case (6):
                    return '6';
                    break;
                case (7):
                    return '7';
                    break;
                case (8):
                    return '8';
                    break;
                case (9):
                    return '9';
                    break;
                case (10):
                    return 'A';
                    break;
                case (11):
                    return 'B';
                    break;
                case (12):
                    return 'C';
                    break;
                case (13):
                    return 'D';
                    break;
                case (14):
                    return 'E';
                    break;
                case (15):
                    return 'F';
                    break;
                case (16):
                    return 'G';
                    break;
                case (17):
                    return 'H';
                    break;
                case (18):
                    return 'I';
                    break;
                case (19):
                    return 'J';
                    break;
                case (20):
                    return 'K';
                    break;
                case (21):
                    return 'L';
                    break;
                case (22):
                    return 'M';
                    break;
                case (23):
                    return 'N';
                    break;
                case (24):
                    return 'O';
                    break;
                case (25):
                    return 'P';
                    break;
                case (26):
                    return 'Q';
                    break;
                case (27):
                    return 'R';
                    break;
                case (28):
                    return 'S';
                    break;
                case (29):
                    return 'T';
                    break;
                case (30):
                    return 'U';
                    break;
                case (31):
                    return 'V';
                    break;
                case (32):
                    return 'W';
                    break;
                case (33):
                    return 'X';
                    break;
                case (34):
                    return 'Y';
                    break;
                case (35):
                    return 'Z';
                    break;
                case (36):
                    return 'a';
                    break;
                case (37):
                    return 'b';
                    break;
                case (38):
                    return 'd';
                    break;
                case (39):
                    return 'e';
                    break;
                case (40):
                    return 'f';
                    break;
                case (41):
                    return 'g';
                    break;
                case (42):
                    return 'h';
                    break;
                case (43):
                    return 'n';
                    break;
                case (44):
                    return 'q';
                    break;
                case (45):
                    return 'r';
                    break;
                case (46):
                    return 't';
                    break;
                default:
                    return '#';
                    break;
            }
        }

        // RESETTING PASSWORD

        private void RewritePassword(string input)
        {
            byte[] data = System.Text.Encoding.ASCII.GetBytes(input); // Convert string to array of bytes
            data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data); // Convert data to a hash
            String hash = System.Text.Encoding.ASCII.GetString(data); // Convert hash to a string

            StreamWriter sw = new StreamWriter(@"C:\Users\turbo\source\repos\OCR User Interface\OCR User Interface\HashedPassword.txt");
            sw.Flush();
            sw.Write(hash);
            sw.Close();
        }

        private void newPWbutton_Click(object sender, EventArgs e)
        {
            if (PWbox.Text != String.Empty)
            {
                RewritePassword(PWbox.Text);
                label6.Text = "New password set";
            }
            else
            {
                label6.Text = "Please enter a non-empty new pasword";
            }
        }

    }
}