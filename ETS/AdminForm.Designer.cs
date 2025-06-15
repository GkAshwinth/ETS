namespace ETS
{
    partial class AdminForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnViewEvents;
        private System.Windows.Forms.Button btnViewPayments;
        private System.Windows.Forms.Button btnTrackSales;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.btnViewEvents = new System.Windows.Forms.Button();
            this.btnViewPayments = new System.Windows.Forms.Button();
            this.btnTrackSales = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnViewEvents
            // 
            this.btnViewEvents.Location = new System.Drawing.Point(100, 40);
            this.btnViewEvents.Name = "btnViewEvents";
            this.btnViewEvents.Size = new System.Drawing.Size(200, 40);
            this.btnViewEvents.TabIndex = 0;
            this.btnViewEvents.Text = "View Events";
            this.btnViewEvents.UseVisualStyleBackColor = true;
            this.btnViewEvents.Click += new System.EventHandler(this.btnViewEvents_Click);
            // 
            // btnViewPayments
            // 
            this.btnViewPayments.Location = new System.Drawing.Point(100, 100);
            this.btnViewPayments.Name = "btnViewPayments";
            this.btnViewPayments.Size = new System.Drawing.Size(200, 40);
            this.btnViewPayments.TabIndex = 1;
            this.btnViewPayments.Text = "View Payments";
            this.btnViewPayments.UseVisualStyleBackColor = true;
            this.btnViewPayments.Click += new System.EventHandler(this.btnViewPayments_Click);
            // 
            // btnTrackSales
            // 
            this.btnTrackSales.Location = new System.Drawing.Point(100, 160);
            this.btnTrackSales.Name = "btnTrackSales";
            this.btnTrackSales.Size = new System.Drawing.Size(200, 40);
            this.btnTrackSales.TabIndex = 2;
            this.btnTrackSales.Text = "Track Sales";
            this.btnTrackSales.UseVisualStyleBackColor = true;
            this.btnTrackSales.Click += new System.EventHandler(this.btnTrackSales_Click);
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 260);
            this.Controls.Add(this.btnTrackSales);
            this.Controls.Add(this.btnViewPayments);
            this.Controls.Add(this.btnViewEvents);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AdminForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Admin Dashboard";
            this.ResumeLayout(false);
        }
    }
}
