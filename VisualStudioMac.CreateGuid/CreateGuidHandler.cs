using System;
namespace VisualStudioMac.CreateGuid
{
	public class CreateGuidHandler : CommandHandler
	{
		public CreateGuidHandler()
		{
		}

        protected override void Run()
        {
            base.Run();

            var dlg = new CreateGuidDialog();
            dlg.Show();
        }
    }
}

