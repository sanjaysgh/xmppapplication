//
// Connection.cs
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
using System.ComponentModel;
using System.Windows.Forms;
using System.Xml;

namespace XmppApplication.Base
{
	public class Connection : Component
	{
		private bool connected;
		private bool explicit_connect = true;
		
		#region Constructor
		internal Connection ()
		{
			XmppGlobal.InternalClient.OnAuthenticate += new bedrock.ObjectHandler (InternalClient_OnAuthenticate);
			XmppGlobal.InternalClient.OnAuthError += new jabber.protocol.ProtocolHandler (InternalClient_OnAuthError);
			XmppGlobal.InternalClient.OnConnect += new jabber.connection.StanzaStreamHandler (InternalClient_OnConnect);
			XmppGlobal.InternalClient.OnDisconnect += new bedrock.ObjectHandler (InternalClient_OnDisconnect);
			XmppGlobal.InternalClient.OnError += new bedrock.ExceptionHandler (InternalClient_OnError);
			XmppGlobal.InternalClient.OnInvalidCertificate += new System.Net.Security.RemoteCertificateValidationCallback (InternalClient_OnInvalidCertificate);
			XmppGlobal.InternalClient.OnStreamError += new jabber.protocol.ProtocolHandler (InternalClient_OnStreamError);
			XmppGlobal.InternalClient.OnStreamInit += new jabber.connection.StreamHandler (InternalClient_OnStreamInit);
		}
		#endregion

		#region Public Properties
		public bool IsConnected {
			get { return connected; }
		}
		
		public EncryptionMode Encryption
		{
			get
			{
				if (!XmppGlobal.InternalClient.SSL && !XmppGlobal.InternalClient.AutoStartTLS)
					return EncryptionMode.NoEncryption;
				else if (!XmppGlobal.InternalClient.SSL && XmppGlobal.InternalClient.AutoStartTLS)
					return EncryptionMode.PreferEncryption;
				else if (XmppGlobal.InternalClient.SSL && XmppGlobal.InternalClient.AutoStartTLS)
					return EncryptionMode.ForceEncryption;

				return EncryptionMode.NoEncryption;
			}
			set
			{
				switch (value) {
					case EncryptionMode.NoEncryption:
						XmppGlobal.InternalClient.SSL = false;
						XmppGlobal.InternalClient.AutoStartTLS = false;
						break;
					case EncryptionMode.PreferEncryption:
						XmppGlobal.InternalClient.SSL = false;
						XmppGlobal.InternalClient.AutoStartTLS = true;
						break;
					case EncryptionMode.ForceEncryption:
						XmppGlobal.InternalClient.SSL = true;
						XmppGlobal.InternalClient.AutoStartTLS = true;
						break;
				}
			}
		}

		public bool IsConnectionEncrypted
		{
			get { return XmppGlobal.InternalClient.SSLon; }
		}

		public XmlDocument JabberDocument
		{
			get { return XmppGlobal.InternalClient.Document; }
		}

		public jabber.JID Jid {
			get { return XmppGlobal.InternalClient.JID; }
		}
		
		public string NetworkHost
		{
			get { return XmppGlobal.InternalClient.NetworkHost; }
			set { XmppGlobal.InternalClient.NetworkHost = value; }
		}

		public string Password
		{
			get { return XmppGlobal.InternalClient.Password; }
			set { XmppGlobal.InternalClient.Password = value; }
		}

		public int Port
		{
			get { return XmppGlobal.InternalClient.Port; }
			set { XmppGlobal.InternalClient.Port = value; }
		}

		public int Priority
		{
			get { return XmppGlobal.InternalClient.Priority; }
			set { XmppGlobal.InternalClient.Priority = value; }
		}

		public string Resource
		{
			get { return XmppGlobal.InternalClient.Resource; }
			set { XmppGlobal.InternalClient.Resource = value; }
		}

		public string Server
		{
			get { return XmppGlobal.InternalClient.Server; }
			set { XmppGlobal.InternalClient.Server = value; }
		}

		public string Username
		{
			get { return XmppGlobal.InternalClient.User; }
			set { XmppGlobal.InternalClient.User = value; }
		}
		#endregion

		#region Public Methods
		public void Connect ()
		{
			try {
				XmppGlobal.InternalClient.AutoLogin = true;
				XmppGlobal.InternalClient.AutoPresence = false;
				XmppGlobal.InternalClient.AutoRoster = true;
				XmppGlobal.InternalClient.AutoReconnect = 5;
				XmppGlobal.InternalClient.PlaintextAuth = false;
				XmppGlobal.InternalClient.AutoStartCompression = true;
				XmppGlobal.InternalClient.AutoStartTLS = true;
				XmppGlobal.InternalClient.Connect ();
			} catch (Exception) {
				throw;
			}
		}

