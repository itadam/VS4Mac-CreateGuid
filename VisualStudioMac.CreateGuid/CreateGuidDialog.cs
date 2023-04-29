using System;
using AppKit;

namespace VisualStudioMac.CreateGuid
{
	public class CreateGuidDialog : Xwt.Window
	{

		public CreateGuidDialog() : base()
		{
			this.BuildDialog();
		}

        private RadioButtonGroup radioButtonGroup1;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private RadioButton radioButton3;
        private RadioButton radioButton4;
        private RadioButton radioButton5;
        private RadioButton radioButton6;

        private RadioButton radioButton7;
        private RadioButton radioButton8;

        private Label ResultLabel1;
        private Label ResultLabel2;

        private void BuildDialog()
		{

			var hbox1 = new HBox();

			var vbox1 = new VBox();

			var instructionsText = GettextCatalog.GetString("InstructionsText");

			if (string.IsNullOrWhiteSpace(instructionsText) || "InstructionsText".Equals(instructionsText))
			{
				instructionsText =
					@"Choose the desired format below, then select ""Copy"" to copy the results to the " +
                    @"clipboard (the results can then be pasted into your source code). " +
                    @"Choose ""Exit"" when done.";
            }

            var instructionsLabel = new Label();
            instructionsLabel.WidthRequest = 320;
			instructionsLabel.Text = instructionsText;
            instructionsLabel.Wrap = WrapMode.Word;
			vbox1.PackStart(instructionsLabel);

			var frameBox1 = new FrameBox();
            frameBox1.BorderColor = new Xwt.Drawing.Color(211, 211, 211);
            frameBox1.MarginTop = 5;

            var frame1 = new Frame();
			frame1.Label = GettextCatalog.GetString("GUID Format");

            if (radioButtonGroup1 == null)
            {
                radioButtonGroup1 = new RadioButtonGroup();
                radioButtonGroup1.ActiveRadioButtonChanged += RadioButtonGroup1_ActiveRadioButtonChanged;
            }

            if (radioButton1 == null)
            {
                radioButton1 = new RadioButton();
                radioButton1.Name = nameof(radioButton1);
                radioButton1.Label = GettextCatalog.GetString("1. IMPLEMENT_OLECREATE(...)");
                radioButton1.Group = radioButtonGroup1;
            }

            if (radioButton2 == null)
            {
                radioButton2 = new RadioButton();
                radioButton2.Name = nameof(radioButton2);
                radioButton2.Label = GettextCatalog.GetString("2. DEFINE_GUID(...)");
                radioButton2.Group = radioButtonGroup1;
            }

            if (radioButton3 == null)
            {
                radioButton3 = new RadioButton();
                radioButton3.Name = nameof(radioButton3);
                radioButton3.Label = GettextCatalog.GetString("3. static const struct GUID = {...}");
                radioButton3.Group = radioButtonGroup1;
            }

            if (radioButton4 == null)
            {
                radioButton4 = new RadioButton();
                radioButton4.Name = nameof(radioButton4);
                radioButton4.Label = GettextCatalog.GetString("4. Registry Format (ie. {...}");
                radioButton4.Group = radioButtonGroup1;
            }

            if (radioButton5 == null)
            {
                radioButton5 = new RadioButton();
                radioButton5.Name = nameof(radioButton5);
                radioButton5.Label = GettextCatalog.GetString("5. [Guid(\"...\")]");
                radioButton5.Group = radioButtonGroup1;
            }

            if (radioButton6 == null)
            {
                radioButton6 = new RadioButton();
                radioButton6.Name = nameof(radioButton6);
                radioButton6.Label = GettextCatalog.GetString("6. <Guid(\"...\")>");
                radioButton6.Group = radioButtonGroup1;
            }

            if (radioButton7 == null)
            {
                radioButton7 = new RadioButton();
                radioButton7.Name = nameof(radioButton7);
                radioButton7.Label = GettextCatalog.GetString("7. const string GUID = \"...\";");
                radioButton7.Group = radioButtonGroup1;
            }

            if (radioButton8 == null)
            {
                radioButton8 = new RadioButton();
                radioButton8.Name = nameof(radioButton8);
                radioButton8.Label = GettextCatalog.GetString("8. var guid = new Guid(\"...\");");
                radioButton8.Group = radioButtonGroup1;
            }

            var vbox3 = new VBox();

			vbox3.PackStart(radioButton1);
            vbox3.PackStart(radioButton2);
            vbox3.PackStart(radioButton3);
            vbox3.PackStart(radioButton4);
            vbox3.PackStart(radioButton5);
            vbox3.PackStart(radioButton6);

            vbox3.PackStart(radioButton7);
            vbox3.PackStart(radioButton8);

            frame1.Content = vbox3;

            frameBox1.Content = frame1;

            vbox1.PackStart(frameBox1);

            var frameBox2 = new FrameBox();
            frameBox2.BorderColor = new Xwt.Drawing.Color(211, 211, 211);
            frameBox2.MarginTop = 5;

            var frame2 = new Frame();
            frame2.Label = GettextCatalog.GetString("Result");

            var vbox4 = new VBox();

            if (ResultLabel1 == null)
            {
                ResultLabel1 = new Label();
            }

            ResultLabel1.Text = string.Empty;

            vbox4.PackStart(ResultLabel1);

            if (ResultLabel2 == null)
            {
                ResultLabel2 = new Label();
                ResultLabel2.Wrap = WrapMode.Character;
            }

            ResultLabel2.Text = string.Empty;

            vbox4.PackStart(ResultLabel2);

            frame2.Content = vbox4;

            frameBox2.Content = frame2;

            vbox1.PackEnd(frameBox2);

            hbox1.PackStart(vbox1);

            var vbox2 = new VBox();

            var copyButton = new Button();
            copyButton.Name = nameof(copyButton);
            copyButton.Label = GettextCatalog.GetString("Copy");
            copyButton.Clicked += CopyButton_Clicked;
            vbox2.PackStart(copyButton);

            var newGuidButton = new Button();
            newGuidButton.Name = nameof(newGuidButton);
            newGuidButton.Label = GettextCatalog.GetString("New GUID");
            newGuidButton.Clicked += NewGuidButton_Clicked;
            vbox2.PackStart(newGuidButton);

            var exitButton = new Button();
            exitButton.Name = nameof(exitButton);
            exitButton.Label = GettextCatalog.GetString("Exit");
            exitButton.Clicked += ExitButton_Clicked;
            vbox2.PackStart(exitButton);

            hbox1.PackEnd(vbox2);

			this.Content = hbox1;
			this.Height = 380;
			this.Width = 420;
			this.Title = GettextCatalog.GetString("Create GUID");
            this.Resizable = false;
            this.ShowInTaskbar = false;

		}

