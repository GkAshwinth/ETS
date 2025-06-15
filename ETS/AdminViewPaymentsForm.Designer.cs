namespace ETS
{
    partial class AdminViewPaymentsForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dataGridViewPayments;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dataGridViewPayments = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPayments)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewPayments
            // 
            this.dataGridViewPayments.AllowUserToAddRows = false;
            this.dataGridViewPayments.AllowUserToDeleteRows = false;
            this.dataGridViewPayments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewPayments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPayments.Location = new System.Drawing.Point(20, 20);
            this.dataGridViewPayments.Name = "dataGridViewPayments";
            this.dataGridViewPayments.ReadOnly = true;
            this.dataGridViewPayments.RowHeadersVisible = false;
            this.dataGridViewPayments.RowTemplate.Height = 25;
            this.dataGridViewPayments.Size = new System.Drawing.Size(740, 400);
            this.dataGridViewPayments.TabIndex = 0;
            // 
            // AdminViewPaymentsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 450);
            this.Controls.Add(this.dataGridViewPayments);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AdminViewPaymentsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "All Payments";
            this.Load += new System.EventHandler(this.AdminViewPaymentsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPayments)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
