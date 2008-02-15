//
// Commands.cs
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

using System.Collections.Generic;
using System.Xml;

namespace XmppApplication.Base
{
	public class Command : jabber.protocol.Element
	{
		public const string COMMANDS = "http://jabber.org/protocol/commands";
		
		public Command (XmlDocument doc)
			: base ("command", string.Empty, doc)
		{
		}

		public Command (string prefix, XmlQualifiedName qname, XmlDocument doc)
			: base (prefix, qname, doc)
		{
		}

		#region Public Properties
		public CommandAction Action {
			get { return (CommandAction)GetEnumAttr ("action", typeof (CommandAction)); }
			set {
				if (value == CommandAction.NONE)
					RemoveAttribute ("action");
				else
					SetAttribute ("action", value.ToString ());
			}
		}
		
		public string Node {
			get { return GetAttribute ("node"); }
			set { SetAttribute ("node", value); }
		}

		public string SessionID {
			get { return GetAttribute ("sessionid"); }
			set { SetAttribute ("sessionid", value); }
		}

		public CommandStatus Status {
			get { return (CommandStatus)GetEnumAttr ("status", typeof (CommandStatus)); }
			set {
				if (value == CommandStatus.NONE)
					RemoveAttribute ("status");
				else
					SetAttribute ("status", value.ToString ());
			}
		}
		#endregion

		#region Public Methods
		public CommandActions AddActions (bool execute, bool next, bool previous, bool cancel, bool complete)
		{
			CommandActions ca = new CommandActions (OwnerDocument);
			AddChild (ca);
			
			ca.IsExecuteAllowed = execute;
			ca.IsNextAllowed = next;
			ca.IsPreviousAllowed = previous;
			ca.IsCancelAllowed = cancel;
			ca.IsCompleteAllowed = complete;
			
			return ca;
		}
		
		public CommandNote AddNote (CommandNoteType type, string text)
		{
			CommandNote cn = new CommandNote (OwnerDocument);
			AddChild (cn);
			
			cn.Type = type;
			cn.InnerText = text;
			
			return cn;
		}
		
		public CommandActions GetActions ()
		{
			return (CommandActions)this["actions"];
		}
		
		public CommandNote[] GetNotes ()
		{
			XmlNodeList nl = GetElementsByTagName ("note");
			
			List<CommandNote> items = new List<CommandNote> ();
			
			foreach (CommandNote n in nl)
			        items.Add (n);
			
			return items.ToArray ();
		}
		#endregion
	}
	
	public class CommandActions : jabber.protocol.Element
	{
		public CommandActions (XmlDocument doc)
			: base ("actions", string.Empty, doc)
		{
		}

		public CommandActions (string prefix, XmlQualifiedName qname, XmlDocument doc)
			: base (prefix, qname, doc)
		{
		}

		#region Public Properties
		public CommandAction Execute {
			get { return (CommandAction)GetEnumAttr ("execute", typeof (CommandAction)); }
			set {
				if (value == CommandAction.NONE)
					RemoveAttribute ("execute");
				else
					SetAttribute ("execute", value.ToString ());
			}
		}

		public bool IsCancelAllowed {
			get { return this["cancel"] != null; }
			set {
				if (value)
					SetElem ("cancel", null);
				else
					RemoveElem ("cancel");
			}
		}

		public bool IsCompleteAllowed {
			get { return this["complete"] != null; }
			set {
				if (value)
					SetElem ("complete", null);
				else
					RemoveElem ("complete");
			}
		}
		
		public bool IsExecuteAllowed {
			get { return this["execute"] != null; }
			set {
				if (value)
					SetElem ("execute", null);
				else
					RemoveElem ("execute");
			}
		}

		public bool IsNextAllowed {
			get { return this["next"] != null; }
			set {
				if (value)
					SetElem ("next", null);
				else
					RemoveElem ("next");
			}
		}

		public bool IsPreviousAllowed {
			get { return this["prev"] != null; }
			set
			{
				if (value)
					SetElem ("prev", null);
				else
					RemoveElem ("prev");
			}
		}
		#endregion
	}
	
	public class CommandFactory : jabber.protocol.IPacketTypes
	{
		private static List<jabber.protocol.QnameType> types = new List<jabber.protocol.QnameType> ();
		
		static CommandFactory ()
		{
			types.Add (new jabber.protocol.QnameType ("command", Command.COMMANDS, typeof (Command)));
			types.Add (new jabber.protocol.QnameType ("actions", Command.COMMANDS, typeof (CommandActions)));
			types.Add (new jabber.protocol.QnameType ("note", Command.COMMANDS, typeof (CommandNote)));
			
		}
		
		#region IPacketTypes Members
		public jabber.protocol.QnameType[] Types
		{
			get { return types.ToArray (); }
		}
		#endregion
	}
	
	public class CommandsIQ : jabber.protocol.client.IQ
	{
		public CommandsIQ (XmlDocument doc) : base (doc)
		{
			Query = new Command (doc);
		}
	}
	
	public class CommandNote : jabber.protocol.Element
	{
		public CommandNote (XmlDocument doc)
			: base ("note", string.Empty, doc)
		{
		}

		public CommandNote (string prefix, XmlQualifiedName qname, XmlDocument doc)
			: base (prefix, qname, doc)
		{
		}
	
		public CommandNoteType Type {
			get { return (CommandNoteType)GetEnumAttr ("type", typeof (CommandNoteType)); }
			set {
				if (value == CommandNoteType.NONE)
					RemoveAttribute ("type");
				else
					SetAttribute ("type", value.ToString ());
			}
		}
	}
	
	public enum CommandAction
	{
		NONE = -1,
		execute,
		cancel,
		prev,
		next,
		complete
	}

	public enum CommandNoteType
	{
		NONE = -1,
		info,
		error,
		warn
	}

	public enum CommandStatus
	{
		NONE = -1,
		executing,
		completed,
		canceled
	}
}
