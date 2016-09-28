/*
 * Created by SharpDevelop.
 * User: zfarkas
 * Date: 23/02/2016
 * Time: 17:57
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace FFTrans
{
	/// <summary>
	/// Description of Class2.
	/// </summary>
	public class PresetLoad
	{
		
		
		
		public string vcodec(string vcodecSent)
		{
			
			
			if (vcodecSent != "")
				
			{
			
			
				string returnVcodec = String.Format("-vcodec {0}", vcodecSent);
				
				return returnVcodec;
			
			
			}
			
			
			return vcodecSent;
			
			
		}
		
		
		public string acodec(string acodecSent)
		{
			
			
			if (acodecSent != "")
				
			{
			
			
				string returnacodec = String.Format(" -acodec {0}", acodecSent);
				
				return returnacodec;
			
			
			}
			
			
			return acodecSent;
			
			
		}
		
		
		
		public string acodecBitrate(string acodecBitrateSent)
		{
			
			
			if (acodecBitrateSent != "")
				
			{
			
			
				string returnAcodecBitrate = String.Format(" -b:a {0}", acodecBitrateSent);
				
				return returnAcodecBitrate;
			
			
			}
			
			
			return acodecBitrateSent;
			
			
		}
		
		public string vcodecBitrate(string vcodecBitrateSent)
		{
			
			
			if (vcodecBitrateSent != "")
				
			{
			
			
				string returnVcodecBitrate = String.Format(" -b:v {0}", vcodecBitrateSent);
				
				return returnVcodecBitrate;
			
			
			}
			
			
			return vcodecBitrateSent;
			
			
		}
		
		
		public string pix_fmt(string pixFmtSent)
		{
			
			
			if (pixFmtSent != "")
				
			{
			
			
				string returnPixFmtSent = String.Format(" -pix_fmt {0}", pixFmtSent);
				
				return returnPixFmtSent;
			
			
			}
			
			
			return pixFmtSent;
			
			
		}
		
		
		public string presetSpeed(string presetSpeedSent)
		{
			
			
			if (presetSpeedSent != "")
				
			{
			
			
				string returnpresetspeedSpent = String.Format(" -preset {0}", presetSpeedSent);
				
				return returnpresetspeedSpent;
			
			
			}
			
			
			return presetSpeedSent;
			
		
		}
		
		public string scale(string scaleSent)
		{
			
			
			if (scaleSent != "")
				
			{
			
			
				string returnscaleSent = String.Format(" -vf scale={0}", scaleSent);
				
				return returnscaleSent;
			
			
			}
			
			
			return scaleSent;
			
			
		}
		
		
		public string mapAudio(int mapAudioSent)
		{
			
			
			if (mapAudioSent != 0)
				
			{
			
			
				string returnmapAudioSent = String.Format(" -map 0:a:{0}", mapAudioSent-1);
				
				return returnmapAudioSent;
			
			
			}
			
			
			string notExistingAudioTrackNumber = "";
			
			return notExistingAudioTrackNumber;
			
			
		}
		
		
		
		
		
	}
}