		public void Connect (string username, string server, string password, string resource)
		{
			Username = username;
			Server = server;
			Password = password;
			Resource = resource;
			Connect ();
		}

		public void Disconnect ()
		{
			XmppGlobal.InternalClient.Close (true);
		}

		public void SendPacket (XmlElement packet)
		{
			XmppGlobal.InternalClient.Write (packet);
		}
		#endregion

		#region Protected Methods
		protected void OnAuthenticate (EventArgs e)
		{
			EventHandler eh = (EventHandler)(Events[AuthenticatedEvent]);
			if (eh != null)
				eh (this, e);
		}

		protected void OnConnect (EventArgs e)
		{
			EventHandler eh = (EventHandler)(Events[ConnectedEvent]);
			if (eh != null)
				eh (this, e);
		}

		protected void OnDisconnect (EventArgs e)
		{
			EventHandler eh = (EventHandler)(Events[DisconnectedEvent]);
			if (eh != null)
				eh (this, e);
		}
		#endregion

		#region Public Events
		static object AuthenticatedEvent = new object ();
		static object ConnectedEvent = new object ();
		static object DisconnectedEvent = new object ();

		public event EventHandler Authenticated
		{
			add { Events.AddHandler (AuthenticatedEvent, value); }
			remove { Events.RemoveHandler (AuthenticatedEvent, value); }
		}

		public event EventHandler Connected
		{
			add { Events.AddHandler (ConnectedEvent, value); }
			remove { Events.RemoveHandler (ConnectedEvent, value); }
		}

		public event EventHandler Disconnected
		{
			add { Events.AddHandler (DisconnectedEvent, value); }
			remove { Events.RemoveHandler (DisconnectedEvent, value); }
		}
		#endregion

		#region Event Handlers
		private void InternalClient_OnAuthenticate (object sender)
		{
			OnAuthenticate (EventArgs.Empty);
		}

		private void InternalClient_OnAuthError (object sender, XmlElement xe)
		{
			throw new Exception (xe.OuterXml);
		}

		private void InternalClient_OnConnect (object sender, jabber.connection.StanzaStream stream)
		{
			connected = true;
			OnConnect (EventArgs.Empty);
		}

		private void InternalClient_OnDisconnect (object sender)
		{
			connected = false;
			OnDisconnect (EventArgs.Empty);
			XmppGlobal.Roster.Clear ();
		}

		private void InternalClient_OnError (object sender, Exception ex)
		{
			if (ex is bedrock.net.AsyncSocketConnectionException && ex.Message.Contains ("Bad host:")) {
				if (explicit_connect)
					MessageBox.Show (string.Format ("Cannot connect to server: {0}", ex.Message.Substring (10)));
			} else if (ex is jabber.connection.sasl.SASLException && ex.Message.Contains ("not-authorized")) {
				Disconnect ();
				if (explicit_connect)
					MessageBox.Show ("Cannot authenticate to server.  Please check your username and password.");
			} else if (ex is System.Net.Sockets.SocketException && ex.Message.Contains ("No connection could be made because the target machine actively refused it")) {
				if (explicit_connect)
					MessageBox.Show (string.Format ("Cannot find an instant messaging server running on server: {0}", Server));
			} else if (ex is System.Net.Sockets.SocketException && ex.Message.Contains ("connected host has failed to respond")) {
				if (explicit_connect)
					MessageBox.Show (string.Format ("Could not connect to server: {0}", Server));
			} else if (ex is System.IO.IOException && ex.Message.Contains ("forcibly closed by the remote host")) {
				// We were disconnected, nothing we can do about it, don't show error
			} else
				MessageBox.Show ("Connection Error:\n" + ex.ToString ());
		}

		private bool InternalClient_OnInvalidCertificate (object sender, System.Security.Cryptography.X509Certificates.X509Certificate certificate, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
		{
			return true;
		}

		private void InternalClient_OnStreamError (object sender, System.Xml.XmlElement rp)
		{
			throw new Exception (rp.OuterXml);
		}

		private void InternalClient_OnStreamInit (object sender, jabber.protocol.ElementStream stream)
		{
			stream.AddFactory (new CommandFactory ());
		}
		#endregion
	}
}