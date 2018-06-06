/*
 * Created by SharpDevelop.
 * User: Jiří
 * Date: 6. 5. 2018
 * Time: 15:16
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace PaintProg
{
	partial class ToolBox
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.HScrollBar hScrollBar1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button penButton;
		private System.Windows.Forms.Button FillButton;
		private System.Windows.Forms.Button RectButton;
		private System.Windows.Forms.Button EllipseButton;
		private System.Windows.Forms.Button sprayButton;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem novýObrázekToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem uložitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ukončitToolStripMenuItem;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
		private System.Windows.Forms.CheckBox checkBox1;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ToolBox));
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
			this.label2 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.button2 = new System.Windows.Forms.Button();
			this.penButton = new System.Windows.Forms.Button();
			this.FillButton = new System.Windows.Forms.Button();
			this.RectButton = new System.Windows.Forms.Button();
			this.EllipseButton = new System.Windows.Forms.Button();
			this.sprayButton = new System.Windows.Forms.Button();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.novýObrázekToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.uložitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ukončitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.label1.Location = new System.Drawing.Point(12, 44);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(271, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Nastavení";
			this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.hScrollBar1);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Location = new System.Drawing.Point(12, 182);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(259, 76);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Pero";
			// 
			// hScrollBar1
			// 
			this.hScrollBar1.LargeChange = 1;
			this.hScrollBar1.Location = new System.Drawing.Point(7, 44);
			this.hScrollBar1.Maximum = 10;
			this.hScrollBar1.Minimum = 1;
			this.hScrollBar1.Name = "hScrollBar1";
			this.hScrollBar1.Size = new System.Drawing.Size(246, 20);
			this.hScrollBar1.TabIndex = 1;
			this.hScrollBar1.Value = 1;
			this.hScrollBar1.ValueChanged += new System.EventHandler(this.HScrollBar1ValueChanged);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(7, 20);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(246, 24);
			this.label2.TabIndex = 0;
			this.label2.Text = "Tloušťka pera: 1";
			this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// button1
			// 
			this.button1.BackColor = System.Drawing.Color.Black;
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button1.Location = new System.Drawing.Point(7, 19);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(46, 23);
			this.button1.TabIndex = 2;
			this.button1.UseVisualStyleBackColor = false;
			this.button1.Click += new System.EventHandler(this.Button1Click);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.button2);
			this.groupBox2.Controls.Add(this.button1);
			this.groupBox2.Location = new System.Drawing.Point(19, 117);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(123, 56);
			this.groupBox2.TabIndex = 3;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Barvy";
			// 
			// button2
			// 
			this.button2.BackColor = System.Drawing.Color.White;
			this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button2.ForeColor = System.Drawing.Color.Black;
			this.button2.Location = new System.Drawing.Point(71, 19);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(46, 23);
			this.button2.TabIndex = 3;
			this.button2.UseVisualStyleBackColor = false;
			this.button2.Click += new System.EventHandler(this.Button2Click);
			// 
			// penButton
			// 
			this.penButton.Image = ((System.Drawing.Image)(resources.GetObject("penButton.Image")));
			this.penButton.Location = new System.Drawing.Point(12, 70);
			this.penButton.Name = "penButton";
			this.penButton.Size = new System.Drawing.Size(36, 36);
			this.penButton.TabIndex = 4;
			this.penButton.UseVisualStyleBackColor = true;
			this.penButton.Click += new System.EventHandler(this.PenButtonClick);
			// 
			// FillButton
			// 
			this.FillButton.Image = ((System.Drawing.Image)(resources.GetObject("FillButton.Image")));
			this.FillButton.Location = new System.Drawing.Point(69, 70);
			this.FillButton.Name = "FillButton";
			this.FillButton.Size = new System.Drawing.Size(36, 36);
			this.FillButton.TabIndex = 5;
			this.FillButton.UseVisualStyleBackColor = true;
			this.FillButton.Click += new System.EventHandler(this.FillButtonClick);
			// 
			// RectButton
			// 
			this.RectButton.Image = ((System.Drawing.Image)(resources.GetObject("RectButton.Image")));
			this.RectButton.Location = new System.Drawing.Point(126, 70);
			this.RectButton.Name = "RectButton";
			this.RectButton.Size = new System.Drawing.Size(36, 36);
			this.RectButton.TabIndex = 6;
			this.RectButton.UseVisualStyleBackColor = true;
			this.RectButton.Click += new System.EventHandler(this.RectButtonClick);
			// 
			// EllipseButton
			// 
			this.EllipseButton.Image = ((System.Drawing.Image)(resources.GetObject("EllipseButton.Image")));
			this.EllipseButton.Location = new System.Drawing.Point(182, 70);
			this.EllipseButton.Name = "EllipseButton";
			this.EllipseButton.Size = new System.Drawing.Size(36, 36);
			this.EllipseButton.TabIndex = 7;
			this.EllipseButton.UseVisualStyleBackColor = true;
			this.EllipseButton.Click += new System.EventHandler(this.EllipseButtonClick);
			// 
			// sprayButton
			// 
			this.sprayButton.Image = ((System.Drawing.Image)(resources.GetObject("sprayButton.Image")));
			this.sprayButton.Location = new System.Drawing.Point(235, 70);
			this.sprayButton.Name = "sprayButton";
			this.sprayButton.Size = new System.Drawing.Size(36, 36);
			this.sprayButton.TabIndex = 8;
			this.sprayButton.UseVisualStyleBackColor = true;
			this.sprayButton.Click += new System.EventHandler(this.SprayButtonClick);
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.novýObrázekToolStripMenuItem,
			this.uložitToolStripMenuItem,
			this.ukončitToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(288, 24);
			this.menuStrip1.TabIndex = 9;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// novýObrázekToolStripMenuItem
			// 
			this.novýObrázekToolStripMenuItem.Name = "novýObrázekToolStripMenuItem";
			this.novýObrázekToolStripMenuItem.Size = new System.Drawing.Size(91, 20);
			this.novýObrázekToolStripMenuItem.Text = "Nový obrázek";
			this.novýObrázekToolStripMenuItem.Click += new System.EventHandler(this.NovýObrázekToolStripMenuItemClick);
			// 
			// uložitToolStripMenuItem
			// 
			this.uložitToolStripMenuItem.Name = "uložitToolStripMenuItem";
			this.uložitToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
			this.uložitToolStripMenuItem.Text = "Uložit";
			this.uložitToolStripMenuItem.Click += new System.EventHandler(this.UložitToolStripMenuItemClick);
			// 
			// ukončitToolStripMenuItem
			// 
			this.ukončitToolStripMenuItem.Name = "ukončitToolStripMenuItem";
			this.ukončitToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
			this.ukončitToolStripMenuItem.Text = "Ukončit";
			this.ukončitToolStripMenuItem.Click += new System.EventHandler(this.UkončitToolStripMenuItemClick);
			// 
			// statusStrip1
			// 
			this.statusStrip1.BackColor = System.Drawing.SystemColors.Control;
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.toolStripStatusLabel1});
			this.statusStrip1.Location = new System.Drawing.Point(0, 263);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(288, 22);
			this.statusStrip1.TabIndex = 10;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// toolStripStatusLabel1
			// 
			this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			this.toolStripStatusLabel1.Size = new System.Drawing.Size(119, 17);
			this.toolStripStatusLabel1.Text = "Vybraný nástroj: Pero";
			// 
			// checkBox1
			// 
			this.checkBox1.Location = new System.Drawing.Point(148, 135);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(123, 24);
			this.checkBox1.TabIndex = 11;
			this.checkBox1.Text = "Vyplnit obrazce";
			this.checkBox1.UseVisualStyleBackColor = true;
			this.checkBox1.CheckedChanged += new System.EventHandler(this.CheckBox1CheckedChanged);
			// 
			// ToolBox
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(288, 285);
			this.Controls.Add(this.checkBox1);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.sprayButton);
			this.Controls.Add(this.EllipseButton);
			this.Controls.Add(this.RectButton);
			this.Controls.Add(this.FillButton);
			this.Controls.Add(this.penButton);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.menuStrip1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "ToolBox";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Panel nástrojů";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ToolBoxFormClosed);
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		}

	}

