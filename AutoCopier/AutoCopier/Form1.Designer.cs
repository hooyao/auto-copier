﻿using System.Collections.Generic;
using System.Windows.Forms;

namespace AutoCopier
{
    partial class copierForm
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
            this.startMonBtn = new System.Windows.Forms.Button();
            this.statusPgBar = new System.Windows.Forms.ProgressBar();
            this.srcLb = new System.Windows.Forms.Label();
            this.tgtLb = new System.Windows.Forms.Label();
            this.srcText = new System.Windows.Forms.TextBox();
            this.tgtText = new System.Windows.Forms.TextBox();
            this.srcBtn = new System.Windows.Forms.Button();
            this.tgtBtn = new System.Windows.Forms.Button();
            this.copyRdBtn = new System.Windows.Forms.RadioButton();
            this.cutRdBtn = new System.Windows.Forms.RadioButton();
            this.lbExt = new System.Windows.Forms.Label();
            this.txtExt = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // startMonBtn
            // 
            this.startMonBtn.Location = new System.Drawing.Point(142, 264);
            this.startMonBtn.Name = "startMonBtn";
            this.startMonBtn.Size = new System.Drawing.Size(159, 36);
            this.startMonBtn.TabIndex = 0;
            this.startMonBtn.Text = "Start Monitoring";
            this.startMonBtn.UseVisualStyleBackColor = true;
            this.startMonBtn.Click += new System.EventHandler(this.startMonBtn_Click);
            // 
            // statusPgBar
            // 
            this.statusPgBar.Location = new System.Drawing.Point(24, 221);
            this.statusPgBar.Name = "statusPgBar";
            this.statusPgBar.Size = new System.Drawing.Size(396, 23);
            this.statusPgBar.TabIndex = 1;
            // 
            // srcLb
            // 
            this.srcLb.AutoSize = true;
            this.srcLb.Location = new System.Drawing.Point(21, 54);
            this.srcLb.Name = "srcLb";
            this.srcLb.Size = new System.Drawing.Size(53, 17);
            this.srcLb.TabIndex = 2;
            this.srcLb.Text = "Source";
            // 
            // tgtLb
            // 
            this.tgtLb.AutoSize = true;
            this.tgtLb.Location = new System.Drawing.Point(21, 112);
            this.tgtLb.Name = "tgtLb";
            this.tgtLb.Size = new System.Drawing.Size(50, 17);
            this.tgtLb.TabIndex = 3;
            this.tgtLb.Text = "Target";
            // 
            // srcText
            // 
            this.srcText.Location = new System.Drawing.Point(80, 51);
            this.srcText.Name = "srcText";
            this.srcText.ReadOnly = true;
            this.srcText.Size = new System.Drawing.Size(275, 22);
            this.srcText.TabIndex = 4;
            this.srcText.Text = "Z:\\";
            // 
            // tgtText
            // 
            this.tgtText.Location = new System.Drawing.Point(80, 107);
            this.tgtText.Name = "tgtText";
            this.tgtText.ReadOnly = true;
            this.tgtText.Size = new System.Drawing.Size(275, 22);
            this.tgtText.TabIndex = 5;
            this.tgtText.Text = "F:\\";
            // 
            // srcBtn
            // 
            this.srcBtn.Location = new System.Drawing.Point(384, 48);
            this.srcBtn.Name = "srcBtn";
            this.srcBtn.Size = new System.Drawing.Size(36, 23);
            this.srcBtn.TabIndex = 6;
            this.srcBtn.Text = "...";
            this.srcBtn.UseVisualStyleBackColor = true;
            this.srcBtn.Click += new System.EventHandler(this.srcBtn_Click);
            // 
            // tgtBtn
            // 
            this.tgtBtn.Location = new System.Drawing.Point(384, 107);
            this.tgtBtn.Name = "tgtBtn";
            this.tgtBtn.Size = new System.Drawing.Size(36, 23);
            this.tgtBtn.TabIndex = 7;
            this.tgtBtn.Text = "...";
            this.tgtBtn.UseVisualStyleBackColor = true;
            this.tgtBtn.Click += new System.EventHandler(this.tgtBtn_Click);
            // 
            // copyRdBtn
            // 
            this.copyRdBtn.AutoSize = true;
            this.copyRdBtn.Location = new System.Drawing.Point(40, 141);
            this.copyRdBtn.Name = "copyRdBtn";
            this.copyRdBtn.Size = new System.Drawing.Size(94, 21);
            this.copyRdBtn.TabIndex = 8;
            this.copyRdBtn.Text = "Copy Only";
            this.copyRdBtn.UseVisualStyleBackColor = true;
            // 
            // cutRdBtn
            // 
            this.cutRdBtn.AutoSize = true;
            this.cutRdBtn.Checked = true;
            this.cutRdBtn.Location = new System.Drawing.Point(156, 141);
            this.cutRdBtn.Name = "cutRdBtn";
            this.cutRdBtn.Size = new System.Drawing.Size(50, 21);
            this.cutRdBtn.TabIndex = 9;
            this.cutRdBtn.TabStop = true;
            this.cutRdBtn.Text = "Cut";
            this.cutRdBtn.UseVisualStyleBackColor = true;
            // 
            // lbExt
            // 
            this.lbExt.AutoSize = true;
            this.lbExt.Location = new System.Drawing.Point(21, 186);
            this.lbExt.Name = "lbExt";
            this.lbExt.Size = new System.Drawing.Size(76, 17);
            this.lbExt.TabIndex = 10;
            this.lbExt.Text = "Extensions";
            // 
            // txtExt
            // 
            this.txtExt.Location = new System.Drawing.Point(120, 183);
            this.txtExt.Name = "txtExt";
            this.txtExt.Size = new System.Drawing.Size(202, 22);
            this.txtExt.TabIndex = 11;
            this.txtExt.Text = "*rar,*zip";
            // 
            // copierForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 330);
            this.Controls.Add(this.txtExt);
            this.Controls.Add(this.lbExt);
            this.Controls.Add(this.cutRdBtn);
            this.Controls.Add(this.copyRdBtn);
            this.Controls.Add(this.tgtBtn);
            this.Controls.Add(this.srcBtn);
            this.Controls.Add(this.tgtText);
            this.Controls.Add(this.srcText);
            this.Controls.Add(this.tgtLb);
            this.Controls.Add(this.srcLb);
            this.Controls.Add(this.statusPgBar);
            this.Controls.Add(this.startMonBtn);
            this.Name = "copierForm";
            this.Text = "Copier";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.copierForm_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private List<Control> ctrlList = new List<Control>();

        private System.Windows.Forms.Button startMonBtn;
        private System.Windows.Forms.Label srcLb;
        private System.Windows.Forms.Label tgtLb;
        private System.Windows.Forms.TextBox srcText;
        private System.Windows.Forms.TextBox tgtText;
        private System.Windows.Forms.Button srcBtn;
        private System.Windows.Forms.Button tgtBtn;
        private System.Windows.Forms.RadioButton copyRdBtn;
        private System.Windows.Forms.RadioButton cutRdBtn;
        private Label lbExt;
        private TextBox txtExt;
        private ProgressBar statusPgBar;

    }
}

