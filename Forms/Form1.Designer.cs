﻿namespace Forms
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            groupBox1 = new GroupBox();
            rcTxBx_InputData = new RichTextBox();
            gB_Controller = new GroupBox();
            bGetKNF = new Button();
            bGetDNF = new Button();
            b4_SaveEval = new Button();
            b3_ExpEval = new Button();
            b2_GetListLex = new Button();
            b1_GetTreeLex = new Button();
            gB_LexAnal = new GroupBox();
            rcTxBx_outData = new RichTextBox();
            bGetTableTruth = new Button();
            groupBox1.SuspendLayout();
            gB_Controller.SuspendLayout();
            gB_LexAnal.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 24F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(657, 36);
            label1.TabIndex = 0;
            label1.Text = "Интерпретатор арифметических выражений";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(rcTxBx_InputData);
            groupBox1.Font = new Font("Times New Roman", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            groupBox1.Location = new Point(21, 54);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(667, 100);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Ввод арифметического выражения";
            // 
            // rcTxBx_InputData
            // 
            rcTxBx_InputData.Location = new Point(6, 31);
            rcTxBx_InputData.Name = "rcTxBx_InputData";
            rcTxBx_InputData.Size = new Size(655, 63);
            rcTxBx_InputData.TabIndex = 0;
            rcTxBx_InputData.Text = "";
            rcTxBx_InputData.TextChanged += rcTxBx_InputData_TextChanged;
            // 
            // gB_Controller
            // 
            gB_Controller.Controls.Add(bGetKNF);
            gB_Controller.Controls.Add(bGetDNF);
            gB_Controller.Controls.Add(b4_SaveEval);
            gB_Controller.Controls.Add(b3_ExpEval);
            gB_Controller.Controls.Add(b2_GetListLex);
            gB_Controller.Controls.Add(b1_GetTreeLex);
            gB_Controller.Font = new Font("Times New Roman", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            gB_Controller.Location = new Point(21, 160);
            gB_Controller.Name = "gB_Controller";
            gB_Controller.Size = new Size(240, 338);
            gB_Controller.TabIndex = 2;
            gB_Controller.TabStop = false;
            gB_Controller.Text = "Управление";
            // 
            // bGetKNF
            // 
            bGetKNF.BackColor = SystemColors.ButtonFace;
            bGetKNF.Enabled = false;
            bGetKNF.Font = new Font("Times New Roman", 14.25F, FontStyle.Bold);
            bGetKNF.Location = new Point(122, 208);
            bGetKNF.Name = "bGetKNF";
            bGetKNF.Size = new Size(112, 53);
            bGetKNF.TabIndex = 5;
            bGetKNF.Text = "KNF";
            bGetKNF.UseVisualStyleBackColor = false;
            bGetKNF.Click += bGetKNF_Click;
            // 
            // bGetDNF
            // 
            bGetDNF.BackColor = SystemColors.ButtonFace;
            bGetDNF.Enabled = false;
            bGetDNF.Font = new Font("Times New Roman", 14.25F, FontStyle.Bold);
            bGetDNF.Location = new Point(6, 208);
            bGetDNF.Name = "bGetDNF";
            bGetDNF.Size = new Size(112, 53);
            bGetDNF.TabIndex = 4;
            bGetDNF.Text = "DNF";
            bGetDNF.UseVisualStyleBackColor = false;
            bGetDNF.Click += bGetDNF_Click;
            // 
            // b4_SaveEval
            // 
            b4_SaveEval.BackColor = SystemColors.ButtonFace;
            b4_SaveEval.Enabled = false;
            b4_SaveEval.Font = new Font("Times New Roman", 14.25F, FontStyle.Bold);
            b4_SaveEval.ForeColor = SystemColors.ControlText;
            b4_SaveEval.Location = new Point(6, 31);
            b4_SaveEval.Name = "b4_SaveEval";
            b4_SaveEval.Size = new Size(228, 53);
            b4_SaveEval.TabIndex = 3;
            b4_SaveEval.Text = "Сохранить выражение\r\n";
            b4_SaveEval.UseVisualStyleBackColor = false;
            b4_SaveEval.Click += b4_SaveEval_Click;
            // 
            // b3_ExpEval
            // 
            b3_ExpEval.BackColor = SystemColors.ButtonFace;
            b3_ExpEval.Enabled = false;
            b3_ExpEval.Font = new Font("Times New Roman", 14.25F, FontStyle.Bold);
            b3_ExpEval.Location = new Point(6, 267);
            b3_ExpEval.Name = "b3_ExpEval";
            b3_ExpEval.Size = new Size(228, 53);
            b3_ExpEval.TabIndex = 2;
            b3_ExpEval.Text = "Вычисление выражения";
            b3_ExpEval.UseVisualStyleBackColor = false;
            b3_ExpEval.Click += b3_ExpEval_Click;
            // 
            // b2_GetListLex
            // 
            b2_GetListLex.BackColor = SystemColors.ButtonFace;
            b2_GetListLex.Enabled = false;
            b2_GetListLex.Font = new Font("Times New Roman", 14.25F, FontStyle.Bold);
            b2_GetListLex.Location = new Point(6, 149);
            b2_GetListLex.Name = "b2_GetListLex";
            b2_GetListLex.Size = new Size(228, 53);
            b2_GetListLex.TabIndex = 1;
            b2_GetListLex.Text = "Получить список лексем";
            b2_GetListLex.UseVisualStyleBackColor = false;
            b2_GetListLex.Click += b2_GetListLex_Click;
            // 
            // b1_GetTreeLex
            // 
            b1_GetTreeLex.BackColor = SystemColors.ButtonFace;
            b1_GetTreeLex.Enabled = false;
            b1_GetTreeLex.Font = new Font("Times New Roman", 14.25F, FontStyle.Bold);
            b1_GetTreeLex.Location = new Point(6, 90);
            b1_GetTreeLex.Name = "b1_GetTreeLex";
            b1_GetTreeLex.Size = new Size(228, 53);
            b1_GetTreeLex.TabIndex = 0;
            b1_GetTreeLex.Text = "Получить дерево лексем";
            b1_GetTreeLex.UseVisualStyleBackColor = false;
            b1_GetTreeLex.Click += b1_GetTreeLex_Click;
            // 
            // gB_LexAnal
            // 
            gB_LexAnal.Controls.Add(bGetTableTruth);
            gB_LexAnal.Controls.Add(rcTxBx_outData);
            gB_LexAnal.Font = new Font("Times New Roman", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            gB_LexAnal.Location = new Point(267, 160);
            gB_LexAnal.Name = "gB_LexAnal";
            gB_LexAnal.Size = new Size(421, 332);
            gB_LexAnal.TabIndex = 3;
            gB_LexAnal.TabStop = false;
            gB_LexAnal.Text = "Лексический анализ";
            // 
            // rcTxBx_outData
            // 
            rcTxBx_outData.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            rcTxBx_outData.Location = new Point(6, 31);
            rcTxBx_outData.Name = "rcTxBx_outData";
            rcTxBx_outData.ReadOnly = true;
            rcTxBx_outData.Size = new Size(409, 230);
            rcTxBx_outData.TabIndex = 1;
            rcTxBx_outData.Text = "";
            // 
            // bGetTableTruth
            // 
            bGetTableTruth.BackColor = SystemColors.ButtonFace;
            bGetTableTruth.Enabled = false;
            bGetTableTruth.Font = new Font("Times New Roman", 14.25F, FontStyle.Bold);
            bGetTableTruth.Location = new Point(6, 267);
            bGetTableTruth.Name = "bGetTableTruth";
            bGetTableTruth.Size = new Size(409, 53);
            bGetTableTruth.TabIndex = 3;
            bGetTableTruth.Text = "Получить таблицу истинности";
            bGetTableTruth.UseVisualStyleBackColor = false;
            bGetTableTruth.Click += bGetTableTruth_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientInactiveCaption;
            ClientSize = new Size(702, 510);
            Controls.Add(gB_LexAnal);
            Controls.Add(gB_Controller);
            Controls.Add(groupBox1);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            groupBox1.ResumeLayout(false);
            gB_Controller.ResumeLayout(false);
            gB_LexAnal.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private GroupBox groupBox1;
        private GroupBox gB_Controller;
        private Button b3_ExpEval;
        private Button b2_GetListLex;
        private Button b1_GetTreeLex;
        private RichTextBox rcTxBx_InputData;
        private GroupBox gB_LexAnal;
        private RichTextBox rcTxBx_outData;
        private Button b4_SaveEval;
        private Button bGetKNF;
        private Button bGetDNF;
        private Button bGetTableTruth;
    }
}
