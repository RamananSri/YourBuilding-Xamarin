﻿using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using KeyboardOverlap.Forms.Plugin.iOSUnified;
using UIKit;

namespace KundePortal.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            Xamarin.Forms.Forms.Init();
            KeyboardOverlapRenderer.Init();
            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }
    }
}
