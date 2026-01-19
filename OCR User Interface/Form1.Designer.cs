namespace OCR_User_Interface
{
    partial class MainMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu));
            this.Title = new System.Windows.Forms.Label();
            this.fileInputLabel = new System.Windows.Forms.Label();
            this.drawInputLabel = new System.Windows.Forms.Label();
            this.DrawBoard = new System.Windows.Forms.PictureBox();
            this.FileSearchButton = new System.Windows.Forms.Button();
            this.clearDrawBox = new System.Windows.Forms.Button();
            this.predictionBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.confidenceBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.undoBtn = new System.Windows.Forms.Button();
            this.newPWbutton = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.PWbox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DrawBoard)).BeginInit();
            this.SuspendLayout();
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title.Location = new System.Drawing.Point(12, 9);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(342, 29);
            this.Title.TabIndex = 0;
            this.Title.Text = "Handwritten character analyser";
            // 
            // fileInputLabel
            // 
            this.fileInputLabel.AutoSize = true;
            this.fileInputLabel.Location = new System.Drawing.Point(13, 55);
            this.fileInputLabel.Name = "fileInputLabel";
            this.fileInputLabel.Size = new System.Drawing.Size(121, 20);
            this.fileInputLabel.TabIndex = 1;
            this.fileInputLabel.Text = "Input character:";
            // 
            // drawInputLabel
            // 
            this.drawInputLabel.AutoSize = true;
            this.drawInputLabel.Location = new System.Drawing.Point(397, 32);
            this.drawInputLabel.Name = "drawInputLabel";
            this.drawInputLabel.Size = new System.Drawing.Size(117, 20);
            this.drawInputLabel.TabIndex = 2;
            this.drawInputLabel.Text = "Draw character";
            // 
            // DrawBoard
            // 
            this.DrawBoard.BackColor = System.Drawing.Color.White;
            this.DrawBoard.Location = new System.Drawing.Point(401, 63);
            this.DrawBoard.Name = "DrawBoard";
            this.DrawBoard.Size = new System.Drawing.Size(280, 280);
            this.DrawBoard.TabIndex = 3;
            this.DrawBoard.TabStop = false;
            this.DrawBoard.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DrawBoard_MouseDown);
            this.DrawBoard.MouseMove += new System.Windows.Forms.MouseEventHandler(this.DrawBoard_MouseMove);
            this.DrawBoard.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DrawBoard_MouseUp);
            // 
            // FileSearchButton
            // 
            this.FileSearchButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.FileSearchButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.FileSearchButton.Location = new System.Drawing.Point(12, 78);
            this.FileSearchButton.Name = "FileSearchButton";
            this.FileSearchButton.Size = new System.Drawing.Size(118, 37);
            this.FileSearchButton.TabIndex = 4;
            this.FileSearchButton.Text = "Search Files";
            this.FileSearchButton.UseVisualStyleBackColor = false;
            this.FileSearchButton.Click += new System.EventHandler(this.FileSearchButton_Click);
            // 
            // clearDrawBox
            // 
            this.clearDrawBox.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.clearDrawBox.Location = new System.Drawing.Point(606, 20);
            this.clearDrawBox.Name = "clearDrawBox";
            this.clearDrawBox.Size = new System.Drawing.Size(75, 37);
            this.clearDrawBox.TabIndex = 5;
            this.clearDrawBox.Text = "Clear";
            this.clearDrawBox.UseVisualStyleBackColor = false;
            this.clearDrawBox.Click += new System.EventHandler(this.clearDrawBox_Click);
            // 
            // predictionBox
            // 
            this.predictionBox.Location = new System.Drawing.Point(271, 68);
            this.predictionBox.Name = "predictionBox";
            this.predictionBox.Size = new System.Drawing.Size(100, 26);
            this.predictionBox.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(267, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 20);
            this.label2.TabIndex = 11;
            this.label2.Text = "Prediction:";
            // 
            // confidenceBox
            // 
            this.confidenceBox.Location = new System.Drawing.Point(271, 120);
            this.confidenceBox.Name = "confidenceBox";
            this.confidenceBox.Size = new System.Drawing.Size(100, 26);
            this.confidenceBox.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(267, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 20);
            this.label3.TabIndex = 15;
            this.label3.Text = "Confidence:";
            // 
            // undoBtn
            // 
            this.undoBtn.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.undoBtn.Location = new System.Drawing.Point(529, 20);
            this.undoBtn.Name = "undoBtn";
            this.undoBtn.Size = new System.Drawing.Size(71, 37);
            this.undoBtn.TabIndex = 16;
            this.undoBtn.Text = "Undo";
            this.undoBtn.UseVisualStyleBackColor = false;
            this.undoBtn.Click += new System.EventHandler(this.undoBtn_Click);
            // 
            // newPWbutton
            // 
            this.newPWbutton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.newPWbutton.Location = new System.Drawing.Point(21, 391);
            this.newPWbutton.Name = "newPWbutton";
            this.newPWbutton.Size = new System.Drawing.Size(75, 41);
            this.newPWbutton.TabIndex = 18;
            this.newPWbutton.Text = "Enter";
            this.newPWbutton.UseVisualStyleBackColor = false;
            this.newPWbutton.Click += new System.EventHandler(this.newPWbutton_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 336);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 20);
            this.label1.TabIndex = 20;
            this.label1.Text = "New Password:";
            // 
            // PWbox
            // 
            this.PWbox.Location = new System.Drawing.Point(21, 359);
            this.PWbox.Name = "PWbox";
            this.PWbox.Size = new System.Drawing.Size(164, 26);
            this.PWbox.TabIndex = 21;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 156);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(292, 180);
            this.label4.TabIndex = 22;
            this.label4.Text = resources.GetString("label4.Text");
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(8, 130);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 20);
            this.label5.TabIndex = 23;
            this.label5.Text = "Help:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(102, 401);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 20);
            this.label6.TabIndex = 24;
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1129, 655);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.PWbox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.newPWbutton);
            this.Controls.Add(this.undoBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.confidenceBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.predictionBox);
            this.Controls.Add(this.clearDrawBox);
            this.Controls.Add(this.FileSearchButton);
            this.Controls.Add(this.DrawBoard);
            this.Controls.Add(this.drawInputLabel);
            this.Controls.Add(this.fileInputLabel);
            this.Controls.Add(this.Title);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainMenu";
            this.Text = "Main Menu";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainMenu_FormClosing);
            this.Load += new System.EventHandler(this.MainMenu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DrawBoard)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.Label fileInputLabel;
        private System.Windows.Forms.Label drawInputLabel;
        private System.Windows.Forms.PictureBox DrawBoard;
        private System.Windows.Forms.Button FileSearchButton;
        private System.Windows.Forms.Button clearDrawBox;
        private System.Windows.Forms.TextBox predictionBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox confidenceBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button undoBtn;
        private System.Windows.Forms.Button newPWbutton;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox PWbox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}

