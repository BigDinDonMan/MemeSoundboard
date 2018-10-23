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
            dość, 
            co, 
            nie_wiem,
            REEEE,
            pan_Jezus,
            nie_wiem_choc_sie_domyslam,
            zaklecie_korwina,
            to_be_continued,
            OOF,
            spok_co_do_kurwy,
            usrr_anthem,
            maxmoefoe,
            its_time_to_stop,
            tak_bylo
        }

        public static Dictionary<Memez, string> soundPaths = new Dictionary<Memez, string>() {
            { Memez.otusznje,                                   "Sounds/00_otusznje.wav" },
            { Memez.jeszcze_jak,                                "Sounds/01_jeszcze_jak.wav" },
            { Memez.dość,                                       "Sounds/02_dość.wav" },
            { Memez.co,                                         "Sounds/03_co.wav" },
            { Memez.nie_wiem,                                   "Sounds/04_nie_wiem.wav" },
            { Memez.REEEE,                                      "Sounds/05_REEE.wav" },
            { Memez.pan_Jezus,                                  "Sounds/06_takjakpanJezuspowiedzial.wav" },
            { Memez.nie_wiem_choc_sie_domyslam,                 "Sounds/07_niewiemchocsiedomyslam.wav" },
            { Memez.zaklecie_korwina,                           "Sounds/08_zaklecie_korwina.wav" },
            { Memez.to_be_continued,                            "Sounds/09_to_be_continued.wav" },
            { Memez.OOF,                                        "Sounds/10_OOF.wav" },
            { Memez.spok_co_do_kurwy,                           "Sounds/11_spok_co_do_kurwy.wav" },
            { Memez.usrr_anthem,                                "Sounds/12_usrr_anthem.wav" },
            { Memez.maxmoefoe,                                  "Sounds/13_maxmoefoe.wav" },
            { Memez.its_time_to_stop,                           "Sounds/14_its_time_to_stop.wav" },
            { Memez.tak_bylo,                                   "Sounds/15_tak_było.wav" }
        };

        static void Main(string[] args) {
            Memez succ;
            string[] files = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.*", SearchOption.AllDirectories);
            files = files.Where(x => Path.GetExtension(x).ToLower() == ".wav").ToArray();
            long[] durations = null;
            durations = files.Select(file => TagLib.File.Create(file)).
                Select(dur => dur.Properties.Duration.TotalMilliseconds).
                Select(val => (long)val).
                ToArray();
            try {
                succ = (Memez)Convert.ToInt32(args[0]);
            } catch (Exception) {
                Console.WriteLine("Wrong meme/no memez");
                return;
            }
            (new SoundPlayer(soundPaths[succ])).Play();
            System.Threading.Thread.Sleep((int)durations[(int)succ] + 400);
        }
    }
}
