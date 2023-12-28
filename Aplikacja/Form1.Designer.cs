namespace Aplikacja
{
    partial class mainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuPanel = new Panel();
            mainPanel = new Panel();
            fileButton = new Button();
            editButton = new Button();
            viewButton = new Button();
            algorithmPanel = new Button();
            resultsPanel = new Button();
            menuPanel.SuspendLayout();
            SuspendLayout();
            // 
            // menuPanel
            // 
            menuPanel.BackColor = Color.CadetBlue;
            menuPanel.Controls.Add(resultsPanel);
            menuPanel.Controls.Add(algorithmPanel);
            menuPanel.Controls.Add(viewButton);
            menuPanel.Controls.Add(editButton);
            menuPanel.Controls.Add(fileButton);
            menuPanel.Dock = DockStyle.Top;
            menuPanel.Location = new Point(0, 0);
            menuPanel.Name = "menuPanel";
            menuPanel.Size = new Size(1206, 70);
            menuPanel.TabIndex = 0;
            // 
            // mainPanel
            // 
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Location = new Point(0, 70);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(1206, 475);
            mainPanel.TabIndex = 1;
            // 
            // fileButton
            // 
            fileButton.Location = new Point(50, 12);
            fileButton.Margin = new Padding(50, 3, 3, 3);
            fileButton.Name = "fileButton";
            fileButton.Size = new Size(100, 50);
            fileButton.TabIndex = 0;
            fileButton.Text = "File";
            fileButton.UseVisualStyleBackColor = true;
            // 
            // editButton
            // 
            editButton.Location = new Point(174, 12);
            editButton.Margin = new Padding(50, 3, 3, 3);
            editButton.Name = "editButton";
            editButton.Size = new Size(100, 50);
            editButton.TabIndex = 1;
            editButton.Text = "Edit";
            editButton.UseVisualStyleBackColor = true;
            // 
            // viewButton
            // 
            viewButton.Location = new Point(300, 12);
            viewButton.Margin = new Padding(50, 3, 3, 3);
            viewButton.Name = "viewButton";
            viewButton.Size = new Size(100, 50);
            viewButton.TabIndex = 2;
            viewButton.Text = "View";
            viewButton.UseVisualStyleBackColor = true;
            // 
            // algorithmPanel
            // 
            algorithmPanel.Location = new Point(427, 12);
            algorithmPanel.Margin = new Padding(50, 3, 3, 3);
            algorithmPanel.Name = "algorithmPanel";
            algorithmPanel.Size = new Size(100, 50);
            algorithmPanel.TabIndex = 3;
            algorithmPanel.Text = "Algorithm";
            algorithmPanel.UseVisualStyleBackColor = true;
            // 
            // resultsPanel
            // 
            resultsPanel.Location = new Point(556, 12);
            resultsPanel.Margin = new Padding(50, 3, 3, 3);
            resultsPanel.Name = "resultsPanel";
            resultsPanel.Size = new Size(100, 50);
            resultsPanel.TabIndex = 4;
            resultsPanel.Text = "Results";
            resultsPanel.UseVisualStyleBackColor = true;
            // 
            // mainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1206, 545);
            Controls.Add(mainPanel);
            Controls.Add(menuPanel);
            Name = "mainForm";
            Text = "Text Comparator";
            menuPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel menuPanel;
        private Panel mainPanel;
        private Button resultsPanel;
        private Button algorithmPanel;
        private Button viewButton;
        private Button editButton;
        private Button fileButton;
    }
}