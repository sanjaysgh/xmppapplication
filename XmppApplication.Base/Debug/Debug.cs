//
// Debug.cs
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
using XmppApplication.Interfaces;

namespace XmppApplication.Base
{
	public class Debug
	{
		private IDebugWindow debug_form;
		
		internal Debug ()
		{
			XmppGlobal.InternalClient.OnReadText += new bedrock.TextHandler (InternalClient_OnReadText);
			XmppGlobal.InternalClient.OnWriteText += new bedrock.TextHandler (InternalClient_OnWriteText);
		}

		#region Public Properties
		public IDebugWindow DebugWindow {
			get { return debug_form; }
			set { debug_form = value; }
		}
		#endregion
		
		#region Public Methods
		public void ShowDebugWindow ()
		{
			if (debug_form != null)
				debug_form.Show ();
			else
				throw new InvalidOperationException ("No debug window has been registered with XmppGlobal.Debug.DebugWindow");
		}
		#endregion

		#region Private Methods
		void InternalClient_OnReadText (object sender, string txt)
		{
			Console.WriteLine ("IN:  {0}", txt);
			if (debug_form != null)
				debug_form.LogString (true, txt);
		}

		void InternalClient_OnWriteText (object sender, string txt)
		{
			Console.WriteLine ("OUT: {0}", txt);
			if (txt.Trim ().Length > 0)
				if (debug_form != null)
					debug_form.LogString (false, txt);
		}
		#endregion
	}
}
