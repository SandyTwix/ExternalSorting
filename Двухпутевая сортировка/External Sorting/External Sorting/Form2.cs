using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace External_Sorting
{
    public partial class Form2 : Form
    {
        Film resultFilm;

        public Form2(Film film)
        {
            InitializeComponent();
            for (int i = 0; i < 5; ++i)
            {
                hoursComboBox.Items.Add(i);
            }
            for (int i = 0; i < 60; ++i)
            {
                minutesComboBox.Items.Add(i);
            }
            for (int i = 1895; i < 2021; ++i)
            {
                yearComboBox.Items.Add(i);
            }
            resultFilm = film;
        }

        private bool TextAndComboBoxesNotEmpty()
        {
            return (this.Controls.OfType<TextBox>().All(textBox => textBox.Text != "")
            && this.Controls.OfType<ComboBox>().All(textBox => textBox.Text != ""));
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if (TextAndComboBoxesNotEmpty())
            {
                resultFilm.title = titleTextBox.Text;
                resultFilm.releaseYear = Convert.ToInt32(yearComboBox.Text);
                resultFilm.studio = studioTextBox.Text;
                resultFilm.director = directorTextBox.Text;
                resultFilm.duration = Convert.ToInt32(hoursComboBox.Text) * 60 + Convert.ToInt32(minutesComboBox.Text);
                resultFilm.isRewarded = (isRewardedComboBox.SelectedIndex == 0);
                resultFilm.protagonists[0] = protagonist1TextBox.Text;
                resultFilm.protagonists[1] = protagonist2TextBox.Text;
                resultFilm.protagonists[2] = protagonist3TextBox.Text;
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Сначала заполните все поля!");
            }
        }
    }
}