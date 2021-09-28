namespace DungeonReminder
{
    using Styx.Helpers;
    using Styx.Plugins.PluginClass;
    using Styx.WoWInternals;
    using Styx.WoWInternals.WoWObjects;
    using System;
    using System.Threading;
    using System.Windows.Forms;

    public class DungeonReminder : HBPlugin
    {
        public override string Name { get { return "DreamfulFinder"; } }
        public override string Author { get { return "Dreamful"; } }
        public override Version Version { get { return new Version(1, 0); } }
        private static readonly LocalPlayer Me = ObjectManager.Me;

        private Random r = new Random();

        public void OpenDungeonFinder()
        {
            if (Me.IsAlive)
            {
                Thread.Sleep(r.Next(3500, 5500));
                Logging.Write("[DungeonAlerter] Open Dungeonfinder");
                Lua.DoString("RunMacroText(\"/dungeonfinder\");");

                Thread.Sleep(r.Next(3500, 5500));
                Logging.Write("[DungeonAlerter] Click for finding a group");
                Lua.DoString("LFDQueueFrameFindGroupButton:Click()");
            }
        }

        public void CloserDungeonFinder()
        {
            if (Me.IsAlive)
            {
                Thread.Sleep(r.Next(3500, 5500));
                Logging.Write("[DungeonAlerter] Click Dungeonfinder window away");
                Lua.DoString("LFDQueueFrameCancelButton:Click()");
            }
        }

        public void Invite()
        {
            if (Me.IsAlive)
            {
                Logging.Write("[DungeonAlerter] Waiting for invite");
                MessageBox.Show("[DungeonAlerter] Dungeon Invite!");
                Thread.Sleep(r.Next(3500, 5500));
                Lua.DoString("RunMacroText(\"/click LFGDungeonReadyDialogEnterDungeonButton\");");
            }
        }

        public override void Pulse()
        {
            throw new NotImplementedException();
        }
    }
}