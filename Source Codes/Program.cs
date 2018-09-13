using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Media;



namespace otusznje {
    class Program {
        public enum Memez {
            otusznje = 0,
            jeszcze_jak,
            dość, //jp2 mówiący "dość"
            co, //jp2 mówiący "coooo?"
            nie_wiem,
            REEEE,
            ph1,
            ph2,
            ph3,
            ph4
        }
        static void Main(string[] args) {
            System.Media.SoundPlayer benin = null;
            Memez succ;
            string current = Directory.GetCurrentDirectory();
            string[] files = Directory.GetFiles(current, "*.*", SearchOption.AllDirectories);
            files = files.Where(x => Path.GetExtension(x).ToLower() == ".wav").ToArray();
            long[] durations = null;

            durations = files.Select(file => TagLib.File.Create(file)).
                Select(dur => dur.Properties.Duration.Seconds * 1000 + dur.Properties.Duration.Milliseconds).
                Select(val => (long)val).
                ToArray();
            Console.WriteLine(durations.Length.ToString());
            try {
                succ = (Memez)Convert.ToInt32(args[0]);
            } catch (Exception) {
                Console.WriteLine("Wrong meme/no memez");
                return;
            }
            switch (succ) {
                case Memez.otusznje:
                    benin = new SoundPlayer("Sounds/0_otusznje.wav");
                    break;
                case Memez.jeszcze_jak:
                    benin = new SoundPlayer("Sounds/1_jeszcze_jak.wav");
                    break;
                case Memez.dość:
                    benin = new SoundPlayer("Sounds/2_dość.wav");
                    break;
                case Memez.co:
                    benin = new SoundPlayer("Sounds/3_co.wav");
                    break;
                case Memez.nie_wiem:
                    benin = new SoundPlayer("Sounds/4_nie_wiem.wav");
                    break;
                case Memez.REEEE:
                    benin = new SoundPlayer("Sounds/5_REEE.wav");
                    break;
                default:
                    return;
            }
            benin.Play();
            System.Threading.Thread.Sleep((int)durations[(int)succ]);
        }
    }
}
