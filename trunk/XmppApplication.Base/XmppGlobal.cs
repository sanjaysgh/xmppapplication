//
// XmppGlobal.cs
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

using System.ComponentModel;
using jabber.client;
using jabber.connection;

namespace XmppApplication.Base
{
	public static class XmppGlobal
	{
		private static JabberClient jabber_client;
		private static RosterManager roster_manager;
		private static PresenceManager presence_manager;
		private static IQTracker iq_tracker;

		private static Connection connection;
		private static Debug debug;
		private static Disco disco;
		private static Messaging messaging;
		private static Presence presence;
		private static Queries queries;
		private static QueryCache query_cache;
		private static Roster roster;

		#region Public Constructor
		static XmppGlobal ()
		{
			jabber_client = new JabberClient ();

			roster_manager = new RosterManager ();
			roster_manager.Stream = jabber_client;

			presence_manager = new PresenceManager ();
			presence_manager.Stream = jabber_client;

			iq_tracker = new IQTracker (jabber_client);

			connection = new Connection ();
			debug = new Debug ();
			disco = new Disco ();
			presence = new Presence ();
			roster = new Roster ();
			queries = new Queries ();
			query_cache = new QueryCache ();
			messaging = new Messaging ();
		}
		#endregion

		#region Public Properties
		public static Connection Connection { get { return connection; } }
		public static Debug Debug { get { return debug; } }
		public static Disco Disco { get { return disco; } }
		public static Messaging Messaging { get { return messaging; } }
		public static Presence Presence { get { return presence; } }
		public static Queries Queries { get { return queries; } }
		public static Roster Roster { get { return roster; } }
		#endregion

		#region Internal Properties
		internal static JabberClient InternalClient { get { return jabber_client; } }
		internal static RosterManager InternalRoster { get { return roster_manager; } }
		internal static PresenceManager InternalPresence { get { return presence_manager; } }
		internal static QueryCache InternalQueryCache { get { return query_cache; } }
		internal static IQTracker InternalTracker { get { return iq_tracker; } }
		#endregion

		#region Public Methods
		public static void SetGuiForm (ISynchronizeInvoke control)
		{
			jabber_client.InvokeControl = control;
		}
		#endregion
	}
}