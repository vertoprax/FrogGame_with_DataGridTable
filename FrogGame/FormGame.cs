using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrogGame
{
    public partial class FormGame : Form
    {
        int indEmptyCell = 4;
        public FormGame()
        {
            InitializeComponent();
        }

        private void FormGame_Load(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add();
            dataGridView1.Rows[0].Height = 104;
            Bitmap imageFrogRight = new Bitmap("pictures/frogRight.png");
            Bitmap imageFrogLeft = new Bitmap("pictures/frogLeft.png");
            Bitmap imageLeaf = new Bitmap("pictures/leaf.png");

            dataGridView1.Rows[0].Cells[4].Value = imageLeaf;
            for (int i = 0; i < 4; i++)
            {
                dataGridView1.Rows[0].Cells[i].Value = imageFrogLeft;
                dataGridView1.Rows[0].Cells[5 + i].Value = imageFrogRight;
            }
            this.Width = 110 * 9;
            dataGridView1.Width = 106 * 9;
            
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Math.Abs(e.ColumnIndex - indEmptyCell) > 0 && Math.Abs(e.ColumnIndex - indEmptyCell) < 3)
            {
                MessageBox.Show("Ходить можно");
            }
            else
            {
                MessageBox.Show("Так ходить нельзя!");

            }
        }
    }
}
