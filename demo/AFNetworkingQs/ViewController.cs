using System;
using AFNetworking;
using Foundation;
using UIKit;

namespace AFNetworkingQs
{
    public partial class ViewController : UIViewController
    {
        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            var url = new NSUrl("https://www.lottiefiles.com");
            var manager = new AFHTTPSessionManager(url);
            manager.GET("/storage/datafiles/VAXwxp1twbwSPaU/data.json", null, (arg1, arg2) =>
            {
                System.Diagnostics.Debug.WriteLine(arg2);
            }, (arg1, arg2) =>
            {
                System.Diagnostics.Debug.WriteLine(arg2);
            });
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}
