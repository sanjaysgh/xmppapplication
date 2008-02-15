//
// ExtensionManager.cs
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
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using XmppApplication.Interfaces;

namespace XmppApplication
{
	public static class ExtensionManager
	{
		#region Public Methods
		public static Extension[] GetExtensions (string directory)
		{
			List<Extension> extensions = new List<Extension> ();
			
			if (!Directory.Exists (directory))
				return extensions.ToArray ();
				
			foreach (string f in Directory.GetFiles (directory, "*.dll", SearchOption.AllDirectories)) {
				try {
					Assembly a = Assembly.LoadFile (f);
					
					foreach (Type t in a.GetTypes ()) {
						if (t.IsSubclassOf (typeof (Extension)))
							extensions.Add ((Extension)a.CreateInstance (t.FullName));
					}
				} catch (Exception) {

					throw;
				}
			}
			
			return extensions.ToArray ();
		}
		#endregion
	}
}