        private void ExitButton_Clicked(object sender, EventArgs e)
        {
            Close();
        }

        private void NewGuidButton_Clicked(object sender, EventArgs e)
        {
            guid = Guid.NewGuid();
            ShowResults(radioButtonGroup1.ActiveRadioButton, guid.Value);
        }

        protected override void OnShown()
        {
            base.OnShown();
            guid = Guid.NewGuid();
            ShowResults(radioButton1, guid.Value);
        }

        static readonly string pasteboardType = NSPasteboard.NSPasteboardTypeString;
        readonly string[] pasteboardTypes = { pasteboardType };

        NSPasteboard Pasteboard => NSPasteboard.GeneralPasteboard;

        private Guid? guid;
        private string guidString1;
        private string guidString2;

        private void ShowResults(RadioButton radioButton, Guid guid)
        {

            var guidStr = guid.ToString();

            switch (radioButton.Name)
            {

                case nameof(radioButton1):

                    // 8
                    // -
                    // 4
                    // -
                    // 4
                    // -
                    // 4
                    // -
                    // 12

                    guidString1 = $"// {{{guid}}}";
                    guidString2 = $"IMPLEMENT_OLECREATE(" +
                        $"<<class>>, " +
                        $"<<external_name>>, " +
                        $"0x{guidStr.Substring(0, 8).ToLower()}, " +
                        $"0x{guidStr.Substring(9, 4).ToLower()}, " +
                        $"0x{guidStr.Substring(14, 4).ToLower()}, " +
                        $"0x{guidStr.Substring(19, 2).ToLower()}, " +
                        $"0x{guidStr.Substring(21, 2).ToLower()}, " +
                        $"0x{guidStr.Substring(24, 2).ToLower()}, " +
                        $"0x{guidStr.Substring(26, 2).ToLower()}, " +
                        $"0x{guidStr.Substring(28, 2).ToLower()}, " +
                        $"0x{guidStr.Substring(30, 2).ToLower()}, " +
                        $"0x{guidStr.Substring(32, 2).ToLower()}, " +
                        $"0x{guidStr.Substring(34, 2).ToLower()}" +
                        $")";

                    break;

                case nameof(radioButton2):

                    guidString1 = $"// {{{guid}}}";
                    guidString2 = $"DEFINE_GUID({guid})";

                    break;

                case nameof(radioButton3):

                    guidString1 = $"// {{{guid}}}";
                    guidString2 = $"static const struct GUID = {{{guid}}}";

                    break;

                case nameof(radioButton4):

                    guidString1 = $"// {{{guid}}}";
                    guidString2 = $"{{{guid}}}";

                    break;

                case nameof(radioButton5):

                    guidString1 = $"// {{{guid}}}";
                    guidString2 = $"[Guid(\"{guid}\")]";

                    break;

                case nameof(radioButton6):

                    guidString1 = $"// {{{guid}}}";
                    guidString2 = $"<Guid(\"{guid}\")>";

                    break;

                case nameof(radioButton7):

                    guidString1 = $"// {{{guid}}}";
                    guidString2 = $"const string GUID = \"{guid}\"";

                    break;

                case nameof(radioButton8):

                    guidString1 = $"// {{{guid}}}";
                    guidString2 = $"var guid = new Guid(\"{guid}\");";

                    break;
            }

            ResultLabel1.Text = guidString1;
            ResultLabel2.Text = guidString2;

        }

        private void CopyButton_Clicked(object sender, EventArgs e)
        {
            Pasteboard.DeclareTypes(pasteboardTypes, null);
            Pasteboard.ClearContents();
            Pasteboard.SetStringForType(guidString2, pasteboardType);
        }

        private void RadioButtonGroup1_ActiveRadioButtonChanged(object sender, EventArgs e)
        {

            if (!guid.HasValue)
            {
                guid = Guid.NewGuid();
            }

            ShowResults(radioButtonGroup1.ActiveRadioButton, guid.Value);
        }
    }
}

