/*
 * Created by SharpDevelop.
 * User: Jiří
 * Date: 7. 5. 2018
 * Time: 16:34
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace FloodFill
{
	/// <summary>
	/// Třída fungující jako "kyblík" v MS paint.
	/// </summary>
	public class Fill
	{
		/// <summary>
		/// Vyplní oblast se stejnou barvou jinou barvou.
		/// Algoritmus převzat z https://simpledevcode.wordpress.com/2015/12/29/flood-fill-algorithm-using-c-net/
		/// </summary>
		/// <param name="bmp">Bitmapa ve které dojde k vyplnění.</param>
		/// <param name="pb">Picturebox, který se bude po vyplnění obnovovat.</param>
		/// <param name="pt">Počáteční bod vyplňování.</param>
		/// <param name="targetColor">Původní barva.</param>
		/// <param name="replacementColor">"Nová barva.</param>
		public void FillRegion(Bitmap bmp, PictureBox pb, Point pt, Color targetColor, Color replacementColor)
		{
			Stack<Point> pixels = new Stack<Point>();
			pixels.Push(pt);

			while (pixels.Count > 0)
			{
				Point activePoint = pixels.Pop();
				if (activePoint.X < bmp.Width && activePoint.X >= 0 && activePoint.Y < bmp.Height && activePoint.Y >= 0)
				{
					if (bmp.GetPixel(activePoint.X, activePoint.Y) == targetColor)
					{
						bmp.SetPixel(activePoint.X, activePoint.Y, replacementColor);
						pixels.Push(new Point(activePoint.X - 1, activePoint.Y));
						pixels.Push(new Point(activePoint.X + 1, activePoint.Y));
						pixels.Push(new Point(activePoint.X, activePoint.Y - 1));
						pixels.Push(new Point(activePoint.X, activePoint.Y + 1));
					}
				}
			}
			
			pb.Refresh();
			return;
		}
	}
}