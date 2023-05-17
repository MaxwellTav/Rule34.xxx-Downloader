using R34Downloader.Models;
using R34Downloader.Properties;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Net.Configuration;
using System.Windows.Forms;

namespace R34Downloader.Forms
{
    /// <summary>
    /// Settings form.
    /// </summary>
    public partial class SettingsForm : Form
    {
        #region Variables
        List<string> restrictions = new List<string>(); 
        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the SettingsForm class.
        /// </summary>
        public SettingsForm()
        {
            InitializeComponent();
        }

        #endregion

        #region Handlers

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            if (SettingsModel.IsApi)
            {
                radioButton1.Checked = true;
            }
            else
            {
                radioButton2.Checked = true;
            }

            restrictionsListBox.Text = Settings.Default.RestrictionList.ToString();
            textBox1.Text = Settings.Default.Path.ToString();
        }

        private void radioButton_MouseClick(object sender, MouseEventArgs e)
        {
            SettingsModel.IsApi = radioButton1.Checked;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Settings.Default.Path = textBox1.Text;
            Settings.Default.Save();
            MessageBox.Show("Done");
            Close();
        }

        #endregion

        private void button2_Click(object sender, EventArgs e)
        {
            string sNewRestriction = " " + restrictionsTextbox.Text.ToString(),
                sSavedRestriction = Settings.Default.RestrictionList.ToString();

            restrictionsListBox.Text = sSavedRestriction + sNewRestriction;
            Settings.Default.RestrictionList = sSavedRestriction + sNewRestriction;

            MessageBox.Show("Done");
            restrictionsTextbox.Text = string.Empty;
            restrictionsTextbox.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Settings.Default.Reset();
            restrictionsTextbox.Text = string.Empty;
            restrictionsListBox.Text = string.Empty;
            MessageBox.Show("Saved");
        }
    }
}
