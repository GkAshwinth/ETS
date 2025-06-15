using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ETS
{
    public partial class EventOrganizerForm : Form
    {
        private System.Windows.Forms.Timer autoEventTimer;
        private List<EventTemplate> eventTemplates;
        private EventController eventController;
        private Event currentEvent;

        public EventOrganizerForm()
        {
            InitializeComponent(); // This uses the designer-generated controls
            eventController = new EventController();
            currentEvent = null;
            eventTemplates = new List<EventTemplate>(); // Add this
            SetupEventHandlers(); // Setup event handlers for the designer controls
            LoadEvents();
            StartAutoEventGeneration();
        }

        // Setup event handlers for the controls created by the designer
        private void SetupEventHandlers()
        {
            btnCreate.Click += BtnCreate_Click;
            btnUpdate.Click += BtnUpdate_Click;
            btnDelete.Click += BtnDelete_Click;
            btnClear.Click += BtnClear_Click;
            dgvEvents.CellClick += DgvEvents_CellClick;

            // Set initial button states
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void LoadEvents()
        {
            try
            {
                List<Event> events = eventController.ReadEvents();

                dgvEvents.DataSource = events.Select(e => new
                {
                    ID = e.EventID,
                    Name = e.Name,
                    Date = e.Date.ToString("yyyy-MM-dd HH:mm"),
                    Location = e.Location,
                    Tickets = e.NoOfTickets,
                    CreatedBy = e.CreatedBy
                }).ToList();

                if (dgvEvents.Columns.Count > 0)
                {
                    dgvEvents.Columns["ID"].Width = 60;
                    dgvEvents.Columns["Name"].Width = 150;
                    dgvEvents.Columns["Date"].Width = 120;
                    dgvEvents.Columns["Location"].Width = 120;
                    dgvEvents.Columns["Tickets"].Width = 80;
                    dgvEvents.Columns["CreatedBy"].Width = 100;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Error loading events: {ex.Message}", "Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCreate_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                Event newEvent = new Event
                {
                    Name = txtName.Text.Trim(),
                    Date = dateTimePicker1.Value, // Use the designer control name
                    Location = txtLocation.Text.Trim(),
                    NoOfTickets = int.Parse(txtTickets.Text), // Convert from TextBox
                    CreatedBy = txtCreatedBy.Text.Trim()
                };

                if (eventController.CreateEvent(newEvent))
                {
                    ClearForm();
                    LoadEvents();
                    MessageBox.Show("Event created successfully!", "Success",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (currentEvent != null && ValidateInput())
            {
                currentEvent.Name = txtName.Text.Trim();
                currentEvent.Date = dateTimePicker1.Value;
                currentEvent.Location = txtLocation.Text.Trim();
                currentEvent.NoOfTickets = int.Parse(txtTickets.Text);

                if (eventController.UpdateEvent(currentEvent))
                {
                    ClearForm();
                    LoadEvents();
                    MessageBox.Show("Event updated successfully!", "Success",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (currentEvent != null)
            {
                DialogResult result = MessageBox.Show(
                    $"Are you sure you want to delete the event '{currentEvent.Name}'?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    if (eventController.DeleteEvent(currentEvent.EventID))
                    {
                        ClearForm();
                        LoadEvents();
                        MessageBox.Show("Event deleted successfully!", "Success",
                                      MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void DgvEvents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvEvents.Rows[e.RowIndex];
                int eventID = Convert.ToInt32(row.Cells["ID"].Value);

                currentEvent = eventController.ReadEvent(eventID);

                if (currentEvent != null)
                {
                    txtName.Text = currentEvent.Name;
                    dateTimePicker1.Value = currentEvent.Date;
                    txtLocation.Text = currentEvent.Location;
                    txtTickets.Text = currentEvent.NoOfTickets.ToString();
                    txtCreatedBy.Text = currentEvent.CreatedBy;

                    btnUpdate.Enabled = true;
                    btnDelete.Enabled = true;
                    btnCreate.Enabled = false;
                }
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Please enter event name.", "Validation Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtLocation.Text))
            {
                MessageBox.Show("Please enter event location.", "Validation Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLocation.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtCreatedBy.Text))
            {
                MessageBox.Show("Please enter creator name.", "Validation Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCreatedBy.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtTickets.Text) || !int.TryParse(txtTickets.Text, out int tickets) || tickets <= 0)
            {
                MessageBox.Show("Please enter a valid number of tickets.", "Validation Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTickets.Focus();
                return false;
            }

            if (dateTimePicker1.Value <= DateTime.Now)
            {
                MessageBox.Show("Event date must be in the future.", "Validation Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dateTimePicker1.Focus();
                return false;
            }

            return true;
        }

        private void StartAutoEventGeneration()
        {
            // Check every 30 minutes for events to create
            autoEventTimer = new System.Windows.Forms.Timer();
            autoEventTimer.Interval = 30 * 60 * 1000; // 30 minutes
            autoEventTimer.Tick += AutoEventTimer_Tick;
            autoEventTimer.Start();

            // Create initial template
            CreateDefaultTemplate();
        }

        private void AutoEventTimer_Tick(object sender, EventArgs e)
        {
            GenerateAutomaticEvents();
        }

        private void CreateDefaultTemplate()
        {
            // Add a default template for automatic event generation
            eventTemplates.Add(new EventTemplate
            {
                Name = "Weekly Concert",
                Location = "Main Auditorium",
                NoOfTickets = 100,
                CreatedBy = "System",
                IntervalDays = 7, // Every 7 days
                StartDate = DateTime.Now.AddDays(1),
                EventTime = new TimeSpan(19, 0, 0) // 7:00 PM
            });
        }

        private void GenerateAutomaticEvents()
        {
            try
            {
                DateTime futureDate = DateTime.Now.AddDays(7); // Plan events 1 week ahead

                foreach (var template in eventTemplates)
                {
                    // Check if we need to create an event for this template
                    if (ShouldCreateEvent(template, futureDate))
                    {
                        Event autoEvent = new Event
                        {
                            Name = $"{template.Name} - {futureDate:MMM dd}",
                            Date = futureDate.Date.Add(template.EventTime),
                            Location = template.Location,
                            NoOfTickets = template.NoOfTickets,
                            CreatedBy = template.CreatedBy + " (Auto)"
                        };

                        if (eventController.CreateEvent(autoEvent))
                        {
                            LoadEvents(); // Refresh the display
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Auto-generation error: {ex.Message}", "Error");
            }
        }

        private bool ShouldCreateEvent(EventTemplate template, DateTime targetDate)
        {
            // Check if event already exists for this date and template
            List<Event> existingEvents = eventController.ReadEvents();
            string expectedName = $"{template.Name} - {targetDate:MMM dd}";

            return !existingEvents.Any(e =>
                e.Name.Contains(template.Name) &&
                e.Date.Date == targetDate.Date);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
                autoEventTimer?.Stop(); // Add this
                autoEventTimer?.Dispose(); // Add this
            }
            base.Dispose(disposing);
        }

        private void ClearForm()
        {
            txtName.Clear();
            dateTimePicker1.Value = DateTime.Now.AddDays(1);
            txtLocation.Clear();
            txtTickets.Clear();
            txtCreatedBy.Clear();

            currentEvent = null;

            btnCreate.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }

        // Event handlers for designer-generated events (keep these empty if not needed)
        private void EventOrganizerForm_Load(object sender, EventArgs e)
        {
            // Form load logic if needed
        }

        private void label2_Click(object sender, EventArgs e)
        {
            // Label click handler if needed
        }

        private void label4_Click(object sender, EventArgs e)
        {
            // Label click handler if needed
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // This is linked to btnUpdate in the designer
            // The actual logic is now in BtnUpdate_Click
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            // Date picker change handler if needed
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {

        }
    }
}