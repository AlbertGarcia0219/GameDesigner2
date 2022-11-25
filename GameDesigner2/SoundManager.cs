using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using GameDesigner2.Properties;
using System.Threading;

namespace GameDesigner2
{
    internal class SoundManager
    {
        public static SoundPlayer bgm = new SoundPlayer();
        private static SoundPlayer add = new SoundPlayer();
        private static SoundPlayer exp = new SoundPlayer();
        private static SoundPlayer fire = new SoundPlayer();
        private static SoundPlayer hit = new SoundPlayer();
        public static void InitSound()
        {
            bgm.Stream = Resources.fc;
            add.Stream = Resources.add;
            exp.Stream = Resources.blast;
            fire.Stream = Resources.fire;
            hit.Stream = Resources.hit;
        }
        public static void PlayBGM()
        {
            if (Settings.mute == false)
            {
                bgm.PlayLooping();
            }
        }
        public static void PlayAdd()
        {
            if (Settings.mute == false)
            {
                add.Play();
            }
        }
        public static void PlayExp()
        {
            if (Settings.mute == false)
            {
                exp.Play();
            }
        }
        public static void PlayFire()
        {
            if (Settings.mute == false)
            {
                fire.Play();
            }
        }
        public static void PlayHit()
        {
            if (Settings.mute == false)
            {
                hit.Play();
            }
        }
    }
}
