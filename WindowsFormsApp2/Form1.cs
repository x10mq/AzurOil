using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        string[] nameOil = { "Gasoline-92", "Gasoline-95", "Gasoline-95-premium", "Diesel fuel", "Gas" };
        double[] oil = { 29.99, 30.99, 31.99, 13.78, 29.99 };
        double PayGasSt { get; set; } = 0;
        double PayCafe { get; set; } = 0;
        double PayTotal { get; set; } = 0;
        double countHotDog, countHam, countCola, countFri = 0;
        

        public Form1()
        {
            InitializeComponent();
            InitialTrackBar();

            this.Load += grBoxPaymentPet_Enter;
        }

        private void InitialTrackBar()
        {        
  
            trackBarBestOil.Minimum = 1;
            trackBarBestOil.Maximum =255;
            trackBarBestOil.ValueChanged += TrackBarBestOil_ValueChanged;
            trackBarCafe.ValueChanged += TrackBarBestOil_ValueChanged;
            trackBarAllSum.ValueChanged += TrackBarBestOil_ValueChanged;
        }


        private void TrackBarBestOil_ValueChanged(object sender, EventArgs e)
        {          
            this.BackColor = Color.FromArgb(trackBarBestOil.Value, trackBarCafe.Value, trackBarAllSum.Value);
        }


        private void grBoxPaymentPet_Enter(object sender, EventArgs e)
        {
            comboBoxPetrol.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxPetrol.Items.AddRange(nameOil);
            string fistElement = comboBoxPetrol.Items[0] as string;
            int count = comboBoxPetrol.Items.Count;
            comboBoxPetrol.SelectedIndex = 0;
            txtBoxPrice.Text = $" {oil[0]}";
            txtBoxHotDogPrice.Text = $"21,00";
            txtBoxGambPrice.Text = $"32,00";
            txtBoxFriPrice.Text = $"15,00";
            txtBoxColaPrice.Text = $"18,00";
            comboBoxPetrol.SelectedIndexChanged += comboBoxPetrol_SelectedIndexChanged;
            radButQuantity.CheckedChanged += RadioButtonCheckedChanged;
            radButSum.CheckedChanged += RadioButtonCheckedChanged;
            comboBoxPetrol.SelectedValueChanged += comboBoxPetrol_SelectedValueChanged;

            txtBoxQuantity.Enter += TextBox_Enter;
            txtBoxQuantity.Leave += TextBox_Leave;
            txtBoxSum.Enter += TextBox_Enter;
            txtBoxSum.Leave += TextBox_Enter;
            txtBoxHotDogQuant.Enter += TextBox_Enter;
            txtBoxHotDogQuant.Leave += TextBox_Leave;
            txtBoxGambQuant.Enter += TextBox_Enter;
            txtBoxGambQuant.Leave += TextBox_Leave;
            txtBoxFriQuant.Enter += TextBox_Enter;
            txtBoxFriQuant.Leave += TextBox_Leave;
            txtBoxColaQuant.Enter += TextBox_Enter;
            txtBoxColaQuant.Leave += TextBox_Leave;

            txtBoxQuantity.TextChanged += Radio_TextChanged;
            txtBoxSum.TextChanged += Radio_TextChanged;

            
            chBoxHotDog.CheckedChanged += chBoxHotDog_CheckedChanged;
            chBoxGamb.CheckedChanged += chBoxGamb_CheckedChanged;
            chBoxFri.CheckedChanged += chBoxFri_CheckedChanged;
            chBoxCola.CheckedChanged += chBoxCola_CheckedChanged;

           
            txtBoxHotDogQuant.TextChanged += txtBoxHotDogQuant_TextChanged;
            txtBoxGambQuant.TextChanged += txtBoxGambQuant_TextChanged;
            txtBoxFriQuant.TextChanged += txtBoxFriQuant_TextChanged;
            txtBoxColaQuant.TextChanged += txtBoxColaQuant_TextChanged;
            
            txtBoxToPayCafe.TextChanged += txtBoxToPayCafe_TextChanged;
            txtBoxToPayGasSt.TextChanged += txtBoxToPayGasSt_TextChanged;

            butToCount.Click += butToCount_Click;




        }

        private void txtBoxToPayCafe_TextChanged(object sender, EventArgs e)
        {
            if (txtBoxToPayCafe.Text == "0")
            {
                txtBoxToPayCafe.Text = "0,00";
            }
        }

        private void txtBoxToPayGasSt_TextChanged(object sender, EventArgs e)
        {
            if (txtBoxToPayGasSt.Text == "0")
            {
                txtBoxToPayGasSt.Text = "0,00";
            }
        }



        private void butToCount_Click(object sender, EventArgs e)
        {
            if (PayGasSt + PayCafe != 0)
            {
                txtBoxToPayTotal.Text = (Math.Round((PayGasSt + PayCafe), 2)).ToString();
                DialogResult result = MessageBox.Show("Clear all fields?", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    txtBoxToPayGasSt.Text = "";
                    comboBoxPetrol.Text = "";
                    txtBoxPrice.Clear();
                    txtBoxQuantity.Clear();
                    txtBoxHotDogQuant.Clear();
                    txtBoxGambQuant.Clear();
                    txtBoxFriQuant.Clear();
                    txtBoxColaQuant.Clear();
                    txtBoxToPayCafe.Text = "";
                    txtBoxToPayTotal.Text = "";
                    radButQuantity.Checked = false;
                    radButSum.Checked = false;
                    chBoxHotDog.Checked = false;
                    chBoxGamb.Checked = false;
                    chBoxFri.Checked = false;
                    chBoxCola.Checked = false;
                }
                else
                {
                    Thread.Sleep(3000);
                    MessageBox.Show("Continue? Click count again!", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            else
            {
                MessageBox.Show("You have not performed any transactions", "Attention!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }



        private void txtBoxColaQuant_TextChanged(object sender, EventArgs e)
        {
            TextBox text = sender as TextBox;
            try
            {
                if (text.Text != "")
                {
                    if (double.Parse(text.Text) != countCola)
                    {
                        PayCafe -= (double.Parse(txtBoxColaPrice.Text) * countCola);
                        countCola = double.Parse(text.Text);
                        PayCafe += (double.Parse(txtBoxColaPrice.Text) * countCola);
                        txtBoxToPayCafe.Text = Math.Round(PayCafe, 2).ToString();
                    }
                }
            }
            catch (Exception)
            {
                text.Text = "0,00";
                MessageBox.Show("Incorrect data entry!", "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtBoxFriQuant_TextChanged(object sender, EventArgs e)
        {
            TextBox text = sender as TextBox;
            try
            {
                if (text.Text != "")
                {
                    if (double.Parse(text.Text) != countFri)
                    {
                        PayCafe -= (double.Parse(txtBoxFriPrice.Text) * countFri);
                        countFri = double.Parse(text.Text);
                        PayCafe += (double.Parse(txtBoxFriPrice.Text) * countFri);
                        txtBoxToPayCafe.Text = Math.Round(PayCafe, 2).ToString();
                    }
                }
            }
            catch (Exception)
            {
                text.Text = "0,00";
                MessageBox.Show("Incorrect data entry!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtBoxGambQuant_TextChanged(object sender, EventArgs e)
        {

            TextBox text = sender as TextBox;
            try
            {
                if (text.Text != "")
                {
                    if (double.Parse(text.Text) != countHam)
                    {
                        PayCafe -= (double.Parse(txtBoxGambPrice.Text) * countHam);
                        countHam = double.Parse(text.Text);
                        PayCafe += (double.Parse(txtBoxGambPrice.Text) * countHam);
                        txtBoxToPayCafe.Text = Math.Round(PayCafe, 2).ToString();
                    }
                }
            }
            catch (Exception)
            {
                text.Text = "0,00";
                MessageBox.Show("Incorrect data entry!", "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtBoxHotDogQuant_TextChanged(object sender, EventArgs e)
        {
            TextBox text = sender as TextBox;
            try
            {
                if (text.Text != "")
                {
                    if (double.Parse(text.Text) != countHotDog)
                    {
                        PayCafe -= (double.Parse(txtBoxHotDogPrice.Text) * countHotDog);
                        countHotDog = double.Parse(text.Text);
                        PayCafe += (double.Parse(txtBoxHotDogPrice.Text) * countHotDog);
                        txtBoxToPayCafe.Text = Math.Round(PayCafe, 2).ToString();
                    }
                }
            }
            catch (Exception)
            {
                text.Text = "0,00";
                MessageBox.Show("Incorrect data entry!", "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chBoxCola_CheckedChanged(object sender, EventArgs e)
        {
            if (chBoxCola.Checked)
            {
                txtBoxColaQuant.ReadOnly = false;
                txtBoxColaQuant.Enabled = true;
                txtBoxColaQuant.Focus();
            }
            else
            {

                PayCafe -= (double.Parse(txtBoxColaPrice.Text) * countCola);
                countCola = 0;
                txtBoxColaQuant.ReadOnly = true;
                txtBoxColaQuant.Text = "0,00";
                txtBoxToPayCafe.Text = Math.Round(PayCafe, 2).ToString();
            }
        }

        private void chBoxFri_CheckedChanged(object sender, EventArgs e)
        {
            if (chBoxFri.Checked)
            {
                txtBoxFriQuant.ReadOnly = false;
                txtBoxFriQuant.Enabled = true;
                txtBoxFriQuant.Focus();
            }
            else
            {

                PayCafe -= (double.Parse(txtBoxFriPrice.Text) * countFri);
                countFri = 0;
                txtBoxFriQuant.ReadOnly = true;
                txtBoxFriQuant.Text = "0,00";
                txtBoxToPayCafe.Text = Math.Round(PayCafe, 2).ToString();
            }
        }

        private void chBoxGamb_CheckedChanged(object sender, EventArgs e)
        {
            if (chBoxGamb.Checked)
            {
                txtBoxGambQuant.ReadOnly = false;
                txtBoxGambQuant.Enabled = true;
                txtBoxGambQuant.Focus();
            }
            else
            {

                PayCafe -= (double.Parse(txtBoxGambPrice.Text) * countHam);
                countHam = 0;
                txtBoxGambQuant.ReadOnly = true;
                txtBoxGambQuant.Text = "0,00";
                txtBoxToPayCafe.Text = Math.Round(PayCafe, 2).ToString();
            }
        }

        private void chBoxHotDog_CheckedChanged(object sender, EventArgs e)
        {
            if (chBoxHotDog.Checked)
            {
                txtBoxHotDogQuant.ReadOnly = false;
                txtBoxHotDogQuant.Enabled = true;
                txtBoxHotDogQuant.Focus();
            }
            else
            {

                PayCafe -= (double.Parse(txtBoxHotDogPrice.Text) * countHotDog);
                countHotDog = 0;
                txtBoxHotDogQuant.ReadOnly = true;
                txtBoxHotDogQuant.Text = "0,00";
                txtBoxToPayCafe.Text = Math.Round(PayCafe, 2).ToString();
            }
        }

        private void Radio_TextChanged(object sender, EventArgs e)
        {
            TextBox text = sender as TextBox;
            try
            {
                if (radButQuantity.Checked)
                {
                    PayGasSt = 0;
                    if (text.Text == "")
                    {
                        txtBoxToPayGasSt.Text = "0,00";
                    }
                    else
                    {
                        PayGasSt = double.Parse(txtBoxPrice.Text) * double.Parse(text.Text);
                        txtBoxToPayGasSt.Text = Math.Round(PayGasSt, 2).ToString();
                    }
                }
                if (radButSum.Checked)
                {
                    PayGasSt = 0;
                    if (text.Text == "")
                    {
                        txtBoxToPayGasSt.Text = "0,00";
                    }
                    else
                    {
                        PayGasSt = double.Parse(text.Text);
                        txtBoxToPayGasSt.Text = Math.Round((double.Parse(text.Text) / double.Parse(txtBoxPrice.Text)), 2).ToString();
                    }
                }
            }
            catch (Exception)
            {
                text.Text = "0,00";
                MessageBox.Show("Incorrect data entry!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void TextBox_Leave(object sender, EventArgs e)
        {
            TextBox text = sender as TextBox;
            if (text.Text == "0,00")
            {
                text.Text = "";
            }
        }

        private void TextBox_Enter(object sender, EventArgs e)
        {
            TextBox text = sender as TextBox;
            if (text.Text == "")
            {
                text.Text = "0,00";
            }
        }

        private void comboBoxPetrol_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedPetrol = comboBoxPetrol.SelectedItem.ToString();
            
        }

        private void RadioButtonCheckedChanged(object sender, EventArgs e)
        {
            if (radButQuantity.Checked)
            {
                txtBoxQuantity.ReadOnly = false;
                txtBoxSum.ReadOnly = true;
                txtBoxQuantity.Enabled = true;
                txtBoxSum.Text = "0,00";
                txtBoxToPayGasSt.Text = "0,00";

            }
            if (radButSum.Checked)
            {
                txtBoxQuantity.ReadOnly = true;
                txtBoxSum.ReadOnly = false;
                txtBoxSum.Enabled = true;
                txtBoxQuantity.Text = "0,00";
                txtBoxToPayGasSt.Text = "0,00";
            }
        }

        private void comboBoxPetrol_SelectedValueChanged(object sender, EventArgs e)
        {
            ComboBox radio = sender as ComboBox;
            if (radio.SelectedIndex == 0)
            {
                txtBoxPrice.Text = $"{oil[0]}";
            }
            if (radio.SelectedIndex == 1)
            {
                txtBoxPrice.Text = $"{oil[1]}";
            }
            if (radio.SelectedIndex == 2)
            {
                txtBoxPrice.Text = $"{oil[2]}";
            }
            if (radio.SelectedIndex == 3)
            {
                txtBoxPrice.Text = $"{oil[4]}";
            }
            if (radio.SelectedIndex == 4)
            {
                txtBoxPrice.Text = $"{oil[3]}";
            }
            txtBoxQuantity.Text = "0,00";
            txtBoxSum.Text = "0,00";
            txtBoxToPayGasSt.Text = "0,00";
        }
    }
}
