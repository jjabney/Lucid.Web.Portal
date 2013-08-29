using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Lucid.Web.Portal.Models
{
    public class LucidWebPortalContextInitializer : DropCreateDatabaseAlways<LucidWebPortalContext>
    {

        protected override void Seed(LucidWebPortalContext context)
        {

            List<Video> videos = new List<Video>();
            context.Videos.Add(new Video() { Title = "Asthma", MobileUrl = "http://progressive.iplayerhd.com/data/3/029d2303.mp4", DesktopUrl = "http://progressive.iplayerhd.com/data/3/029d2303.mp4", Thumb="http://cdn.iplayerhd.com/data/5/4d8d0dd5.jpg" });
            context.Videos.Add(new Video() { Title = "TMJ", MobileUrl = "http://progressive.iplayerhd.com/data/e/3305033e.mp4", DesktopUrl = "http://progressive.iplayerhd.com/data/e/3305033e.mp4", Thumb="http://cdn.iplayerhd.com/data/d/5c2246ed.jpg" });
            context.Videos.Add(new Video() { Title = "Headaches", MobileUrl = "http://progressive.iplayerhd.com/data/1/1a82c601.mp4", DesktopUrl = "http://progressive.iplayerhd.com/data/1/1a82c601.mp4", Thumb="http://cdn.iplayerhd.com/data/0/43a009b0.jpg" });
            context.Videos.Add(new Video() { Title = "Digestive", MobileUrl = "http://progressive.iplayerhd.com/data/f/6cbd4d5f.mp4", DesktopUrl = "http://progressive.iplayerhd.com/data/f/6cbd4d5f.mp4", Thumb="http://cdn.iplayerhd.com/data/b/7407e9eb.jpg" });
            context.Videos.Add(new Video() { Title = "First Visit", MobileUrl = "http://progressive.iplayerhd.com/data/5/250c6465.mp4", DesktopUrl = "http://progressive.iplayerhd.com/data/5/250c6465.mp4", Thumb="http://cdn.iplayerhd.com/data/4/4e29a814.jpg" });
            context.Videos.Add(new Video() { Title = "Nervious System", MobileUrl = "http://progressive.iplayerhd.com/data/a/3297f8ea.mp4", DesktopUrl = "http://progressive.iplayerhd.com/data/a/3297f8ea.mp4", Thumb = "http://cdn.iplayerhd.com/data/9/5bb53c99.jpg" });
            context.Videos.Add(new Video() { Title = "Adjustments", MobileUrl = "http://progressive.iplayerhd.com/data/5/62ffd925.mp4", DesktopUrl = "http://progressive.iplayerhd.com/data/5/62ffd925.mp4", Thumb="http://cdn.iplayerhd.com/data/4/0c1d1cd4.jpg" });
            context.Videos.Add(new Video() { Title = "Carpel Tunnel", MobileUrl = "http://progressive.iplayerhd.com/data/4/0261ec44.mp4", DesktopUrl = "http://progressive.iplayerhd.com/data/4/0261ec44.mp4", Thumb="http://cdn.iplayerhd.com/data/5/5944a895.jpg" });
            
            base.Seed(context);
        }
    }
}