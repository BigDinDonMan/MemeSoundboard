#!/usr/bin/python3 

import pyaudio  
import wave
import sys
import os
from enum import Enum, auto

def dct(x):
    return {
        "0": "0_otusznje.wav",
        "1": "1_jeszcze_jak.wav",
        "2": "2_dość.wav",
        "3": "3_co.wav",
        "4": "4_nie_wiem.wav",
        "5": "5_REEE.wav",
        "6": "6_takjakpanJezuspowiedzial.wav",
        "7": "7_niewiemchocsiedomyslam.wav",
        "8": "8_zaklecie_korwina.wav",
        "9": "9_to_be_continued.wav"
    }[x]

audio = pyaudio.PyAudio()

file = wave.open(os.path.dirname(__file__) + "/../Sounds/" + dct(sys.argv[1]),"rb")
stream = audio.open(format = audio.get_format_from_width(file.getsampwidth()),
    channels = file.getnchannels(),
    rate = file.getframerate(),
    output = True)

stream.write(file.readframes(file.getnframes()))
stream.stop_stream()
stream.close()

audio.terminate()