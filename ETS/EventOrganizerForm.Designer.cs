namespace ETS
{
    partial class EventOrganizerForm
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
            label1 = new Label();
            lblTitle = new Label();
            lblName = new Label();
            lblDate = new Label();
            lblLocation = new Label();
            lblTickets = new Label();
            lblCreatedBy = new Label();
            txtName = new TextBox();
            txtLocation = new TextBox();
            txtTickets = new TextBox();
            txtCreatedBy = new TextBox();
            dateTimePicker1 = new DateTimePicker();
            btnCreate = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnClear = new Button();
            lblEventList = new Label();
            btnRefresh = new Button();
            dgvEvents = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvEvents).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(296, 9);
            label1.Name = "label1";
            label1.Size = new Size(208, 25);
            label1.TabIndex = 0;
            label1.Text = "Event Organizer Panel";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.BackColor = SystemColors.ActiveCaption;
            lblTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(76, 77);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(110, 21);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "Event Details";
            lblTitle.Click += label2_Click;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.BackColor = SystemColors.ActiveCaption;
            lblName.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblName.Location = new Point(40, 136);
            lblName.Name = "lblName";
            lblName.Size = new Size(78, 15);
            lblName.TabIndex = 2;
            lblName.Text = "Event Name:";
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.BackColor = SystemColors.ActiveCaption;
            lblDate.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDate.Location = new Point(40, 170);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(72, 15);
            lblDate.TabIndex = 3;
            lblDate.Text = "Event Date:";
            // 
            // lblLocation
            // 
            lblLocation.AutoSize = true;
            lblLocation.BackColor = SystemColors.ActiveCaption;
            lblLocation.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblLocation.Location = new Point(40, 204);
            lblLocation.Name = "lblLocation";
            lblLocation.Size = new Size(57, 15);
            lblLocation.TabIndex = 4;
            lblLocation.Text = "Location:";
            lblLocation.Click += label4_Click;
            // 
            // lblTickets
            // 
            lblTickets.AutoSize = true;
            lblTickets.BackColor = SystemColors.ActiveCaption;
            lblTickets.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTickets.Location = new Point(40, 239);
            lblTickets.Name = "lblTickets";
            lblTickets.Size = new Size(87, 15);
            lblTickets.TabIndex = 5;
            lblTickets.Text = "No. of Tickets:";
            // 
            // lblCreatedBy
            // 
            lblCreatedBy.AutoSize = true;
            lblCreatedBy.BackColor = SystemColors.ActiveCaption;
            lblCreatedBy.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCreatedBy.ForeColor = SystemColors.ControlText;
            lblCreatedBy.Location = new Point(40, 275);
            lblCreatedBy.Name = "lblCreatedBy";
            lblCreatedBy.Size = new Size(71, 15);
            lblCreatedBy.TabIndex = 6;
            lblCreatedBy.Text = "Created By:";
            // 
            // txtName
            // 
            txtName.Location = new Point(166, 133);
            txtName.Name = "txtName";
            txtName.Size = new Size(200, 23);
            txtName.TabIndex = 7;
            txtName.TextChanged += txtName_TextChanged;
            // 
            // txtLocation
            // 
            txtLocation.Location = new Point(166, 201);
            txtLocation.Name = "txtLocation";
            txtLocation.Size = new Size(200, 23);
            txtLocation.TabIndex = 9;
            // 
            // txtTickets
            // 
            txtTickets.Location = new Point(166, 236);
            txtTickets.Name = "txtTickets";
            txtTickets.Size = new Size(200, 23);
            txtTickets.TabIndex = 10;
            // 
            // txtCreatedBy
            // 
            txtCreatedBy.Location = new Point(166, 272);
            txtCreatedBy.Name = "txtCreatedBy";
            txtCreatedBy.Size = new Size(200, 23);
            txtCreatedBy.TabIndex = 11;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.CustomFormat = "yyyy-MM-dd HH:mm";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.Location = new Point(166, 164);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(200, 23);
            dateTimePicker1.TabIndex = 12;
            dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // btnCreate
            // 
            btnCreate.BackColor = Color.Green;
            btnCreate.ForeColor = Color.White;
            btnCreate.Location = new Point(44, 333);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(75, 30);
            btnCreate.TabIndex = 13;
            btnCreate.Text = "Create";
            btnCreate.UseVisualStyleBackColor = false;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.Orange;
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Location = new Point(144, 333);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(75, 30);
            btnUpdate.TabIndex = 14;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += button2_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.Red;
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(248, 333);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 30);
            btnDelete.TabIndex = 15;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.Gray;
            btnClear.ForeColor = Color.White;
            btnClear.Location = new Point(347, 333);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(75, 30);
            btnClear.TabIndex = 16;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = false;
            // 
            // lblEventList
            // 
            lblEventList.AutoSize = true;
            lblEventList.BackColor = SystemColors.ActiveCaption;
            lblEventList.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEventList.Location = new Point(474, 77);
            lblEventList.Name = "lblEventList";
            lblEventList.Size = new Size(90, 21);
            lblEventList.TabIndex = 17;
            lblEventList.Text = "Events List";
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.Blue;
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Location = new Point(757, 77);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(75, 25);
            btnRefresh.TabIndex = 18;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // dgvEvents
            // 
            dgvEvents.AllowUserToAddRows = false;
            dgvEvents.AllowUserToDeleteRows = false;
            dgvEvents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvEvents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEvents.Location = new Point(474, 133);
            dgvEvents.MultiSelect = false;
            dgvEvents.Name = "dgvEvents";
            dgvEvents.ReadOnly = true;
            dgvEvents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEvents.Size = new Size(382, 385);
            dgvEvents.TabIndex = 19;
            // 
            // EventOrganizerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(884, 561);
            Controls.Add(dgvEvents);
            Controls.Add(btnRefresh);
            Controls.Add(lblEventList);
            Controls.Add(btnClear);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnCreate);
            Controls.Add(dateTimePicker1);
            Controls.Add(txtCreatedBy);
            Controls.Add(txtTickets);
            Controls.Add(txtLocation);
            Controls.Add(txtName);
            Controls.Add(lblCreatedBy);
            Controls.Add(lblTickets);
            Controls.Add(lblLocation);
            Controls.Add(lblDate);
            Controls.Add(lblName);
            Controls.Add(lblTitle);
            Controls.Add(label1);
            Name = "EventOrganizerForm";
            Text = "Event Organizer - ETS";
            Load += EventOrganizerForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvEvents).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #region Control Declarations
        private Label label1;
        private Label lblTitle;
        private Label lblName;
        private Label lblDate;
        private Label lblLocation;
        private Label lblTickets;
        private Label lblCreatedBy;
        private TextBox txtName;
        private TextBox txtLocation;
        private TextBox txtTickets;
        private TextBox txtCreatedBy;
        private DateTimePicker dateTimePicker1;
        private Button btnCreate;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnClear;
        private Label lblEventList;
        private Button btnRefresh; // THIS WAS MISSING!
        private DataGridView dgvEvents;
        #endregion

    }
}
#endregion