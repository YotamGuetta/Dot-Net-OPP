using System;
using System.Drawing;
using System.Windows.Forms;

namespace GameSettings
{
    public partial class GameSettingsForm : Form
    {
        private Label m_labelPlayers;
        private Label m_labelPlayer1;
        private TextBox m_textBoxPlayer1;
        private CheckBox m_checkBoxPlayer2;
        private TextBox m_textBoxPlayer2;
        private Label m_labelBoardSize;
        private Label m_labelRows;
        private NumericUpDown m_numericUpDownRows;
        private Label m_labelCols;
        private NumericUpDown m_numericUpDownCols;
        private Button m_buttonStart;

        public GameSettingsForm()
        {
            initializeControls();
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Size = new Size(m_textBoxPlayer2.Right + 30, m_buttonStart.Bottom + 50);
            Text = "Game Settings";
        }

        private void initializeControls()
        {
            m_labelPlayers = new Label();
            m_labelPlayers.Text = "Players:";
            m_labelPlayers.Location = new Point(20, 20);
            m_labelPlayers.AutoSize = true;

            m_labelPlayer1 = new Label();
            m_labelPlayer1.Text = "Player 1:";
            m_labelPlayer1.Width = 80;
            m_labelPlayer1.Location = new Point(m_labelPlayers.Left + 10, m_labelPlayers.Bottom + 5);
            m_labelPlayer1.AutoSize = true;

            m_textBoxPlayer1 = new TextBox();
            m_textBoxPlayer1.Location = new Point(m_labelPlayer1.Right + 5, m_labelPlayer1.Top);
            m_textBoxPlayer1.Width = 100;

            m_checkBoxPlayer2 = new CheckBox();
            m_checkBoxPlayer2.Text = "Player 2:";
            m_checkBoxPlayer2.Location = new Point(m_labelPlayer1.Left, m_labelPlayer1.Bottom);
            m_checkBoxPlayer2.AutoSize = true;

            m_textBoxPlayer2 = new TextBox();
            m_textBoxPlayer2.Text = "[Computer]";
            m_textBoxPlayer2.Location = new Point(m_textBoxPlayer1.Left, m_checkBoxPlayer2.Top);
            m_textBoxPlayer2.Width = 100;
            m_textBoxPlayer2.Enabled = false;
            m_checkBoxPlayer2.CheckedChanged += (sender, e) =>
            {
                m_textBoxPlayer2.Enabled = m_checkBoxPlayer2.Checked;
            };

            m_labelBoardSize = new Label();
            m_labelBoardSize.Text = "Board Size:";
            m_labelBoardSize.Location = new Point(m_labelPlayers.Left, m_checkBoxPlayer2.Bottom + 20);
            m_labelBoardSize.AutoSize = true;

            m_labelRows = new Label();
            m_labelRows.Text = "Rows:";
            m_labelRows.Location = new Point(m_labelBoardSize.Left + 10, m_labelBoardSize.Bottom + 5);
            m_labelRows.AutoSize = true;

            m_numericUpDownRows = new NumericUpDown();
            m_numericUpDownRows.Location = new Point(m_labelRows.Left + 40, m_labelRows.Top);
            m_numericUpDownRows.Width = 35;
            m_numericUpDownRows.Minimum = 4;
            m_numericUpDownRows.Maximum = 10;
            m_numericUpDownRows.ValueChanged += rowsNumericUpDown_ValueChanged;

            m_labelCols = new Label();
            m_labelCols.Text = "Cols:";
            m_labelCols.Location = new Point(m_numericUpDownRows.Left + 70, m_labelRows.Top);
            m_labelCols.AutoSize = true;

            m_numericUpDownCols = new NumericUpDown();
            m_numericUpDownCols.Location = new Point(m_labelCols.Left + 40, m_labelRows.Top);
            m_numericUpDownCols.Width = 35;
            m_numericUpDownCols.Minimum = 4;
            m_numericUpDownCols.Maximum = 10;
            m_numericUpDownCols.ValueChanged += colsNumericUpDown_ValueChanged;

            m_buttonStart = new Button();
            m_buttonStart.Text = "Start";
            m_buttonStart.Width = m_numericUpDownCols.Right - m_labelPlayer1.Left;
            m_buttonStart.Location = new Point(m_labelPlayer1.Left, m_labelRows.Bottom + 20);
            m_buttonStart.Click += startButton_Click;

            Controls.Add(m_labelPlayers);
            Controls.Add(m_labelPlayer1);
            Controls.Add(m_textBoxPlayer1);
            Controls.Add(m_checkBoxPlayer2);
            Controls.Add(m_textBoxPlayer2);
            Controls.Add(m_labelBoardSize);
            Controls.Add(m_labelRows);
            Controls.Add(m_numericUpDownRows);
            Controls.Add(m_labelCols);
            Controls.Add(m_numericUpDownCols);
            Controls.Add(m_buttonStart);
        }

        private void rowsNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            m_numericUpDownCols.ValueChanged -= colsNumericUpDown_ValueChanged;
            m_numericUpDownCols.Value = m_numericUpDownRows.Value;
            m_numericUpDownCols.ValueChanged += colsNumericUpDown_ValueChanged;
        }

        private void colsNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            m_numericUpDownRows.ValueChanged -= rowsNumericUpDown_ValueChanged;
            m_numericUpDownRows.Value = m_numericUpDownCols.Value;
            m_numericUpDownRows.ValueChanged += rowsNumericUpDown_ValueChanged;
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
