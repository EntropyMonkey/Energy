using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using MapGenTest;
using Gtk;

public partial class MainWindow: Gtk.Window
{	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
	}
	
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}

	protected void OnButton2Clicked (object sender, System.EventArgs e)
	{
		for (int z = 0; z<50; z++){
			int imgsize = 50;
			Random r = new Random();
		    PerlinNoise perlinNoise = new PerlinNoise(r.Next(1,99));
		    Bitmap bitmap = new Bitmap(imgsize,imgsize);
			double widthDivisor = 1 / (double)imgsize;
		    double heightDivisor = 1 / (double)imgsize;
			for(int y = 0; y<imgsize; y++)
			{
				for(int x = 0; x<imgsize; x++)
				{
					// Note that the result from the noise function is in the range -1 to 1, but I want it in the range of 0 to 1
		            // that's the reason of the strange code
					 double v =
		                // First octave
		                (perlinNoise.Noise(2 * x * widthDivisor, 2 * y * heightDivisor, -0.5) + 1) / 2 * 0.7 +
		                // Second octave
		                (perlinNoise.Noise(4 * x * widthDivisor, 4 * y * heightDivisor, 0) + 1) / 2 * 0.2 +
		                // Third octave
		                (perlinNoise.Noise(8 * x * widthDivisor, 8 * y * heightDivisor, +0.5) + 1) / 2 * 0.1;
		
		            v = Math.Min(1, Math.Max(0, v));
					
					double b = Math.Round((v*50));
					Console.Write(b+" ");
		            //byte b = (byte)(v * 255);
					if (b <= 18) { 
						bitmap.SetPixel(x, y, Color.Black); //Berg
					}else if (b>= 19 && b <= 21){
						bitmap.SetPixel(x, y, Color.Yellow); //Wüste
					}else if (b>=22 && b <= 23){
						bitmap.SetPixel(x, y, Color.Green); //Grassland
					}else if (b>= 25 && b<=29){
						bitmap.SetPixel(x, y, Color.Green); //
					}else if (b>=30 && b<=34){
						bitmap.SetPixel(x, y, Color.Blue);
					}else{
						bitmap.SetPixel(x, y, Color.Cyan);
					}
					
					
					
					
					//bitmap.SetPixel(x, y, Color.FromArgb(b*10, b*10, b*10));
					
				}
				Console.WriteLine("");
			}
			//bitmap.Dispose();
			bitmap.Save("/media/DATENKLOTZ/MapGenTest/maps/test"+z+".bmp", ImageFormat.Bmp);
			//MemoryStream bmpstream = new MemoryStream();
			//bitmap.Save(bmpstream, ImageFormat.MemoryBmp);
			//image1.Pixbuf = new Gdk.Pixbuf("/home/stefan/Dokumente/test.bmp");
		}
	}
}
