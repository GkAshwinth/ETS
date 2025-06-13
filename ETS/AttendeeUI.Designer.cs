namespace ETS
{
    partial class AttendeeUI
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
            this.label1 = new System.Windows.Forms.Label();
            this.ViewAndRegisterButton = new System.Windows.Forms.Button();
            this.ManageMyTicketsButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.label1.Location = new System.Drawing.Point(327, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "Attendee UI";
            // 
            // ViewAndRegisterButton
            // 
            this.ViewAndRegisterButton.Location = new System.Drawing.Point(333, 166);
            this.ViewAndRegisterButton.Name = "ViewAndRegisterButton";
            this.ViewAndRegisterButton.Size = new System.Drawing.Size(166, 38);
            this.ViewAndRegisterButton.TabIndex = 1;
            this.ViewAndRegisterButton.Text = "View And Register";
            this.ViewAndRegisterButton.UseVisualStyleBackColor = true;
            this.ViewAndRegisterButton.Click += new System.EventHandler(this.ViewAndRegisterButton_Click);
            // 
            // ManageMyTicketsButton
            // 
            this.ManageMyTicketsButton.Location = new System.Drawing.Point(333, 238);
            this.ManageMyTicketsButton.Name = "ManageMyTicketsButton";
            this.ManageMyTicketsButton.Size = new System.Drawing.Size(166, 38);
            this.ManageMyTicketsButton.TabIndex = 2;
            this.ManageMyTicketsButton.Text = "Manage My Tickets";
            this.ManageMyTicketsButton.UseVisualStyleBackColor = true;
            this.ManageMyTicketsButton.Click += new System.EventHandler(this.ManageMyTicketsButton_Click);
            // 
            // AttendeeUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ManageMyTicketsButton);
            this.Controls.Add(this.ViewAndRegisterButton);
            this.Controls.Add(this.label1);
            this.Name = "AttendeeUI";
            this.Text = "AttendeeUI";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ViewAndRegisterButton;
        private System.Windows.Forms.Button ManageMyTicketsButton;
    }
}