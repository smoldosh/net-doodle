/*
 * Created by SharpDevelop.
 * User: Jiří
 * Date: 6. 5. 2018
 * Time: 14:25
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using RectangleGetter;
using FloodFill;

namespace PaintProg
{
	/// <summary>
	/// Hlavní metoda programu
	/// </summary>
	public partial class MainForm : Form
	{
		/// <summary>
		/// Objekt obsahující pomocné výpočty pro zjištění obdelníků pro vykreslování.
		/// Jedna z instancí externí knihovny, kterou jsem vytvořil.
		/// </summary>
		RectGetter rectGetter = new RectGetter();
		/// <summary>
		/// Objekt obsahující metodu pro vyplnění oblasti danou barvou.
		/// Druhá ukázka externí knihovny.
		/// </summary>
		Fill fl = new Fill();
		
		/// <summary>
		/// Bitmapa reprezentující obrázek, na který se bude kreslit.
		/// </summary>
		public static Bitmap bmp;

		/// <summary>
		/// Kolekce sloužící pro uchování bodů, ze kterých se posléze vytvoří "křivka".
		/// </summary>
		List<Point> pointsToDraw = new List<Point>();
		
		/// <summary>
		/// Uchovává informaci zda-li uživatel provádí kreslící operaci či nikoliv.
		/// </summary>
		bool isEditing = false;
		
		/// <summary>
		/// Uchovává informaci zda-li uživatel stiskl pravé tlačítko či nikoliv;
		/// </summary>
		bool rightPressed = false;
		
		/// <summary>
		/// Bude-li obrazec vybarven či se nakreslí jen obrys.
		/// </summary>
		public static bool fillingShapes = false;
		
		/// <summary>
		/// Proměnná pro uchování Xové souřadnice kurzoru na pictureboxu.
		/// </summary>
		int mX = 0;
		
		/// <summary>
		/// Proměnná pro uchování Yové souřadnice kurzoru na pictureboxu.
		/// </summary>
		int mY = 0;
		
		/// <summary>
		/// Enumerát pro určení aktivní kreslící operace.
		/// </summary>
		public enum ActiveTool {Pen, Fill, Rectangle, Ellipse, Spray};
		
		/// <summary>
		/// Proměnná pro uložení vybrané kreslící operace.
		/// </summary>
		public static ActiveTool selectedTool = ActiveTool.Pen;
		
		/// <summary>
		/// Tloušťka pera.
		/// </summary>
		public static float penWidth = 1;
		
		/// <summary>
		/// Vybrané barvy(pro levé a pravé tlačítko myši).
		/// </summary>
		public static Color[] colors = {Color.Black, Color.White};
		
		/// <summary>
		/// Pomocný bod pro kreslení obdélníků a elips.
		/// Vykreslení pomocí kolekce pointsToDraw se mi nepovedlo implementovat
		/// kvůli neschopnosti měnit souřadnice bodu v kolekci(zatím nevím proč).
		/// </summary>
		public Point helpPoint = new Point(0,0);
		
		public MainForm()
		{
			InitializeComponent();
			
			new Intro().ShowDialog();
			
			this.Text = "Plátno";
			ToolBox toolBox = new ToolBox(this);
			toolBox.Show();
			bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
		}
		
		/// <summary>
		/// Provede změnu velikosti plátna, resp. bitmapy, bez deformace(viz změna velikosti v MS Paint
		/// pomocí táhnutí za pravý dolní roh.
		/// </summary>
		void ResizeBitmap()
		{
			Bitmap tempBmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
			
			for(int y = 0; y < tempBmp.Height; y++)
			{
				if(y > bmp.Height-1)
					break;
				
				for(int x = 0; x < tempBmp.Width; x++)
				{
					if(x > bmp.Width-1)
						break;
					
					tempBmp.SetPixel(x, y, bmp.GetPixel(x, y));
				}
			}
			
			bmp = tempBmp;
			pictureBox1.Refresh();
		}
		
		void PictureBox1MouseDown(object sender, MouseEventArgs e)
		{
			rightPressed = true;
			
			//Timer zde slouží pro vykonávání samotných kreslících operací. Tímto způsobem
			//lze "kreslit" i když se myš nehýbe, čehož je využito u nástoje "sprej".
			timer1.Enabled = true;
			
			if(e.Button == MouseButtons.Left)
				rightPressed = false;
			
			switch(selectedTool)
			{
				case ActiveTool.Pen:
				case ActiveTool.Spray:
				case ActiveTool.Rectangle:
				case ActiveTool.Ellipse:
					isEditing = true;
					pointsToDraw.Add(new Point(e.Location.X, e.Location.Y));
					pointsToDraw.Add(new Point(e.Location.X, e.Location.Y));
					break;
				case ActiveTool.Fill:
					
					Color onPointer = bmp.GetPixel(e.Location.X, e.Location.Y);
					Color toFill = colors[Convert.ToInt16(rightPressed)];
					
					fl.FillRegion(bmp, pictureBox1, new Point(e.Location.X, e.Location.Y), onPointer, toFill);
					
					break;
			}
			
			pointsToDraw.Clear();
			pointsToDraw.Add(new Point(e.Location.X, e.Location.Y));
		}
		
		void PictureBox1MouseUp(object sender, MouseEventArgs e)
		{
			pictureBox1.DrawToBitmap(bmp, pictureBox1.ClientRectangle);
			isEditing = false;
			timer1.Enabled = false;
			pointsToDraw.Clear();
			
		}
		
		void PictureBox1MouseMove(object sender, MouseEventArgs e)
		{
			mX = e.Location.X;
			mY = e.Location.Y;
		}
		
		void PictureBox1Paint(object sender, PaintEventArgs e)
		{
			e.Graphics.DrawImage(bmp, 0, 0);
			
			//Pomocná pro kreslení čar perem
			Color tempCol = colors[(Convert.ToInt16(rightPressed))];
			
			if(pointsToDraw.Count > 1)
			{
				e.Graphics.DrawLines(new Pen(tempCol, penWidth), pointsToDraw.ToArray());
			}
			
			/*
  			Jelikož mi metody FillRectangle a DrawREctangle neumožnily vykreslovat pomocí
			negativních hodnot, musel jsem se uchýlit k vykreslení "obdélníkového polygonu"
			 */
			if(pointsToDraw.Count == 1 && isEditing && selectedTool == ActiveTool.Rectangle)
			{
				var rect = rectGetter.GetRectangularPolygon(pointsToDraw[0], helpPoint);
				
				if(fillingShapes)
					e.Graphics.FillPolygon(new SolidBrush(colors[1]), rect);
				e.Graphics.DrawPolygon(new Pen(colors[0], penWidth), rect);
			}
			
			//Elipsa tneto problém neměla
			if(pointsToDraw.Count == 1 && isEditing && selectedTool == ActiveTool.Ellipse)
			{
				var rect = rectGetter.GetRectangle(pointsToDraw[0], helpPoint);
				if(fillingShapes)
					e.Graphics.FillEllipse(new SolidBrush(colors[1]), rect);
				e.Graphics.DrawEllipse(new Pen(colors[0], penWidth), rect);
			}
			
		}
		
		void PictureBox1Resize(object sender, EventArgs e)
		{
			ResizeBitmap();
		}
		
		void Timer1Tick(object sender, EventArgs e)
		{
			if(selectedTool == ActiveTool.Pen && isEditing)
			{
				pointsToDraw.Add(new Point(mX, mY));
				pictureBox1.Refresh();
			}
			
			if((selectedTool == ActiveTool.Rectangle || selectedTool == ActiveTool.Ellipse) && isEditing)
			{
				
				helpPoint.X = mX;
				helpPoint.Y = mY;
				
				pictureBox1.Refresh();
			}
			
			if(selectedTool == ActiveTool.Spray && isEditing)
			{
				for(int i = 0; i < penWidth*5; i++)
				{
					Random rnd = new Random();
					
					int rndNum = rnd.Next(0, (int)penWidth);
					
					int spreadX = Convert.ToInt16(penWidth-(rndNum*2));
					rndNum = rnd.Next(0, (int)penWidth);
					int spreadY = Convert.ToInt16(penWidth-(rndNum*2));
					
					int pX = mX+spreadX;
					int pY = mY+spreadY;
					
					if(pX >= 0 && pX < bmp.Width-1 && pY >= 0 && pY < bmp.Height-1)
						bmp.SetPixel(mX+spreadX, mY+spreadY, colors[Convert.ToInt16(rightPressed)]);
					
				}
				
				pictureBox1.Refresh();
			}
		}
	}
}
