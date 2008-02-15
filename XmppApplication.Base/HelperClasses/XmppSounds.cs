//
// XmppSounds.cs
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
using System.Media;

namespace XmppApplication.Base
{
	public static class XmppSounds
	{
		private static bool sound_enabled = false;
		private static DateTime last_played = DateTime.MinValue;
		private static TimeSpan minimum_time_between_sounds = new TimeSpan (0, 0, 3);

		private static SoundPlayer logon = new SoundPlayer ();
		private static SoundPlayer logoff = new SoundPlayer ();
		private static SoundPlayer message_in = new SoundPlayer ();
		private static SoundPlayer message_out = new SoundPlayer ();
		
		#region Properties
		public static bool Enabled {
			get { return sound_enabled; }
			set { sound_enabled = value; }
		}
		#endregion

		#region Public Methods
		public static void PlaySound (DefaultSounds sound)
		{
			if (sound_enabled) {
				if (DateTime.Now.Subtract (last_played) > minimum_time_between_sounds) {
					switch (sound) {
						case DefaultSounds.Logon:
							logon.Play ();
							break;
						case DefaultSounds.Logoff:
							logoff.Play ();
							break;
						case DefaultSounds.MessageIn:
							message_in.Play ();
							break;
						case DefaultSounds.MessageOut:
							message_out.Play ();
							break;
					}
					
					last_played = DateTime.Now;
				}
			}
		}

		public static void PlaySound (string soundFile)
		{
			if (sound_enabled)
				if (DateTime.Now.Subtract (last_played) > minimum_time_between_sounds) {
					SoundPlayer sp = new SoundPlayer (soundFile);
					sp.Play ();
					last_played = DateTime.Now;
				}
		}
		#endregion
	}
}
