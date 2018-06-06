/*
 * Created by SharpDevelop.
 * User: Jiří
 * Date: 6. 5. 2018
 * Time: 15:16
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace PaintProg
{
	/// <summary>
	/// A form that allows user to select and setup drawing tools.
	/// </summary>
	public partial class ToolBox : Form
	{
		MainForm mf;
		
		public ToolBox(MainForm cMainForm)
		{
			InitializeComponent();
			penButton.PerformClick();
			mf = cMainForm;
		}
		
		void SetTool(MainForm.ActiveTool selected, string s)
		{
			MainForm.selectedTool = selected;
			toolStripStatusLabel1.Text = "Vybraný nástroj: " + s;
		}
		
		void HScrollBar1ValueChanged(object sender, EventArgs e)
		{
			MainForm.penWidth = hScrollBar1.Value;
			label2.Text = "Tloušťka pera: " + hScrollBar1.Value.ToString();
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			var colDial = new ColorDialog();
			
			if(colDial.ShowDialog() == DialogResult.OK)
			{
				button1.BackColor = colDial.Color;
				MainForm.colors[0] = colDial.Color;
			}
			
		}
		void Button2Click(object sender, EventArgs e)
		{
			var colDial = new ColorDialog();
			if(colDial.ShowDialog() == DialogResult.OK)
			{
				button2.BackColor = colDial.Color;
				MainForm.colors[1] = colDial.Color;
			}
		}
		void PenButtonClick(object sender, EventArgs e)
		{
			SetTool(MainForm.ActiveTool.Pen, "Pero");
		}
		void FillButtonClick(object sender, EventArgs e)
		{
			SetTool(MainForm.ActiveTool.Fill, "Vyplňění oblasti");
		}
		void RectButtonClick(object sender, EventArgs e)
		{
			SetTool(MainForm.ActiveTool.Rectangle, "Obdélník");
		}
		void EllipseButtonClick(object sender, EventArgs e)
		{
			SetTool(MainForm.ActiveTool.Ellipse, "Elipsa");
		}
		void SprayButtonClick(object sender, EventArgs e)
		{
			SetTool(MainForm.ActiveTool.Spray, "Sprej");
		}
		void ToolBoxFormClosed(object sender, FormClosedEventArgs e)
		{
			Application.Exit();
		}
		void NovýObrázekToolStripMenuItemClick(object sender, EventArgs e)
		{
			Bitmap tempBmp = new Bitmap(MainForm.bmp.Width, MainForm.bmp.Height);
			MainForm.bmp = tempBmp;
			mf.Refresh();
		}
		void UložitToolStripMenuItemClick(object sender, EventArgs e)
		{
			SaveFileDialog save = new SaveFileDialog();
			save.Filter = "Obrázky ve formátu png (*.png)|*.png";
			
			if (save.ShowDialog() == DialogResult.OK)
			{
				MainForm.bmp.Save(save.FileName, ImageFormat.Png);
			}
		}
		void CheckBox1CheckedChanged(object sender, EventArgs e)
		{
			MainForm.fillingShapes = checkBox1.Checked;
		}
		void UkončitToolStripMenuItemClick(object sender, EventArgs e)
		{
			Application.Exit();
		}

	}
}
