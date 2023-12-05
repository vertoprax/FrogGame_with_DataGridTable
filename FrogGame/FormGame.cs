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
        int indEmptyCell = 3;
        int[] swamp = { 2, 2, 2, 0, 2, 1, 1, 1, 1 };
        Bitmap imageFrogRight, imageFrogLeft, imageLeaf;
        int score = 0;


        void ShowMassToDataGrid()
        {
            for (int i = 0; i < 9; i++)
            {
                switch (swamp[i])
                {
                    case 1: dataGridView1.Rows[0].Cells[i].Value = imageFrogLeft; break;
                    case 2: dataGridView1.Rows[0].Cells[i].Value = imageFrogRight; break;
                    case 0: dataGridView1.Rows[0].Cells[i].Value = imageLeaf; break;
                }
            }
        }

        void NewGame()
        {
            // внутренне представление model в MVC
            swamp = new int[9]{ 1, 1, 1, 1, 0, 2, 2, 2, 2 };
            score = 0;
            indEmptyCell = 4;
            // внешнее представление view в MVC
            ShowMassToDataGrid();
            labelScore.Text = score.ToString();
        }

        public FormGame()
        {
            InitializeComponent();
        }

        private void FormGame_Load(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add();
            dataGridView1.Rows[0].Height = 104;
            imageFrogRight = new Bitmap("pictures/frogRight.png");
            imageFrogLeft = new Bitmap("pictures/frogLeft.png");
            imageLeaf = new Bitmap("pictures/leaf.png");

            ShowMassToDataGrid();

            this.Width = 110 * 9;
            dataGridView1.Width = 106 * 9;
        }

        bool IsWin()
        {
            int[] winSwamp = { 2, 2, 2, 2, 0, 1, 1, 1, 1 };
            for (int i = 0; i < 9; i++)
            {
                if (swamp[i] != winSwamp[i])
                    return false;
            }
            return true;
        }

        void MoveFrog(int indFrog)
        {
            int temp = swamp[indFrog];
            swamp[indFrog] = 0; 
            swamp[indEmptyCell] = temp;
            indEmptyCell = indFrog;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Math.Abs(e.ColumnIndex - indEmptyCell) > 0 && Math.Abs(e.ColumnIndex - indEmptyCell) < 3)
            {
                // MessageBox.Show("Ходить можно");
                MoveFrog(e.ColumnIndex);
                ShowMassToDataGrid();
                score++;
                labelScore.Text = score.ToString();
                if (IsWin())
                {
                    MessageBox.Show("Вы выиграли!");
                    NewGame();
                }
            }
            else
            {
                MessageBox.Show("Так ходить нельзя!");
            }
        }
    }
}
