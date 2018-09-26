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
            usrr_anthem
        }
        static void Main(string[] args) {
            SoundPlayer benin = null;
            Memez succ;
            string current = Directory.GetCurrentDirectory();
            string[] files = Directory.GetFiles(current, "*.*", SearchOption.AllDirectories);
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
            switch (succ) {
                case Memez.otusznje:
                    benin = new SoundPlayer("Sounds/00_otusznje.wav");
                    break;
                case Memez.jeszcze_jak:
                    benin = new SoundPlayer("Sounds/01_jeszcze_jak.wav");
                    break;
                case Memez.dość:
                    benin = new SoundPlayer("Sounds/02_dość.wav");
                    break;
                case Memez.co:
                    benin = new SoundPlayer("Sounds/03_co.wav");
                    break;
                case Memez.nie_wiem:
                    benin = new SoundPlayer("Sounds/04_nie_wiem.wav");
                    break;
                case Memez.REEEE:
                    benin = new SoundPlayer("Sounds/05_REEE.wav");
                    break;
                case Memez.pan_Jezus:
                    benin = new SoundPlayer("Sounds/06_takjakpanJezuspowiedzial.wav");
                    break;
                case Memez.nie_wiem_choc_sie_domyslam:
                    benin = new SoundPlayer("Sounds/07_niewiemchocsiedomyslam.wav");
                    break;
                case Memez.zaklecie_korwina:
                    benin = new SoundPlayer("Sounds/08_zaklecie_korwina.wav");
                    break;
                case Memez.to_be_continued:
                    benin = new SoundPlayer("Sounds/09_to_be_continued.wav");
                    break;
                case Memez.OOF:
                    benin = new SoundPlayer("Sounds/10_OOF.wav");
                    break;
                case Memez.spok_co_do_kurwy:
                    benin = new SoundPlayer("Sounds/11_spok_co_do_kurwy.wav");
                    break;
                case Memez.usrr_anthem:
                    benin = new SoundPlayer("Sounds/12_usrr_anthem.wav");
                    break;
                default:
                    return;
            }
            benin.Play();
            System.Threading.Thread.Sleep((int)durations[(int)succ]);
        }
    }
}
