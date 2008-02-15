//
// QueryCache.cs
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

using jabber.protocol.client;

namespace XmppApplication.Base
{
	public class QueryCache
	{
		private DictionaryCache<string, IQ> vcard_cache = new DictionaryCache<string, IQ> ();
		private DictionaryCache<string, IQ> disco_info_cache = new DictionaryCache<string, IQ> ();
		private DictionaryCache<string, IQ> disco_items_cache = new DictionaryCache<string, IQ> ();

		internal QueryCache ()
		{
		}
		
		#region Public Properties
		public DictionaryCache<string, IQ> VCard { get { return vcard_cache; } }
		public DictionaryCache<string, IQ> DiscoInfo { get { return disco_info_cache; } }
		public DictionaryCache<string, IQ> DiscoItems { get { return disco_items_cache; } }
		#endregion
	}
}