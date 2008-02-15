//
// EventingList.cs
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

//There is probably a better way to do this, but I don't know one off hand.  
//Basically, I need to raise an event any time this collection is modified
//so the GUI can save the changes to the user's profile.
//Since this is a .DLL library, it shouldn't have application settings.

using System;
using System.Collections.Generic;

namespace XmppApplication.Base
{
	public class EventingList<T> : List<T>
	{
		#region Public Methods
		public new void Add (T item)
		{
			base.Add (item);
			
			OnListChanged (EventArgs.Empty);
		}
		
		public new void AddRange (IEnumerable<T> collection)
		{
			base.AddRange (collection);
			
			OnListChanged (EventArgs.Empty);
		}
		
		public new bool Remove (T item)
		{
			bool retval = base.Remove (item);

			OnListChanged (EventArgs.Empty);
			return retval;
		}
		
		public new void RemoveAt (int index)
		{
			base.RemoveAt (index);

			OnListChanged (EventArgs.Empty);
		}
		
		public new int RemoveAll (Predicate<T> match)
		{
			int retval = base.RemoveAll (match);

			OnListChanged (EventArgs.Empty);
			return retval;
		}
		
		public new void RemoveRange (int index, int count)
		{
			base.RemoveRange (index, count);

			OnListChanged (EventArgs.Empty);
		}
		
		public new void Insert (int index, T item)
		{
			base.Insert (index, item);

			OnListChanged (EventArgs.Empty);
		}
		
		public new void InsertRange (int index, IEnumerable<T> collection)
		{
			base.InsertRange (index, collection);

			OnListChanged (EventArgs.Empty);
		}
		#endregion


		#region Protected Methods
		protected void OnListChanged (EventArgs e)
		{
			if (ListChanged != null)
				ListChanged (this, e);
		}
		#endregion

		#region Events
		public event EventHandler ListChanged;
		#endregion
	}
}
