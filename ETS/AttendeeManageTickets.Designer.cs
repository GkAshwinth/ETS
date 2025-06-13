namespace ETS
{
    partial class AttendeeManageTickets
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
            this.MyTicketsDataGrid = new System.Windows.Forms.DataGridView();
            this.RemoveTicketButton = new System.Windows.Forms.Button();
            this.GoBackButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.MyTicketsDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // MyTicketsDataGrid
            // 
            this.MyTicketsDataGrid.AllowUserToAddRows = false;
            this.MyTicketsDataGrid.AllowUserToDeleteRows = false;
            this.MyTicketsDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MyTicketsDataGrid.Location = new System.Drawing.Point(31, 82);
            this.MyTicketsDataGrid.MultiSelect = false;
            this.MyTicketsDataGrid.Name = "MyTicketsDataGrid";
            this.MyTicketsDataGrid.ReadOnly = true;
            this.MyTicketsDataGrid.RowHeadersWidth = 51;
            this.MyTicketsDataGrid.RowTemplate.Height = 24;
            this.MyTicketsDataGrid.Size = new System.Drawing.Size(505, 275);
            this.MyTicketsDataGrid.TabIndex = 1;
            // 
            // RemoveTicketButton
            // 
            this.RemoveTicketButton.Location = new System.Drawing.Point(564, 162);
            this.RemoveTicketButton.Name = "RemoveTicketButton";
            this.RemoveTicketButton.Size = new System.Drawing.Size(134, 49);
            this.RemoveTicketButton.TabIndex = 2;
            this.RemoveTicketButton.Text = "Remove Ticket";
            this.RemoveTicketButton.UseVisualStyleBackColor = true;
            this.RemoveTicketButton.Click += new System.EventHandler(this.RemoveTicketButton_Click);
            // 
            // GoBackButton
            // 
            this.GoBackButton.Location = new System.Drawing.Point(564, 244);
            this.GoBackButton.Name = "GoBackButton";
            this.GoBackButton.Size = new System.Drawing.Size(134, 49);
            this.GoBackButton.TabIndex = 3;
            this.GoBackButton.Text = "Go Back";
            this.GoBackButton.UseVisualStyleBackColor = true;
            this.GoBackButton.Click += new System.EventHandler(this.GoBackButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label1.Location = new System.Drawing.Point(303, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(233, 29);
            this.label1.TabIndex = 4;
            this.label1.Text = "Manage My Tickets";
            // 
            // AttendeeManageTickets
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.GoBackButton);
            this.Controls.Add(this.RemoveTicketButton);
            this.Controls.Add(this.MyTicketsDataGrid);
            this.Name = "AttendeeManageTickets";
            this.Text = "AttendeeManageTickets";
            this.Load += new System.EventHandler(this.AttendeeManageTickets_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MyTicketsDataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView MyTicketsDataGrid;
        private System.Windows.Forms.Button RemoveTicketButton;
        private System.Windows.Forms.Button GoBackButton;
        private System.Windows.Forms.Label label1;
    }
}