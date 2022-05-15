using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cold_War_Class_Storage_V2
{
    public static class SocialLinks
    {
        public static void Web(String url)
        {
            Process.Start(url);
        }
        public static void AddGunTutorial()
        {
            Web("https://youtu.be/uvr9CZDrgqk");
        }
        public static void YoutubeChannel ()
        {
        Web("https://www.youtube.com/channel/UCyTsi1Tja0kkDv26gX5CjxQ");
        }
    }
}
