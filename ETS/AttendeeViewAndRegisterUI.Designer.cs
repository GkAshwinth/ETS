namespace ETS
{
    partial class AttendeeViewAndRegisterUI
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
            this.AvailableEventsDataGrid = new System.Windows.Forms.DataGridView();
            this.RegisterForEventButton = new System.Windows.Forms.Button();
            this.GoBackButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.AvailableEventsDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // AvailableEventsDataGrid
            // 
            this.AvailableEventsDataGrid.AllowUserToAddRows = false;
            this.AvailableEventsDataGrid.AllowUserToDeleteRows = false;
            this.AvailableEventsDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AvailableEventsDataGrid.Location = new System.Drawing.Point(44, 54);
            this.AvailableEventsDataGrid.MultiSelect = false;
            this.AvailableEventsDataGrid.Name = "AvailableEventsDataGrid";
            this.AvailableEventsDataGrid.ReadOnly = true;
            this.AvailableEventsDataGrid.RowHeadersWidth = 51;
            this.AvailableEventsDataGrid.RowTemplate.Height = 24;
            this.AvailableEventsDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.AvailableEventsDataGrid.Size = new System.Drawing.Size(505, 275);
            this.AvailableEventsDataGrid.TabIndex = 0;
            // 
            // RegisterForEventButton
            // 
            this.RegisterForEventButton.Location = new System.Drawing.Point(591, 122);
            this.RegisterForEventButton.Name = "RegisterForEventButton";
            this.RegisterForEventButton.Size = new System.Drawing.Size(149, 36);
            this.RegisterForEventButton.TabIndex = 1;
            this.RegisterForEventButton.Text = "Register for Event";
            this.RegisterForEventButton.UseVisualStyleBackColor = true;
            this.RegisterForEventButton.Click += new System.EventHandler(this.RegisterForEventButton_Click);
            // 
            // GoBackButton
            // 
            this.GoBackButton.Location = new System.Drawing.Point(591, 219);
            this.GoBackButton.Name = "GoBackButton";
            this.GoBackButton.Size = new System.Drawing.Size(149, 36);
            this.GoBackButton.TabIndex = 2;
            this.GoBackButton.Text = "Go Back";
            this.GoBackButton.UseVisualStyleBackColor = true;
            this.GoBackButton.Click += new System.EventHandler(this.GoBackButton_Click);
            // 
            // AttendeeViewAndRegisterUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.GoBackButton);
            this.Controls.Add(this.RegisterForEventButton);
            this.Controls.Add(this.AvailableEventsDataGrid);
            this.Name = "AttendeeViewAndRegisterUI";
            this.Text = "AttendeeViewAndRegisterUI";
            this.Load += new System.EventHandler(this.AttendeeViewAndRegisterUI_Load);
            ((System.ComponentModel.ISupportInitialize)(this.AvailableEventsDataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView AvailableEventsDataGrid;
        private System.Windows.Forms.Button RegisterForEventButton;
        private System.Windows.Forms.Button GoBackButton;
    }
}