using LongTech.Portable;
using LongTech.Core;
using LongTech.UI.Controls;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace LongTech.Apps
{
  public partial class BingoForm : Form
  {
    private bool isRunning = false;
    private short hours = 0, minutes = 0, seconds = 0;

    public BingoForm()
    {
      InitializeComponent();
    }

    private void Bingo_Application_Shown(object sender, EventArgs e)
    {
      cameraVideo1.CameraOn = true;
    }

    private void Bingo_Application_FormClosing(object sender, FormClosingEventArgs e)
    {
      cameraVideo1.CameraOn = false;
    }

    private void ResetBoard()
    {
      foreach (var ctl in tableLayoutPanel1.Controls)
      {
        if (ctl.GetType() == typeof(BingoBallButton))
          ((BingoBallButton)ctl).BallDropped = false;
      }
    }

    private void BingoBall_OnBallDropped(BingoBallButton sender)
    {
      try
      {
        // Log the ball drop
        PortableLib.Log.WriteLine(string.Format("{0} \t{1} \t{2} \t{3} \t{4}", sender, sender.BallDropped,
          DateTime.Now, gameNumberTextBox.Text, ComboBoxGameColor.SelectedText));
      }
      catch (Exception ex)
      {
        PortableLib.Log.WriteLine("OnClick: " + ex);
      }
    }

    private void ButtonStartStop_Click(object sender, EventArgs e)
    {
      isRunning = !isRunning;

      string msg = "";
      if (isRunning)
      {
        ResetBoard();

        gameNumberTextBox.Enabled = false;
        ComboBoxGameColor.Enabled = false;
        startStopButton.Text = "End Game";
        timeLabel.Text = "00:00:00";
        msg += string.Format("Starting Game #{0} ({1}) at {2}", gameNumberTextBox.Text, ComboBoxGameColor.SelectedText, DateTime.Now);

        timer1.Start();
      }
      else
      {
        timer1.Stop();

        msg += string.Format("Ending Game #{0} ({1}) at {2}, Game length: {3}:{4}:{5}",
          gameNumberTextBox.Text, ComboBoxGameColor.SelectedText, DateTime.Now, hours, minutes, seconds);

        gameNumberTextBox.Enabled = true;
        ComboBoxGameColor.Enabled = true;
        startStopButton.Text = "Start Game!";
        hours = minutes = seconds = 0;
      }

      PortableLib.Log.WriteLine(msg);
    }

    private void Timer1_Tick(object sender, EventArgs e)
    {
      seconds++;

      if (seconds > 59)
      {
        seconds = 0;
        minutes++;
        if (minutes > 59)
        {
          minutes = 0;
          hours++;
        }
      }

      timeLabel.Text = string.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds);
    }

    private void ComboBoxGameColor_SelectedIndexChanged(object sender, EventArgs e)
    {
      Color c;

      switch (ComboBoxGameColor.Text)
      {
        case "White": c = Color.White; break;
        case "Red": c = Color.Red; break;
        case "Orange": c = Color.Orange; break;
        case "Yellow": c = Color.Yellow; break;
        case "Green": c = Color.Green; break;
        case "Blue": c = Color.Blue; break;
        case "Indigo": c = Color.Indigo; break;
        case "Violet": c = Color.Violet; break;
        case "Black": c = Color.Black; break;
        default: c = Color.White; break;
      }

      ComboBoxGameColor.BackColor = c;
    }
  }

  public class BingoPlugin : Plugin
  {
    public BingoPlugin()
    {
      PortableLib.Initialize();

      Assembly = new PluginAssemblyInfo()
      {
        Name = "Live Bingo! Plugin"
      };
    }

    public override IPluginResult Process(string[] args)
    {
      Application.EnableVisualStyles();
      // Application.SetCompatibleTextRenderingDefault(false);
      Application.Run(new BingoForm());

      return new PluginResult() { Result = PluginResults.OK };
    }

    public static void Main(string[] args)
    {
      new BingoPlugin().Process(args);
    }
  }
}
