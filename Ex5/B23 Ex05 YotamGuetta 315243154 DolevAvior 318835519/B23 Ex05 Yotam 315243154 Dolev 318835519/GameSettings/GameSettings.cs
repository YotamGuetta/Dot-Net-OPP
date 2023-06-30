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
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Size = new Size(m_textBoxPlayer2.Right + 30, m_buttonStart.Bottom + 50);
            Text = "Game Settings";
        }

        private void InitializeComponent()
        {
            this.m_labelPlayers = new System.Windows.Forms.Label();
            this.m_labelPlayer1 = new System.Windows.Forms.Label();
            this.m_textBoxPlayer1 = new System.Windows.Forms.TextBox();
            this.m_checkBoxPlayer2 = new System.Windows.Forms.CheckBox();
            this.m_textBoxPlayer2 = new System.Windows.Forms.TextBox();
            this.m_labelBoardSize = new System.Windows.Forms.Label();
            this.m_labelRows = new System.Windows.Forms.Label();
            this.m_numericUpDownRows = new System.Windows.Forms.NumericUpDown();
            this.m_labelCols = new System.Windows.Forms.Label();
            this.m_numericUpDownCols = new System.Windows.Forms.NumericUpDown();
            this.m_buttonStart = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.m_numericUpDownRows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_numericUpDownCols)).BeginInit();
            this.SuspendLayout();
            // 
            // m_labelPlayers
            // 
            this.m_labelPlayers.AutoSize = true;
            this.m_labelPlayers.Location = new System.Drawing.Point(17, 23);
            this.m_labelPlayers.Name = "m_labelPlayers";
            this.m_labelPlayers.Size = new System.Drawing.Size(64, 20);
            this.m_labelPlayers.TabIndex = 0;
            this.m_labelPlayers.Text = "Players:";
            // 
            // m_labelPlayer1
            // 
            this.m_labelPlayer1.AutoSize = true;
            this.m_labelPlayer1.Location = new System.Drawing.Point(29, 57);
            this.m_labelPlayer1.Name = "m_labelPlayer1";
            this.m_labelPlayer1.Size = new System.Drawing.Size(69, 20);
            this.m_labelPlayer1.TabIndex = 1;
            this.m_labelPlayer1.Text = "Player 1:";
            // 
            // m_textBoxPlayer1
            // 
            this.m_textBoxPlayer1.Location = new System.Drawing.Point(127, 54);
            this.m_textBoxPlayer1.Name = "m_textBoxPlayer1";
            this.m_textBoxPlayer1.Size = new System.Drawing.Size(151, 26);
            this.m_textBoxPlayer1.TabIndex = 2;
            // 
            // m_checkBoxPlayer2
            // 
            this.m_checkBoxPlayer2.AutoSize = true;
            this.m_checkBoxPlayer2.Location = new System.Drawing.Point(26, 98);
            this.m_checkBoxPlayer2.Name = "m_checkBoxPlayer2";
            this.m_checkBoxPlayer2.Size = new System.Drawing.Size(95, 24);
            this.m_checkBoxPlayer2.TabIndex = 3;
            this.m_checkBoxPlayer2.Text = "Player 2:";
            this.m_checkBoxPlayer2.CheckedChanged += new System.EventHandler(this.m_checkBoxPlayer2_CheckedChanged);
            // 
            // m_textBoxPlayer2
            // 
            this.m_textBoxPlayer2.Enabled = false;
            this.m_textBoxPlayer2.Location = new System.Drawing.Point(127, 96);
            this.m_textBoxPlayer2.Name = "m_textBoxPlayer2";
            this.m_textBoxPlayer2.Size = new System.Drawing.Size(151, 26);
            this.m_textBoxPlayer2.TabIndex = 4;
            this.m_textBoxPlayer2.Text = "[Computer]";
            // 
            // m_labelBoardSize
            // 
            this.m_labelBoardSize.AutoSize = true;
            this.m_labelBoardSize.Location = new System.Drawing.Point(17, 140);
            this.m_labelBoardSize.Name = "m_labelBoardSize";
            this.m_labelBoardSize.Size = new System.Drawing.Size(91, 20);
            this.m_labelBoardSize.TabIndex = 5;
            this.m_labelBoardSize.Text = "Board Size:";
            // 
            // m_labelRows
            // 
            this.m_labelRows.AutoSize = true;
            this.m_labelRows.Location = new System.Drawing.Point(29, 172);
            this.m_labelRows.Name = "m_labelRows";
            this.m_labelRows.Size = new System.Drawing.Size(53, 20);
            this.m_labelRows.TabIndex = 6;
            this.m_labelRows.Text = "Rows:";
            // 
            // m_numericUpDownRows
            // 
            this.m_numericUpDownRows.Location = new System.Drawing.Point(229, 169);
            this.m_numericUpDownRows.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.m_numericUpDownRows.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.m_numericUpDownRows.Name = "m_numericUpDownRows";
            this.m_numericUpDownRows.Size = new System.Drawing.Size(47, 26);
            this.m_numericUpDownRows.TabIndex = 7;
            this.m_numericUpDownRows.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.m_numericUpDownRows.ValueChanged += new System.EventHandler(this.rowsNumericUpDown_ValueChanged);
            // 
            // m_labelCols
            // 
            this.m_labelCols.AutoSize = true;
            this.m_labelCols.Location = new System.Drawing.Point(173, 172);
            this.m_labelCols.Name = "m_labelCols";
            this.m_labelCols.Size = new System.Drawing.Size(44, 20);
            this.m_labelCols.TabIndex = 8;
            this.m_labelCols.Text = "Cols:";
            // 
            // m_numericUpDownCols
            // 
            this.m_numericUpDownCols.Location = new System.Drawing.Point(99, 171);
            this.m_numericUpDownCols.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.m_numericUpDownCols.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.m_numericUpDownCols.Name = "m_numericUpDownCols";
            this.m_numericUpDownCols.Size = new System.Drawing.Size(44, 26);
            this.m_numericUpDownCols.TabIndex = 9;
            this.m_numericUpDownCols.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.m_numericUpDownCols.ValueChanged += new System.EventHandler(this.colsNumericUpDown_ValueChanged);
            // 
            // m_buttonStart
            // 
            this.m_buttonStart.Location = new System.Drawing.Point(38, 220);
            this.m_buttonStart.Name = "m_buttonStart";
            this.m_buttonStart.Size = new System.Drawing.Size(247, 27);
            this.m_buttonStart.TabIndex = 10;
            this.m_buttonStart.Text = "Start";
            this.m_buttonStart.Click += new System.EventHandler(this.startButton_Click);
            // 
            // GameSettingsForm
            // 
            this.ClientSize = new System.Drawing.Size(317, 273);
            this.Controls.Add(this.m_labelPlayers);
            this.Controls.Add(this.m_labelPlayer1);
            this.Controls.Add(this.m_textBoxPlayer1);
            this.Controls.Add(this.m_checkBoxPlayer2);
            this.Controls.Add(this.m_textBoxPlayer2);
            this.Controls.Add(this.m_labelBoardSize);
            this.Controls.Add(this.m_labelRows);
            this.Controls.Add(this.m_numericUpDownRows);
            this.Controls.Add(this.m_labelCols);
            this.Controls.Add(this.m_numericUpDownCols);
            this.Controls.Add(this.m_buttonStart);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GameSettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Game Settings";
            ((System.ComponentModel.ISupportInitialize)(this.m_numericUpDownRows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_numericUpDownCols)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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

        private void m_checkBoxPlayer2_CheckedChanged(object sender, EventArgs e)
        {
            m_textBoxPlayer2.Enabled = m_checkBoxPlayer2.Checked;
        }
    }
}
