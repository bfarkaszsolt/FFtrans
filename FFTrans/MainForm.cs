/*
 * Created by SharpDevelop.
 * User: zfarkas
 * Date: 09/02/2016
 * Time: 14:17
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

using System.Drawing;

using System.Diagnostics;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Xml.Linq;


namespace FFTrans
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	/// 
	
	
	
	public partial class MainForm : Form
	{
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			SetdataGridView1();
		
			OutFileBox.ForeColor = Color.Gray;
			
			OutFileBox.Text = "This folder must be set";
			//PopulatePresetBox();
			
			PopulatePresetList();
			
			
	
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		static public TimeSpan Duration;
		
		static public string ffmpegPath = String.Format("\"{0}\\ffmpeg.exe\"", Directory.GetCurrentDirectory());
		
		static public string presetsPath = String.Format("\"{0}\\FFTransPresets.xml\"", Directory.GetCurrentDirectory());
		
		static public Dictionary<string, string> Extensions = new Dictionary<string, string>{};
		
		
		public string PresetBoxDefine(string selectedPreset)
			
		{
			
			XDocument doc = XDocument.Load("FFTransPresets.xml");
			
			
		//	string vcodec = doc.Root.Element(selectedPreset).Name.ToString(); //.Attribute("vcodec").Value;

			
			
			  				foreach	(XElement el in doc.Root.Elements())
  				  
  					  
  					  	{
  					  	
  					  	
  					  	 string selectedPresetBoxItem = String.Format("{0}", el.Attribute("name").Value);
  					  	 
  					  	 if(selectedPresetBoxItem == selectedPreset)
  					  	 	
  					  	 {
  					  	 
  					  	 	
  					  	 	PresetLoad thisPreset = new PresetLoad();
  					  	 	
  					  	 	
  					  	 	string vcodec = thisPreset.vcodec(el.Attribute("vcodec").Value);
  					  	 		
  					  	 		string acodec = thisPreset.acodec(el.Attribute("acodec").Value);
  					  	 		
  					  	 		string acodec_bitrate = thisPreset.acodecBitrate(el.Attribute("acodec_bitrate").Value);
  					  	 		
  					  	 		string vcodec_bitrate = thisPreset.vcodecBitrate(el.Attribute("vcodec_bitrate").Value);
  					  	 		
  					  	 		string pix_fmt = thisPreset.pix_fmt(el.Attribute("pix_fmt").Value);
  					  	 		
  					  	 		string preset_speed = thisPreset.presetSpeed(el.Attribute("preset_speed").Value);
  					  	 		
  					  	 		string scale = thisPreset.scale(el.Attribute("scale").Value);
  					  	 		
  					  	 		
  					  	 		
  					  	 		
  					  	 		int mapAudioTrackNumber = int.Parse(dataGridView1.Rows[0].Cells["trackNumber"].Value.ToString());
  					  	 		
  					  	 		string mapAudio = thisPreset.mapAudio(mapAudioTrackNumber);
  					  	 		
  					  	 		
  					  	 		/*
  					  	 		foreach (XElement element in doc.Root.Elements())
  					  	 			
  					  	 			
  					  	 		{
  					  	 		
  					  	 			string element.Name = element.Value.ToString();
  					  	 		
  					  	 		
  					  	 		}
  					  	 		
  					  	 	
  					  	 	*/
  					  	 	
  					  	 	string returnPresetAttributes = String.Format("{0}{1}{2}{3}{4}{5}{6}{7}", vcodec, pix_fmt, preset_speed, vcodec_bitrate, scale, acodec, mapAudio, acodec_bitrate);
  					  	 	
  					  	 	
  					  	 	return returnPresetAttributes;
  					  	 
  					  	 
  					  	 
  					  	 }
  					  	
  					  	
  		
  				  		}
  					  
  					  
  					  
  					  string returnstr = "swss";
  		
  					  return returnstr;
			
			
			
			
			
			
			
			
			
			
			
			/*
		
			string vcodec = "-vcodec copy";
			
			string mpeg2video = "-vcodec mpeg2video";
			
		//	string selectedPreset = PresetBox.SelectedItem.ToString();
		
			if (selectedPreset == "Copy video")
				
			{
			
							
				return vcodec;
			
			}
		
			
			if (selectedPreset == "Convert mpeg")
				
			{
			
							
				return mpeg2video;
			
			}
			
			return "";
		*/
		}
		
		
		
	
    
                
	
		
		void TextBox1TextChanged(object sender, EventArgs e)
		{
	
		}
		private void Button1Click(object sender, EventArgs e)
		{
			
	
			startConvertProcess();
	
			

			
	
		}
		
		
		void startConvertProcess()
			
		{
		
		
			if (!ffmpegWorker.IsBusy)
			
			{
				
				
			if (dataGridView1.Rows.Count > 0)
		
			{
			
				
			if (dataGridView1.Rows[0].Cells["inFile"].Value !=null && dataGridView1.Rows[0].Cells["outFile"].Value !=null && dataGridView1.Rows[0].Cells["Preset"].Value !=null)
				
			{
			
				Tuple<string, string, string> passArgs = new Tuple<string, string, string>(dataGridView1.Rows[0].Cells["inFile"].Value.ToString(), dataGridView1.Rows[0].Cells["outFile"].Value.ToString(), PresetBoxDefine(dataGridView1.Rows[0].Cells["Preset"].Value.ToString()));
			
			
			
				ffmpegWorker.RunWorkerAsync(passArgs);
			
			
			}
			
			}
				
			
		
			}
		
		
		
		}
		
		
		void Label1Click(object sender, EventArgs e)
		{
	
		}
		void InputBrowseClick(object sender, EventArgs e)
		{
	
			
		
			
			 DialogResult result = inputFileDialog.ShowDialog();
	   	

			 if (result == DialogResult.OK) // Test result.
	    
				 {
	    		
	   			
			 	InFileBox.Text = inputFileDialog.FileName;
	   			
	   			}
			
			
		}
		void OutputFileBrowseClick(object sender, EventArgs e)
		{
	
			DialogResult result = folderBrowserDialog1.ShowDialog();
			
			if (!string.IsNullOrWhiteSpace(folderBrowserDialog1.SelectedPath))
				
			{
			
			
				OutFileBox.ForeColor = Color.Black;
				OutFileBox.Text = folderBrowserDialog1.SelectedPath;
			
			
			}
		
		
		
			
		}
		private void FfmpegWorkerDoWork(object sender, DoWorkEventArgs e)
		{
	
			
			Tuple<string, string, string> value = e.Argument as Tuple<string, string, string>;  
			
			string inFile = value.Item1;
			
			
			string outFile = value.Item2;
			
			string preset = value.Item3;
			
		//	string nn = value[0];
		
			string argumenttoProcess = String.Format("-i " + "{0}" + " " + "{1}" + " " + "{2}" + " " + "-y", inFile, preset, outFile);
			
			   Process proc = new Process ();
                proc.StartInfo.FileName = ffmpegPath;
                proc.StartInfo.Arguments = argumenttoProcess;
                proc.StartInfo.RedirectStandardError = true;
                proc.StartInfo.UseShellExecute = false;
                proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                proc.StartInfo.CreateNoWindow = true;
                if (!proc.Start()) {
                        MessageBox.Show("Error starting");
                        return;
                }
                StreamReader reader = proc.StandardError;
                string line;
                while ((line = reader.ReadLine()) != null) {
                      
                	if (line.Contains("Duration: "))
                	{
                	
                		string parsedDuration = line.Substring(11, 12);
                		
                		TimeSpan parsedDurationTs = TimeSpan.Parse(parsedDuration);
                		
                		
                		Duration = parsedDurationTs;
                		
                		string AddInfo = Duration.ToString();
                		
                //	MessageBox.Show(parsedDuration);
                	}
                	
                	if (line.Contains("size="))
                	{
                		
                		TimeSpan actualDuration = TimeSpan.Parse(line.Substring(line.LastIndexOf("time=")+5, 12));
                		
                		long remainder;
                		
                		long progressPercLong = Math.DivRem((actualDuration.Ticks * 100), Duration.Ticks, out remainder);
                		
                		string percinString = progressPercLong.ToString();
                		
                		int progpercinInt = int.Parse(percinString);
                		
                		if (ffmpegWorker.CancellationPending)
                			
                			{
                			
                			proc.Kill();
                			 proc.Close();
                			 
                			 
                			
                			 (sender as BackgroundWorker).ReportProgress(0);
                			 
     						    e.Cancel = true;
     						    reader.Close();
     						    
     						    CloseApplication();
     						    
       						   return;
      						}
                		
                		(sender as BackgroundWorker).ReportProgress(progpercinInt);
                		
                	//	textBox1.Text = progressPercLong.ToString();
                	//	textBox1.Refresh();
                		
                	//	int progressPercentage = progressPercLong * 100;
                		
                	}
                	
                
                	
                	
                	
                	
                	
                	//MessageBox.Show(line);
                }
                
                reader.Close();
                proc.Close();
			
			
			
		}
			private void Ffmpegworker_ProgressChanged(object sender,  ProgressChangedEventArgs e)
	{
	   
	 
	    dataGridView1.Rows[0].Cells["Percent"].Value = e.ProgressPercentage;
	    
	    
	}
		void CancelClick(object sender, EventArgs e)
		{
		
			
			if (dataGridView1.CurrentCell != null)
				
			{
			
				if (dataGridView1.CurrentCell.RowIndex == 0)
					
				{
				
					if (dataGridView1.Rows[0].Cells["Percent"].Value != null)
					
						{
				
							this.ffmpegWorker.CancelAsync();
							
							return;
			
						}
					
					
					if (dataGridView1.Rows[0].Cells["Percent"].Value == null)
					
						{
				
							RemoveListEvent(false);
							return;
			
						}
				
				}
			
	
				
						RemoveListEvent(false);
						return;
			
					
				
			}
			
			
		}
		
		
		
		private void Ffmpegworker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		
		
		{
		
		
			RemoveListEvent(true);
			
			if (dataGridView1.Rows.Count > 0)
				
			{
			
				Tuple<string, string, string> passArgs = new Tuple<string, string, string>(dataGridView1.Rows[0].Cells["inFile"].Value.ToString(), dataGridView1.Rows[0].Cells["outFile"].Value.ToString(), PresetBoxDefine(dataGridView1.Rows[0].Cells["Preset"].Value.ToString()));
			
				ffmpegWorker.RunWorkerAsync(passArgs);
			
			
			}
			
		
		
		
		}
		
		
		
		void SetdataGridView1()
 	
 		{
 		
 			dataGridView1.ColumnCount = 5;
 			
 			//dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
 			
 			dataGridView1.Columns[0].Name = "inFile";
 			dataGridView1.Columns["inFile"].ValueType = typeof(string);
 			dataGridView1.Columns["inFile"].SortMode = DataGridViewColumnSortMode.NotSortable;
 			dataGridView1.Columns["inFile"].Width = 350;
 			
 			
 			dataGridView1.Columns[1].Name = "outFile";
 			dataGridView1.Columns["outFile"].ValueType = typeof(string);
 			dataGridView1.Columns["outFile"].SortMode = DataGridViewColumnSortMode.NotSortable;
 			dataGridView1.Columns["outFile"].Width = 350;
 			
 			dataGridView1.Columns[2].Name = "Preset";
 			dataGridView1.Columns["Preset"].ValueType = typeof(string);
 			dataGridView1.Columns["Preset"].SortMode = DataGridViewColumnSortMode.NotSortable;
 			dataGridView1.Columns["Preset"].Width = 80;
 			
 			dataGridView1.Columns[3].Name = "Percent";
 			dataGridView1.Columns["Percent"].ValueType = typeof(int);
 			
 			dataGridView1.Columns["Percent"].SortMode = DataGridViewColumnSortMode.NotSortable;
 			dataGridView1.Columns["Percent"].Width = 51;
 			dataGridView1.Columns["Percent"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
 			
 			dataGridView1.Columns[4].Name = "trackNumber";
 			dataGridView1.Columns["trackNumber"].ValueType = typeof(int);
 			dataGridView1.Columns["trackNumber"].SortMode = DataGridViewColumnSortMode.NotSortable;
 			dataGridView1.Columns["trackNumber"].Width = 51;
 			dataGridView1.Columns["trackNumber"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
 			dataGridView1.Columns["trackNumber"].Visible = false;
 			
 			
 			dataGridView1.RowHeadersVisible = false;
 			
 			
 			
 		}
		
		
		
		
		void RowMaker(string inFile, string outFile, string Preset, int trackNumber)
 			
 		{
 		
 		
 			DataGridViewRow dataGridViewlistRow = dataGridView1.Rows[dataGridView1.Rows.Add()];
 				
 												
 				
 				dataGridViewlistRow.Cells["inFile"].Value = inFile;
 				
 				dataGridViewlistRow.Cells["outFile"].Value = outFile;
 				
 				dataGridViewlistRow.Cells["Preset"].Value = Preset;
 				
 				dataGridViewlistRow.Cells["trackNumber"].Value = trackNumber;
			
	
	}
		void AddtoListClick(object sender, EventArgs e)
		{
			
			if (InFileBox.Text != "" && OutFileBox.Text != "" && OutFileBox.Text != "This folder must be set" && PresetBox.SelectedItem != null)
			
			{
				
			PreAddtoListCheck(InFileBox.Text, OutFileBox.Text);
			
			}
			
			
			
		}
		
		
		
		void PreAddtoListCheck(string inFile, string outFolder)
			
		{
			
			
			string inFileName = Path.GetFileNameWithoutExtension(inFile);
			
			string outFileNamewithPath = String.Format("{0}\\{1}", outFolder, inFileName);
			
			
			string extensionforthePreset = string.IsNullOrEmpty(Extensions[PresetBox.SelectedItem.ToString()]) ? Path.GetExtension(inFile).TrimStart('.') : Extensions[PresetBox.SelectedItem.ToString()];
			               
			     
			
			string outFileNamewithPathandExtension = String.Format("{0}.{1}", outFileNamewithPath, extensionforthePreset);
			
				
				if (PresetBox.SelectedItem.ToString() == "Wav_demux")
					
				{
				
				
					
					int numberofAudioTracks = CheckAudioNumberForDemux(inFile);
					
					if (numberofAudioTracks != 0)
						
					{
					
						
						for (int i = 1; i < numberofAudioTracks+1; i++)
							
							
						{
							
							
							
							string filePathandNameforDemuxedAudio = String.Format("{0}_{1}.wav", outFileNamewithPath, i);
					
				
								RowMaker(inFile, filePathandNameforDemuxedAudio, PresetBox.SelectedItem.ToString(), i);
				
								AddtoListEvent();
				
				
						
						
						
						}
					
					
						return;
						
						
					
					}
					
					string outFilefromBox = String.Format("The file {0} does not contain audio tracks", InFileBox.Text.ToString());
					
					MessageBox.Show(outFilefromBox);
					
					return;
				
				
				}
				
				int trackNumber = 0;
				
				RowMaker(inFile, outFileNamewithPathandExtension, PresetBox.SelectedItem.ToString(), trackNumber);
				
				AddtoListEvent();
				
				
			
		
		}
		
		
		void AddtoListEvent()
			
		{
		
			
			button1.Visible = true;
			cancel.Visible = true;
			
		
			if (dataGridView1.Rows.Count == 2)
				
			{
			
				int newHeight = this.Height + 25;
				this.Size = new Size(877, newHeight);
				
				
			
			}
			
				if (dataGridView1.Rows.Count > 2)
				
			{
			
				int newHeight = this.Height + 22;
				this.Size = new Size(877, newHeight);
				
			
			}
		
		
		
		}
		
		
		void RemoveListEvent(bool istheWorkerCompleteCalling)
			
		{
		
			
			
			if (istheWorkerCompleteCalling == true)
				
			{
			
			
				dataGridView1.Rows.RemoveAt(0);
				
					int newHeight = this.Height - 22;
				this.Size = new Size(877, newHeight);
				
				return;
			
			
			
			
			}
			
			
		
		
			
			
			
			
				if (istheWorkerCompleteCalling == false)
				
			{
			
					dataGridView1.Rows.RemoveAt(dataGridView1.CurrentCell.RowIndex);
					
					
				int newHeight = this.Height - 22;
				this.Size = new Size(877, newHeight);
				
			
				return;
				
			}
		
		
		
		}
		
		
		int CheckAudioNumberForDemux(string inFiletoCheck)
			
		{
		
		int returnInt = 0;
			
			string argumenttoProcess = String.Format("-i " + "{0}", inFiletoCheck);
			
			   Process proc = new Process ();
                proc.StartInfo.FileName = ffmpegPath;
                proc.StartInfo.Arguments = argumenttoProcess;
                proc.StartInfo.RedirectStandardError = true;
                proc.StartInfo.UseShellExecute = false;
                proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                proc.StartInfo.CreateNoWindow = true;
                if (!proc.Start()) {
                        MessageBox.Show("Error starting");
                        return returnInt;
                }
                StreamReader reader = proc.StandardError;
                string line;
                while ((line = reader.ReadLine()) != null) {
                      
                	if (line.Contains("Stream") && line.Contains("Audio"))
                	{
                	
                		returnInt++;
                //	MessageBox.Show(parsedDuration);
                	}
                	
			
			
			
		
                }
                
                return returnInt;
		
		}
		
		
		
		private void dataGridKeydown(object sender, KeyEventArgs e)
			
		{
		
			if (e.KeyCode == Keys.Up && e.Modifiers == Keys.Alt)
				
			{
			
				moveLineUp();
			
			
			
			}
			
				if (e.KeyCode == Keys.Down && e.Modifiers == Keys.Alt)
				
			{
			
				moveLineDown();
			
			
			
			}
				
				
				if (e.KeyCode == Keys.Delete)
				
			{
			
				RemoveListEvent(false);
			
			
			
			}
				
			
			
			
			
		
		
		
		}
		
		
		
		private void moveLineUp()
			
			
		{
		
		
		
			if (dataGridView1.RowCount > 1)
			
			{
			
			
				if (dataGridView1.CurrentCell.RowIndex > 1)
					
				{
				
					int rowIndex =  dataGridView1.SelectedCells[0].OwningRow.Index; //  dataGridView1.CurrentCell.RowIndex;
					
					DataGridViewRow prevRow = dataGridView1.Rows[rowIndex - 1];
					
					dataGridView1.Rows.Remove(prevRow);
							
					dataGridView1.Rows.Insert(rowIndex, prevRow);
					
					dataGridView1.CurrentCell = dataGridView1.Rows[rowIndex].Cells[0];
					
					
					
					dataGridView1.Rows[rowIndex].Selected = true;
				
				
				
				
				}
					
			
			
			
			
			}
		
		
		
		
		}
		
		
		
		private void moveLineDown()
			
			
		{
		
			
			
		
		
			if (dataGridView1.RowCount > 1)
			
			{
			
			
				if (dataGridView1.CurrentCell.RowIndex < dataGridView1.RowCount-1)
					
				{
				
					int rowIndex =  dataGridView1.SelectedCells[0].OwningRow.Index; //  dataGridView1.CurrentCell.RowIndex;
					
					DataGridViewRow nextRow = dataGridView1.Rows[rowIndex + 1];
					
					dataGridView1.Rows.Remove(nextRow);
							
					dataGridView1.Rows.Insert(rowIndex, nextRow);
					
					dataGridView1.CurrentCell = dataGridView1.Rows[rowIndex].Cells[0];
					
					
					
					dataGridView1.Rows[rowIndex].Selected = true;
				
				
				
				
				}
					
			
			
			
			
			}
		
		
		
		
		}
		
		
		
		volatile bool isClosePending = false;
		
		private void FormClosingEvent(object sender, FormClosingEventArgs e)
			
						
		{
			
			
			if (dataGridView1.RowCount > 0)
				
			{
				
			
			
			if (ffmpegWorker.IsBusy == true)
					
						{
				
				isClosePending = true;
				
				this.ffmpegWorker.CancelAsync();
				
				return;
				
							
						
			
						}
			
			
			
			
			}
			
			
			
			
		//	this.Close();
		Application.Exit();
			
		
		
		}
		
		
		
		
		
		void CloseApplication()
			
		{
		
	
			if (isClosePending)
				
			{
			
			Application.Exit();
			
			}
			
		}
	

		void PopulatePresetList()
		
			{
			
			
		//	Uri xmlUri = new Uri(presetsPath);
			//string xmlDoc = String.Format(@"{0}", presetsPath);
			
			
			
			XDocument doc = XDocument.Load("FFTransPresets.xml");
			
			
			

  					  foreach (XElement el in doc.Root.Elements())
  				  {
        //Console.WriteLine("{0} {1}", el.Name, el.Attribute("id").Value);
        
        string addPresetBoxItem = String.Format("{0}", el.Attribute("name").Value);
        
        PresetBox.Items.Add(addPresetBoxItem);
        
        Extensions.Add(el.Attribute("name").Value, el.Attribute("extension").Value);
        
        
        
        
       /* 
        Console.WriteLine("  Attributes:");
        foreach (XAttribute attr in el.Attributes())
            Console.WriteLine("    {0}", attr);
        Console.WriteLine("  Elements:");

        foreach (XElement element in el.Elements())
            Console.WriteLine("    {0}: {1}", element.Name, element.Value);
            
            */
				}
		

		
    
			}
		
		
		
		
		void Form_DragEnter(object sender, DragEventArgs e)
			
			
		{
		
			if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
		
		
		
		}
		
		
		void Form_DragDrop(object sender, DragEventArgs e)
			
		{
		
			string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
		
			foreach (string file in files)
				
			{
			
				
				if (OutFileBox.Text != "" && OutFileBox.Text != "This folder must be set" && PresetBox.SelectedItem != null)
					
				{
				

						PreAddtoListCheck(file, OutFileBox.Text);
			
				
				
				
			
				}
			}
		
		
		}
		
		
		private void OnFocus(object sender, EventArgs e)
		{
		
		
			if (OutFileBox.Text == "This folder must be set")
				
			{
			
				OutFileBox.Clear();
		
			}
		
		}
		
		
		
	

	}

	//TimeSpan
		
	}
	
	
	

		
	
		
	
	
	
	
	
	
	

	

