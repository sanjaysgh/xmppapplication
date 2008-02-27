//
// ImageManipulation.cs
//
// Author:
//   Jonathan Pobst  <monkey@jpobst.com>
//
// Copyright (C) 2008 Jonathan Pobst
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//

using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Security.Cryptography;

namespace XmppApplication.Base
{
	public static class ImageManipulation
	{
		private static ColorMatrix grayscale_matrix = new ColorMatrix (new float[][] {
			new float[] {0.3f, 0.3f, 0.3f, 0f, 0f},
			new float[] {0.59f, 0.59f, 0.59f, 0f, 0f},
			new float[] {0.11f, 0.11f, 0.11f, 0f, 0f},
			new float[] {0f, 0f, 0f, 1f, 0f},
			new float[] {0f, 0f, 0f, 0f, 1f}});

		#region Public Methods
		public static Image Base64ToImage (string base64String)
		{
			Byte[] image_bytes = Convert.FromBase64String (base64String);
			MemoryStream ms = new MemoryStream (image_bytes);
			
			return new Bitmap (ms);
		}

		public static Image ConvertImageToGrayscale (Image image)
		{
			Bitmap return_image = new Bitmap (image.Width, image.Height);
			
			using (Graphics g = Graphics.FromImage (return_image))
				using (ImageAttributes ia = new ImageAttributes ()) {
					ia.SetColorMatrix (grayscale_matrix);
					
					g.DrawImage (image, new Rectangle (Point.Empty, return_image.Size), 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, ia);
				}
				
			return return_image;
		}
		
		public static Image FadeImage (Image image, float opacity)
		{
			ColorMatrix opacity_matrix = new ColorMatrix (new float[][] {
				new float[] {1f, 0f, 0f, 0f, 0f},
				new float[] {0f, 1f, 0f, 0f, 0f},
				new float[] {0f, 0f, 1f, 0f, 0f},
				new float[] {0f, 0f, 0f, opacity, 0f},
				new float[] {0f, 0f, 0f, 0f, 1f}});
				
			Bitmap return_image = new Bitmap (image.Width, image.Height);
			
			using (Graphics g = Graphics.FromImage (return_image))
				using (ImageAttributes ia = new ImageAttributes ()) {
					ia.SetColorMatrix (opacity_matrix);

					g.DrawImage (image, new Rectangle (Point.Empty, return_image.Size), 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, ia);
				}
				
			return return_image;
		}

		public static string HashImage (Image image)
		{
			MemoryStream ms = new MemoryStream ();
			image.Save (ms, ImageFormat.Png);

			SHA1 sha = SHA1Managed.Create ();
			byte[] b = sha.ComputeHash (ms.GetBuffer ());
			
			return Convert.ToString (b);
		}

		public static string ImageToBase64 (Image image)
		{
			MemoryStream ms = new MemoryStream ();
			image.Save (ms, ImageFormat.Png);
			
			return Convert.ToBase64String (ms.GetBuffer ());
		}

		public static Image OverlayImage (Image baseImage, Image overlay)
		{
			Bitmap i = new Bitmap (baseImage.Width, baseImage.Height);
			
			using (Graphics g = Graphics.FromImage (i)) {
				g.DrawImage (baseImage, Point.Empty);
				GraphicsUnit gu = GraphicsUnit.Pixel;
				
				g.DrawImage (overlay, new RectangleF (i.Width - overlay.Width, i.Height - overlay.Height, overlay.Width, overlay.Height), overlay.GetBounds (ref gu), GraphicsUnit.Pixel);
			}
			
			return i;
		}
		#endregion
	}
}
