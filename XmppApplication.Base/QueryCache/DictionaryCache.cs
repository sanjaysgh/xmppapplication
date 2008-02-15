//
// DictionaryCache.cs
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
using System.Collections;
using System.Collections.Generic;

namespace XmppApplication.Base
{
	public class DictionaryCache<Tkey, Tvalue> : Dictionary<Tkey, DictionaryEntry>
	{
		private int cache_lifetime = 60 * 24;

		#region Public Methods
		public void Add (Tkey t, Tvalue v)
		{
			base.Add (t, new DictionaryEntry (DateTime.Now, v));
		}

		public new bool ContainsKey (Tkey key)
		{
			if (base.ContainsKey (key)) {
				DictionaryEntry d = base[key];
				if (!IsExpired (d))
					return true;
			}

			return false;
		}

		public bool ContainsValue (Tvalue value)
		{
			foreach (DictionaryEntry d in base.Values)
				if (d.Value.Equals (value))
					if (!IsExpired (d))
						return true;

			return false;
		}
		#endregion

		#region Public Properties
		public new Tvalue this[Tkey t]
		{
			get
			{
				if (!ContainsKey (t))
					return default (Tvalue);

				DictionaryEntry d = base[t];

				return (Tvalue)d.Value;
			}
			set
			{
				base[t] = new DictionaryEntry (DateTime.Now, value);
			}
		}
		#endregion

		#region Private Methods
		private bool IsExpired (DictionaryEntry d)
		{
			if (DateTime.Now.Subtract ((DateTime)d.Key).TotalMinutes > cache_lifetime) {
				base.Remove ((Tkey)d.Key);
				return true;
			} else {
				return false;
			}
		}
		#endregion
	}
}